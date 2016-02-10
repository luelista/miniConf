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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Online", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Not available", System.Windows.Forms.HorizontalAlignment.Left);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlSendBox = new System.Windows.Forms.Panel();
            this.txtSendmessage = new System.Windows.Forms.TextBox();
            this.pbSendImage = new System.Windows.Forms.PictureBox();
            this.ctxSendImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDeleteSendImage = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlErrMes = new System.Windows.Forms.Panel();
            this.btnCancelReconnect = new System.Windows.Forms.Button();
            this.labErrMes = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMiniConfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMPPConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqliteConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adhocCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contactsImageList = new System.Windows.Forms.ImageList(this.components);
            this.ctxMenuConversationHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.joinConversationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.rejoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuParticipant = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mentionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.privateMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirectChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOfflineUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversationImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lnkInvitetoConference = new System.Windows.Forms.Label();
            this.lnkRoomlistContextMenu = new System.Windows.Forms.Label();
            this.lnkJoinRoom = new System.Windows.Forms.Label();
            this.btnContactInfo = new System.Windows.Forms.Button();
            this.naviBar1 = new Guifreaks.NavigationBar.NaviBar(this.components);
            this.naviBand1 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.lblConferencesEmpty = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.lvOnlineStatus = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbChatrooms = new System.Windows.Forms.ListBox();
            this.naviBand3 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.btnContactInvite = new System.Windows.Forms.Button();
            this.btnContactRemove = new System.Windows.Forms.Button();
            this.btnContactAdd = new System.Windows.Forms.Button();
            this.lvContacts = new System.Windows.Forms.ListView();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.labChatstates = new System.Windows.Forms.Label();
            this.chkToggleSidebar = new System.Windows.Forms.CheckBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.autoToDoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new miniConf.MessageView();
            this.panel3.SuspendLayout();
            this.pnlSendBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSendImage)).BeginInit();
            this.ctxSendImage.SuspendLayout();
            this.pnlErrMes.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.filterBarPanel.SuspendLayout();
            this.ctxMenuConversationHeader.SuspendLayout();
            this.ctxMenuConversation.SuspendLayout();
            this.ctxMenuParticipant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naviBar1)).BeginInit();
            this.naviBar1.SuspendLayout();
            this.naviBand1.ClientArea.SuspendLayout();
            this.naviBand1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.naviBand3.ClientArea.SuspendLayout();
            this.naviBand3.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
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
            // panel3
            // 
            this.panel3.Controls.Add(this.webBrowser1);
            this.panel3.Controls.Add(this.pnlSendBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(138, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(464, 508);
            this.panel3.TabIndex = 7;
            // 
            // pnlSendBox
            // 
            this.pnlSendBox.Controls.Add(this.txtSendmessage);
            this.pnlSendBox.Controls.Add(this.pbSendImage);
            this.pnlSendBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSendBox.Location = new System.Drawing.Point(0, 447);
            this.pnlSendBox.Name = "pnlSendBox";
            this.pnlSendBox.Size = new System.Drawing.Size(464, 61);
            this.pnlSendBox.TabIndex = 3;
            // 
            // txtSendmessage
            // 
            this.txtSendmessage.AllowDrop = true;
            this.txtSendmessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtSendmessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSendmessage.Enabled = false;
            this.txtSendmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSendmessage.Location = new System.Drawing.Point(0, 0);
            this.txtSendmessage.Multiline = true;
            this.txtSendmessage.Name = "txtSendmessage";
            this.txtSendmessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendmessage.Size = new System.Drawing.Size(351, 61);
            this.txtSendmessage.TabIndex = 1;
            this.txtSendmessage.TextChanged += new System.EventHandler(this.txtSendmessage_TextChanged);
            this.txtSendmessage.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtSendmessage_DragDrop);
            this.txtSendmessage.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtSendmessage_DragEnter);
            this.txtSendmessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendmessage_KeyDown);
            this.txtSendmessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendmessage_KeyUp);
            // 
            // pbSendImage
            // 
            this.pbSendImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbSendImage.ContextMenuStrip = this.ctxSendImage;
            this.pbSendImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbSendImage.Location = new System.Drawing.Point(351, 0);
            this.pbSendImage.Name = "pbSendImage";
            this.pbSendImage.Size = new System.Drawing.Size(113, 61);
            this.pbSendImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSendImage.TabIndex = 2;
            this.pbSendImage.TabStop = false;
            this.pbSendImage.Visible = false;
            // 
            // ctxSendImage
            // 
            this.ctxSendImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDeleteSendImage});
            this.ctxSendImage.Name = "ctxSendImage";
            this.ctxSendImage.Size = new System.Drawing.Size(119, 26);
            // 
            // btnDeleteSendImage
            // 
            this.btnDeleteSendImage.Name = "btnDeleteSendImage";
            this.btnDeleteSendImage.Size = new System.Drawing.Size(118, 22);
            this.btnDeleteSendImage.Text = "Löschen";
            this.btnDeleteSendImage.Click += new System.EventHandler(this.btnDeleteSendImage_Click);
            // 
            // pnlErrMes
            // 
            this.pnlErrMes.BackColor = System.Drawing.Color.Firebrick;
            this.pnlErrMes.Controls.Add(this.btnCancelReconnect);
            this.pnlErrMes.Controls.Add(this.labErrMes);
            this.pnlErrMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlErrMes.Location = new System.Drawing.Point(138, 40);
            this.pnlErrMes.Name = "pnlErrMes";
            this.pnlErrMes.Size = new System.Drawing.Size(464, 52);
            this.pnlErrMes.TabIndex = 8;
            this.pnlErrMes.Visible = false;
            // 
            // btnCancelReconnect
            // 
            this.btnCancelReconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelReconnect.Location = new System.Drawing.Point(366, 25);
            this.btnCancelReconnect.Name = "btnCancelReconnect";
            this.btnCancelReconnect.Size = new System.Drawing.Size(96, 22);
            this.btnCancelReconnect.TabIndex = 2;
            this.btnCancelReconnect.Text = "Edit Account ...";
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
            this.labErrMes.Size = new System.Drawing.Size(447, 40);
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
            this.preferencesToolStripMenuItem,
            this.reconnectToolStripMenuItem,
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 286);
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
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.reconnectToolStripMenuItem.Text = "Reconnect";
            this.reconnectToolStripMenuItem.Click += new System.EventHandler(this.reconnectToolStripMenuItem_Click);
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
            this.reloadStylesToolStripMenuItem,
            this.adhocCommandsToolStripMenuItem});
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
            // adhocCommandsToolStripMenuItem
            // 
            this.adhocCommandsToolStripMenuItem.Name = "adhocCommandsToolStripMenuItem";
            this.adhocCommandsToolStripMenuItem.ShortcutKeyDisplayString = "F8";
            this.adhocCommandsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.adhocCommandsToolStripMenuItem.Text = "Ad-hoc commands";
            this.adhocCommandsToolStripMenuItem.Click += new System.EventHandler(this.adhocCommandsToolStripMenuItem_Click);
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
            this.filterBarPanel.Size = new System.Drawing.Size(464, 26);
            this.filterBarPanel.TabIndex = 9;
            this.filterBarPanel.Visible = false;
            // 
            // filterBarCloseBtn
            // 
            this.filterBarCloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterBarCloseBtn.Location = new System.Drawing.Point(435, 1);
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
            // contactsImageList
            // 
            this.contactsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.contactsImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.contactsImageList.TransparentColor = System.Drawing.Color.Transparent;
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
            this.autoToDoToolStripMenuItem,
            this.showFullHistoryToolStripMenuItem,
            this.toolStripMenuItem5,
            this.closeToolStripMenuItem,
            this.rejoinToolStripMenuItem});
            this.ctxMenuConversation.Name = "ctxMenuConversation";
            this.ctxMenuConversation.Size = new System.Drawing.Size(186, 220);
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
            // rejoinToolStripMenuItem
            // 
            this.rejoinToolStripMenuItem.Name = "rejoinToolStripMenuItem";
            this.rejoinToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.rejoinToolStripMenuItem.Text = "Rejoin";
            this.rejoinToolStripMenuItem.Visible = false;
            this.rejoinToolStripMenuItem.Click += new System.EventHandler(this.rejoinToolStripMenuItem_Click);
            // 
            // ctxMenuParticipant
            // 
            this.ctxMenuParticipant.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mentionToolStripMenuItem,
            this.privateMessageToolStripMenuItem,
            this.openDirectChatToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.hideToolStripMenuItem,
            this.showOfflineUsersToolStripMenuItem});
            this.ctxMenuParticipant.Name = "ctxMenuParticipant";
            this.ctxMenuParticipant.Size = new System.Drawing.Size(171, 136);
            // 
            // mentionToolStripMenuItem
            // 
            this.mentionToolStripMenuItem.Name = "mentionToolStripMenuItem";
            this.mentionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.mentionToolStripMenuItem.Text = "Mention";
            this.mentionToolStripMenuItem.Click += new System.EventHandler(this.mentionToolStripMenuItem_Click);
            // 
            // privateMessageToolStripMenuItem
            // 
            this.privateMessageToolStripMenuItem.Name = "privateMessageToolStripMenuItem";
            this.privateMessageToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.privateMessageToolStripMenuItem.Text = "Private message";
            this.privateMessageToolStripMenuItem.Click += new System.EventHandler(this.privateMessageToolStripMenuItem_Click);
            // 
            // openDirectChatToolStripMenuItem
            // 
            this.openDirectChatToolStripMenuItem.Name = "openDirectChatToolStripMenuItem";
            this.openDirectChatToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.openDirectChatToolStripMenuItem.Text = "Open direct chat";
            this.openDirectChatToolStripMenuItem.Click += new System.EventHandler(this.openDirectChatToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // showOfflineUsersToolStripMenuItem
            // 
            this.showOfflineUsersToolStripMenuItem.Checked = true;
            this.showOfflineUsersToolStripMenuItem.CheckOnClick = true;
            this.showOfflineUsersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOfflineUsersToolStripMenuItem.Name = "showOfflineUsersToolStripMenuItem";
            this.showOfflineUsersToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.showOfflineUsersToolStripMenuItem.Text = "Show offline users";
            this.showOfflineUsersToolStripMenuItem.Click += new System.EventHandler(this.showOfflineUsersToolStripMenuItem_Click);
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
            // lnkInvitetoConference
            // 
            this.lnkInvitetoConference.BackColor = System.Drawing.Color.Transparent;
            this.lnkInvitetoConference.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkInvitetoConference.ForeColor = System.Drawing.Color.Gainsboro;
            this.lnkInvitetoConference.Image = global::miniConf.Properties.Resources.user_group_new;
            this.lnkInvitetoConference.Location = new System.Drawing.Point(111, 1);
            this.lnkInvitetoConference.Name = "lnkInvitetoConference";
            this.lnkInvitetoConference.Size = new System.Drawing.Size(18, 17);
            this.lnkInvitetoConference.TabIndex = 3;
            this.toolTip1.SetToolTip(this.lnkInvitetoConference, "Invite users");
            // 
            // lnkRoomlistContextMenu
            // 
            this.lnkRoomlistContextMenu.BackColor = System.Drawing.Color.Transparent;
            this.lnkRoomlistContextMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkRoomlistContextMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.lnkRoomlistContextMenu.Image = global::miniConf.Properties.Resources._12_em_down;
            this.lnkRoomlistContextMenu.Location = new System.Drawing.Point(114, 2);
            this.lnkRoomlistContextMenu.Name = "lnkRoomlistContextMenu";
            this.lnkRoomlistContextMenu.Size = new System.Drawing.Size(17, 15);
            this.lnkRoomlistContextMenu.TabIndex = 1;
            this.toolTip1.SetToolTip(this.lnkRoomlistContextMenu, "Menu");
            this.lnkRoomlistContextMenu.Click += new System.EventHandler(this.lnkRoomlistContextMenu_Click);
            // 
            // lnkJoinRoom
            // 
            this.lnkJoinRoom.BackColor = System.Drawing.Color.Transparent;
            this.lnkJoinRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkJoinRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkJoinRoom.ForeColor = System.Drawing.Color.Gainsboro;
            this.lnkJoinRoom.Image = global::miniConf.Properties.Resources._12_em_plus;
            this.lnkJoinRoom.Location = new System.Drawing.Point(96, 2);
            this.lnkJoinRoom.Name = "lnkJoinRoom";
            this.lnkJoinRoom.Size = new System.Drawing.Size(17, 15);
            this.lnkJoinRoom.TabIndex = 0;
            this.toolTip1.SetToolTip(this.lnkJoinRoom, "Join conference");
            this.lnkJoinRoom.Click += new System.EventHandler(this.joinConversationToolStripMenuItem_Click);
            // 
            // btnContactInfo
            // 
            this.btnContactInfo.Image = global::miniConf.Properties.Resources._16_message_info;
            this.btnContactInfo.Location = new System.Drawing.Point(45, -1);
            this.btnContactInfo.Name = "btnContactInfo";
            this.btnContactInfo.Size = new System.Drawing.Size(27, 22);
            this.btnContactInfo.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnContactInfo, "Contact info");
            this.btnContactInfo.UseVisualStyleBackColor = true;
            // 
            // naviBar1
            // 
            this.naviBar1.ActiveBand = this.naviBand1;
            this.naviBar1.Controls.Add(this.naviBand1);
            this.naviBar1.Controls.Add(this.naviBand3);
            this.naviBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.naviBar1.HeaderHeight = 0;
            this.naviBar1.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBar1.Location = new System.Drawing.Point(0, 40);
            this.naviBar1.Name = "naviBar1";
            this.naviBar1.ShowCollapseButton = false;
            this.naviBar1.ShowMoreOptionsButton = false;
            this.naviBar1.Size = new System.Drawing.Size(138, 586);
            this.naviBar1.TabIndex = 10;
            this.naviBar1.Text = "naviBar1";
            this.naviBar1.SizeChanged += new System.EventHandler(this.naviBar1_SizeChanged);
            // 
            // naviBand1
            // 
            // 
            // naviBand1.ClientArea
            // 
            this.naviBand1.ClientArea.Controls.Add(this.lblConferencesEmpty);
            this.naviBand1.ClientArea.Controls.Add(this.panel5);
            this.naviBand1.ClientArea.Controls.Add(this.panel2);
            this.naviBand1.ClientArea.Controls.Add(this.lvOnlineStatus);
            this.naviBand1.ClientArea.Controls.Add(this.lbChatrooms);
            this.naviBand1.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand1.ClientArea.Name = "ClientArea";
            this.naviBand1.ClientArea.Size = new System.Drawing.Size(136, 546);
            this.naviBand1.ClientArea.TabIndex = 0;
            this.naviBand1.LargeImage = ((System.Drawing.Image)(resources.GetObject("naviBand1.LargeImage")));
            this.naviBand1.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBand1.Location = new System.Drawing.Point(1, 0);
            this.naviBand1.Name = "naviBand1";
            this.naviBand1.Size = new System.Drawing.Size(136, 546);
            this.naviBand1.SmallImage = ((System.Drawing.Image)(resources.GetObject("naviBand1.SmallImage")));
            this.naviBand1.TabIndex = 3;
            this.naviBand1.Text = "Groups";
            // 
            // lblConferencesEmpty
            // 
            this.lblConferencesEmpty.BackColor = System.Drawing.Color.White;
            this.lblConferencesEmpty.ForeColor = System.Drawing.Color.Gray;
            this.lblConferencesEmpty.Location = new System.Drawing.Point(11, 80);
            this.lblConferencesEmpty.Name = "lblConferencesEmpty";
            this.lblConferencesEmpty.Size = new System.Drawing.Size(111, 42);
            this.lblConferencesEmpty.TabIndex = 3;
            this.lblConferencesEmpty.Text = "click the plus sign to join a conference";
            this.lblConferencesEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConferencesEmpty.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(130)))));
            this.panel5.Controls.Add(this.lnkInvitetoConference);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Location = new System.Drawing.Point(0, 211);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(136, 18);
            this.panel5.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(130)))));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Participants";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(130)))));
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lnkRoomlistContextMenu);
            this.panel2.Controls.Add(this.lnkJoinRoom);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(136, 18);
            this.panel2.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(130)))));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Conferences";
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
            this.lvOnlineStatus.Location = new System.Drawing.Point(1, 229);
            this.lvOnlineStatus.Name = "lvOnlineStatus";
            this.lvOnlineStatus.ShowItemToolTips = true;
            this.lvOnlineStatus.Size = new System.Drawing.Size(134, 317);
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
            // lbChatrooms
            // 
            this.lbChatrooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbChatrooms.DisplayMember = "RoomName";
            this.lbChatrooms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbChatrooms.FormattingEnabled = true;
            this.lbChatrooms.IntegralHeight = false;
            this.lbChatrooms.ItemHeight = 20;
            this.lbChatrooms.Location = new System.Drawing.Point(1, 19);
            this.lbChatrooms.Name = "lbChatrooms";
            this.lbChatrooms.Size = new System.Drawing.Size(134, 192);
            this.lbChatrooms.TabIndex = 0;
            this.lbChatrooms.ValueMember = "RoomName";
            this.lbChatrooms.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbChatrooms_DrawItem);
            this.lbChatrooms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbChatrooms_MouseClick);
            // 
            // naviBand3
            // 
            // 
            // naviBand3.ClientArea
            // 
            this.naviBand3.ClientArea.Controls.Add(this.btnContactInfo);
            this.naviBand3.ClientArea.Controls.Add(this.btnContactInvite);
            this.naviBand3.ClientArea.Controls.Add(this.btnContactRemove);
            this.naviBand3.ClientArea.Controls.Add(this.btnContactAdd);
            this.naviBand3.ClientArea.Controls.Add(this.lvContacts);
            this.naviBand3.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand3.ClientArea.Name = "ClientArea";
            this.naviBand3.ClientArea.Size = new System.Drawing.Size(136, 546);
            this.naviBand3.ClientArea.TabIndex = 0;
            this.naviBand3.LargeImage = ((System.Drawing.Image)(resources.GetObject("naviBand3.LargeImage")));
            this.naviBand3.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBand3.Location = new System.Drawing.Point(1, 0);
            this.naviBand3.Name = "naviBand3";
            this.naviBand3.Size = new System.Drawing.Size(136, 546);
            this.naviBand3.SmallImage = ((System.Drawing.Image)(resources.GetObject("naviBand3.SmallImage")));
            this.naviBand3.TabIndex = 7;
            this.naviBand3.Text = "Contacts";
            this.naviBand3.Click += new System.EventHandler(this.naviBand3_Click);
            // 
            // btnContactInvite
            // 
            this.btnContactInvite.Image = global::miniConf.Properties.Resources.user_group_new;
            this.btnContactInvite.Location = new System.Drawing.Point(78, -1);
            this.btnContactInvite.Name = "btnContactInvite";
            this.btnContactInvite.Size = new System.Drawing.Size(57, 22);
            this.btnContactInvite.TabIndex = 3;
            this.btnContactInvite.Text = "Invite";
            this.btnContactInvite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnContactInvite.UseVisualStyleBackColor = true;
            this.btnContactInvite.Click += new System.EventHandler(this.btnContactInvite_Click);
            // 
            // btnContactRemove
            // 
            this.btnContactRemove.Location = new System.Drawing.Point(22, -1);
            this.btnContactRemove.Name = "btnContactRemove";
            this.btnContactRemove.Size = new System.Drawing.Size(24, 22);
            this.btnContactRemove.TabIndex = 2;
            this.btnContactRemove.Text = "-";
            this.btnContactRemove.UseVisualStyleBackColor = true;
            this.btnContactRemove.Click += new System.EventHandler(this.btnContactRemove_Click);
            // 
            // btnContactAdd
            // 
            this.btnContactAdd.Location = new System.Drawing.Point(-1, -1);
            this.btnContactAdd.Name = "btnContactAdd";
            this.btnContactAdd.Size = new System.Drawing.Size(24, 22);
            this.btnContactAdd.TabIndex = 1;
            this.btnContactAdd.Text = "+";
            this.btnContactAdd.UseVisualStyleBackColor = true;
            this.btnContactAdd.Click += new System.EventHandler(this.btnContactAdd_Click);
            // 
            // lvContacts
            // 
            this.lvContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvContacts.LargeImageList = this.contactsImageList;
            this.lvContacts.Location = new System.Drawing.Point(0, 21);
            this.lvContacts.Name = "lvContacts";
            this.lvContacts.Size = new System.Drawing.Size(136, 525);
            this.lvContacts.SmallImageList = this.contactsImageList;
            this.lvContacts.TabIndex = 0;
            this.lvContacts.UseCompatibleStateImageBehavior = false;
            this.lvContacts.View = System.Windows.Forms.View.Tile;
            this.lvContacts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvContacts_MouseDoubleClick);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.Silver;
            this.pnlToolbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlToolbar.BackgroundImage")));
            this.pnlToolbar.Controls.Add(this.button4);
            this.pnlToolbar.Controls.Add(this.labChatstates);
            this.pnlToolbar.Controls.Add(this.chkToggleSidebar);
            this.pnlToolbar.Controls.Add(this.txtSubject);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(602, 40);
            this.pnlToolbar.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(33, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 28);
            this.button4.TabIndex = 0;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // labChatstates
            // 
            this.labChatstates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labChatstates.BackColor = System.Drawing.Color.Cyan;
            this.labChatstates.Image = ((System.Drawing.Image)(resources.GetObject("labChatstates.Image")));
            this.labChatstates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labChatstates.Location = new System.Drawing.Point(65, 6);
            this.labChatstates.Name = "labChatstates";
            this.labChatstates.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labChatstates.Size = new System.Drawing.Size(530, 28);
            this.labChatstates.TabIndex = 4;
            this.labChatstates.Text = "             label4";
            this.labChatstates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labChatstates.Visible = false;
            // 
            // chkToggleSidebar
            // 
            this.chkToggleSidebar.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkToggleSidebar.BackColor = System.Drawing.SystemColors.Control;
            this.chkToggleSidebar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkToggleSidebar.Location = new System.Drawing.Point(5, 6);
            this.chkToggleSidebar.Name = "chkToggleSidebar";
            this.chkToggleSidebar.Size = new System.Drawing.Size(28, 28);
            this.chkToggleSidebar.TabIndex = 11;
            this.chkToggleSidebar.Text = "<";
            this.chkToggleSidebar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkToggleSidebar.UseVisualStyleBackColor = true;
            this.chkToggleSidebar.CheckedChanged += new System.EventHandler(this.chkToggleSidebar_CheckedChanged);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.BackColor = System.Drawing.SystemColors.Window;
            this.txtSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubject.Location = new System.Drawing.Point(67, 9);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(523, 21);
            this.txtSubject.TabIndex = 1;
            // 
            // autoToDoToolStripMenuItem
            // 
            this.autoToDoToolStripMenuItem.Name = "autoToDoToolStripMenuItem";
            this.autoToDoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.autoToDoToolStripMenuItem.Text = "Auto-To-Do ...";
            this.autoToDoToolStripMenuItem.Click += new System.EventHandler(this.autoToDoToolStripMenuItem_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(464, 447);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webBrowser1.OnRealKeyDown += new System.Windows.Forms.HtmlElementEventHandler(this.webBrowser1_OnRealKeyDown);
            this.webBrowser1.QuoteMessage += new System.EventHandler(this.webBrowser1_QuoteMessage);
            this.webBrowser1.OnSpecialUrl += new miniConf.MessageView.SpecialUrlEvent(this.webBrowser1_OnSpecialUrl);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 626);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlErrMes);
            this.Controls.Add(this.filterBarPanel);
            this.Controls.Add(this.naviBar1);
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
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel3.ResumeLayout(false);
            this.pnlSendBox.ResumeLayout(false);
            this.pnlSendBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSendImage)).EndInit();
            this.ctxSendImage.ResumeLayout(false);
            this.pnlErrMes.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.filterBarPanel.ResumeLayout(false);
            this.filterBarPanel.PerformLayout();
            this.ctxMenuConversationHeader.ResumeLayout(false);
            this.ctxMenuConversation.ResumeLayout(false);
            this.ctxMenuParticipant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.naviBar1)).EndInit();
            this.naviBar1.ResumeLayout(false);
            this.naviBand1.ClientArea.ResumeLayout(false);
            this.naviBand1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.naviBand3.ClientArea.ResumeLayout(false);
            this.naviBand3.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSendmessage;
        private MessageView webBrowser1;
        private System.Windows.Forms.TextBox txtSubject;
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
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Timer tmrReconnect;
        private System.Windows.Forms.ToolStripMenuItem enablePopupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Timer tmrBlinky;
        private System.Windows.Forms.Panel filterBarPanel;
        private System.Windows.Forms.Button filterBarCloseBtn;
        private System.Windows.Forms.TextBox filterTextbox;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMPPConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqliteConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editStylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadStylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchForUpdatesToolStripMenuItem;
        private System.Windows.Forms.Label labChatstates;
        private System.Windows.Forms.Timer tmrChatstatePaused;
        private System.Windows.Forms.CheckBox chkToggleSidebar;
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
        private System.Windows.Forms.ImageList contactsImageList;
        private System.Windows.Forms.ImageList conversationImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem showAllRoomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejoinToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guifreaks.NavigationBar.NaviBand naviBand3;
        private System.Windows.Forms.ListView lvContacts;
        private Guifreaks.NavigationBar.NaviBand naviBand1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lnkRoomlistContextMenu;
        private System.Windows.Forms.Label lnkJoinRoom;
        private System.Windows.Forms.ListView lvOnlineStatus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListBox lbChatrooms;
        private Guifreaks.NavigationBar.NaviBar naviBar1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.Button btnCancelReconnect;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.Label lblConferencesEmpty;
        private System.Windows.Forms.Button btnContactInfo;
        private System.Windows.Forms.Button btnContactInvite;
        private System.Windows.Forms.Button btnContactRemove;
        private System.Windows.Forms.Button btnContactAdd;
        private System.Windows.Forms.ToolStripMenuItem showOfflineUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adhocCommandsToolStripMenuItem;
        private System.Windows.Forms.Label lnkInvitetoConference;
        private System.Windows.Forms.PictureBox pbSendImage;
        private System.Windows.Forms.Panel pnlSendBox;
        private System.Windows.Forms.ContextMenuStrip ctxSendImage;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteSendImage;
        private System.Windows.Forms.ToolStripMenuItem autoToDoToolStripMenuItem;
    }
}

