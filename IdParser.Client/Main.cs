﻿using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.PointOfService;

namespace IdParser.Client {
    public partial class Main : Form {
        private Scanner _scanner;

        public Main() {
            InitializeComponent();
        }

        private void txtConnectScanner_Click(object sender, EventArgs e) {
            txtConnectScanner.Enabled = false;

            if (txtConnectScanner.Text == "Connect to Scanner") {
                Connect();
            }
            else {
                Disconnect();
            }

            txtConnectScanner.Enabled = true;
        }

        private void Connect() {
            if (string.IsNullOrEmpty(txtLogicalName.Text)) {
                SetStatus(Level.Warning, "Enter a logical name to connect to the scanner");
                return;
            }

            txtLogicalName.Enabled = false;
            txtConnectScanner.Text = "Disconnect Scanner";

            try {
                var explorer = new PosExplorer();
                _scanner = explorer.CreateInstance(explorer.GetDevice(DeviceType.Scanner, txtLogicalName.Text)) as Scanner;

                AddDataEvent(_scanner);

                SetStatus(Level.Info, "Opening " + txtLogicalName.Text);
                _scanner.Open();
                SetStatus(Level.Info, "Claiming scanner");
                _scanner.Claim(1000);
                SetStatus(Level.Info, "Enabling scanner");
                _scanner.DeviceEnabled = true;
                _scanner.DataEventEnabled = true;
                _scanner.DecodeData = true;

                SetStatus(Level.Success, "Ready");
            }
            catch (PosControlException ex) {
                SetStatus(Level.Error, "Failed to connect to scanner. " + ex.Message);
            }
        }

        private void Disconnect() {
            txtLogicalName.Enabled = true;
            txtConnectScanner.Text = "Connect to Scanner";

            try {
                SetStatus(Level.Info, "Disconnecting scanner");
                RemoveDataEvent(_scanner);
                _scanner.DeviceEnabled = false;
                _scanner.Release();
                _scanner.Close();

                SetStatus(Level.Success, "Scanner disconnected");
            }
            // Catch the generic Exception because we don't want to block the application from exiting
            catch (Exception ex) {
                SetStatus(Level.Error, "Failed to disconnect to scanner. " + ex.Message);
            }
            finally {
                _scanner = null;
            }
        }

        private void SetStatus(Level level, string message) {
            lblStatus.Text = message;

            if (level == Level.Success) {
                lblStatus.ForeColor = Color.DarkGreen;
            }
            else if (level == Level.Warning) {
                lblStatus.ForeColor = Color.DarkOrange;
            }
            else if (level == Level.Error) {
                lblStatus.ForeColor = Color.DarkRed;
            }
            else if (level == Level.Info) {
                lblStatus.ForeColor = Color.Black;
            }
        }

        public enum Level {
            Info,
            Success,
            Warning,
            Error
        }

        private void AddDataEvent(object eventSource) {
            var dataEvent = eventSource.GetType().GetEvent("DataEvent");

            if (dataEvent != null) {
                dataEvent.AddEventHandler(eventSource, new DataEventHandler(OnDataEvent));
            }
        }

        private void RemoveDataEvent(object eventSource) {
            if (eventSource == null)
                return;

            var dataEvent = eventSource.GetType().GetEvent("DataEvent");

            if (dataEvent != null) {
                dataEvent.RemoveEventHandler(eventSource, new DataEventHandler(OnDataEvent));
            }
        }

        private void OnDataEvent(object source, DataEventArgs e) {
            if (InvokeRequired) {
                //Ensure calls to Windows Form Controls are from this application's thread
                Invoke(new DataEventHandler(OnDataEvent), new object[2]
                {
                    source,
                    e
                });
                return;
            }

            SetStatus(Level.Info, "Reading data");

            var data = Encoding.ASCII.GetString(_scanner.ScanDataLabel);
            var symbology = _scanner.ScanDataType;

            txtScanData.Text = data;
            lblSymbology.Text = symbology.ToString().ToUpper();

            if (symbology == BarCodeSymbology.Pdf417 && data.Contains("@"))
            {
                SetStatus(Level.Info, "Parsing ID");
            }

            _scanner.DataEventEnabled = true;
            SetStatus(Level.Success, "Ready");
        }

        private void btnSaveDataToFile_Click(object sender, EventArgs e) {
            var dialog = saveFileDialog;
            if (dialog.ShowDialog() == DialogResult.OK) {
                SetStatus(Level.Info, "Writing file");
                File.WriteAllText(dialog.FileName, txtScanData.Text);
                SetStatus(Level.Success, "Ready");
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            Disconnect();
        }

        private void btnSaveHidToFile_Click(object sender, EventArgs e) {
            var dialog = saveFileDialog;
            if (dialog.ShowDialog() == DialogResult.OK) {
                SetStatus(Level.Info, "Writing file");
                File.WriteAllText(dialog.FileName, txtHidData.Text);
                SetStatus(Level.Success, "Ready");
            }
        }
    }
}