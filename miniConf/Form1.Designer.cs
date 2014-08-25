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
            this.txtChatrooms = new System.Windows.Forms.TextBox();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.chkDisplayOccupantStatus = new System.Windows.Forms.CheckBox();
            this.comboMessageTheme = new System.Windows.Forms.ComboBox();
            this.chkSternchen = new System.Windows.Forms.CheckBox();
            this.chkEnableImagePreview = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
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
            this.searchForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.enableNotificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enablePopupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrReconnect = new System.Windows.Forms.Timer(this.components);
            this.tmrBlinky = new System.Windows.Forms.Timer(this.components);
            this.pnlConfig.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlErrMes.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrefServer
            // 
            this.txtPrefServer.Location = new System.Drawing.Point(8, 25);
            this.txtPrefServer.Name = "txtPrefServer";
            this.txtPrefServer.Size = new System.Drawing.Size(104, 20);
            this.txtPrefServer.TabIndex = 0;
            this.txtPrefServer.Text = "teamwiki.de";
            // 
            // txtPrefUsername
            // 
            this.txtPrefUsername.Location = new System.Drawing.Point(117, 25);
            this.txtPrefUsername.Name = "txtPrefUsername";
            this.txtPrefUsername.Size = new System.Drawing.Size(125, 20);
            this.txtPrefUsername.TabIndex = 1;
            // 
            // txtPrefPassword
            // 
            this.txtPrefPassword.Location = new System.Drawing.Point(247, 25);
            this.txtPrefPassword.Name = "txtPrefPassword";
            this.txtPrefPassword.PasswordChar = '*';
            this.txtPrefPassword.Size = new System.Drawing.Size(125, 20);
            this.txtPrefPassword.TabIndex = 2;
            // 
            // txtChatrooms
            // 
            this.txtChatrooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChatrooms.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatrooms.Location = new System.Drawing.Point(7, 68);
            this.txtChatrooms.Multiline = true;
            this.txtChatrooms.Name = "txtChatrooms";
            this.txtChatrooms.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChatrooms.Size = new System.Drawing.Size(367, 80);
            this.txtChatrooms.TabIndex = 4;
            this.txtChatrooms.Text = "feedback@chat.teamwiki.de\r\nlounge@chat.teamwiki.de";
            this.txtChatrooms.WordWrap = false;
            // 
            // pnlConfig
            // 
            this.pnlConfig.BackColor = System.Drawing.Color.Gold;
            this.pnlConfig.Controls.Add(this.chkDisplayOccupantStatus);
            this.pnlConfig.Controls.Add(this.comboMessageTheme);
            this.pnlConfig.Controls.Add(this.chkSternchen);
            this.pnlConfig.Controls.Add(this.chkEnableImagePreview);
            this.pnlConfig.Controls.Add(this.btnRegister);
            this.pnlConfig.Controls.Add(this.label4);
            this.pnlConfig.Controls.Add(this.label3);
            this.pnlConfig.Controls.Add(this.button2);
            this.pnlConfig.Controls.Add(this.label2);
            this.pnlConfig.Controls.Add(this.label1);
            this.pnlConfig.Controls.Add(this.txtChatrooms);
            this.pnlConfig.Controls.Add(this.txtPrefPassword);
            this.pnlConfig.Controls.Add(this.txtPrefUsername);
            this.pnlConfig.Controls.Add(this.txtPrefServer);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConfig.Location = new System.Drawing.Point(0, 65);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(382, 208);
            this.pnlConfig.TabIndex = 5;
            this.pnlConfig.Visible = false;
            // 
            // chkDisplayOccupantStatus
            // 
            this.chkDisplayOccupantStatus.AutoSize = true;
            this.chkDisplayOccupantStatus.Location = new System.Drawing.Point(153, 181);
            this.chkDisplayOccupantStatus.Name = "chkDisplayOccupantStatus";
            this.chkDisplayOccupantStatus.Size = new System.Drawing.Size(116, 17);
            this.chkDisplayOccupantStatus.TabIndex = 13;
            this.chkDisplayOccupantStatus.Text = "Display status texts";
            this.chkDisplayOccupantStatus.UseVisualStyleBackColor = true;
            this.chkDisplayOccupantStatus.CheckedChanged += new System.EventHandler(this.chkDisplayOccupantStatus_CheckedChanged);
            // 
            // comboMessageTheme
            // 
            this.comboMessageTheme.FormattingEnabled = true;
            this.comboMessageTheme.Items.AddRange(new object[] {
            "Default",
            "Compact",
            "Hanging_Indent",
            "Conversations",
            "Custom"});
            this.comboMessageTheme.Location = new System.Drawing.Point(276, 179);
            this.comboMessageTheme.Name = "comboMessageTheme";
            this.comboMessageTheme.Size = new System.Drawing.Size(138, 21);
            this.comboMessageTheme.TabIndex = 12;
            this.comboMessageTheme.Visible = false;
            // 
            // chkSternchen
            // 
            this.chkSternchen.AutoSize = true;
            this.chkSternchen.Location = new System.Drawing.Point(117, 181);
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
            this.chkEnableImagePreview.Location = new System.Drawing.Point(8, 181);
            this.chkEnableImagePreview.Name = "chkEnableImagePreview";
            this.chkEnableImagePreview.Size = new System.Drawing.Size(100, 17);
            this.chkEnableImagePreview.TabIndex = 10;
            this.chkEnableImagePreview.Text = "Preview images";
            this.chkEnableImagePreview.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegister.Location = new System.Drawing.Point(285, 152);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(89, 22);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Create Account";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Chatrooms:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(7, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 22);
            this.button2.TabIndex = 1;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server:";
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
            this.lvOnlineStatus.Size = new System.Drawing.Size(106, 190);
            this.lvOnlineStatus.SmallImageList = this.imageList1;
            this.lvOnlineStatus.TabIndex = 8;
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
            this.pnlToolbar.Size = new System.Drawing.Size(382, 27);
            this.pnlToolbar.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(7, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "=";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // chkToggleSidebar
            // 
            this.chkToggleSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkToggleSidebar.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkToggleSidebar.BackColor = System.Drawing.SystemColors.Control;
            this.chkToggleSidebar.Location = new System.Drawing.Point(362, 2);
            this.chkToggleSidebar.Name = "chkToggleSidebar";
            this.chkToggleSidebar.Size = new System.Drawing.Size(19, 23);
            this.chkToggleSidebar.TabIndex = 4;
            this.chkToggleSidebar.Text = "<";
            this.chkToggleSidebar.UseVisualStyleBackColor = false;
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
            this.txtSubject.Size = new System.Drawing.Size(272, 20);
            this.txtSubject.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(314, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "config";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 273);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(382, 353);
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
            this.splitContainer1.Size = new System.Drawing.Size(382, 353);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 9;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(1, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(270, 286);
            this.webBrowser1.TabIndex = 5;
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            this.webBrowser1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowser1_PreviewKeyDown);
            // 
            // txtSendmessage
            // 
            this.txtSendmessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendmessage.Location = new System.Drawing.Point(0, 292);
            this.txtSendmessage.Multiline = true;
            this.txtSendmessage.Name = "txtSendmessage";
            this.txtSendmessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendmessage.Size = new System.Drawing.Size(270, 61);
            this.txtSendmessage.TabIndex = 6;
            this.txtSendmessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendmessage_KeyDown);
            this.txtSendmessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendmessage_KeyUp);
            // 
            // txtNickname
            // 
            this.txtNickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNickname.BackColor = System.Drawing.SystemColors.Window;
            this.txtNickname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNickname.Location = new System.Drawing.Point(30, 191);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(75, 20);
            this.txtNickname.TabIndex = 6;
            this.txtNickname.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNickname_KeyUp);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-1, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nick:";
            // 
            // lbChatrooms
            // 
            this.lbChatrooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbChatrooms.FormattingEnabled = true;
            this.lbChatrooms.Location = new System.Drawing.Point(0, 213);
            this.lbChatrooms.Name = "lbChatrooms";
            this.lbChatrooms.Size = new System.Drawing.Size(106, 139);
            this.lbChatrooms.TabIndex = 9;
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
            this.pnlErrMes.Size = new System.Drawing.Size(382, 38);
            this.pnlErrMes.TabIndex = 8;
            this.pnlErrMes.Visible = false;
            // 
            // btnCancelReconnect
            // 
            this.btnCancelReconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelReconnect.Location = new System.Drawing.Point(357, 6);
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
            this.labErrMes.Size = new System.Drawing.Size(365, 40);
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
            this.searchForUpdatesToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStripMenuItem2,
            this.enableNotificationsToolStripMenuItem,
            this.enablePopupToolStripMenuItem,
            this.enableSoundToolStripMenuItem,
            this.toolStripMenuItem1,
            this.beendenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 170);
            // 
            // openMiniConfToolStripMenuItem
            // 
            this.openMiniConfToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openMiniConfToolStripMenuItem.Name = "openMiniConfToolStripMenuItem";
            this.openMiniConfToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.openMiniConfToolStripMenuItem.Text = "Open miniConf";
            this.openMiniConfToolStripMenuItem.Click += new System.EventHandler(this.openMiniConfToolStripMenuItem_Click);
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(171, 6);
            // 
            // enableNotificationsToolStripMenuItem
            // 
            this.enableNotificationsToolStripMenuItem.Checked = true;
            this.enableNotificationsToolStripMenuItem.CheckOnClick = true;
            this.enableNotificationsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableNotificationsToolStripMenuItem.Name = "enableNotificationsToolStripMenuItem";
            this.enableNotificationsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.enableNotificationsToolStripMenuItem.Text = "Enable balloon tips";
            this.enableNotificationsToolStripMenuItem.Click += new System.EventHandler(this.enableNotificationsToolStripMenuItem_Click);
            // 
            // enablePopupToolStripMenuItem
            // 
            this.enablePopupToolStripMenuItem.CheckOnClick = true;
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
            this.tmrReconnect.Interval = 5000;
            this.tmrReconnect.Tick += new System.EventHandler(this.tmrReconnect_Tick);
            // 
            // tmrBlinky
            // 
            this.tmrBlinky.Interval = 1000;
            this.tmrBlinky.Tick += new System.EventHandler(this.tmrBlinky_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 626);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.pnlErrMes);
            this.Controls.Add(this.pnlToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(360, 450);
            this.Name = "Form1";
            this.Text = "*miniConf";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrefServer;
        private System.Windows.Forms.TextBox txtPrefUsername;
        private System.Windows.Forms.TextBox txtPrefPassword;
        private System.Windows.Forms.TextBox txtChatrooms;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSendmessage;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView lvOnlineStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.CheckBox chkToggleSidebar;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.ToolStripMenuItem searchForUpdatesToolStripMenuItem;
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
    }
}

