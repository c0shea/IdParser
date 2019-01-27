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
            this.tabPageOpos = new System.Windows.Forms.TabPage();
            this.btnSaveDataToFile = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSymbology = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageHidKeyboardEmulation = new System.Windows.Forms.TabPage();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnSaveHidToFile = new System.Windows.Forms.Button();
            this.txtHidData = new System.Windows.Forms.TextBox();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblIdType = new System.Windows.Forms.Label();
            this.txtParsedId = new System.Windows.Forms.RichTextBox();
            this.btnParseFile = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFileContents = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPageOpos.SuspendLayout();
            this.tabPageHidKeyboardEmulation.SuspendLayout();
            this.tabPageFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogicalName
            // 
            this.txtLogicalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogicalName.Location = new System.Drawing.Point(163, 10);
            this.txtLogicalName.MaxLength = 255;
            this.txtLogicalName.Name = "txtLogicalName";
            this.txtLogicalName.Size = new System.Drawing.Size(372, 25);
            this.txtLogicalName.TabIndex = 0;
            // 
            // txtScanData
            // 
            this.txtScanData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScanData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtScanData.Location = new System.Drawing.Point(9, 91);
            this.txtScanData.Name = "txtScanData";
            this.txtScanData.Size = new System.Drawing.Size(526, 312);
            this.txtScanData.TabIndex = 3;
            this.txtScanData.Text = "";
            // 
            // txtBarcodeType
            // 
            this.txtBarcodeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcodeType.AutoSize = true;
            this.txtBarcodeType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBarcodeType.Location = new System.Drawing.Point(6, 43);
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
            this.txtConnectScanner.Location = new System.Drawing.Point(273, 409);
            this.txtConnectScanner.Name = "txtConnectScanner";
            this.txtConnectScanner.Size = new System.Drawing.Size(151, 32);
            this.txtConnectScanner.TabIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(962, 38);
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
            this.tabControl1.Controls.Add(this.tabPageOpos);
            this.tabControl1.Controls.Add(this.tabPageHidKeyboardEmulation);
            this.tabControl1.Controls.Add(this.tabPageFile);
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(549, 480);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageOpos
            // 
            this.tabPageOpos.Controls.Add(this.btnSaveDataToFile);
            this.tabPageOpos.Controls.Add(this.lblSymbology);
            this.tabPageOpos.Controls.Add(this.label3);
            this.tabPageOpos.Controls.Add(this.txtLogicalName);
            this.tabPageOpos.Controls.Add(this.label2);
            this.tabPageOpos.Controls.Add(this.txtScanData);
            this.tabPageOpos.Controls.Add(this.txtBarcodeType);
            this.tabPageOpos.Controls.Add(this.txtConnectScanner);
            this.tabPageOpos.Location = new System.Drawing.Point(4, 26);
            this.tabPageOpos.Name = "tabPageOpos";
            this.tabPageOpos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOpos.Size = new System.Drawing.Size(541, 450);
            this.tabPageOpos.TabIndex = 0;
            this.tabPageOpos.Text = "OPOS";
            this.tabPageOpos.UseVisualStyleBackColor = true;
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
            this.btnSaveDataToFile.Location = new System.Drawing.Point(116, 409);
            this.btnSaveDataToFile.Name = "btnSaveDataToFile";
            this.btnSaveDataToFile.Size = new System.Drawing.Size(151, 32);
            this.btnSaveDataToFile.TabIndex = 2;
            this.btnSaveDataToFile.Text = "Save Data to File";
            this.btnSaveDataToFile.UseVisualStyleBackColor = false;
            this.btnSaveDataToFile.Click += new System.EventHandler(this.btnSaveDataToFile_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(13, 536);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(936, 25);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSymbology
            // 
            this.lblSymbology.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSymbology.AutoSize = true;
            this.lblSymbology.Location = new System.Drawing.Point(166, 43);
            this.lblSymbology.Name = "lblSymbology";
            this.lblSymbology.Size = new System.Drawing.Size(0, 17);
            this.lblSymbology.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data:";
            // 
            // tabPageHidKeyboardEmulation
            // 
            this.tabPageHidKeyboardEmulation.Controls.Add(this.btnParse);
            this.tabPageHidKeyboardEmulation.Controls.Add(this.btnSaveHidToFile);
            this.tabPageHidKeyboardEmulation.Controls.Add(this.txtHidData);
            this.tabPageHidKeyboardEmulation.Location = new System.Drawing.Point(4, 26);
            this.tabPageHidKeyboardEmulation.Name = "tabPageHidKeyboardEmulation";
            this.tabPageHidKeyboardEmulation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHidKeyboardEmulation.Size = new System.Drawing.Size(541, 450);
            this.tabPageHidKeyboardEmulation.TabIndex = 1;
            this.tabPageHidKeyboardEmulation.Text = "HID Keyboard Emulation";
            this.tabPageHidKeyboardEmulation.UseVisualStyleBackColor = true;
            // 
            // btnParse
            // 
            this.btnParse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParse.BackColor = System.Drawing.Color.SteelBlue;
            this.btnParse.FlatAppearance.BorderSize = 0;
            this.btnParse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParse.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParse.ForeColor = System.Drawing.Color.White;
            this.btnParse.Location = new System.Drawing.Point(273, 412);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(151, 32);
            this.btnParse.TabIndex = 11;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = false;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
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
            this.btnSaveHidToFile.Location = new System.Drawing.Point(116, 412);
            this.btnSaveHidToFile.Name = "btnSaveHidToFile";
            this.btnSaveHidToFile.Size = new System.Drawing.Size(151, 32);
            this.btnSaveHidToFile.TabIndex = 10;
            this.btnSaveHidToFile.Text = "Save Data to File";
            this.btnSaveHidToFile.UseVisualStyleBackColor = false;
            this.btnSaveHidToFile.Click += new System.EventHandler(this.btnSaveHidToFile_Click);
            // 
            // txtHidData
            // 
            this.txtHidData.Location = new System.Drawing.Point(7, 7);
            this.txtHidData.Multiline = true;
            this.txtHidData.Name = "txtHidData";
            this.txtHidData.Size = new System.Drawing.Size(528, 399);
            this.txtHidData.TabIndex = 0;
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.txtFileContents);
            this.tabPageFile.Controls.Add(this.btnParseFile);
            this.tabPageFile.Controls.Add(this.btnSelectFile);
            this.tabPageFile.Controls.Add(this.txtFilePath);
            this.tabPageFile.Controls.Add(this.label4);
            this.tabPageFile.Location = new System.Drawing.Point(4, 26);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFile.Size = new System.Drawing.Size(541, 450);
            this.tabPageFile.TabIndex = 2;
            this.tabPageFile.Text = "File";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(136, 10);
            this.txtFilePath.MaxLength = 2048;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(366, 25);
            this.txtFilePath.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Path of File to Load:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.Filter = "All files (*.*)|*.*";
            // 
            // lblIdType
            // 
            this.lblIdType.AutoSize = true;
            this.lblIdType.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdType.ForeColor = System.Drawing.Color.Orange;
            this.lblIdType.Location = new System.Drawing.Point(567, 52);
            this.lblIdType.Name = "lblIdType";
            this.lblIdType.Size = new System.Drawing.Size(0, 17);
            this.lblIdType.TabIndex = 7;
            // 
            // txtParsedId
            // 
            this.txtParsedId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtParsedId.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParsedId.Location = new System.Drawing.Point(567, 78);
            this.txtParsedId.Name = "txtParsedId";
            this.txtParsedId.Size = new System.Drawing.Size(382, 454);
            this.txtParsedId.TabIndex = 8;
            this.txtParsedId.Text = "";
            // 
            // btnParseFile
            // 
            this.btnParseFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParseFile.BackColor = System.Drawing.Color.SteelBlue;
            this.btnParseFile.FlatAppearance.BorderSize = 0;
            this.btnParseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParseFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParseFile.ForeColor = System.Drawing.Color.White;
            this.btnParseFile.Location = new System.Drawing.Point(195, 412);
            this.btnParseFile.Name = "btnParseFile";
            this.btnParseFile.Size = new System.Drawing.Size(151, 32);
            this.btnParseFile.TabIndex = 13;
            this.btnParseFile.Text = "Parse";
            this.btnParseFile.UseVisualStyleBackColor = false;
            this.btnParseFile.Click += new System.EventHandler(this.btnParseFile_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSelectFile.FlatAppearance.BorderSize = 0;
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelectFile.Location = new System.Drawing.Point(505, 10);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(30, 25);
            this.btnSelectFile.TabIndex = 12;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFileContents
            // 
            this.txtFileContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileContents.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileContents.Location = new System.Drawing.Point(9, 41);
            this.txtFileContents.Name = "txtFileContents";
            this.txtFileContents.Size = new System.Drawing.Size(526, 365);
            this.txtFileContents.TabIndex = 14;
            this.txtFileContents.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Text files|*.txt|All files|*.*";
            // 
            // Main
            // 
            this.AcceptButton = this.txtConnectScanner;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(961, 569);
            this.Controls.Add(this.txtParsedId);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblIdType);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID Parser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageOpos.ResumeLayout(false);
            this.tabPageOpos.PerformLayout();
            this.tabPageHidKeyboardEmulation.ResumeLayout(false);
            this.tabPageHidKeyboardEmulation.PerformLayout();
            this.tabPageFile.ResumeLayout(false);
            this.tabPageFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogicalName;
        private System.Windows.Forms.RichTextBox txtScanData;
        private System.Windows.Forms.Label txtBarcodeType;
        private System.Windows.Forms.Button txtConnectScanner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOpos;
        private System.Windows.Forms.TabPage tabPageHidKeyboardEmulation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSymbology;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSaveDataToFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox txtHidData;
        private System.Windows.Forms.Button btnSaveHidToFile;
        private System.Windows.Forms.Label lblIdType;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.RichTextBox txtParsedId;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtFileContents;
        private System.Windows.Forms.Button btnParseFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

