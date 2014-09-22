namespace miniConf
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Online", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Not available", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtPrefServer = new System.Windows.Forms.TextBox();
            this.txtPrefUsername = new System.Windows.Forms.TextBox();
            this.txtPrefPassword = new System.Windows.Forms.TextBox();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlPrefConnectAdvanced = new System.Windows.Forms.Panel();
            this.txtPrefServerPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkConnectAdvanced = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lnkInstallSmiley = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSmileyTheme = new System.Windows.Forms.ComboBox();
            this.btnClosePrefs = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFileUploadService = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkEnableImagePreview = new System.Windows.Forms.CheckBox();
            this.chkSternchen = new System.Windows.Forms.CheckBox();
            this.comboMessageTheme = new System.Windows.Forms.ComboBox();
            this.chkFiletransferAutoAccept = new System.Windows.Forms.CheckBox();
            this.chkDisplayOccupantStatus = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listServerFeatures = new System.Windows.Forms.ListBox();
            this.txtConnInfo = new System.Windows.Forms.TextBox();
            this.lvOnlineStatus = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labChatstates = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSendmessage = new System.Windows.Forms.TextBox();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlErrMes = new System.Windows.Forms.Panel();
            this.btnCancelReconnect = new System.Windows.Forms.Button();
            this.labErrMes = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMiniConfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.searchForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMPPConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqliteConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.enableNotificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enablePopupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrReconnect = new System.Windows.Forms.Timer(this.components);
            this.tmrBlinky = new System.Windows.Forms.Timer(this.components);
            this.filterBarPanel = new System.Windows.Forms.Panel();
            this.filterBarCloseBtn = new System.Windows.Forms.Button();
            this.filterTextbox = new System.Windows.Forms.TextBox();
            this.tmrChatstatePaused = new System.Windows.Forms.Timer(this.components);
            this.naviBar1 = new Guifreaks.NavigationBar.NaviBar(this.components);
            this.naviBand1 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.naviGroup2 = new Guifreaks.NavigationBar.NaviGroup(this.components);
            this.naviGroup1 = new Guifreaks.NavigationBar.NaviGroup(this.components);
            this.lbChatrooms = new System.Windows.Forms.ListBox();
            this.ctxMenuConversationHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.joinConversationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naviBand3 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.lvContacts = new System.Windows.Forms.ListView();
            this.contactsImageList = new System.Windows.Forms.ImageList(this.components);
            this.naviBand2 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.chkToggleSidebar = new System.Windows.Forms.CheckBox();
            this.ctxMenuConversation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeNickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.alwaysNotifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyOnMentionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableNotificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.showFullHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuParticipant = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mentionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.privateMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirectChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversationImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new miniConf.MessageView();
            this.pnlConfig.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlPrefConnectAdvanced.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlErrMes.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.filterBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naviBar1)).BeginInit();
            this.naviBar1.SuspendLayout();
            this.naviBand1.ClientArea.SuspendLayout();
            this.naviBand1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naviGroup2)).BeginInit();
            this.naviGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naviGroup1)).BeginInit();
            this.naviGroup1.SuspendLayout();
            this.ctxMenuConversationHeader.SuspendLayout();
            this.naviBand3.ClientArea.SuspendLayout();
            this.naviBand3.SuspendLayout();
            this.naviBand2.ClientArea.SuspendLayout();
            this.naviBand2.SuspendLayout();
            this.ctxMenuConversation.SuspendLayout();
            this.ctxMenuParticipant.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrefServer
            // 
            this.txtPrefServer.Location = new System.Drawing.Point(86, 7);
            this.txtPrefServer.Name = "txtPrefServer";
            this.txtPrefServer.Size = new System.Drawing.Size(140, 20);
            this.txtPrefServer.TabIndex = 1;
            // 
            // txtPrefUsername
            // 
            this.txtPrefUsername.Location = new System.Drawing.Point(88, 21);
            this.txtPrefUsername.Name = "txtPrefUsername";
            this.txtPrefUsername.Size = new System.Drawing.Size(200, 20);
            this.txtPrefUsername.TabIndex = 3;
            this.txtPrefUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrefUsername_KeyPress);
            // 
            // txtPrefPassword
            // 
            this.txtPrefPassword.Location = new System.Drawing.Point(88, 47);
            this.txtPrefPassword.Name = "txtPrefPassword";
            this.txtPrefPassword.PasswordChar = '*';
            this.txtPrefPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPrefPassword.TabIndex = 5;
            // 
            // pnlConfig
            // 
            this.pnlConfig.BackColor = System.Drawing.Color.Gold;
            this.pnlConfig.Controls.Add(this.tabControl1);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConfig.Location = new System.Drawing.Point(138, 78);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(478, 212);
            this.pnlConfig.TabIndex = 5;
            this.pnlConfig.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 205);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlPrefConnectAdvanced);
            this.tabPage1.Controls.Add(this.lnkConnectAdvanced);
            this.tabPage1.Controls.Add(this.txtPrefUsername);
            this.tabPage1.Controls.Add(this.txtPrefPassword);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnConnect);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnRegister);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(457, 179);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlPrefConnectAdvanced
            // 
            this.pnlPrefConnectAdvanced.Controls.Add(this.txtPrefServerPort);
            this.pnlPrefConnectAdvanced.Controls.Add(this.txtPrefServer);
            this.pnlPrefConnectAdvanced.Controls.Add(this.label1);
            this.pnlPrefConnectAdvanced.Location = new System.Drawing.Point(2, 108);
            this.pnlPrefConnectAdvanced.Name = "pnlPrefConnectAdvanced";
            this.pnlPrefConnectAdvanced.Size = new System.Drawing.Size(310, 61);
            this.pnlPrefConnectAdvanced.TabIndex = 13;
            this.pnlPrefConnectAdvanced.Visible = false;
            // 
            // txtPrefServerPort
            // 
            this.txtPrefServerPort.FormattingEnabled = true;
            this.txtPrefServerPort.Items.AddRange(new object[] {
            "5222"});
            this.txtPrefServerPort.Location = new System.Drawing.Point(232, 7);
            this.txtPrefServerPort.Name = "txtPrefServerPort";
            this.txtPrefServerPort.Size = new System.Drawing.Size(54, 21);
            this.txtPrefServerPort.TabIndex = 11;
            this.txtPrefServerPort.Text = "5222";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server/Port:";
            // 
            // lnkConnectAdvanced
            // 
            this.lnkConnectAdvanced.AutoSize = true;
            this.lnkConnectAdvanced.Location = new System.Drawing.Point(9, 106);
            this.lnkConnectAdvanced.Name = "lnkConnectAdvanced";
            this.lnkConnectAdvanced.Size = new System.Drawing.Size(65, 13);
            this.lnkConnectAdvanced.TabIndex = 12;
            this.lnkConnectAdvanced.TabStop = true;
            this.lnkConnectAdvanced.Text = "Advanced...";
            this.lnkConnectAdvanced.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkConnectAdvanced_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jabber ID:";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect.Location = new System.Drawing.Point(88, 73);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(105, 22);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect >";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegister.Location = new System.Drawing.Point(199, 73);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(89, 22);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "New Account";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(457, 179);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Appearance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(53, 237);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 13);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lnkInstallSmiley
            // 
            this.lnkInstallSmiley.AutoSize = true;
            this.lnkInstallSmiley.BackColor = System.Drawing.Color.Transparent;
            this.lnkInstallSmiley.Location = new System.Drawing.Point(4, 237);
            this.lnkInstallSmiley.Name = "lnkInstallSmiley";
            this.lnkInstallSmiley.Size = new System.Drawing.Size(43, 13);
            this.lnkInstallSmiley.TabIndex = 22;
            this.lnkInstallSmiley.TabStop = true;
            this.lnkInstallSmiley.Text = "Install...";
            this.lnkInstallSmiley.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInstallSmiley_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(4, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Smiley theme:";
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
            this.cmbSmileyTheme.Location = new System.Drawing.Point(7, 212);
            this.cmbSmileyTheme.Name = "cmbSmileyTheme";
            this.cmbSmileyTheme.Size = new System.Drawing.Size(121, 21);
            this.cmbSmileyTheme.TabIndex = 20;
            this.cmbSmileyTheme.DropDown += new System.EventHandler(this.cmbSmileyTheme_DropDown);
            // 
            // btnClosePrefs
            // 
            this.btnClosePrefs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClosePrefs.BackColor = System.Drawing.SystemColors.Control;
            this.btnClosePrefs.Location = new System.Drawing.Point(7, 455);
            this.btnClosePrefs.Name = "btnClosePrefs";
            this.btnClosePrefs.Size = new System.Drawing.Size(105, 22);
            this.btnClosePrefs.TabIndex = 19;
            this.btnClosePrefs.Text = "OK";
            this.btnClosePrefs.UseVisualStyleBackColor = true;
            this.btnClosePrefs.Click += new System.EventHandler(this.btnClosePrefs_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(4, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Chat theme:";
            // 
            // cmbFileUploadService
            // 
            this.cmbFileUploadService.FormattingEnabled = true;
            this.cmbFileUploadService.Items.AddRange(new object[] {
            "https://mediacru.sh"});
            this.cmbFileUploadService.Location = new System.Drawing.Point(7, 124);
            this.cmbFileUploadService.Name = "cmbFileUploadService";
            this.cmbFileUploadService.Size = new System.Drawing.Size(121, 21);
            this.cmbFileUploadService.TabIndex = 17;
            this.cmbFileUploadService.Text = "https://mediacru.sh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(4, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "File upload service:";
            // 
            // chkEnableImagePreview
            // 
            this.chkEnableImagePreview.AutoSize = true;
            this.chkEnableImagePreview.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableImagePreview.Checked = true;
            this.chkEnableImagePreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableImagePreview.Location = new System.Drawing.Point(7, 38);
            this.chkEnableImagePreview.Name = "chkEnableImagePreview";
            this.chkEnableImagePreview.Size = new System.Drawing.Size(100, 17);
            this.chkEnableImagePreview.TabIndex = 10;
            this.chkEnableImagePreview.Text = "Preview images";
            this.chkEnableImagePreview.UseVisualStyleBackColor = false;
            this.chkEnableImagePreview.CheckedChanged += new System.EventHandler(this.chkEnableImagePreview_CheckedChanged);
            // 
            // chkSternchen
            // 
            this.chkSternchen.AutoSize = true;
            this.chkSternchen.BackColor = System.Drawing.Color.Transparent;
            this.chkSternchen.Location = new System.Drawing.Point(94, 84);
            this.chkSternchen.Name = "chkSternchen";
            this.chkSternchen.Size = new System.Drawing.Size(30, 17);
            this.chkSternchen.TabIndex = 11;
            this.chkSternchen.Text = "*";
            this.chkSternchen.UseVisualStyleBackColor = false;
            this.chkSternchen.CheckedChanged += new System.EventHandler(this.chkSternchen_CheckedChanged);
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
            this.comboMessageTheme.Location = new System.Drawing.Point(7, 168);
            this.comboMessageTheme.Name = "comboMessageTheme";
            this.comboMessageTheme.Size = new System.Drawing.Size(121, 21);
            this.comboMessageTheme.TabIndex = 13;
            this.comboMessageTheme.SelectedIndexChanged += new System.EventHandler(this.comboMessageTheme_SelectedIndexChanged);
            // 
            // chkFiletransferAutoAccept
            // 
            this.chkFiletransferAutoAccept.AutoSize = true;
            this.chkFiletransferAutoAccept.BackColor = System.Drawing.Color.Transparent;
            this.chkFiletransferAutoAccept.Checked = true;
            this.chkFiletransferAutoAccept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiletransferAutoAccept.Location = new System.Drawing.Point(7, 84);
            this.chkFiletransferAutoAccept.Name = "chkFiletransferAutoAccept";
            this.chkFiletransferAutoAccept.Size = new System.Drawing.Size(81, 17);
            this.chkFiletransferAutoAccept.TabIndex = 14;
            this.chkFiletransferAutoAccept.Text = "Accept files";
            this.chkFiletransferAutoAccept.UseVisualStyleBackColor = false;
            this.chkFiletransferAutoAccept.CheckedChanged += new System.EventHandler(this.chkFiletransferAutoAccept_CheckedChanged);
            // 
            // chkDisplayOccupantStatus
            // 
            this.chkDisplayOccupantStatus.AutoSize = true;
            this.chkDisplayOccupantStatus.BackColor = System.Drawing.Color.Transparent;
            this.chkDisplayOccupantStatus.Location = new System.Drawing.Point(7, 61);
            this.chkDisplayOccupantStatus.Name = "chkDisplayOccupantStatus";
            this.chkDisplayOccupantStatus.Size = new System.Drawing.Size(116, 17);
            this.chkDisplayOccupantStatus.TabIndex = 12;
            this.chkDisplayOccupantStatus.Text = "Display status texts";
            this.chkDisplayOccupantStatus.UseVisualStyleBackColor = false;
            this.chkDisplayOccupantStatus.CheckedChanged += new System.EventHandler(this.chkDisplayOccupantStatus_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(4, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Server features:";
            // 
            // listServerFeatures
            // 
            this.listServerFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listServerFeatures.FormattingEnabled = true;
            this.listServerFeatures.IntegralHeight = false;
            this.listServerFeatures.Location = new System.Drawing.Point(7, 274);
            this.listServerFeatures.Name = "listServerFeatures";
            this.listServerFeatures.Size = new System.Drawing.Size(124, 175);
            this.listServerFeatures.TabIndex = 1;
            // 
            // txtConnInfo
            // 
            this.txtConnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtConnInfo.Location = new System.Drawing.Point(7, 421);
            this.txtConnInfo.Multiline = true;
            this.txtConnInfo.Name = "txtConnInfo";
            this.txtConnInfo.Size = new System.Drawing.Size(124, 28);
            this.txtConnInfo.TabIndex = 0;
            this.txtConnInfo.Visible = false;
            // 
            // lvOnlineStatus
            // 
            this.lvOnlineStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOnlineStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvOnlineStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOnlineStatus.FullRowSelect = true;
            listViewGroup1.Header = "Online";
            listViewGroup1.Name = "online";
            listViewGroup2.Header = "Not available";
            listViewGroup2.Name = "off";
            this.lvOnlineStatus.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lvOnlineStatus.LargeImageList = this.imageList1;
            this.lvOnlineStatus.Location = new System.Drawing.Point(1, 22);
            this.lvOnlineStatus.Name = "lvOnlineStatus";
            this.lvOnlineStatus.ShowItemToolTips = true;
            this.lvOnlineStatus.Size = new System.Drawing.Size(134, 213);
            this.lvOnlineStatus.SmallImageList = this.imageList1;
            this.lvOnlineStatus.TabIndex = 0;
            this.lvOnlineStatus.UseCompatibleStateImageBehavior = false;
            this.lvOnlineStatus.View = System.Windows.Forms.View.SmallIcon;
            this.lvOnlineStatus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvOnlineStatus_MouseClick);
            this.lvOnlineStatus.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvOnlineStatus_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Members";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status Message";
            this.columnHeader2.Width = 150;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "off");
            this.imageList1.Images.SetKeyName(1, "online");
            this.imageList1.Images.SetKeyName(2, "red");
            this.imageList1.Images.SetKeyName(3, "dnd");
            this.imageList1.Images.SetKeyName(4, "away");
            this.imageList1.Images.SetKeyName(5, "chat");
            this.imageList1.Images.SetKeyName(6, "xa");
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.Silver;
            this.pnlToolbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlToolbar.BackgroundImage")));
            this.pnlToolbar.Controls.Add(this.button4);
            this.pnlToolbar.Controls.Add(this.button1);
            this.pnlToolbar.Controls.Add(this.labChatstates);
            this.pnlToolbar.Controls.Add(this.txtSubject);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(138, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(478, 40);
            this.pnlToolbar.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(5, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 28);
            this.button4.TabIndex = 0;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(425, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Info...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labChatstates
            // 
            this.labChatstates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labChatstates.BackColor = System.Drawing.Color.Cyan;
            this.labChatstates.Image = ((System.Drawing.Image)(resources.GetObject("labChatstates.Image")));
            this.labChatstates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labChatstates.Location = new System.Drawing.Point(34, 6);
            this.labChatstates.Name = "labChatstates";
            this.labChatstates.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labChatstates.Size = new System.Drawing.Size(388, 28);
            this.labChatstates.TabIndex = 4;
            this.labChatstates.Text = "             label4";
            this.labChatstates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labChatstates.Visible = false;
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.BackColor = System.Drawing.SystemColors.Window;
            this.txtSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubject.Location = new System.Drawing.Point(36, 9);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(381, 21);
            this.txtSubject.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(138, 290);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(478, 310);
            this.panel3.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.webBrowser1);
            this.splitContainer1.Panel1.Controls.Add(this.txtSendmessage);
            this.splitContainer1.Panel1MinSize = 200;
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(478, 310);
            this.splitContainer1.SplitterDistance = 368;
            this.splitContainer1.TabIndex = 9;
            // 
            // txtSendmessage
            // 
            this.txtSendmessage.AllowDrop = true;
            this.txtSendmessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendmessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtSendmessage.Enabled = false;
            this.txtSendmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSendmessage.Location = new System.Drawing.Point(0, 249);
            this.txtSendmessage.Multiline = true;
            this.txtSendmessage.Name = "txtSendmessage";
            this.txtSendmessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendmessage.Size = new System.Drawing.Size(476, 61);
            this.txtSendmessage.TabIndex = 1;
            this.txtSendmessage.TextChanged += new System.EventHandler(this.txtSendmessage_TextChanged);
            this.txtSendmessage.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtSendmessage_DragDrop);
            this.txtSendmessage.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtSendmessage_DragEnter);
            this.txtSendmessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendmessage_KeyDown);
            this.txtSendmessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendmessage_KeyUp);
            // 
            // txtNickname
            // 
            this.txtNickname.BackColor = System.Drawing.SystemColors.Window;
            this.txtNickname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNickname.Location = new System.Drawing.Point(35, 6);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(75, 20);
            this.txtNickname.TabIndex = 2;
            this.txtNickname.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNickname_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(4, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nick:";
            // 
            // pnlErrMes
            // 
            this.pnlErrMes.BackColor = System.Drawing.Color.Firebrick;
            this.pnlErrMes.Controls.Add(this.btnCancelReconnect);
            this.pnlErrMes.Controls.Add(this.labErrMes);
            this.pnlErrMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlErrMes.Location = new System.Drawing.Point(138, 40);
            this.pnlErrMes.Name = "pnlErrMes";
            this.pnlErrMes.Size = new System.Drawing.Size(478, 38);
            this.pnlErrMes.TabIndex = 8;
            this.pnlErrMes.Visible = false;
            // 
            // btnCancelReconnect
            // 
            this.btnCancelReconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelReconnect.FlatAppearance.BorderSize = 0;
            this.btnCancelReconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelReconnect.Location = new System.Drawing.Point(453, 6);
            this.btnCancelReconnect.Name = "btnCancelReconnect";
            this.btnCancelReconnect.Size = new System.Drawing.Size(22, 23);
            this.btnCancelReconnect.TabIndex = 1;
            this.btnCancelReconnect.Text = "X";
            this.btnCancelReconnect.UseVisualStyleBackColor = true;
            this.btnCancelReconnect.Click += new System.EventHandler(this.btnCancelReconnect_Click);
            // 
            // labErrMes
            // 
            this.labErrMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labErrMes.ForeColor = System.Drawing.Color.White;
            this.labErrMes.Location = new System.Drawing.Point(9, 5);
            this.labErrMes.Name = "labErrMes";
            this.labErrMes.Size = new System.Drawing.Size(461, 40);
            this.labErrMes.TabIndex = 0;
            this.labErrMes.Text = "label5";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "miniConf";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMiniConfToolStripMenuItem,
            this.sendFileToolStripMenuItem,
            this.findToolStripMenuItem,
            this.toolStripMenuItem3,
            this.searchForUpdatesToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.toolStripMenuItem2,
            this.enableNotificationsToolStripMenuItem,
            this.enablePopupToolStripMenuItem,
            this.enableSoundToolStripMenuItem,
            this.toolStripMenuItem1,
            this.beendenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 242);
            // 
            // openMiniConfToolStripMenuItem
            // 
            this.openMiniConfToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openMiniConfToolStripMenuItem.Name = "openMiniConfToolStripMenuItem";
            this.openMiniConfToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.openMiniConfToolStripMenuItem.Text = "Open miniConf";
            this.openMiniConfToolStripMenuItem.Click += new System.EventHandler(this.openMiniConfToolStripMenuItem_Click);
            // 
            // sendFileToolStripMenuItem
            // 
            this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            this.sendFileToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.sendFileToolStripMenuItem.Text = "Send file ...";
            this.sendFileToolStripMenuItem.Click += new System.EventHandler(this.sendFileToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.findToolStripMenuItem.Text = "Find ...";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(171, 6);
            // 
            // searchForUpdatesToolStripMenuItem
            // 
            this.searchForUpdatesToolStripMenuItem.Name = "searchForUpdatesToolStripMenuItem";
            this.searchForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.searchForUpdatesToolStripMenuItem.Text = "Search for updates";
            this.searchForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.searchForUpdatesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMPPConsoleToolStripMenuItem,
            this.sqliteConsoleToolStripMenuItem,
            this.editStylesToolStripMenuItem,
            this.reloadStylesToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.extrasToolStripMenuItem.Text = "Tools";
            // 
            // xMPPConsoleToolStripMenuItem
            // 
            this.xMPPConsoleToolStripMenuItem.Name = "xMPPConsoleToolStripMenuItem";
            this.xMPPConsoleToolStripMenuItem.ShortcutKeyDisplayString = "F9";
            this.xMPPConsoleToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.xMPPConsoleToolStripMenuItem.Text = "XMPP console";
            this.xMPPConsoleToolStripMenuItem.Click += new System.EventHandler(this.xMPPConsoleToolStripMenuItem_Click);
            // 
            // sqliteConsoleToolStripMenuItem
            // 
            this.sqliteConsoleToolStripMenuItem.Name = "sqliteConsoleToolStripMenuItem";
            this.sqliteConsoleToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F9";
            this.sqliteConsoleToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.sqliteConsoleToolStripMenuItem.Text = "Sqlite console";
            this.sqliteConsoleToolStripMenuItem.Click += new System.EventHandler(this.sqliteConsoleToolStripMenuItem_Click);
            // 
            // editStylesToolStripMenuItem
            // 
            this.editStylesToolStripMenuItem.Name = "editStylesToolStripMenuItem";
            this.editStylesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+E";
            this.editStylesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.editStylesToolStripMenuItem.Text = "Edit styles";
            this.editStylesToolStripMenuItem.Click += new System.EventHandler(this.editStylesToolStripMenuItem_Click);
            // 
            // reloadStylesToolStripMenuItem
            // 
            this.reloadStylesToolStripMenuItem.Name = "reloadStylesToolStripMenuItem";
            this.reloadStylesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+R";
            this.reloadStylesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.reloadStylesToolStripMenuItem.Text = "Reload styles";
            this.reloadStylesToolStripMenuItem.Click += new System.EventHandler(this.reloadStylesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(171, 6);
            // 
            // enableNotificationsToolStripMenuItem
            // 
            this.enableNotificationsToolStripMenuItem.CheckOnClick = true;
            this.enableNotificationsToolStripMenuItem.Name = "enableNotificationsToolStripMenuItem";
            this.enableNotificationsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.enableNotificationsToolStripMenuItem.Text = "Enable balloon tips";
            this.enableNotificationsToolStripMenuItem.Click += new System.EventHandler(this.enableNotificationsToolStripMenuItem_Click);
            // 
            // enablePopupToolStripMenuItem
            // 
            this.enablePopupToolStripMenuItem.Checked = true;
            this.enablePopupToolStripMenuItem.CheckOnClick = true;
            this.enablePopupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enablePopupToolStripMenuItem.Name = "enablePopupToolStripMenuItem";
            this.enablePopupToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.enablePopupToolStripMenuItem.Text = "Enable popup";
            this.enablePopupToolStripMenuItem.Click += new System.EventHandler(this.enablePopupToolStripMenuItem_Click);
            // 
            // enableSoundToolStripMenuItem
            // 
            this.enableSoundToolStripMenuItem.Checked = true;
            this.enableSoundToolStripMenuItem.CheckOnClick = true;
            this.enableSoundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableSoundToolStripMenuItem.Name = "enableSoundToolStripMenuItem";
            this.enableSoundToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.enableSoundToolStripMenuItem.Text = "Enable sound";
            this.enableSoundToolStripMenuItem.Click += new System.EventHandler(this.enableSoundToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.beendenToolStripMenuItem.Text = "Quit";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // tmrReconnect
            // 
            this.tmrReconnect.Interval = 10000;
            this.tmrReconnect.Tick += new System.EventHandler(this.tmrReconnect_Tick);
            // 
            // tmrBlinky
            // 
            this.tmrBlinky.Interval = 1000;
            this.tmrBlinky.Tick += new System.EventHandler(this.tmrBlinky_Tick);
            // 
            // filterBarPanel
            // 
            this.filterBarPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.filterBarPanel.Controls.Add(this.filterBarCloseBtn);
            this.filterBarPanel.Controls.Add(this.filterTextbox);
            this.filterBarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filterBarPanel.Location = new System.Drawing.Point(138, 600);
            this.filterBarPanel.Name = "filterBarPanel";
            this.filterBarPanel.Size = new System.Drawing.Size(478, 26);
            this.filterBarPanel.TabIndex = 9;
            this.filterBarPanel.Visible = false;
            // 
            // filterBarCloseBtn
            // 
            this.filterBarCloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterBarCloseBtn.Location = new System.Drawing.Point(449, 1);
            this.filterBarCloseBtn.Name = "filterBarCloseBtn";
            this.filterBarCloseBtn.Size = new System.Drawing.Size(22, 23);
            this.filterBarCloseBtn.TabIndex = 1;
            this.filterBarCloseBtn.Text = "X";
            this.filterBarCloseBtn.UseVisualStyleBackColor = true;
            this.filterBarCloseBtn.Click += new System.EventHandler(this.filterBarCloseBtn_Click);
            // 
            // filterTextbox
            // 
            this.filterTextbox.Location = new System.Drawing.Point(10, 2);
            this.filterTextbox.Name = "filterTextbox";
            this.filterTextbox.Size = new System.Drawing.Size(207, 20);
            this.filterTextbox.TabIndex = 0;
            this.filterTextbox.TextChanged += new System.EventHandler(this.filterTextbox_TextChanged);
            this.filterTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filterTextbox_KeyDown);
            // 
            // tmrChatstatePaused
            // 
            this.tmrChatstatePaused.Interval = 7500;
            this.tmrChatstatePaused.Tick += new System.EventHandler(this.tmrChatstatePaused_Tick);
            // 
            // naviBar1
            // 
            this.naviBar1.ActiveBand = this.naviBand1;
            this.naviBar1.Controls.Add(this.naviBand1);
            this.naviBar1.Controls.Add(this.naviBand2);
            this.naviBar1.Controls.Add(this.naviBand3);
            this.naviBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.naviBar1.HeaderHeight = 39;
            this.naviBar1.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBar1.Location = new System.Drawing.Point(0, 0);
            this.naviBar1.Name = "naviBar1";
            this.naviBar1.ShowCollapseButton = false;
            this.naviBar1.Size = new System.Drawing.Size(138, 626);
            this.naviBar1.TabIndex = 10;
            this.naviBar1.Text = "naviBar1";
            this.naviBar1.VisibleLargeButtons = 2;
            this.naviBar1.SizeChanged += new System.EventHandler(this.naviBar1_SizeChanged);
            // 
            // naviBand1
            // 
            // 
            // naviBand1.ClientArea
            // 
            this.naviBand1.ClientArea.Controls.Add(this.naviGroup2);
            this.naviBand1.ClientArea.Controls.Add(this.naviGroup1);
            this.naviBand1.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand1.ClientArea.Name = "ClientArea";
            this.naviBand1.ClientArea.Size = new System.Drawing.Size(136, 483);
            this.naviBand1.ClientArea.TabIndex = 0;
            this.naviBand1.LargeImage = ((System.Drawing.Image)(resources.GetObject("naviBand1.LargeImage")));
            this.naviBand1.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBand1.Location = new System.Drawing.Point(1, 39);
            this.naviBand1.Name = "naviBand1";
            this.naviBand1.Size = new System.Drawing.Size(136, 483);
            this.naviBand1.SmallImage = ((System.Drawing.Image)(resources.GetObject("naviBand1.SmallImage")));
            this.naviBand1.TabIndex = 3;
            this.naviBand1.Text = "Groups";
            // 
            // naviGroup2
            // 
            this.naviGroup2.Caption = "Participants";
            this.naviGroup2.Controls.Add(this.lvOnlineStatus);
            this.naviGroup2.Dock = System.Windows.Forms.DockStyle.Top;
            this.naviGroup2.ExpandedHeight = 236;
            this.naviGroup2.HeaderContextMenuStrip = null;
            this.naviGroup2.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviGroup2.Location = new System.Drawing.Point(0, 206);
            this.naviGroup2.Name = "naviGroup2";
            this.naviGroup2.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
            this.naviGroup2.Size = new System.Drawing.Size(136, 236);
            this.naviGroup2.TabIndex = 1;
            this.naviGroup2.Text = "naviGroup2";
            this.naviGroup2.HeaderMouseClick += new System.Windows.Forms.MouseEventHandler(this.naviGroup1_HeaderMouseClick);
            this.naviGroup2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.naviGroup2_MouseDown);
            // 
            // naviGroup1
            // 
            this.naviGroup1.Caption = "Conversations";
            this.naviGroup1.Controls.Add(this.lbChatrooms);
            this.naviGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.naviGroup1.ExpandedHeight = 206;
            this.naviGroup1.HeaderContextMenuStrip = this.ctxMenuConversationHeader;
            this.naviGroup1.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviGroup1.Location = new System.Drawing.Point(0, 0);
            this.naviGroup1.Name = "naviGroup1";
            this.naviGroup1.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
            this.naviGroup1.Size = new System.Drawing.Size(136, 206);
            this.naviGroup1.TabIndex = 0;
            this.naviGroup1.Text = "Conversations";
            this.naviGroup1.HeaderMouseClick += new System.Windows.Forms.MouseEventHandler(this.naviGroup1_HeaderMouseClick);
            // 
            // lbChatrooms
            // 
            this.lbChatrooms.DisplayMember = "RoomName";
            this.lbChatrooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbChatrooms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbChatrooms.FormattingEnabled = true;
            this.lbChatrooms.IntegralHeight = false;
            this.lbChatrooms.ItemHeight = 20;
            this.lbChatrooms.Location = new System.Drawing.Point(1, 22);
            this.lbChatrooms.Name = "lbChatrooms";
            this.lbChatrooms.Size = new System.Drawing.Size(134, 183);
            this.lbChatrooms.TabIndex = 0;
            this.lbChatrooms.ValueMember = "RoomName";
            this.lbChatrooms.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbChatrooms_DrawItem);
            this.lbChatrooms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChatrooms_MouseClick);
            // 
            // ctxMenuConversationHeader
            // 
            this.ctxMenuConversationHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joinConversationToolStripMenuItem,
            this.createNewRoomToolStripMenuItem,
            this.toolStripMenuItem7,
            this.showAllRoomsToolStripMenuItem});
            this.ctxMenuConversationHeader.Name = "ctxMenuConversationHeader";
            this.ctxMenuConversationHeader.Size = new System.Drawing.Size(178, 76);
            // 
            // joinConversationToolStripMenuItem
            // 
            this.joinConversationToolStripMenuItem.Name = "joinConversationToolStripMenuItem";
            this.joinConversationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.joinConversationToolStripMenuItem.Text = "Join conversation";
            this.joinConversationToolStripMenuItem.Click += new System.EventHandler(this.joinConversationToolStripMenuItem_Click);
            // 
            // createNewRoomToolStripMenuItem
            // 
            this.createNewRoomToolStripMenuItem.Name = "createNewRoomToolStripMenuItem";
            this.createNewRoomToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.createNewRoomToolStripMenuItem.Text = "Create new room ...";
            this.createNewRoomToolStripMenuItem.Click += new System.EventHandler(this.createNewRoomToolStripMenuItem_Click);
            // 
            // naviBand3
            // 
            // 
            // naviBand3.ClientArea
            // 
            this.naviBand3.ClientArea.Controls.Add(this.lvContacts);
            this.naviBand3.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand3.ClientArea.Name = "ClientArea";
            this.naviBand3.ClientArea.Size = new System.Drawing.Size(136, 483);
            this.naviBand3.ClientArea.TabIndex = 0;
            this.naviBand3.LargeImage = ((System.Drawing.Image)(resources.GetObject("naviBand3.LargeImage")));
            this.naviBand3.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBand3.Location = new System.Drawing.Point(1, 39);
            this.naviBand3.Name = "naviBand3";
            this.naviBand3.Size = new System.Drawing.Size(136, 483);
            this.naviBand3.SmallImage = ((System.Drawing.Image)(resources.GetObject("naviBand3.SmallImage")));
            this.naviBand3.TabIndex = 7;
            this.naviBand3.Text = "Contacts";
            this.naviBand3.Click += new System.EventHandler(this.naviBand3_Click);
            // 
            // lvContacts
            // 
            this.lvContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvContacts.LargeImageList = this.contactsImageList;
            this.lvContacts.Location = new System.Drawing.Point(0, 0);
            this.lvContacts.Name = "lvContacts";
            this.lvContacts.Size = new System.Drawing.Size(136, 483);
            this.lvContacts.SmallImageList = this.contactsImageList;
            this.lvContacts.TabIndex = 0;
            this.lvContacts.UseCompatibleStateImageBehavior = false;
            this.lvContacts.View = System.Windows.Forms.View.Tile;
            this.lvContacts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvContacts_MouseDoubleClick);
            // 
            // contactsImageList
            // 
            this.contactsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.contactsImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.contactsImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // naviBand2
            // 
            // 
            // naviBand2.ClientArea
            // 
            this.naviBand2.ClientArea.Controls.Add(this.listServerFeatures);
            this.naviBand2.ClientArea.Controls.Add(this.btnClosePrefs);
            this.naviBand2.ClientArea.Controls.Add(this.linkLabel1);
            this.naviBand2.ClientArea.Controls.Add(this.txtConnInfo);
            this.naviBand2.ClientArea.Controls.Add(this.lnkInstallSmiley);
            this.naviBand2.ClientArea.Controls.Add(this.label4);
            this.naviBand2.ClientArea.Controls.Add(this.cmbSmileyTheme);
            this.naviBand2.ClientArea.Controls.Add(this.label8);
            this.naviBand2.ClientArea.Controls.Add(this.txtNickname);
            this.naviBand2.ClientArea.Controls.Add(this.cmbFileUploadService);
            this.naviBand2.ClientArea.Controls.Add(this.comboMessageTheme);
            this.naviBand2.ClientArea.Controls.Add(this.label5);
            this.naviBand2.ClientArea.Controls.Add(this.label7);
            this.naviBand2.ClientArea.Controls.Add(this.chkEnableImagePreview);
            this.naviBand2.ClientArea.Controls.Add(this.chkDisplayOccupantStatus);
            this.naviBand2.ClientArea.Controls.Add(this.label6);
            this.naviBand2.ClientArea.Controls.Add(this.chkFiletransferAutoAccept);
            this.naviBand2.ClientArea.Controls.Add(this.chkSternchen);
            this.naviBand2.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand2.ClientArea.Name = "ClientArea";
            this.naviBand2.ClientArea.Size = new System.Drawing.Size(136, 483);
            this.naviBand2.ClientArea.TabIndex = 0;
            this.naviBand2.LargeImage = ((System.Drawing.Image)(resources.GetObject("naviBand2.LargeImage")));
            this.naviBand2.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBand2.Location = new System.Drawing.Point(1, 39);
            this.naviBand2.Name = "naviBand2";
            this.naviBand2.Size = new System.Drawing.Size(136, 483);
            this.naviBand2.SmallImage = ((System.Drawing.Image)(resources.GetObject("naviBand2.SmallImage")));
            this.naviBand2.TabIndex = 5;
            this.naviBand2.Text = "Preferences";
            // 
            // chkToggleSidebar
            // 
            this.chkToggleSidebar.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkToggleSidebar.BackColor = System.Drawing.SystemColors.Control;
            this.chkToggleSidebar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkToggleSidebar.Location = new System.Drawing.Point(107, 6);
            this.chkToggleSidebar.Name = "chkToggleSidebar";
            this.chkToggleSidebar.Size = new System.Drawing.Size(25, 28);
            this.chkToggleSidebar.TabIndex = 11;
            this.chkToggleSidebar.Text = "<";
            this.chkToggleSidebar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkToggleSidebar.UseVisualStyleBackColor = true;
            this.chkToggleSidebar.CheckedChanged += new System.EventHandler(this.chkToggleSidebar_CheckedChanged);
            // 
            // ctxMenuConversation
            // 
            this.ctxMenuConversation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.changeNickToolStripMenuItem,
            this.toolStripMenuItem4,
            this.alwaysNotifyToolStripMenuItem,
            this.notifyOnMentionToolStripMenuItem,
            this.disableNotificationToolStripMenuItem,
            this.toolStripMenuItem6,
            this.showFullHistoryToolStripMenuItem,
            this.toolStripMenuItem5,
            this.closeToolStripMenuItem,
            this.rejoinToolStripMenuItem});
            this.ctxMenuConversation.Name = "ctxMenuConversation";
            this.ctxMenuConversation.Size = new System.Drawing.Size(186, 198);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // changeNickToolStripMenuItem
            // 
            this.changeNickToolStripMenuItem.Name = "changeNickToolStripMenuItem";
            this.changeNickToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.changeNickToolStripMenuItem.Text = "Change nick name ...";
            this.changeNickToolStripMenuItem.Visible = false;
            this.changeNickToolStripMenuItem.Click += new System.EventHandler(this.changeNickToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(182, 6);
            // 
            // alwaysNotifyToolStripMenuItem
            // 
            this.alwaysNotifyToolStripMenuItem.Checked = true;
            this.alwaysNotifyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alwaysNotifyToolStripMenuItem.Name = "alwaysNotifyToolStripMenuItem";
            this.alwaysNotifyToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.alwaysNotifyToolStripMenuItem.Tag = "2";
            this.alwaysNotifyToolStripMenuItem.Text = "Always notify";
            this.alwaysNotifyToolStripMenuItem.Click += new System.EventHandler(this.alwaysNotifyToolStripMenuItem_Click);
            // 
            // notifyOnMentionToolStripMenuItem
            // 
            this.notifyOnMentionToolStripMenuItem.Name = "notifyOnMentionToolStripMenuItem";
            this.notifyOnMentionToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.notifyOnMentionToolStripMenuItem.Tag = "1";
            this.notifyOnMentionToolStripMenuItem.Text = "Notify on mention";
            this.notifyOnMentionToolStripMenuItem.Click += new System.EventHandler(this.alwaysNotifyToolStripMenuItem_Click);
            // 
            // disableNotificationToolStripMenuItem
            // 
            this.disableNotificationToolStripMenuItem.Name = "disableNotificationToolStripMenuItem";
            this.disableNotificationToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.disableNotificationToolStripMenuItem.Tag = "0";
            this.disableNotificationToolStripMenuItem.Text = "Disable notification";
            this.disableNotificationToolStripMenuItem.Click += new System.EventHandler(this.alwaysNotifyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(182, 6);
            // 
            // showFullHistoryToolStripMenuItem
            // 
            this.showFullHistoryToolStripMenuItem.Name = "showFullHistoryToolStripMenuItem";
            this.showFullHistoryToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.showFullHistoryToolStripMenuItem.Text = "Show full history";
            this.showFullHistoryToolStripMenuItem.Click += new System.EventHandler(this.showFullHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(182, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.closeToolStripMenuItem.Text = "Close conversation";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // ctxMenuParticipant
            // 
            this.ctxMenuParticipant.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mentionToolStripMenuItem,
            this.privateMessageToolStripMenuItem,
            this.openDirectChatToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.ctxMenuParticipant.Name = "ctxMenuParticipant";
            this.ctxMenuParticipant.Size = new System.Drawing.Size(163, 92);
            // 
            // mentionToolStripMenuItem
            // 
            this.mentionToolStripMenuItem.Name = "mentionToolStripMenuItem";
            this.mentionToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.mentionToolStripMenuItem.Text = "Mention";
            // 
            // privateMessageToolStripMenuItem
            // 
            this.privateMessageToolStripMenuItem.Name = "privateMessageToolStripMenuItem";
            this.privateMessageToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.privateMessageToolStripMenuItem.Text = "Private message";
            // 
            // openDirectChatToolStripMenuItem
            // 
            this.openDirectChatToolStripMenuItem.Name = "openDirectChatToolStripMenuItem";
            this.openDirectChatToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openDirectChatToolStripMenuItem.Text = "Open direct chat";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // conversationImageList
            // 
            this.conversationImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("conversationImageList.ImageStream")));
            this.conversationImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.conversationImageList.Images.SetKeyName(0, "notify1");
            this.conversationImageList.Images.SetKeyName(1, "error");
            this.conversationImageList.Images.SetKeyName(2, "history");
            this.conversationImageList.Images.SetKeyName(3, "notify0");
            this.conversationImageList.Images.SetKeyName(4, "group");
            this.conversationImageList.Images.SetKeyName(5, "user");
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(174, 6);
            // 
            // showAllRoomsToolStripMenuItem
            // 
            this.showAllRoomsToolStripMenuItem.CheckOnClick = true;
            this.showAllRoomsToolStripMenuItem.Name = "showAllRoomsToolStripMenuItem";
            this.showAllRoomsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.showAllRoomsToolStripMenuItem.Text = "Show all rooms";
            this.showAllRoomsToolStripMenuItem.Click += new System.EventHandler(this.showAllRoomsToolStripMenuItem_Click);
            // 
            // rejoinToolStripMenuItem
            // 
            this.rejoinToolStripMenuItem.Name = "rejoinToolStripMenuItem";
            this.rejoinToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.rejoinToolStripMenuItem.Text = "Rejoin";
            this.rejoinToolStripMenuItem.Visible = false;
            this.rejoinToolStripMenuItem.Click += new System.EventHandler(this.rejoinToolStripMenuItem_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(1, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(476, 246);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webBrowser1.OnRealKeyDown += new System.Windows.Forms.HtmlElementEventHandler(this.webBrowser1_OnRealKeyDown);
            this.webBrowser1.OnSpecialUrl += new miniConf.MessageView.SpecialUrlEvent(this.webBrowser1_OnSpecialUrl);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 626);
            this.Controls.Add(this.chkToggleSidebar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.pnlErrMes);
            this.Controls.Add(this.filterBarPanel);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.naviBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(360, 450);
            this.Name = "Form1";
            this.Text = "*miniConf";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.pnlConfig.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlPrefConnectAdvanced.ResumeLayout(false);
            this.pnlPrefConnectAdvanced.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.pnlErrMes.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.filterBarPanel.ResumeLayout(false);
            this.filterBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naviBar1)).EndInit();
            this.naviBar1.ResumeLayout(false);
            this.naviBand1.ClientArea.ResumeLayout(false);
            this.naviBand1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.naviGroup2)).EndInit();
            this.naviGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.naviGroup1)).EndInit();
            this.naviGroup1.ResumeLayout(false);
            this.ctxMenuConversationHeader.ResumeLayout(false);
            this.naviBand3.ClientArea.ResumeLayout(false);
            this.naviBand3.ResumeLayout(false);
            this.naviBand2.ClientArea.ResumeLayout(false);
            this.naviBand2.ClientArea.PerformLayout();
            this.naviBand2.ResumeLayout(false);
            this.ctxMenuConversation.ResumeLayout(false);
            this.ctxMenuParticipant.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrefServer;
        private System.Windows.Forms.TextBox txtPrefUsername;
        private System.Windows.Forms.TextBox txtPrefPassword;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSendmessage;
        private MessageView webBrowser1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListView lvOnlineStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel pnlErrMes;
        private System.Windows.Forms.Label labErrMes;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMiniConfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableNotificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableSoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox chkEnableImagePreview;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Timer tmrReconnect;
        private System.Windows.Forms.Button btnCancelReconnect;
        private System.Windows.Forms.CheckBox chkSternchen;
        private System.Windows.Forms.ToolStripMenuItem enablePopupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Timer tmrBlinky;
        private System.Windows.Forms.ComboBox comboMessageTheme;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox chkDisplayOccupantStatus;
        private System.Windows.Forms.Panel filterBarPanel;
        private System.Windows.Forms.Button filterBarCloseBtn;
        private System.Windows.Forms.TextBox filterTextbox;
        private System.Windows.Forms.CheckBox chkFiletransferAutoAccept;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMPPConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqliteConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editStylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadStylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbFileUploadService;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlPrefConnectAdvanced;
        private System.Windows.Forms.ComboBox txtPrefServerPort;
        private System.Windows.Forms.LinkLabel lnkConnectAdvanced;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtConnInfo;
        private System.Windows.Forms.Label labChatstates;
        private System.Windows.Forms.Timer tmrChatstatePaused;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listServerFeatures;
        private System.Windows.Forms.Button btnClosePrefs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSmileyTheme;
        private System.Windows.Forms.LinkLabel lnkInstallSmiley;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guifreaks.NavigationBar.NaviBar naviBar1;
        private Guifreaks.NavigationBar.NaviBand naviBand1;
        private Guifreaks.NavigationBar.NaviGroup naviGroup2;
        private Guifreaks.NavigationBar.NaviGroup naviGroup1;
        private Guifreaks.NavigationBar.NaviBand naviBand2;
        private System.Windows.Forms.CheckBox chkToggleSidebar;
        private Guifreaks.NavigationBar.NaviBand naviBand3;
        private System.Windows.Forms.ContextMenuStrip ctxMenuConversationHeader;
        private System.Windows.Forms.ToolStripMenuItem joinConversationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewRoomToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxMenuConversation;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeNickToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem alwaysNotifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifyOnMentionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableNotificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem showFullHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxMenuParticipant;
        private System.Windows.Forms.ToolStripMenuItem mentionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem privateMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDirectChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ListView lvContacts;
        private System.Windows.Forms.ImageList contactsImageList;
        private System.Windows.Forms.ListBox lbChatrooms;
        private System.Windows.Forms.ImageList conversationImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem showAllRoomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejoinToolStripMenuItem;
    }
}

