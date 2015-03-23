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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lnkInstallSmiley = new System.Windows.Forms.LinkLabel();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRememberPassword = new System.Windows.Forms.CheckBox();
            this.qq_txtPrefServerPort = new System.Windows.Forms.ComboBox();
            this.qq_txtPrefServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.qq_txtPrefUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.qq_txtPrefPassword = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labProgramVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.Location = new System.Drawing.Point(252, 458);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 22);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(159, 75);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lnkInstallSmiley
            // 
            this.lnkInstallSmiley.AutoSize = true;
            this.lnkInstallSmiley.BackColor = System.Drawing.Color.Transparent;
            this.lnkInstallSmiley.Location = new System.Drawing.Point(110, 75);
            this.lnkInstallSmiley.Name = "lnkInstallSmiley";
            this.lnkInstallSmiley.Size = new System.Drawing.Size(43, 13);
            this.lnkInstallSmiley.TabIndex = 4;
            this.lnkInstallSmiley.TabStop = true;
            this.lnkInstallSmiley.Text = "Install...";
            this.lnkInstallSmiley.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInstallSmiley_LinkClicked);
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
            this.cmbSmileyTheme.Location = new System.Drawing.Point(113, 51);
            this.cmbSmileyTheme.Name = "cmbSmileyTheme";
            this.cmbSmileyTheme.Size = new System.Drawing.Size(181, 21);
            this.cmbSmileyTheme.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(9, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Smiley theme:";
            // 
            // txtNickname
            // 
            this.txtNickname.BackColor = System.Drawing.SystemColors.Window;
            this.txtNickname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNickname.Location = new System.Drawing.Point(92, 128);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(200, 20);
            this.txtNickname.TabIndex = 8;
            // 
            // cmbFileUploadService
            // 
            this.cmbFileUploadService.FormattingEnabled = true;
            this.cmbFileUploadService.Items.AddRange(new object[] {
            "https://chat2.teamwiki.de"});
            this.cmbFileUploadService.Location = new System.Drawing.Point(111, 22);
            this.cmbFileUploadService.Name = "cmbFileUploadService";
            this.cmbFileUploadService.Size = new System.Drawing.Size(181, 21);
            this.cmbFileUploadService.TabIndex = 1;
            this.cmbFileUploadService.Text = "https://chat2.teamwiki.de";
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
            this.comboMessageTheme.Location = new System.Drawing.Point(113, 24);
            this.comboMessageTheme.Name = "comboMessageTheme";
            this.comboMessageTheme.Size = new System.Drawing.Size(181, 21);
            this.comboMessageTheme.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(13, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nick:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(9, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Chat theme:";
            // 
            // chkEnableImagePreview
            // 
            this.chkEnableImagePreview.AutoSize = true;
            this.chkEnableImagePreview.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableImagePreview.Checked = true;
            this.chkEnableImagePreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableImagePreview.Location = new System.Drawing.Point(305, 24);
            this.chkEnableImagePreview.Name = "chkEnableImagePreview";
            this.chkEnableImagePreview.Size = new System.Drawing.Size(100, 17);
            this.chkEnableImagePreview.TabIndex = 6;
            this.chkEnableImagePreview.Text = "Preview images";
            this.chkEnableImagePreview.UseVisualStyleBackColor = false;
            // 
            // chkDisplayOccupantStatus
            // 
            this.chkDisplayOccupantStatus.AutoSize = true;
            this.chkDisplayOccupantStatus.BackColor = System.Drawing.Color.Transparent;
            this.chkDisplayOccupantStatus.Location = new System.Drawing.Point(305, 47);
            this.chkDisplayOccupantStatus.Name = "chkDisplayOccupantStatus";
            this.chkDisplayOccupantStatus.Size = new System.Drawing.Size(116, 17);
            this.chkDisplayOccupantStatus.TabIndex = 7;
            this.chkDisplayOccupantStatus.Text = "Display status texts";
            this.chkDisplayOccupantStatus.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "File upload service:";
            // 
            // chkFiletransferAutoAccept
            // 
            this.chkFiletransferAutoAccept.AutoSize = true;
            this.chkFiletransferAutoAccept.BackColor = System.Drawing.Color.Transparent;
            this.chkFiletransferAutoAccept.Checked = true;
            this.chkFiletransferAutoAccept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiletransferAutoAccept.Location = new System.Drawing.Point(12, 53);
            this.chkFiletransferAutoAccept.Name = "chkFiletransferAutoAccept";
            this.chkFiletransferAutoAccept.Size = new System.Drawing.Size(219, 17);
            this.chkFiletransferAutoAccept.TabIndex = 2;
            this.chkFiletransferAutoAccept.Text = "Accept direct file transfer (recommended)";
            this.chkFiletransferAutoAccept.UseVisualStyleBackColor = false;
            // 
            // chkSternchen
            // 
            this.chkSternchen.AutoSize = true;
            this.chkSternchen.BackColor = System.Drawing.Color.Transparent;
            this.chkSternchen.Location = new System.Drawing.Point(305, 70);
            this.chkSternchen.Name = "chkSternchen";
            this.chkSternchen.Size = new System.Drawing.Size(104, 17);
            this.chkSternchen.TabIndex = 8;
            this.chkSternchen.Text = "Put \"*\" in titlebar";
            this.chkSternchen.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRememberPassword);
            this.groupBox1.Controls.Add(this.qq_txtPrefServerPort);
            this.groupBox1.Controls.Add(this.qq_txtPrefServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNickname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.qq_txtPrefUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.qq_txtPrefPassword);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(18, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 162);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jabber account";
            // 
            // chkRememberPassword
            // 
            this.chkRememberPassword.AutoSize = true;
            this.chkRememberPassword.Location = new System.Drawing.Point(93, 72);
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.Size = new System.Drawing.Size(125, 17);
            this.chkRememberPassword.TabIndex = 11;
            this.chkRememberPassword.Text = "Remember password";
            this.chkRememberPassword.UseVisualStyleBackColor = true;
            // 
            // qq_txtPrefServerPort
            // 
            this.qq_txtPrefServerPort.FormattingEnabled = true;
            this.qq_txtPrefServerPort.Items.AddRange(new object[] {
            "5222",
            "5223"});
            this.qq_txtPrefServerPort.Location = new System.Drawing.Point(238, 102);
            this.qq_txtPrefServerPort.Name = "qq_txtPrefServerPort";
            this.qq_txtPrefServerPort.Size = new System.Drawing.Size(54, 21);
            this.qq_txtPrefServerPort.TabIndex = 6;
            this.qq_txtPrefServerPort.Text = "5222";
            // 
            // qq_txtPrefServer
            // 
            this.qq_txtPrefServer.Location = new System.Drawing.Point(92, 102);
            this.qq_txtPrefServer.Name = "qq_txtPrefServer";
            this.qq_txtPrefServer.Size = new System.Drawing.Size(140, 20);
            this.qq_txtPrefServer.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server/Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Jabber ID:";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegister.Location = new System.Drawing.Point(311, 19);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(105, 22);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "New Account";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // qq_txtPrefUsername
            // 
            this.qq_txtPrefUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.qq_txtPrefUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.qq_txtPrefUsername.Location = new System.Drawing.Point(92, 19);
            this.qq_txtPrefUsername.Name = "qq_txtPrefUsername";
            this.qq_txtPrefUsername.Size = new System.Drawing.Size(200, 20);
            this.qq_txtPrefUsername.TabIndex = 1;
            this.qq_txtPrefUsername.TextChanged += new System.EventHandler(this.qq_txtPrefUsername_TextChanged);
            this.qq_txtPrefUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qq_txtPrefUsername_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // qq_txtPrefPassword
            // 
            this.qq_txtPrefPassword.Location = new System.Drawing.Point(92, 45);
            this.qq_txtPrefPassword.Name = "qq_txtPrefPassword";
            this.qq_txtPrefPassword.PasswordChar = '*';
            this.qq_txtPrefPassword.Size = new System.Drawing.Size(200, 20);
            this.qq_txtPrefPassword.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect.Location = new System.Drawing.Point(311, 45);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(105, 22);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Text = "Test connection";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.lnkInstallSmiley);
            this.groupBox2.Controls.Add(this.cmbSmileyTheme);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboMessageTheme);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.chkEnableImagePreview);
            this.groupBox2.Controls.Add(this.chkDisplayOccupantStatus);
            this.groupBox2.Controls.Add(this.chkSternchen);
            this.groupBox2.Location = new System.Drawing.Point(18, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 108);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Appearance";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbFileUploadService);
            this.groupBox3.Controls.Add(this.chkFiletransferAutoAccept);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(18, 361);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 82);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Media sharing";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(349, 52);
            this.label4.TabIndex = 0;
            this.label4.Text = "To get started, just fill in the Jabber ID and Password and click on \"OK\".\r\n\r\nYou" +
    " may come back later through the menu item \"Preferences\".";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(353, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 22);
            this.button1.TabIndex = 46;
            this.button1.Text = "&Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labProgramVersion
            // 
            this.labProgramVersion.AutoSize = true;
            this.labProgramVersion.ForeColor = System.Drawing.Color.Gray;
            this.labProgramVersion.Location = new System.Drawing.Point(15, 463);
            this.labProgramVersion.Name = "labProgramVersion";
            this.labProgramVersion.Size = new System.Drawing.Size(35, 13);
            this.labProgramVersion.TabIndex = 47;
            this.labProgramVersion.Text = "label9";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(374, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(460, 492);
            this.Controls.Add(this.labProgramVersion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel lnkInstallSmiley;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox qq_txtPrefServerPort;
        private System.Windows.Forms.TextBox qq_txtPrefServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox qq_txtPrefUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox qq_txtPrefPassword;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkRememberPassword;
        private System.Windows.Forms.Label labProgramVersion;
    }
}