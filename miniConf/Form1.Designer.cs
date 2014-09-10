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
            this.chkFiletransferAutoAccept = new System.Windows.Forms.CheckBox();
            this.chkDisplayOccupantStatus = new System.Windows.Forms.CheckBox();
            this.comboMessageTheme = new System.Windows.Forms.ComboBox();
            this.chkSternchen = new System.Windows.Forms.CheckBox();
            this.chkEnableImagePreview = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvOnlineStatus = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.chkToggleSidebar = new System.Windows.Forms.CheckBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new miniConf.MessageView();
            this.txtSendmessage = new System.Windows.Forms.TextBox();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbChatrooms = new System.Windows.Forms.CheckedListBox();
            this.pnlErrMes = new System.Windows.Forms.Panel();
            this.btnCancelReconnect = new System.Windows.Forms.Button();
            this.labErrMes = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMiniConfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.xMPPConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqliteConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFileUploadService = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnRoomList = new System.Windows.Forms.Button();
            this.txtChatrooms = new System.Windows.Forms.TextBox();
            this.txtPrefServerPort = new System.Windows.Forms.ComboBox();
            this.lnkConnectAdvanced = new System.Windows.Forms.LinkLabel();
            this.pnlPrefConnectAdvanced = new System.Windows.Forms.Panel();
            this.lvPrefChatrooms = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnConnect2 = new System.Windows.Forms.Button();
            this.pnlConfig.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlErrMes.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.filterBarPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.pnlPrefConnectAdvanced.SuspendLayout();
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
            this.pnlConfig.Location = new System.Drawing.Point(0, 65);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(616, 208);
            this.pnlConfig.TabIndex = 5;
            this.pnlConfig.Visible = false;
            // 
            // chkFiletransferAutoAccept
            // 
            this.chkFiletransferAutoAccept.AutoSize = true;
            this.chkFiletransferAutoAccept.Checked = true;
            this.chkFiletransferAutoAccept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiletransferAutoAccept.Location = new System.Drawing.Point(26, 58);
            this.chkFiletransferAutoAccept.Name = "chkFiletransferAutoAccept";
            this.chkFiletransferAutoAccept.Size = new System.Drawing.Size(81, 17);
            this.chkFiletransferAutoAccept.TabIndex = 14;
            this.chkFiletransferAutoAccept.Text = "Accept files";
            this.chkFiletransferAutoAccept.UseVisualStyleBackColor = true;
            this.chkFiletransferAutoAccept.CheckedChanged += new System.EventHandler(this.chkFiletransferAutoAccept_CheckedChanged);
            // 
            // chkDisplayOccupantStatus
            // 
            this.chkDisplayOccupantStatus.AutoSize = true;
            this.chkDisplayOccupantStatus.Location = new System.Drawing.Point(26, 35);
            this.chkDisplayOccupantStatus.Name = "chkDisplayOccupantStatus";
            this.chkDisplayOccupantStatus.Size = new System.Drawing.Size(116, 17);
            this.chkDisplayOccupantStatus.TabIndex = 12;
            this.chkDisplayOccupantStatus.Text = "Display status texts";
            this.chkDisplayOccupantStatus.UseVisualStyleBackColor = true;
            this.chkDisplayOccupantStatus.CheckedChanged += new System.EventHandler(this.chkDisplayOccupantStatus_CheckedChanged);
            // 
            // comboMessageTheme
            // 
            this.comboMessageTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMessageTheme.FormattingEnabled = true;
            this.comboMessageTheme.Items.AddRange(new object[] {
            "Default",
            "Compact",
            "Conversations",
            "Custom"});
            this.comboMessageTheme.Location = new System.Drawing.Point(318, 37);
            this.comboMessageTheme.Name = "comboMessageTheme";
            this.comboMessageTheme.Size = new System.Drawing.Size(138, 21);
            this.comboMessageTheme.TabIndex = 13;
            this.comboMessageTheme.SelectedIndexChanged += new System.EventHandler(this.comboMessageTheme_SelectedIndexChanged);
            // 
            // chkSternchen
            // 
            this.chkSternchen.AutoSize = true;
            this.chkSternchen.Location = new System.Drawing.Point(26, 104);
            this.chkSternchen.Name = "chkSternchen";
            this.chkSternchen.Size = new System.Drawing.Size(30, 17);
            this.chkSternchen.TabIndex = 11;
            this.chkSternchen.Text = "*";
            this.chkSternchen.UseVisualStyleBackColor = true;
            this.chkSternchen.CheckedChanged += new System.EventHandler(this.chkSternchen_CheckedChanged);
            // 
            // chkEnableImagePreview
            // 
            this.chkEnableImagePreview.AutoSize = true;
            this.chkEnableImagePreview.Location = new System.Drawing.Point(26, 12);
            this.chkEnableImagePreview.Name = "chkEnableImagePreview";
            this.chkEnableImagePreview.Size = new System.Drawing.Size(100, 17);
            this.chkEnableImagePreview.TabIndex = 10;
            this.chkEnableImagePreview.Text = "Preview images";
            this.chkEnableImagePreview.UseVisualStyleBackColor = true;
            this.chkEnableImagePreview.CheckedChanged += new System.EventHandler(this.chkEnableImagePreview_CheckedChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegister.Location = new System.Drawing.Point(199, 73);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(89, 22);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "New Account";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username:";
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
            // lvOnlineStatus
            // 
            this.lvOnlineStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOnlineStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvOnlineStatus.FullRowSelect = true;
            listViewGroup1.Header = "Online";
            listViewGroup1.Name = "online";
            listViewGroup2.Header = "Not available";
            listViewGroup2.Name = "off";
            this.lvOnlineStatus.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lvOnlineStatus.LargeImageList = this.imageList1;
            this.lvOnlineStatus.Location = new System.Drawing.Point(0, 0);
            this.lvOnlineStatus.Name = "lvOnlineStatus";
            this.lvOnlineStatus.ShowItemToolTips = true;
            this.lvOnlineStatus.Size = new System.Drawing.Size(106, 164);
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
            this.pnlToolbar.BackColor = System.Drawing.Color.DimGray;
            this.pnlToolbar.Controls.Add(this.button4);
            this.pnlToolbar.Controls.Add(this.chkToggleSidebar);
            this.pnlToolbar.Controls.Add(this.txtSubject);
            this.pnlToolbar.Controls.Add(this.button1);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(616, 27);
            this.pnlToolbar.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(7, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 25);
            this.button4.TabIndex = 0;
            this.button4.Text = "=";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // chkToggleSidebar
            // 
            this.chkToggleSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkToggleSidebar.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkToggleSidebar.BackColor = System.Drawing.SystemColors.Control;
            this.chkToggleSidebar.Location = new System.Drawing.Point(596, 2);
            this.chkToggleSidebar.Name = "chkToggleSidebar";
            this.chkToggleSidebar.Size = new System.Drawing.Size(19, 23);
            this.chkToggleSidebar.TabIndex = 3;
            this.chkToggleSidebar.Text = "<";
            this.chkToggleSidebar.UseVisualStyleBackColor = true;
            this.chkToggleSidebar.CheckedChanged += new System.EventHandler(this.chkToggleSidebar_CheckedChanged);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.BackColor = System.Drawing.Color.DimGray;
            this.txtSubject.ForeColor = System.Drawing.Color.White;
            this.txtSubject.Location = new System.Drawing.Point(36, 3);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(506, 20);
            this.txtSubject.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(548, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 273);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(616, 327);
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtNickname);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.lvOnlineStatus);
            this.splitContainer1.Panel2.Controls.Add(this.lbChatrooms);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(616, 327);
            this.splitContainer1.SplitterDistance = 506;
            this.splitContainer1.TabIndex = 9;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(1, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(504, 260);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webBrowser1.OnRealKeyDown += new System.Windows.Forms.HtmlElementEventHandler(this.webBrowser1_OnRealKeyDown);
            this.webBrowser1.OnSpecialUrl += new miniConf.MessageView.SpecialUrlEvent(this.webBrowser1_OnSpecialUrl);
            // 
            // txtSendmessage
            // 
            this.txtSendmessage.AllowDrop = true;
            this.txtSendmessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSendmessage.Location = new System.Drawing.Point(0, 266);
            this.txtSendmessage.Multiline = true;
            this.txtSendmessage.Name = "txtSendmessage";
            this.txtSendmessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendmessage.Size = new System.Drawing.Size(504, 61);
            this.txtSendmessage.TabIndex = 1;
            this.txtSendmessage.TextChanged += new System.EventHandler(this.txtSendmessage_TextChanged);
            this.txtSendmessage.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtSendmessage_DragDrop);
            this.txtSendmessage.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtSendmessage_DragEnter);
            this.txtSendmessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendmessage_KeyDown);
            this.txtSendmessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendmessage_KeyUp);
            // 
            // txtNickname
            // 
            this.txtNickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNickname.BackColor = System.Drawing.SystemColors.Window;
            this.txtNickname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNickname.Location = new System.Drawing.Point(30, 165);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(75, 20);
            this.txtNickname.TabIndex = 2;
            this.txtNickname.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNickname_KeyUp);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-1, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nick:";
            // 
            // lbChatrooms
            // 
            this.lbChatrooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbChatrooms.FormattingEnabled = true;
            this.lbChatrooms.Location = new System.Drawing.Point(0, 187);
            this.lbChatrooms.Name = "lbChatrooms";
            this.lbChatrooms.Size = new System.Drawing.Size(106, 139);
            this.lbChatrooms.TabIndex = 3;
            this.lbChatrooms.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbChatrooms_ItemCheck);
            this.lbChatrooms.Click += new System.EventHandler(this.lbChatrooms_Click);
            // 
            // pnlErrMes
            // 
            this.pnlErrMes.BackColor = System.Drawing.Color.Firebrick;
            this.pnlErrMes.Controls.Add(this.btnCancelReconnect);
            this.pnlErrMes.Controls.Add(this.labErrMes);
            this.pnlErrMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlErrMes.Location = new System.Drawing.Point(0, 27);
            this.pnlErrMes.Name = "pnlErrMes";
            this.pnlErrMes.Size = new System.Drawing.Size(616, 38);
            this.pnlErrMes.TabIndex = 8;
            this.pnlErrMes.Visible = false;
            // 
            // btnCancelReconnect
            // 
            this.btnCancelReconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelReconnect.FlatAppearance.BorderSize = 0;
            this.btnCancelReconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelReconnect.Location = new System.Drawing.Point(591, 6);
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
            this.labErrMes.Size = new System.Drawing.Size(599, 40);
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
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
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
            this.filterBarPanel.Location = new System.Drawing.Point(0, 600);
            this.filterBarPanel.Name = "filterBarPanel";
            this.filterBarPanel.Size = new System.Drawing.Size(616, 26);
            this.filterBarPanel.TabIndex = 9;
            this.filterBarPanel.Visible = false;
            // 
            // filterBarCloseBtn
            // 
            this.filterBarCloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterBarCloseBtn.Location = new System.Drawing.Point(587, 1);
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
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(171, 6);
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
            // searchForUpdatesToolStripMenuItem
            // 
            this.searchForUpdatesToolStripMenuItem.Name = "searchForUpdatesToolStripMenuItem";
            this.searchForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.searchForUpdatesToolStripMenuItem.Text = "Search for updates";
            this.searchForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.searchForUpdatesToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "File upload service:";
            // 
            // cmbFileUploadService
            // 
            this.cmbFileUploadService.FormattingEnabled = true;
            this.cmbFileUploadService.Items.AddRange(new object[] {
            "https://mediacru.sh"});
            this.cmbFileUploadService.Location = new System.Drawing.Point(318, 9);
            this.cmbFileUploadService.Name = "cmbFileUploadService";
            this.cmbFileUploadService.Size = new System.Drawing.Size(177, 21);
            this.cmbFileUploadService.TabIndex = 17;
            this.cmbFileUploadService.Text = "https://mediacru.sh";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 201);
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
            this.tabPage1.Size = new System.Drawing.Size(595, 175);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cmbFileUploadService);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.chkEnableImagePreview);
            this.tabPage2.Controls.Add(this.chkSternchen);
            this.tabPage2.Controls.Add(this.comboMessageTheme);
            this.tabPage2.Controls.Add(this.chkFiletransferAutoAccept);
            this.tabPage2.Controls.Add(this.chkDisplayOccupantStatus);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 175);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Appearance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Chat theme:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnConnect2);
            this.tabPage3.Controls.Add(this.txtChatrooms);
            this.tabPage3.Controls.Add(this.btnRoomList);
            this.tabPage3.Controls.Add(this.lvPrefChatrooms);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(595, 175);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Conferences";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRoomList
            // 
            this.btnRoomList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoomList.BackColor = System.Drawing.SystemColors.Control;
            this.btnRoomList.Location = new System.Drawing.Point(121, 147);
            this.btnRoomList.Name = "btnRoomList";
            this.btnRoomList.Size = new System.Drawing.Size(74, 22);
            this.btnRoomList.TabIndex = 15;
            this.btnRoomList.Text = "List ...";
            this.btnRoomList.UseVisualStyleBackColor = true;
            this.btnRoomList.Click += new System.EventHandler(this.btnRoomList_Click);
            // 
            // txtChatrooms
            // 
            this.txtChatrooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChatrooms.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatrooms.Location = new System.Drawing.Point(10, 9);
            this.txtChatrooms.Multiline = true;
            this.txtChatrooms.Name = "txtChatrooms";
            this.txtChatrooms.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChatrooms.Size = new System.Drawing.Size(579, 138);
            this.txtChatrooms.TabIndex = 7;
            this.txtChatrooms.Text = "feedback@chat.teamwiki.de\r\nlounge@chat.teamwiki.de";
            this.txtChatrooms.WordWrap = false;
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
            // lvPrefChatrooms
            // 
            this.lvPrefChatrooms.CheckBoxes = true;
            this.lvPrefChatrooms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvPrefChatrooms.FullRowSelect = true;
            this.lvPrefChatrooms.Location = new System.Drawing.Point(10, 9);
            this.lvPrefChatrooms.MultiSelect = false;
            this.lvPrefChatrooms.Name = "lvPrefChatrooms";
            this.lvPrefChatrooms.Size = new System.Drawing.Size(578, 158);
            this.lvPrefChatrooms.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvPrefChatrooms.TabIndex = 16;
            this.lvPrefChatrooms.UseCompatibleStateImageBehavior = false;
            this.lvPrefChatrooms.View = System.Windows.Forms.View.Details;
            this.lvPrefChatrooms.Visible = false;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 127;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Topic";
            this.columnHeader4.Width = 306;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nickname";
            this.columnHeader5.Width = 102;
            // 
            // btnConnect2
            // 
            this.btnConnect2.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect2.Location = new System.Drawing.Point(10, 147);
            this.btnConnect2.Name = "btnConnect2";
            this.btnConnect2.Size = new System.Drawing.Size(105, 22);
            this.btnConnect2.TabIndex = 17;
            this.btnConnect2.Text = "OK";
            this.btnConnect2.UseVisualStyleBackColor = true;
            this.btnConnect2.Click += new System.EventHandler(this.btnConnect2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 626);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.pnlErrMes);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.filterBarPanel);
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
            this.pnlConfig.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.pnlErrMes.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.filterBarPanel.ResumeLayout(false);
            this.filterBarPanel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.pnlPrefConnectAdvanced.ResumeLayout(false);
            this.pnlPrefConnectAdvanced.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkToggleSidebar;
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
        private System.Windows.Forms.CheckedListBox lbChatrooms;
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtChatrooms;
        private System.Windows.Forms.Button btnRoomList;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ListView lvPrefChatrooms;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnConnect2;
    }
}

