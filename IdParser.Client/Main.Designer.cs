namespace IdParser.Client {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.txtLogicalName = new System.Windows.Forms.TextBox();
            this.txtScanData = new System.Windows.Forms.RichTextBox();
            this.txtBarcodeType = new System.Windows.Forms.Label();
            this.txtConnectScanner = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSymbology = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveDataToFile = new System.Windows.Forms.Button();
            this.txtHidData = new System.Windows.Forms.TextBox();
            this.btnSaveHidToFile = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogicalName
            // 
            this.txtLogicalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogicalName.Location = new System.Drawing.Point(163, 10);
            this.txtLogicalName.MaxLength = 255;
            this.txtLogicalName.Name = "txtLogicalName";
            this.txtLogicalName.Size = new System.Drawing.Size(402, 25);
            this.txtLogicalName.TabIndex = 0;
            // 
            // txtScanData
            // 
            this.txtScanData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScanData.Location = new System.Drawing.Point(9, 150);
            this.txtScanData.Name = "txtScanData";
            this.txtScanData.Size = new System.Drawing.Size(556, 294);
            this.txtScanData.TabIndex = 1;
            this.txtScanData.Text = "";
            // 
            // txtBarcodeType
            // 
            this.txtBarcodeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcodeType.AutoSize = true;
            this.txtBarcodeType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBarcodeType.Location = new System.Drawing.Point(6, 86);
            this.txtBarcodeType.Name = "txtBarcodeType";
            this.txtBarcodeType.Size = new System.Drawing.Size(76, 17);
            this.txtBarcodeType.TabIndex = 2;
            this.txtBarcodeType.Text = "Symbology:";
            // 
            // txtConnectScanner
            // 
            this.txtConnectScanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectScanner.BackColor = System.Drawing.Color.SteelBlue;
            this.txtConnectScanner.FlatAppearance.BorderSize = 0;
            this.txtConnectScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtConnectScanner.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectScanner.ForeColor = System.Drawing.Color.White;
            this.txtConnectScanner.Location = new System.Drawing.Point(163, 42);
            this.txtConnectScanner.Name = "txtConnectScanner";
            this.txtConnectScanner.Size = new System.Drawing.Size(151, 35);
            this.txtConnectScanner.TabIndex = 3;
            this.txtConnectScanner.Text = "Connect to Scanner";
            this.txtConnectScanner.UseVisualStyleBackColor = false;
            this.txtConnectScanner.Click += new System.EventHandler(this.txtConnectScanner_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(908, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID Parser";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Scanner Logical Name:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 480);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSaveDataToFile);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.lblSymbology);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtLogicalName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtScanData);
            this.tabPage1.Controls.Add(this.txtBarcodeType);
            this.tabPage1.Controls.Add(this.txtConnectScanner);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(571, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "OPOS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSaveHidToFile);
            this.tabPage2.Controls.Add(this.txtHidData);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(571, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HID Keyboard Emulation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data:";
            // 
            // lblSymbology
            // 
            this.lblSymbology.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSymbology.AutoSize = true;
            this.lblSymbology.Location = new System.Drawing.Point(160, 86);
            this.lblSymbology.Name = "lblSymbology";
            this.lblSymbology.Size = new System.Drawing.Size(0, 17);
            this.lblSymbology.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(320, 42);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(245, 35);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.Filter = "All files (*.*)|*.*";
            // 
            // btnSaveDataToFile
            // 
            this.btnSaveDataToFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDataToFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSaveDataToFile.FlatAppearance.BorderSize = 0;
            this.btnSaveDataToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDataToFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDataToFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveDataToFile.Location = new System.Drawing.Point(163, 112);
            this.btnSaveDataToFile.Name = "btnSaveDataToFile";
            this.btnSaveDataToFile.Size = new System.Drawing.Size(151, 32);
            this.btnSaveDataToFile.TabIndex = 9;
            this.btnSaveDataToFile.Text = "Save Data to File";
            this.btnSaveDataToFile.UseVisualStyleBackColor = false;
            this.btnSaveDataToFile.Click += new System.EventHandler(this.btnSaveDataToFile_Click);
            // 
            // txtHidData
            // 
            this.txtHidData.Location = new System.Drawing.Point(7, 7);
            this.txtHidData.Multiline = true;
            this.txtHidData.Name = "txtHidData";
            this.txtHidData.Size = new System.Drawing.Size(558, 399);
            this.txtHidData.TabIndex = 0;
            // 
            // btnSaveHidToFile
            // 
            this.btnSaveHidToFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveHidToFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSaveHidToFile.FlatAppearance.BorderSize = 0;
            this.btnSaveHidToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveHidToFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveHidToFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveHidToFile.Location = new System.Drawing.Point(210, 412);
            this.btnSaveHidToFile.Name = "btnSaveHidToFile";
            this.btnSaveHidToFile.Size = new System.Drawing.Size(151, 32);
            this.btnSaveHidToFile.TabIndex = 10;
            this.btnSaveHidToFile.Text = "Save Data to File";
            this.btnSaveHidToFile.UseVisualStyleBackColor = false;
            this.btnSaveHidToFile.Click += new System.EventHandler(this.btnSaveHidToFile_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(907, 544);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID Parser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogicalName;
        private System.Windows.Forms.RichTextBox txtScanData;
        private System.Windows.Forms.Label txtBarcodeType;
        private System.Windows.Forms.Button txtConnectScanner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSymbology;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSaveDataToFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox txtHidData;
        private System.Windows.Forms.Button btnSaveHidToFile;
    }
}

