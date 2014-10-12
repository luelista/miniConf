namespace miniConf {
    partial class ConfigForm {
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
            this.listServerFeatures = new System.Windows.Forms.ListBox();
            this.btnClosePrefs = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lnkInstallSmiley = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSmileyTheme = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.cmbFileUploadService = new System.Windows.Forms.ComboBox();
            this.comboMessageTheme = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkEnableImagePreview = new System.Windows.Forms.CheckBox();
            this.chkDisplayOccupantStatus = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkFiletransferAutoAccept = new System.Windows.Forms.CheckBox();
            this.chkSternchen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listServerFeatures
            // 
            this.listServerFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listServerFeatures.FormattingEnabled = true;
            this.listServerFeatures.IntegralHeight = false;
            this.listServerFeatures.Location = new System.Drawing.Point(266, 30);
            this.listServerFeatures.Name = "listServerFeatures";
            this.listServerFeatures.Size = new System.Drawing.Size(182, 163);
            this.listServerFeatures.TabIndex = 24;
            // 
            // btnClosePrefs
            // 
            this.btnClosePrefs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClosePrefs.BackColor = System.Drawing.SystemColors.Control;
            this.btnClosePrefs.Location = new System.Drawing.Point(343, 207);
            this.btnClosePrefs.Name = "btnClosePrefs";
            this.btnClosePrefs.Size = new System.Drawing.Size(105, 22);
            this.btnClosePrefs.TabIndex = 36;
            this.btnClosePrefs.Text = "OK";
            this.btnClosePrefs.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(164, 118);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 13);
            this.linkLabel1.TabIndex = 40;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get...";
            // 
            // lnkInstallSmiley
            // 
            this.lnkInstallSmiley.AutoSize = true;
            this.lnkInstallSmiley.BackColor = System.Drawing.Color.Transparent;
            this.lnkInstallSmiley.Location = new System.Drawing.Point(115, 118);
            this.lnkInstallSmiley.Name = "lnkInstallSmiley";
            this.lnkInstallSmiley.Size = new System.Drawing.Size(43, 13);
            this.lnkInstallSmiley.TabIndex = 39;
            this.lnkInstallSmiley.TabStop = true;
            this.lnkInstallSmiley.Text = "Install...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(262, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Server features:";
            // 
            // cmbSmileyTheme
            // 
            this.cmbSmileyTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSmileyTheme.FormattingEnabled = true;
            this.cmbSmileyTheme.Items.AddRange(new object[] {
            "Default",
            "OldDefault",
            "Compact",
            "Conversations",
            "Terminal",
            "Custom"});
            this.cmbSmileyTheme.Location = new System.Drawing.Point(118, 94);
            this.cmbSmileyTheme.Name = "cmbSmileyTheme";
            this.cmbSmileyTheme.Size = new System.Drawing.Size(121, 21);
            this.cmbSmileyTheme.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(14, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Smiley theme:";
            // 
            // txtNickname
            // 
            this.txtNickname.BackColor = System.Drawing.SystemColors.Window;
            this.txtNickname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNickname.Location = new System.Drawing.Point(118, 14);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(121, 20);
            this.txtNickname.TabIndex = 26;
            // 
            // cmbFileUploadService
            // 
            this.cmbFileUploadService.FormattingEnabled = true;
            this.cmbFileUploadService.Items.AddRange(new object[] {
            "https://mediacru.sh"});
            this.cmbFileUploadService.Location = new System.Drawing.Point(118, 40);
            this.cmbFileUploadService.Name = "cmbFileUploadService";
            this.cmbFileUploadService.Size = new System.Drawing.Size(121, 21);
            this.cmbFileUploadService.TabIndex = 34;
            this.cmbFileUploadService.Text = "https://mediacru.sh";
            // 
            // comboMessageTheme
            // 
            this.comboMessageTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMessageTheme.FormattingEnabled = true;
            this.comboMessageTheme.Items.AddRange(new object[] {
            "Default",
            "OldDefault",
            "Compact",
            "Conversations",
            "Terminal",
            "Custom"});
            this.comboMessageTheme.Location = new System.Drawing.Point(118, 67);
            this.comboMessageTheme.Name = "comboMessageTheme";
            this.comboMessageTheme.Size = new System.Drawing.Size(121, 21);
            this.comboMessageTheme.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(14, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Nick:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(14, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Chat theme:";
            // 
            // chkEnableImagePreview
            // 
            this.chkEnableImagePreview.AutoSize = true;
            this.chkEnableImagePreview.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableImagePreview.Checked = true;
            this.chkEnableImagePreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableImagePreview.Location = new System.Drawing.Point(17, 155);
            this.chkEnableImagePreview.Name = "chkEnableImagePreview";
            this.chkEnableImagePreview.Size = new System.Drawing.Size(100, 17);
            this.chkEnableImagePreview.TabIndex = 28;
            this.chkEnableImagePreview.Text = "Preview images";
            this.chkEnableImagePreview.UseVisualStyleBackColor = false;
            // 
            // chkDisplayOccupantStatus
            // 
            this.chkDisplayOccupantStatus.AutoSize = true;
            this.chkDisplayOccupantStatus.BackColor = System.Drawing.Color.Transparent;
            this.chkDisplayOccupantStatus.Location = new System.Drawing.Point(123, 155);
            this.chkDisplayOccupantStatus.Name = "chkDisplayOccupantStatus";
            this.chkDisplayOccupantStatus.Size = new System.Drawing.Size(116, 17);
            this.chkDisplayOccupantStatus.TabIndex = 30;
            this.chkDisplayOccupantStatus.Text = "Display status texts";
            this.chkDisplayOccupantStatus.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(14, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "File upload service:";
            // 
            // chkFiletransferAutoAccept
            // 
            this.chkFiletransferAutoAccept.AutoSize = true;
            this.chkFiletransferAutoAccept.BackColor = System.Drawing.Color.Transparent;
            this.chkFiletransferAutoAccept.Checked = true;
            this.chkFiletransferAutoAccept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiletransferAutoAccept.Location = new System.Drawing.Point(17, 178);
            this.chkFiletransferAutoAccept.Name = "chkFiletransferAutoAccept";
            this.chkFiletransferAutoAccept.Size = new System.Drawing.Size(81, 17);
            this.chkFiletransferAutoAccept.TabIndex = 32;
            this.chkFiletransferAutoAccept.Text = "Accept files";
            this.chkFiletransferAutoAccept.UseVisualStyleBackColor = false;
            // 
            // chkSternchen
            // 
            this.chkSternchen.AutoSize = true;
            this.chkSternchen.BackColor = System.Drawing.Color.Transparent;
            this.chkSternchen.Location = new System.Drawing.Point(123, 178);
            this.chkSternchen.Name = "chkSternchen";
            this.chkSternchen.Size = new System.Drawing.Size(30, 17);
            this.chkSternchen.TabIndex = 29;
            this.chkSternchen.Text = "*";
            this.chkSternchen.UseVisualStyleBackColor = false;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 241);
            this.Controls.Add(this.listServerFeatures);
            this.Controls.Add(this.btnClosePrefs);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lnkInstallSmiley);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSmileyTheme);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.cmbFileUploadService);
            this.Controls.Add(this.comboMessageTheme);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkEnableImagePreview);
            this.Controls.Add(this.chkDisplayOccupantStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkFiletransferAutoAccept);
            this.Controls.Add(this.chkSternchen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listServerFeatures;
        private System.Windows.Forms.Button btnClosePrefs;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel lnkInstallSmiley;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSmileyTheme;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.ComboBox cmbFileUploadService;
        private System.Windows.Forms.ComboBox comboMessageTheme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkEnableImagePreview;
        private System.Windows.Forms.CheckBox chkDisplayOccupantStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkFiletransferAutoAccept;
        private System.Windows.Forms.CheckBox chkSternchen;
    }
}