using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using agsXMPP;
using System.Data.SQLite;
using System.Threading;
using System.Text.RegularExpressions;
using System.Media;
using System.IO;
using agsXMPP.Xml.Dom;
using agsXMPP.protocol.iq.disco;

namespace miniConf {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            webBrowser1.imagePreview = true;
            icon1 = this.Icon; icon2 = Icon.FromHandle(new Bitmap(imageList1.Images[2]).GetHicon());

            CheckForIllegalCrossThreadCalls = false;
            /*pnlLoginWrapper.Location = new Point(0, 0);
            pnlLoginWrapper.Size = this.ClientSize;*/
        }


        Boolean loginError = true;
        string balloonRoom = null;
        UnreadMessageForm popupWindow;
        DirectMessageManager dmManager = new DirectMessageManager();
        //List<string> onlineContacts = new List<string>();
        XmppDebugForm debugForm;

        Icon icon1;
        Icon icon2;


        #region Jabber Connection

        agsXMPP.protocol.x.muc.MucManager muc;
        JabberService jabber = Program.Jabber;
        cls_globPara glob;
        ChatDatabase logs;
        Dictionary<string, Roomdata> rooms = new Dictionary<string, Roomdata>();
        Roomdata currentRoom = null;

        private delegate void XmppMessageDelegate(agsXMPP.protocol.client.Message msg);
        private delegate void XmppPresenceDelegate(agsXMPP.protocol.client.Presence msg);


        private void jabberConnect() {
            /*pnlLoginWrapper.Enabled = false;*/
            UseWaitCursor = true;
            if (jabber.conn == null) {
                jabber.conn = new XmppClientConnection();
                jabber.conn.DiscoInfo.AddFeature(new DiscoFeature("urn:xmpp:avatar:metadata+notify"));
                jabber.conn.DiscoInfo.AddFeature(new DiscoFeature(JabberService.URN_MESSAGE_CORRECT));

                jabber.conn.DiscoInfo.AddIdentity(new DiscoIdentity("pc", "miniConf " + Application.ProductVersion, "client"));
                jabber.conn.Capabilities.SetVersion(jabber.conn.DiscoInfo);
                jabber.conn.Capabilities.Node = "http://home.luelista.net/programme/miniconf";
                jabber.conn.Capabilities.SetAttribute("clientver", Application.ProductVersion);

                //jabber.conn.Capabilities.AddChild(new agsXMPP.protocol.iq.disco.DiscoFeature("urn:xmpp:avatar:metadata+notify"));
                jabber.conn.EnableCapabilities = true;

                jabber.conn.OnAuthError += conn_OnAuthError;
                jabber.conn.OnXmppConnectionStateChanged += conn_OnXmppConnectionStateChanged;
                jabber.conn.OnSocketError += conn_OnSocketError;
                jabber.conn.OnError += conn_OnError;
                jabber.conn.OnBindError += conn_OnBindError;
                jabber.conn.OnLogin += conn_OnLogin;
                jabber.conn.OnIq += conn_OnIq;
                jabber.conn.OnSaslStart += conn_OnSaslStart;
                jabber.conn.OnSaslEnd += conn_OnSaslEnd;
                muc = new agsXMPP.protocol.x.muc.MucManager(jabber.conn);
                jabber.jingle.init(jabber.conn);
                jabber.listenToRoster();

                jabber.conn.OnPresence += conn_OnPresence;
                jabber.conn.OnMessage += conn_OnMessage;

                jabber.jingle.OnFileReceived += delegate(Jid fromJid, string filename, string status) {
                    this.Invoke(new Jingle.OnFileReceivedEvent(jingle_OnFileReceived), fromJid, filename, status);
                };

                jabber.OnContactPresence += jabber_OnContactPresence;
                jabber.OnServerFeaturesUpdated += jabber_OnServerFeaturesUpdated;

                if (glob.para("showXmppDebugOnStartup", "FALSE") == "TRUE") ShowXmppDebugForm();

            } else {
                jabber.conn.Close(); Application.DoEvents();
                System.Threading.Thread.Sleep(400); Application.DoEvents();
            }

            string[] username = ApplicationPreferences.getUsername();
            if (username == null) {
                showNetworkError("Please enter your full jabber ID in the form of username@example.com");
                return;
            }


            jabber.conn.Server = username[1];
            if (!String.IsNullOrEmpty(ApplicationPreferences.AccountServer)) {
                jabber.conn.ConnectServer = ApplicationPreferences.AccountServer;
                jabber.conn.AutoResolveConnectServer = false;
            } else {
                jabber.conn.AutoResolveConnectServer = true;
            }

            //if (glob.para("account__Server") != "") jabber.conn.Server = glob.para("account__Server");
            int port;
            if (!Int32.TryParse(ApplicationPreferences.AccountPort, out port)) {
                port = 5222; ApplicationPreferences.AccountPort = "5222";
            }
            jabber.conn.Port = port;

            if (port == 5223) {
                jabber.conn.UseSSL = true;
                jabber.conn.UseStartTLS = false;
            } else {
                jabber.conn.UseSSL = false;
                jabber.conn.UseStartTLS = (glob.para("useSSL", "TRUE") != "FALSE");
            }
            //jabber.conn.UseSSL = (glob.para("useSSL", "TRUE") != "FALSE");
            jabber.conn.Open(username[0], ApplicationPreferences.AccountPassword, "miniConf-" + Environment.MachineName, 0);
            //txtConnInfo.Text = "";
            webBrowser1.selfNickname = ApplicationPreferences.Nickname;
        }

        void conn_OnSaslEnd(object sender) {
            Console.WriteLine("OnSaslEnd");
        }

        void conn_OnSaslStart(object sender, agsXMPP.Sasl.SaslEventArgs args) {
            Console.WriteLine("OnSaslStart: " + args.ToString());
        }

        void jabber_OnContactPresence(object sender, JabberService.JabberEventArgs e) {
            updateContactList();
        }

        void jabber_OnServerFeaturesUpdated(object sender, EventArgs e) {
            this.Invoke((MethodInvoker)delegate() {
                //listServerFeatures.Items.Clear();
                foreach (string feat in jabber.serverFeatures) {
                    //listServerFeatures.Items.Add(feat);
                }
            });
        }

        void jingle_OnFileReceived(Jid fromJid, string filename, string status) {
            var frm = dmManager.GetWindow(fromJid);
            if (status == "failed") {
                frm.onNotice("ERROR: " + filename);

            } else if (status == "loading") {
                frm.onNotice("Receiving file, please wait ...<br>(" + fromJid.ToString() + ", " + filename + ", " + status + ")");

            } else if (status == "done" && filename.EndsWith(".webp")) {
                var dec = new Imazen.WebP.SimpleDecoder();
                byte[] bytes = System.IO.File.ReadAllBytes(filename);
                var img = dec.DecodeFromBytes(bytes, bytes.Length);
                var jpgpath = System.IO.Path.ChangeExtension(filename, "jpg");
                img.Save(jpgpath, System.Drawing.Imaging.ImageFormat.Jpeg);
                /*var thumb = img.GetThumbnailImage(150, 150, null, IntPtr.Zero);
                ImageConverter ic = new ImageConverter();
                byte[] buffer = (byte[])ic.ConvertTo(thumb, typeof(byte[]));
                var base64="data: Convert.ToBase64String(
                    buffer,
                    Base64FormattingOptions.InsertLineBreaks);*/

                frm.onNotice("<a href=\"special:openjpg:" + jpgpath + "\"><img src=\"" + jpgpath + "\" style='width: 240px'></a><br>" + filename + " (<a href=\"special:open_recv_files_dir\">Open download folder</a>)");
            } else {
                frm.onNotice("Jingle file-transfer: " + fromJid.ToString() + ", " + filename + ", " + status);

            }
        }

        void conn_OnIq(object sender, agsXMPP.protocol.client.IQ iq) {
            //Console.WriteLine("IQ: " + iq.ToString());
            if (iq.Type == agsXMPP.protocol.client.IqType.get) {
                var ping = iq.SelectSingleElement("ping", "urn:xmpp:ping");
                if (ping != null) {
                    var pong = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.result, iq.To, iq.From);
                    pong.Id = iq.Id;
                    jabber.conn.Send(pong);
                }
            }
        }


        private void checkReconnect() {
            if (!String.IsNullOrEmpty(ApplicationPreferences.AccountJID) && !loginError) {
                pnlErrMes.Show(); labErrMes.Text += "\nConnection was closed. Trying to reconnect in 10 sec...";
                tmrReconnect.Stop(); tmrReconnect.Start();
            }
        }

        private void tmrReconnect_Tick(object sender, EventArgs e) {
            tmrReconnect.Stop(); labErrMes.Text = "Connection closed. Trying to reconnect now ...";
            jabberConnect();
        }

        #region Connection error handling
        void conn_OnBindError(object sender, Element e) {
            Console.WriteLine("BIND ERR: " + e.ToString());
            this.Invoke(new ParameterizedThreadStart(showNetworkError),
                "Network error:\n" + e.ToString());
            this.Invoke(new ThreadStart(checkReconnect));
        }
        void conn_OnSocketError(object sender, Exception ex) {
            Console.WriteLine("SOCKET ERR: " + ex.Message);
            this.Invoke(new ParameterizedThreadStart(showNetworkError),
                "Network error:\n" + ex.Message);
            this.Invoke(new ThreadStart(checkReconnect));
        }
        void conn_OnXmppConnectionStateChanged(object sender, XmppConnectionState state) {
            Console.WriteLine("Conn State Changed: " + state.ToString());
            this.Invoke(new ThreadStart(updateWinTitle));
            if (state == XmppConnectionState.Disconnected) {
                this.Invoke(new ThreadStart(checkReconnect));
            }
        }
        void conn_OnError(object sender, Exception ex) {
            //MessageBox.Show("ERROR: " + ex.Message);
            if (loginError) this.Invoke(new ParameterizedThreadStart(showAuthError), "General connection error: \n" + ex.Message);

            Console.WriteLine("conn_OnError:\t" + ex.Message);
            Console.WriteLine(ex.ToString());
            Console.WriteLine("---------");
        }
        void conn_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e) {
            //MessageBox.Show("AUTH ERROR: " + e.ToString());
            string errMes = "Error while logging in to the server: " + e.ToString();
            if (e.HasTag("not-authorized")) {
                errMes = "Incorrect username or password. \n If you don't have an account yet, click on \"New Account\".";

            }
            this.Invoke(new ParameterizedThreadStart(showAuthError), errMes);
            tmrReconnect.Stop();
        }
        #endregion



        void conn_OnMessage(object sender, agsXMPP.protocol.client.Message msg) {
            //Console.WriteLine(msg);
            if (msg.Type == agsXMPP.protocol.client.MessageType.groupchat
                    || (msg.Type == agsXMPP.protocol.client.MessageType.error && rooms.ContainsKey(msg.From.Bare))) {
                this.Invoke(new XmppMessageDelegate(OnMucMessage), msg);
            } else {
                this.Invoke(new XmppMessageDelegate(dmManager.OnPrivateMessage), msg);
            }
        }

        void conn_OnPresence(object sender, agsXMPP.protocol.client.Presence pres) {
            if (pres.HasTag(typeof(agsXMPP.protocol.x.muc.User), true) ||
                (pres.Type == agsXMPP.protocol.client.PresenceType.error && pres.HasTag(typeof(agsXMPP.protocol.x.muc.Muc), true))) {
                //Console.WriteLine(" ... Is MUC Presence: " + pres.From + " ," + pres.To);
                this.Invoke(new XmppPresenceDelegate(OnMucPresence), pres);
            } else if (pres.Type == agsXMPP.protocol.client.PresenceType.error) {

            }

        }

        void conn_OnLogin(object sender) {
            tmrReconnect.Stop();
            jabber.conn.SendMyPresence();

            foreach (var room in rooms.Values) {
                room.online = false;
                if (room.DoJoin != Roomdata.JoinMode.AutoJoin) continue;
                room.jid.Resource = ApplicationPreferences.Nickname;
                jabber.muc.joinRoom(room);
            }
            this.Invoke(new ThreadStart(updateRoomList));
            this.Invoke(new ThreadStart(hideLoginPanel));
            loginError = false;

            jabber.CheckServerFeatures();

            SoundPlayer dingdong3 = new SoundPlayer(Program.appDir + "\\Sounds\\startup.wav");
            if (enableSoundToolStripMenuItem.Enabled) dingdong3.Play();

            //onChatroomSelect();
        }

        private void OnMucSelfPresence(Roomdata room, agsXMPP.protocol.client.Presence pres, agsXMPP.Xml.Dom.Element xChild) {
            room.online = true;
            lbChatrooms.Refresh();
            if (room == currentRoom) txtSendmessage.Enabled = true;
        }

        private void OnMucPresence(agsXMPP.protocol.client.Presence pres) {
            // a presence was received regarding a room we didn't join
            var roomname = pres.From.Bare;
            if (!rooms.ContainsKey(roomname)) {
                //rooms.Add(roomname, new Roomdata(pres.From));
                //this.Invoke(new ThreadStart(updateRoomList));
                //TODO send the right error stanza back
                return;
            }

            var room = rooms[roomname];
            room.errorCondition = (agsXMPP.protocol.client.ErrorCondition)(999);
            if (pres.Type == agsXMPP.protocol.client.PresenceType.error) {
                room.errorCondition = pres.Error.Condition;
                if (currentRoom == room) onChatroomSelect();
                return;
            }

            var xChild = pres.SelectSingleElement("x", "http://jabber.org/protocol/muc#user");
            foreach (agsXMPP.Xml.Dom.Element el in xChild.SelectElements("status")) {
                if (el.GetAttribute("code") == "110") {
                    OnMucSelfPresence(room, pres, xChild);
                    break;
                } else if (el.GetAttribute("code") == "210") {
                    // rename by server
                    room.jid.Resource = pres.From.Resource;
                    break;
                }
            }

            string online = "online";
            if (pres.HasTag("show")) online = pres.GetTag("show");
            if (pres.Type == agsXMPP.protocol.client.PresenceType.unavailable) online = "off";

            string statusStr = "";
            if (pres.HasTag("status")) statusStr = pres.GetTag("status");

            string jid = "";
            if (xChild.HasTag("item")) jid = xChild.SelectSingleElement("item").GetAttribute("jid");

            logs.SetOnlineStatus(pres.From.Bare, pres.From.Resource, online,
                pres.MucUser.Item.Affiliation.ToString(), pres.MucUser.Item.Role.ToString(),
                statusStr, jid);
            if (currentRoom == room) {
                updateMemberList();
            }
        }


        private void OnMucMessage(agsXMPP.protocol.client.Message msg) {
            try {
                Roomdata room = null;
                if (!rooms.TryGetValue(msg.From.Bare, out room)) { //not in room
                    //TODO send error stanza
                    return;
                }

                string dt = JabberService.GetMessageDt(msg);

                if (msg.Type == agsXMPP.protocol.client.MessageType.error) {
                    webBrowser1.addNoticeToView("<b><font color=red>ERROR FROM ROOM " + msg.From + ": <br>" + msg.Error.ToString().Replace("<", "&lt;"));

                    return;
                }

                if (room.handleChatstate(msg))
                    if (currentRoom == room) { updateChatstates(); updateMemberList(); }

                if (msg.HasTag("replace") && msg.HasTag("body")) {
                    Element replace = msg.SelectSingleElement("replace");
                    string replaceId = replace.GetAttribute("id");
                    if (logs.EditMessage(room.RoomName, replaceId, msg.GetAttribute("id"), msg.From.Resource, msg.GetTag("body"), dt)) {
                        room.LastMessageDt = dt; logs.StoreRoom(room);
                        if (webBrowser1.updateMessage(replaceId, msg.GetAttribute("id"), msg.GetTag("body"), DateTime.Parse(dt)))
                            return;
                    }
                }
                if (msg.HasTag("subject")) {
                    string subject = msg.GetTag("subject");
                    //logs.SetSubject(msg.From.Bare, subject);
                    room.Subject = subject; logs.StoreRoom(room);
                    if (currentRoom == room) {
                        webBrowser1.addNoticeToView("The subject was set by " + msg.From.Resource + ": " + subject);
                        txtSubject.Text = subject;
                    }
                } else if (msg.HasTag("body")) {
                    string messageBody = msg.GetTag("body");
                    logs.InsertMessage(msg.From.Bare, msg.GetAttribute("id"), msg.From.Resource, messageBody, dt,
                        "", room.IsAutoToDo(messageBody) ? "1" : "");
                    //logs.SetLastmessageDatetime(msg.From.Bare, dt);
                    room.LastMessageDt = dt; logs.StoreRoom(room);
                    if (currentRoom == room) {
                        string fullJid = logs.GetUserJid(msg.From.Bare, msg.From.Resource);
                        webBrowser1.addMessageToView(msg.From.Resource, messageBody, DateTime.Parse(dt), null, fullJid, msg.Id);
                    }
                    if (currentRoom != room) { room.unreadMsgCount++; lbChatrooms.Refresh(); }
                    bool mention = IsMention(messageBody);
                    bool notify = !msg.HasTag("delay");
                    if (room != null && room.Notify == Roomdata.NotifyMode.Never) notify = false;
                    if (room != null && room.Notify == Roomdata.NotifyMode.OnMention && !mention) notify = false;
                    if (notify) {
                        if (enableSoundToolStripMenuItem.Checked) {
                            string sound = mention ? "popup" : "correct";
                            SoundPlayer dingdong = new SoundPlayer(Program.appDir + "\\Sounds\\" + sound + ".wav");
                            dingdong.Play();
                        }
                        if (!WindowHelper.IsActive(this) || currentRoom != room) {
                            room.unreadNotifyCount++; room.unreadNotifyText = msg.From.Resource + ":" + messageBody;
                            if (enablePopupToolStripMenuItem.Checked) {
                                WindowHelper.ShowWindow(popupWindow.Handle, WindowHelper.SW_SHOWNOACTIVATE); //popupWindow.Show();
                                popupWindow.updateRooms(rooms);
                            }
                            if (enableNotificationsToolStripMenuItem.Checked && !String.IsNullOrEmpty(messageBody)) {
                                if (ApplicationPreferences.WineTricks) {
                                    Console.WriteLine("Displaying notification via notify-send ...");
                                    ProcessStartInfo psi = new ProcessStartInfo();
                                    psi.FileName = "/usr/bin/notify-send";
                                    psi.Arguments = "\"Nachricht von " + msg.From.ToString() + "\" \"" + messageBody + "\"";
                                    Process.Start(psi);
                                } else {
                                    Console.WriteLine("Showing balloon tip: " + msg.From.Resource + " in " + msg.From.User);
                                    balloonRoom = msg.From.Bare;
                                    notifyIcon1.ShowBalloonTip(30000, msg.From.Resource + " in " + msg.From.User + ":", messageBody, ToolTipIcon.Info);
                                }
                            }

                        }
                        if (!WindowHelper.IsActive(this)) tmrBlinky.Start();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void onNotification(agsXMPP.protocol.client.Message msg, Roomdata room) {

        }

        private void ShowXmppDebugForm() {
            if (debugForm == null || debugForm.IsDisposed) debugForm = new XmppDebugForm();
            debugForm.Show();
            debugForm.Activate();
            glob.setPara("showXmppDebugOnStartup", "TRUE");
        }

        private bool IsMention(string text) {
            text = text.ToLower(); string nick = ApplicationPreferences.Nickname.ToLower();
            return text.Contains("@" + nick) || text.Contains(nick + ":");
        }

        private void sendMessage(string text) {
            var msg = new agsXMPP.protocol.client.Message(currentRoom.RoomName, jabber.conn.MyJID, agsXMPP.protocol.client.MessageType.groupchat, text);
            msg.Id = Guid.NewGuid().ToString();
            if (editingMessageId != null) {
                var replace = new Element("replace", null, JabberService.URN_MESSAGE_CORRECT);
                replace.SetAttribute("id", editingMessageId);
                msg.AddChild(replace);
                stopEditingMessage();
            }
            msg.Chatstate = agsXMPP.protocol.extensions.chatstates.Chatstate.active;
            currentRoom.chatstate = agsXMPP.protocol.extensions.chatstates.Chatstate.active;
            if (pbSendImage.Visible) {
                var oob = new agsXMPP.Xml.Dom.Element("x", null, "jabber:x:oob");
                msg.AddChild(oob);
                oob.AddTag("url", (string)pbSendImage.Tag);
            }
            jabber.conn.Send(msg);
        }


        #endregion







        #region GUI


        #region AppInit
        private void Form1_Load(object sender, EventArgs e) {
            onIni(true);
        }

        public void onIni(bool shouldShow) {
            // make sure window is created
            IntPtr handle = this.Handle;

            WinSparkle.win_sparkle_set_appcast_url("http://downloads.luelista.net/miniconf/miniconf.xml");
            //WinSparkle.win_sparkle_set_app_details("Company","App", "Version"); // THIS CALL NOT IMPLEMENTED YET
            WinSparkle.win_sparkle_init();

            logs = new ChatDatabase(Program.dataDir + "chatlogs.db");
            Program.db = logs;

            glob = new cls_globPara(logs); Program.glob = glob;
            if (logs.databaseVersion < 6) glob.legacyImport(Program.dataDir + "miniConf.ini");
            if (logs.databaseVersion < 9) Roomdata.legacyImport();
            // 2015-02-15 ...mediacrush went out of business
            if (ApplicationPreferences.FileUploadServiceUrl == "https://mediacru.sh")
                ApplicationPreferences.FileUploadServiceUrl = "https://chat2.teamwiki.de";

            glob.readFormPos(this);
            glob.readTuttiFrutti(this);
            this.Show(); this.Activate(); this.BringToFront(); Application.DoEvents();

            popupWindow = new UnreadMessageForm();
            popupWindow.OnItemClick += popupWindow_OnItemClick;
            var createTheHandlePlease = popupWindow.Handle;

            enableNotificationsToolStripMenuItem.Checked = glob.para("enableNotifications") == "TRUE";
            enableSoundToolStripMenuItem.Checked = glob.para("enableSound") != "FALSE";
            enablePopupToolStripMenuItem.Checked = glob.para("enablePopup") != "FALSE";

            rooms = Roomdata.MakeDict(logs.GetRooms(false));

            applyPreferences();
            if (ApplicationPreferences.AccountJID == "" || ApplicationPreferences.AccountPassword == "") {
                showPreferences();
            }

            Program.wvl = new TodoForm();
            IntPtr dummy = Program.wvl.Handle;

            DebugTests.PrintDnsServers();
        }
#endregion

        #region Form Events
        public void ShowMe() {
            this.Show(); this.Activate();
            if (WindowState == FormWindowState.Minimized) {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        private void updateWinTitle() {

            this.Text = (ApplicationPreferences.Sternchen ? "*" : "") + Application.ProductName + " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3) +
                (currentRoom != null ? " | " + currentRoom.RoomName : "") + " | " + (jabber.conn != null ? (jabber.conn.XmppConnectionState == XmppConnectionState.SessionStarted ? jabber.conn.MyJID.ToString() : jabber.conn.XmppConnectionState.ToString()) : "NoConnection");
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == WindowHelper.WM_SHOWME) {
                ShowMe();
            }
            if (m.Msg == WindowHelper.WM_ACTIVATEAPP) {
                Console.WriteLine("WM_ACTIVATEAPP " + m.LParam.ToString() + " " + m.WParam.ToString());
                if ((int)m.WParam == 1 && WindowHelper.IsActive(this)) onFormActivated();
            }
            base.WndProc(ref m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            glob.saveFormPos(this);
            glob.saveTuttiFrutti(this);
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                this.Hide();
                if (currentRoom != null) currentRoom.sendChatstate(agsXMPP.protocol.extensions.chatstates.Chatstate.inactive);
            } else {
                if (ApplicationPreferences.RememberPassword == false) {
                    ApplicationPreferences.AccountPassword = "";
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            WinSparkle.win_sparkle_cleanup();
        }

        private void Form1_Shown(object sender, EventArgs e) {
            if (Program.isAutorun) {
                this.Hide();
                Program.isAutorun = false;
            }
        }
        #endregion

        #region Preferences



        private void applyPreferences() {

            //chkSternchen_CheckedChanged
            updateWinTitle();
            //chkDisplayOccupantStatus_CheckedChanged
            lvOnlineStatus.View = (ApplicationPreferences.DisplayOccupantStatus ?
                View.Tile : View.SmallIcon);
            //chkEnableImagePreview_CheckedChanged
            webBrowser1.imagePreview = ApplicationPreferences.EnableImagePreview;
            //comboMessageTheme_SelectedIndexChanged
            Program.glob.setPara("messageView__theme", ApplicationPreferences.ChatTheme);
            webBrowser1.loadStylesheet();
            webBrowser1.loadSmileyTheme();

            if (ApplicationPreferences.AlwaysAskForNickname)
                ApplicationPreferences.Nickname = 
                    UgbDatabaseConnection.InputDlg.InputBoxForced("Choose your Nickname", ApplicationPreferences.Nickname, this);

            if (jabber.conn == null || jabber.conn.XmppConnectionState == XmppConnectionState.Disconnected) {
                if (ApplicationPreferences.AccountJID != "" && ApplicationPreferences.AccountPassword != "") {
                    jabberConnect();
                }
            } else {
                onChatroomSelect();
            }
        }

        #region checkboxes
        private void enableNotificationsToolStripMenuItem_Click(object sender, EventArgs e) {
            glob.setPara("enableNotifications", ((ToolStripMenuItem)sender).Checked ? "TRUE" : "FALSE");
        }

        private void enableSoundToolStripMenuItem_Click(object sender, EventArgs e) {
            glob.setPara("enableSound", ((ToolStripMenuItem)sender).Checked ? "TRUE" : "FALSE");
        }

        private void enablePopupToolStripMenuItem_Click(object sender, EventArgs e) {
            glob.setPara("enablePopup", ((ToolStripMenuItem)sender).Checked ? "TRUE" : "FALSE");
        }

        private void searchForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
            WinSparkle.win_sparkle_check_update_with_ui();
        }

        #endregion
        #endregion

        #region Error handling

        private void hideLoginPanel() {
            /* pnlLoginWrapper.Enabled = true;*/
            UseWaitCursor = false;
            pnlErrMes.Visible = false;
            /*pnlLoginErrMes.Visible = false;
            pnlLoginWrapper.Visible = false;*/
            glob.saveTuttiFrutti(this);
        }

        private void showNetworkError(object errmes) {
            /*pnlLoginWrapper.Enabled = true;*/
            UseWaitCursor = false;
            pnlErrMes.Show();
            labErrMes.Text = (string)errmes;
        }

        private void showAuthError(object errmes) {
            /*pnlLoginWrapper.Enabled = true; UseWaitCursor = false;
            if (errmes != null) {
                pnlLoginErrMes.Show();
                labLoginErrMes.Text = (string)errmes;
            }
            pnlLoginWrapper.Show();
            qq_txtPrefUsername.Text = glob.para("account__JID");
            qq_txtPrefPassword.Text = glob.para("account__Password");
            qq_txtPrefServer.Text = glob.para("account__Server");
            qq_txtPrefServerPort.Text = glob.para("account__Port", "5222");
            pnlPrefConnectAdvanced.Visible = qq_txtPrefServer.Text != "" || qq_txtPrefServerPort.Text != "5222";
            qq_txtPrefUsername.Focus(); qq_txtPrefUsername.SelectAll();*/
            showNetworkError(errmes);
        }


        #endregion
        #region Chatroom list

        private void updateRoomList() {
            lbChatrooms.Items.Clear();
            foreach (Roomdata r in rooms.Values) {
                if (r.DoJoin == Roomdata.JoinMode.AutoJoin || showAllRoomsToolStripMenuItem.Checked)
                    lbChatrooms.Items.Add(r);
            }
            try {
                onChatroomSelect(glob.para("currentRoom"));
                if (currentRoom == null) onChatroomSelect();
            } catch (Exception ex) { }
            lblConferencesEmpty.Visible = lbChatrooms.Items.Count == 0;
        }

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush unreadBrush = new SolidBrush(Color.DarkSlateBlue);

        private void lbChatrooms_DrawItem(object sender, DrawItemEventArgs e) {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index == -1) return;
            Roomdata room = (Roomdata)lbChatrooms.Items[e.Index];
            e.Graphics.DrawString(room.DisplayName, lbChatrooms.Font, 0 != (e.State & DrawItemState.Selected) ? whiteBrush : blackBrush,
                     e.Bounds.Left + 22, e.Bounds.Top + 4);
            if (room.Notify != Roomdata.NotifyMode.Always) {
                e.Graphics.DrawImageUnscaled(conversationImageList.Images["notify" + (Int32)room.Notify], e.Bounds.Width - 20, e.Bounds.Top + 2);
            }
            if (room.unreadMsgCount > 0) {
                e.Graphics.FillRectangle(unreadBrush, e.Bounds.Left + 3, e.Bounds.Top + 2, 19, 16);
                e.Graphics.DrawString((room.unreadMsgCount > 99 ? "..." : room.unreadMsgCount.ToString()), new Font(lbChatrooms.Font, FontStyle.Bold),
                    whiteBrush, e.Bounds.Left + (room.unreadMsgCount > 9 ? 3 : 7), e.Bounds.Top + 3);
            } else {
                string image = room.roomType == Roomdata.RoomType.Multi ? "group" : "user";
                if (!room.online) image = "error";
                if (room.DoJoin == Roomdata.JoinMode.Off) image = "history";
                e.Graphics.DrawImageUnscaled(conversationImageList.Images[image], 4, e.Bounds.Top + 2);
            }
        }

        private void lbChatrooms_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                onChatroomSelect();
            } else {
                int index = lbChatrooms.IndexFromPoint(e.Location);
                if (index == -1) {
                    ctxMenuConversationHeader.Show((Control)sender, e.Location);
                } else {
                    lbChatrooms.SelectedIndex = index;
                    Roomdata selRoom = (Roomdata)lbChatrooms.SelectedItem;
                    closeToolStripMenuItem.Visible = selRoom.DoJoin == Roomdata.JoinMode.AutoJoin || selRoom.online;
                    rejoinToolStripMenuItem.Visible = selRoom.DoJoin != Roomdata.JoinMode.AutoJoin || !selRoom.online;
                    alwaysNotifyToolStripMenuItem.Checked = selRoom.Notify == Roomdata.NotifyMode.Always;
                    notifyOnMentionToolStripMenuItem.Checked = selRoom.Notify == Roomdata.NotifyMode.OnMention;
                    disableNotificationToolStripMenuItem.Checked = selRoom.Notify == Roomdata.NotifyMode.Never;
                    showFullHistoryToolStripMenuItem.Enabled = selRoom.online;
                    ctxMenuConversation.Show((Control)sender, e.Location);
                }
            }
        }

        #region Chatroom LISTBOX/HEADER Context menu

        private void lnkRoomlistContextMenu_Click(object sender, EventArgs e) {
            ctxMenuConversationHeader.Show((Control)sender, 0, 12);
        }

        private void rejoinChatroom(Roomdata myRoom) {
            myRoom.DoJoin = Roomdata.JoinMode.AutoJoin;
            myRoom.jid.Resource = ApplicationPreferences.Nickname;
            jabber.muc.joinRoom(myRoom);
            Program.db.StoreRoom(myRoom);
            updateRoomList();
        }

        public void joinChatroom(string bareJid) {
            if (rooms.ContainsKey(bareJid)) {
                Roomdata myRoom = rooms[bareJid];
                lbChatrooms.SelectedItem = myRoom;
                if (!myRoom.online) {
                    rejoinChatroom(myRoom);
                }

            } else {
                Roomdata newRoom = new Roomdata(bareJid);
                newRoom.DisplayName = newRoom.jid.User;
                newRoom.Notify = Roomdata.NotifyMode.Always;
                rooms.Add(newRoom.jid.Bare, newRoom);
                rejoinChatroom(newRoom);
            }
            onChatroomSelect(bareJid);
        }

        private void joinConversationToolStripMenuItem_Click(object sender, EventArgs e) {
            RoomListForm frm = new RoomListForm();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string bareJid = (string)frm.listView1.SelectedItems[0].Tag;
                if (bareJid.StartsWith("@")) {
                    joinChatroomWithDialog(bareJid); return;
                }
                joinChatroom(bareJid);
            }
        }

        private void rejoinToolStripMenuItem_Click(object sender, EventArgs e) {
            Roomdata selRoom = (Roomdata)lbChatrooms.SelectedItem;
            rejoinChatroom(selRoom);
        }

        private void createNewRoomToolStripMenuItem_Click(object sender, EventArgs e) {
            joinChatroomWithDialog("");
        }

        private void joinChatroomWithDialog(string defValue) {
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Enter jabber id of room to create or join:", "Create / join room", defValue);
            if (!String.IsNullOrEmpty(newName)) {
                joinChatroom(newName);
            }
        }

        private void showAllRoomsToolStripMenuItem_Click(object sender, EventArgs e) {
            updateRoomList();
        }

        #endregion

        #region Chatroom List ITEM Contextmenu
        private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
            Roomdata room = (Roomdata)lbChatrooms.SelectedItem;
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Enter new display name for room \"" + room.jid.Bare + "\":", "Rename", room.DisplayName);
            if (!String.IsNullOrEmpty(newName)) {
                room.DisplayName = newName;
                logs.StoreRoom(room);
                lbChatrooms.Refresh();
            }
        }

        private void changeNickToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void alwaysNotifyToolStripMenuItem_Click(object sender, EventArgs e) {
            Roomdata room = (Roomdata)lbChatrooms.SelectedItem;
            room.Notify = (Roomdata.NotifyMode)Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            logs.StoreRoom(room);
            lbChatrooms.Refresh();
        }

        private void showFullHistoryToolStripMenuItem_Click(object sender, EventArgs e) {
            showLastMessages(1000);
        }

        private void autoToDoToolStripMenuItem_Click(object sender, EventArgs e) {
            Roomdata room = (Roomdata)lbChatrooms.SelectedItem;
            using (var f = new AutoToDoConfig()) {
                f.textBox1.Text = room.AutoToDo;
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    room.AutoToDo = f.textBox1.Text;
                    logs.StoreRoom(room);
                }
            }
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            Roomdata room = (Roomdata)lbChatrooms.SelectedItem;
            room.DoJoin = Roomdata.JoinMode.Off;
            jabber.muc.leaveRoom(room);
            logs.StoreRoom(room);
            clearMessageView();
            updateRoomList();
        }

        #endregion

        #endregion

        #region chatroom details

        private void onChatroomSelect(string gotoRoom = null) {
            tmrChatstatePaused.Stop();
            if (currentRoom != null && currentRoom.online)
                currentRoom.sendChatstate(agsXMPP.protocol.extensions.chatstates.Chatstate.inactive);

            try {
                if (gotoRoom != null) lbChatrooms.SelectedItem = rooms[gotoRoom];
                currentRoom = (Roomdata)lbChatrooms.SelectedItem;
            } catch (Exception ex) {
                currentRoom = null;
                txtSendmessage.Enabled = false;
            }

            updateMemberList();
            histAmount = 0;
            clearMessageView();
            showLastMessages(30);
            if (currentRoom != null) {
                txtSubject.Text = logs.GetSubject(currentRoom.RoomName);
                glob.setPara("currentRoom", currentRoom.RoomName);
                currentRoom.ResetUnread();
                popupWindow.updateRooms(rooms);
                webBrowser1.addNoticeToView("Subject is: " + logs.GetSubject(currentRoom.RoomName));
                if (currentRoom.getErrorMessage() != null)
                    webBrowser1.addNoticeToView("<b><font color=red>" + currentRoom.getErrorMessage() + "</font></b>");
                if (currentRoom.online == false)
                    webBrowser1.addNoticeToView("<b><font color=red>You are offline in this room.</font></b>");
                updateWinTitle();
                updateChatstates();
                if (currentRoom.online)
                    currentRoom.sendChatstate(txtSendmessage.Text == "" ? agsXMPP.protocol.extensions.chatstates.Chatstate.active : agsXMPP.protocol.extensions.chatstates.Chatstate.paused);
                txtSendmessage.Enabled = currentRoom.online;
                txtSendmessage.Focus();
            }
            webBrowser1.scrollDown();
        }


        private void clearMessageView() {
            webBrowser1.clear();
            webBrowser1.Document.GetElementById("tb").InnerHtml = "history: <a href='special:show_more_history'> 10 more</a> | <a href='special:show_more_more_history'> 100 more</a>";
        }
        int histAmount = 0;
        private void showLastMessages(int count) {
            if (currentRoom == null) return;
            var length = logs.GetLogLength(currentRoom.RoomName);
            if (histAmount + count > length) {
                webBrowser1.Document.GetElementById("tb").InnerHtml = "End of local history | <a href='special:load_all'>Try loading server history</a>";
            }
            var msgs = currentRoom.GetLogs(histAmount, count);
            foreach (ChatMessage msg in msgs) {
                webBrowser1.addMessageToView(msg, HtmlElementInsertionOrientation.AfterBegin);
            }
            histAmount += count;
        }

        private void webBrowser1_OnSpecialUrl(string url) {
            switch (url) {
                case "special:show_more_history":
                    showLastMessages(10);
                    webBrowser1.Document.Body.ScrollTop = 0;
                    break;
                case "special:show_more_more_history":
                    showLastMessages(100);
                    //webBrowser1.Document.Body.ScrollTop = 0;
                    break;
                case "special:load_all":
                    if (MessageBox.Show("Loading the server-side history can take several minutes depending on your internet connection. Do you want to start downloading?", "History", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK) {
                        jabber.muc.joinRoom(currentRoom, true);
                    }
                    break;
            }
        }
        #endregion


        #region Sendmessage
        private void txtSendmessage_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !e.Control && !e.Shift && !e.Alt) {
                if (currentRoom == null || String.IsNullOrEmpty(txtSendmessage.Text.Trim())) return;
                sendMessage(txtSendmessage.Text.TrimEnd());
                txtSendmessage.Text = "";
                pbSendImage.Hide();
            }
        }
        private void txtSendmessage_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !e.Control && !e.Shift && !e.Alt) {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.A && e.Control) {
                txtSendmessage.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.V && e.Control) {
                var dobj = Clipboard.GetDataObject();
                Console.WriteLine(string.Join("\n", dobj.GetFormats()));
                if (Clipboard.ContainsImage()) {
                    string uploadfn = Program.dataDir + "Temporary Data\\upload.jpg";
                    if (clipboardImageToFile(uploadfn)) {
                        doMediaUpload(uploadfn);
                    } else {
                        MessageBox.Show("Unable to get image from clipboard.");
                    }
                }
            }
            if (txtSendmessage.Text == "" && e.KeyCode == Keys.Up) {
                string id = webBrowser1.getLastMessageId(currentRoom.jid.Resource);
                editMessage(id);
            }
            //if (e.Control && (e.KeyCode == Keys.A))
            //    e.SuppressKeyPress = true;
        }


        private void txtSendmessage_TextChanged(object sender, EventArgs e) {
            if (currentRoom == null) return;
            var newState = agsXMPP.protocol.extensions.chatstates.Chatstate.active;
            tmrChatstatePaused.Stop();
            if (txtSendmessage.Text != "") {
                newState = agsXMPP.protocol.extensions.chatstates.Chatstate.composing;
                tmrChatstatePaused.Start();
            }
            if (currentRoom.chatstate != newState) {
                currentRoom.sendChatstate(newState);
            }
            if (txtSendmessage.Text == "" && editingMessageId != null) stopEditingMessage();
        }

        private void tmrChatstatePaused_Tick(object sender, EventArgs e) {
            tmrChatstatePaused.Stop();
            if (currentRoom != null) currentRoom.sendChatstate(agsXMPP.protocol.extensions.chatstates.Chatstate.paused);
        }
        #endregion

        #region Media Upload

        private bool clipboardImageToFile(string uploadfn) {
            try {
                Image img = Clipboard.GetImage();
                var dobj = Clipboard.GetDataObject();
                string[] tryFormats = { "PNG", "JFIF", "DeviceIndependentBitmap" };
                int tryIdx = 0;
                while (img == null && tryIdx < tryFormats.Length) {
                    string fmt = tryFormats[tryIdx];
                    tryIdx++;
                    Console.WriteLine("img is null; checking format " + fmt + " ...");
                    if (img == null && dobj.GetDataPresent(fmt)) {
                        Console.WriteLine("getData ...");
                        MemoryStream obj = dobj.GetData(fmt) as MemoryStream;
                        if (obj == null) {
                            Console.WriteLine("NULL!");
                            continue;
                        }
                        using (var fs = new FileStream(uploadfn, FileMode.Create)) {
                            obj.WriteTo(fs);
                        }
                        Console.WriteLine("OK!");
                        return true;
                    }
                }
                if (img == null) return false;
                img.Save(uploadfn);
                return true;
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        private void txtSendmessage_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent("FileDrop")) {
                string[] files = (string[])e.Data.GetData("FileDrop");
                if (files.Length == 1) {
                    var fn = files[0].ToUpper();
                    //if (fn.EndsWith(".JPG") || fn.EndsWith(".PNG") || fn.EndsWith(".GIF") || fn.EndsWith(".TIF")) {
                    e.Effect = DragDropEffects.Copy;
                    //}
                }
            }
        }

        private void txtSendmessage_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData("FileDrop");
            doMediaUpload(files[0]);
        }

        private void doMediaUpload(string filename) {
            FileUploader.ApplicationUrl = ApplicationPreferences.FileUploadServiceUrl;
            var f = new MediaUploadForm(filename);
            f.startUpload();
            var result = f.ShowDialog();
            Console.WriteLine(result);
            Console.WriteLine(f.resultStatus);
            Console.WriteLine(f.jsonResult);

            if (result == System.Windows.Forms.DialogResult.OK) {
                if (f.resultStatus == FileUploader.UploadFileStatus.Success || f.resultStatus == FileUploader.UploadFileStatus.AlreadyUploaded) {

                    var res = Regex.Match(f.jsonResult, "\"hash\":\"([a-zA-Z0-9]+)\"");
                    if (!res.Success) {
                        MessageBox.Show("Could not send image.\n\n(server returned invalid data: " + res.ToString() + ")");
                        return;
                    }
                    string hash = res.Groups[1].Value;

                    string ext = Path.GetExtension(filename).ToLower();
                    string imageUrl = FileUploader.ApplicationUrl + "/" + hash + ext;
                    txtSendmessage.AppendText(imageUrl);

                    try {
                        pbSendImage.Image = MediaUploadForm.SafeImageFromFile(filename);
                        pbSendImage.Tag = imageUrl;
                        pbSendImage.Show();
                    } catch (Exception ex) { }
                } else {
                    MessageBox.Show("Could not send image. \n\n(upload failed with error: " + f.resultStatus.ToString()+")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            f.Close();
        }

        private void btnDeleteSendImage_Click(object sender, EventArgs e) {
            pbSendImage.Hide(); pbSendImage.Image = null; pbSendImage.Tag = null;
        }

        #endregion

        #region Message Editing

        public string editingMessageId = null;

        public void editMessage(string id) {
            if (string.IsNullOrEmpty(id)) return;
            if (editingMessageId != null) stopEditingMessage();
            var message = logs.GetMessageById(currentRoom.RoomName, id);
            if (message == null) return;
            editingMessageId = id;
            webBrowser1.setMessageEditing(id, true);
            txtSendmessage.Text = message["messagebody"];
            txtSendmessage.BackColor = Color.FromArgb(0xFA, 0xFA, 0xA0);

        }

        public void stopEditingMessage() {
            txtSendmessage.BackColor = Color.White;
            txtSendmessage.Text = "";
            webBrowser1.setMessageEditing(editingMessageId, false);
            editingMessageId = null;
        }

        #endregion






        #region Key Events
        private void webBrowser1_OnRealKeyDown(object sender, HtmlElementEventArgs e) {
            OnFormKeydown((Keys)(e.KeyPressedCode
                            | (e.CtrlKeyPressed ? (int)Keys.Control : 0)
                            | (e.ShiftKeyPressed ? (int)Keys.Shift : 0)));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            OnFormKeydown(e.KeyCode
                | (e.Control ? Keys.Control : 0)
                | (e.Shift ? Keys.Shift : 0)
                | (e.Alt ? Keys.Alt : 0));
        }

        private bool OnFormKeydown(Keys keyData) {
            Console.WriteLine("OnFormKeydown ; key=" + keyData);

            switch (keyData) {
                case Keys.Control | Keys.Q:
                    beendenToolStripMenuItem_Click(null, null);
                    return true;
                case Keys.Escape:
                    if (filterBarPanel.Visible) filterBarCloseBtn_Click(null, null);
                    else if (editingMessageId != null) stopEditingMessage();
                    else this.Close();
                    return true;
                case Keys.F1:
                    try { if (lbChatrooms.SelectedIndex > 0) lbChatrooms.SelectedIndex -= 1; onChatroomSelect(); } catch (Exception ex) { }
                    return true;
                case Keys.F2:
                    try { lbChatrooms.SelectedIndex += 1; onChatroomSelect(); } catch (Exception ex) { }
                    return true;
                case Keys.F8:
                    adhocCommandsToolStripMenuItem_Click(null, null);
                    break;
                case Keys.F9:
                    xMPPConsoleToolStripMenuItem_Click(null, null);
                    return true;
                case Keys.Shift | Keys.F9:
                    sqliteConsoleToolStripMenuItem_Click(null, null);
                    return true;
                case Keys.Control | Keys.F9:
                    System.Diagnostics.Process.Start("explorer.exe", "/e,\"" + Program.dataDir + "\"");
                    return true;
                case Keys.Control | Keys.Shift | Keys.U:
                    WinSparkle.win_sparkle_set_appcast_url("http://downloads.luelista.net/miniconf/miniconf-minefield.xml");
                    WinSparkle.win_sparkle_check_update_with_ui();
                    break;
                case Keys.Control | Keys.F:
                    findToolStripMenuItem_Click(null, null);
                    return true;
                case Keys.Control | Keys.B:
                case Keys.F4:
                    chkToggleSidebar.Checked = !chkToggleSidebar.Checked;
                    naviBar1.SetActiveBand(naviBand1);
                    break;
                case Keys.Control | Keys.Oemcomma:
                    showPreferences();
                    break;
                case Keys.Control | Keys.Shift | Keys.R:
                    reloadStylesToolStripMenuItem_Click(null, null);
                    break;
                case Keys.Control | Keys.Shift | Keys.E:
                    editStylesToolStripMenuItem_Click(null, null);
                    break;
            }
            return false;
        }
        #endregion


        #region Participants / Online Status

        private void updateChatstates() {
            if (currentRoom == null) return;
            string typing = currentRoom.getTypingNotice();
            labChatstates.Visible = typing != null;
            labChatstates.Text = "             " + typing;
        }

        private void updateMemberList() {
            bool winetricks = ApplicationPreferences.WineTricks;
            lvOnlineStatus.BeginUpdate();
            lvOnlineStatus.Items.Clear();
            if (currentRoom != null) {
                var onlines = logs.GetMembers(currentRoom.RoomName);
                foreach (System.Data.Common.DbDataRecord k in onlines) {
                    if (showOfflineUsersToolStripMenuItem.Checked == false && k.GetString(2) == "off") continue;
                    string nick = k.GetString(0);
                    if (winetricks && k.GetString(2) == "off") nick = "#" + nick;
                    var item = lvOnlineStatus.Items.Add(nick, k.GetString(2));
                    string statusStr = (k.IsDBNull(5)) ? "" : k.GetString(5);
                    string jid = (k.IsDBNull(6)) ? "" : k.GetString(6);
                    item.ToolTipText = k.GetString(2) + " " + currentRoom.getChatstate(nick) + " - last seen: " + DateTime.FromBinary(k.GetInt64(1)).ToString() + " - affiliation: " + k.GetString(3) + " - role: " + k.GetString(4) + " - jid: " + jid + " - status: " + statusStr;
                    item.SubItems.Add(statusStr);
                    item.ForeColor = currentRoom.getChatstateColor(nick);
                    item.Tag = jid;
                    item.Group = lvOnlineStatus.Groups[k.GetString(2) == "off" ? 1 : 0];
                }
            }
            lvOnlineStatus.EndUpdate();
        }

        private void prefixSendmessageBox(string prefix) {
            txtSendmessage.Text = prefix + txtSendmessage.Text;
            txtSendmessage.Focus();
            txtSendmessage.SelectionLength = 0;
            txtSendmessage.SelectionStart = prefix.Length;
        }
        private void lvOnlineStatus_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                if (lvOnlineStatus.SelectedItems.Count == 0) return;
                hideToolStripMenuItem.Enabled = lvOnlineStatus.SelectedItems[0].ImageKey == "off";
                ctxMenuParticipant.Show((Control)sender, e.X, e.Y);
            }
        }
        private void lvOnlineStatus_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (lvOnlineStatus.SelectedItems.Count == 0) return;
            string prefix = lvOnlineStatus.SelectedItems[0].Text + ": ";
            prefixSendmessageBox(prefix);
        }

        private void mentionToolStripMenuItem_Click(object sender, EventArgs e) {
            string prefix = "" + lvOnlineStatus.SelectedItems[0].Text + ": ";
            prefixSendmessageBox(prefix);
        }

        private void privateMessageToolStripMenuItem_Click(object sender, EventArgs e) {
            string prefix = "/msg \"" + lvOnlineStatus.SelectedItems[0].Text + "\" ";
            prefixSendmessageBox(prefix);
        }

        private void openDirectChatToolStripMenuItem_Click(object sender, EventArgs e) {
            string jid = (string)lvOnlineStatus.SelectedItems[0].Tag;
            if (!String.IsNullOrEmpty(jid)) {
                var frm = dmManager.GetWindow(new Jid(jid));
                frm.Activate(); frm.textBox1.Focus();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e) {
            string ttt = lvOnlineStatus.SelectedItems[0].ToolTipText;
            MessageBox.Show(ttt.Replace(" - ", "\n"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e) {
            logs.RemoveOnlineStatus(currentRoom.RoomName, lvOnlineStatus.SelectedItems[0].Text);
            updateMemberList();
        }

        private void showOfflineUsersToolStripMenuItem_Click(object sender, EventArgs e) {
            updateMemberList();
        }

        #endregion


        #region "Contact list"

        private void updateContactList() {
            lvContacts.BeginUpdate(); lvContacts.Items.Clear();
            foreach (JabberContact contact in jabber.contacts.Values) {
                if (contactsImageList.Images.ContainsKey(contact.jid) == false) {
                    var image = jabber.avatar.GetAvatarIfAvailabe(contact.jid);
                    if (image != null)
                        contactsImageList.Images.Add(contact.jid, Image.FromFile(image));
                    else
                        contactsImageList.Images.Add(contact.jid, JabberContact.getColoredImage(contact.getColor(), 32));
                }
                var lvi = lvContacts.Items.Add(contact.jid, contact.jid);
                if (contact.available) lvi.ForeColor = Color.Green;
                lvi.ToolTipText = "Online clients: " + String.Join(", ", contact.resources.ToArray());
            }
            lvContacts.EndUpdate();
        }

        private void lvContacts_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (lvContacts.SelectedItems.Count == 1) {
                dmManager.GetWindow(lvContacts.SelectedItems[0].Text);
            }
        }

        private void btnContactAdd_Click(object sender, EventArgs e) {
            string jid = Microsoft.VisualBasic.Interaction.InputBox(
                "To add a contact to your contact list, enter their jabber ID:\n\nAdditionally, a subscription request will be sent so you can see their online status, and your contact will be able to see your online status, too.",
                "Add contact", "@" + jabber.conn.MyJID.Server);
            if (String.IsNullOrEmpty(jid) || jid.StartsWith("@")) return;
            try {
                jabber.addContact(new Jid(jid));
            } catch (Exception exc) {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnContactRemove_Click(object sender, EventArgs e) {
            if (lvContacts.SelectedItems.Count != 1) return;
            var item = lvContacts.SelectedItems[0];
            if (DialogResult.Yes != MessageBox.Show("Are you sure you want to remove " + item.Text + " from your contact list?", currentRoom.jid.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)) {
                return;
            }
            jabber.removeContact(new Jid(item.Text));
        }

        private void btnContactInvite_Click(object sender, EventArgs e) {
            if (currentRoom == null) return;
            if (lvContacts.SelectedItems.Count != 1) {
                MessageBox.Show("Please select a contact to invite", currentRoom.jid, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            var item = lvContacts.SelectedItems[0];
            if (DialogResult.Yes != MessageBox.Show("Do you want to invite " + item.Text + " to the active conference?", currentRoom.jid.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)) {
                return;
            }
            Jid recipient = new Jid(item.Text);
            var msg = new agsXMPP.protocol.client.Message(currentRoom.jid, jabber.conn.MyJID);
            var x = new agsXMPP.protocol.x.muc.User();
            string reason = "Invitation to join this conference";
            x.Invite = new agsXMPP.protocol.x.muc.Invite(recipient, reason);
            msg.ChildNodes.Add(x);
            jabber.conn.Send(msg);
        }
        #endregion




        #region Notifications
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e) {
            ShowMe(); lbChatrooms.SelectedItem = balloonRoom; onChatroomSelect();
        }

        private void Form1_Activated(object sender, EventArgs e) {
            //FIXME falsches event - Activated feuert nur wenn vorher eine andere form der gleichen anwendung aktiv war
            onFormActivated();
        }

        private void onFormActivated() {
            if (currentRoom != null) {
                currentRoom.ResetUnread();
                popupWindow.updateRooms(rooms);
                if (currentRoom != null) currentRoom.sendChatstate(txtSendmessage.Text == "" ? agsXMPP.protocol.extensions.chatstates.Chatstate.active : agsXMPP.protocol.extensions.chatstates.Chatstate.paused);
            }
            stopBlinky();
        }

        void popupWindow_OnItemClick(object sender, MouseEventArgs e, string chatroom) {
            ShowMe(); onChatroomSelect(chatroom);
        }

        private void tmrBlinky_Tick(object sender, EventArgs e) {
            notifyIcon1.Icon = (DateTime.Now.Second % 2 == 0) ? icon1 : icon2;
            this.Icon = notifyIcon1.Icon;
        }
        private void stopBlinky() {
            tmrBlinky.Stop(); notifyIcon1.Icon = icon1; this.Icon = icon1;
        }
        #endregion


        #region FilterBar
        private void filterBarCloseBtn_Click(object sender, EventArgs e) {
            filterBarPanel.Hide();
            clearMessageView();
            histAmount = 0;
            showLastMessages(30);
            webBrowser1.highlightString = "";
        }
        private void filterTextbox_KeyDown(object sender, KeyEventArgs e) {
            webBrowser1.highlightString = filterTextbox.Text;
            if (e.KeyCode == Keys.Enter) {
                var messages = this.currentRoom.GetFilteredLogs(filterTextbox.Text, 0, 250);
                clearMessageView();
                webBrowser1.Document.GetElementById("tb").InnerHtml = "Search results, press ESC to quit filter mode";

                foreach (ChatMessage msg in messages) {
                    webBrowser1.addMessageToView(msg, HtmlElementInsertionOrientation.AfterBegin);
                }
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.F) {
                clearMessageView();
                histAmount = 0;
                showLastMessages(100);
            }
        }
        private void filterTextbox_TextChanged(object sender, EventArgs e) {

        }

        #endregion

        #region Navigation Band Resizer
        private void resizeSidebar() {
            /*if (naviGroup2.Expanded) naviGroup1.ExpandedHeight = 180;
            else naviGroup1.ExpandedHeight = naviBand1.Height - 25;

            if (naviGroup1.Expanded) naviGroup1.Height = naviGroup1.ExpandedHeight;

            naviGroup2.ExpandedHeight = Math.Max(100, naviBand1.Height - naviGroup1.Height);

            if (naviGroup2.Expanded) naviGroup2.Height = naviGroup2.ExpandedHeight;
            */
        }

        private void naviGroup2_MouseDown(object sender, MouseEventArgs e) {

        }

        private void Form1_Resize(object sender, EventArgs e) {
            resizeSidebar();
        }

        private void naviGroup1_HeaderMouseClick(object sender, MouseEventArgs e) {
            resizeSidebar();
        }

        private void naviBar1_SizeChanged(object sender, EventArgs e) {
            if (naviBar1.Collapsed) naviBar1.Hide();
        }

        private void naviBand3_Click(object sender, EventArgs e) {

        }

        #endregion

        #region Tools Menu
        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Send media file...";
                ofd.Filter = "Supported media files|*.jpg;*.png;*.gif;*.tif;*.tiff;*.jpeg;*.bmp;*.mp4;*.mpg;*.wav;*.mp3;*.ogg;*.svg;*.ogv;*.webm|All files|*.*";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    doMediaUpload(ofd.FileName);
                }
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e) {
            filterBarPanel.Show();
            filterTextbox.Focus(); filterTextbox.SelectAll();
        }

        private void xMPPConsoleToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowXmppDebugForm();
        }

        private void sqliteConsoleToolStripMenuItem_Click(object sender, EventArgs e) {
            var dbg = new DatabaseDebugForm(); dbg.database = logs; dbg.Show();
        }

        private void editStylesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!File.Exists(Program.dataDir + "style.txt")) {
                File.Copy(Program.appDir + "style-tpl.txt", Program.dataDir + "style.txt");
            }
            System.Diagnostics.Process.Start(Program.dataDir + "style.txt");
        }

        private void reloadStylesToolStripMenuItem_Click(object sender, EventArgs e) {
            webBrowser1.loadStylesheet();
        }

        private void adhocCommandsToolStripMenuItem_Click(object sender, EventArgs e) {
            AdhocCommandForm frm = new AdhocCommandForm();
            frm.Show();
            frm.loadCommandList();
        }
        #endregion

        #region MainMenu
        private void openMiniConfToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowMe();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) {
            openMiniConfToolStripMenuItem.Visible = true;
            sendFileToolStripMenuItem.Visible = false;
            extrasToolStripMenuItem.Visible = false;
            findToolStripMenuItem.Visible = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                openMiniConfToolStripMenuItem_Click(null, null);
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            openMiniConfToolStripMenuItem.Visible = false;
            sendFileToolStripMenuItem.Visible = true;
            extrasToolStripMenuItem.Visible = true;
            findToolStripMenuItem.Visible = true;
            contextMenuStrip1.Show((Control)sender, 0, ((Control)sender).Height);
        }


        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            showPreferences();
        }

        void showPreferences() {
            ConfigForm cfg = new ConfigForm();
            if (cfg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                applyPreferences();
        }

        private void reconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            jabberConnect();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to exit miniConf?", "miniConf", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes) {
                Application.Exit();
            }
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://home.luelista.net/programme/miniconf/hilfe/");
        }

        private void btnCancelReconnect_Click(object sender, EventArgs e) {
            tmrReconnect.Stop(); pnlErrMes.Hide();
            preferencesToolStripMenuItem_Click(null, null);
        }

        private void chkToggleSidebar_CheckedChanged(object sender, EventArgs e) {
            naviBar1.Visible = !chkToggleSidebar.Checked;
            chkToggleSidebar.Text = chkToggleSidebar.Checked ? ">" : "<";
            //chkToggleSidebar.Left = chkToggleSidebar.Checked ? 5 : 107;
            //button4.Left = chkToggleSidebar.Checked ? 30 : 5;
            //labChatstates.Left = button4.Bounds.Right + 3;
            //txtSubject.Left = button4.Bounds.Right + 6;
            //labChatstates.Width = pnlToolbar.Width - labChatstates.Left - 80;
            //txtSubject.Width = pnlToolbar.Width - txtSubject.Left - 85;
            //chkToggleSidebar.Text = splitContainer1.Panel2Collapsed ? "<" : ">";
        }



        #endregion

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {

        }

        private void webBrowser1_QuoteMessage(object sender, EventArgs e) {
            string str = (string)sender;
            txtSendmessage.AppendText(str + "\n");
        }


        #endregion

        

    }
}
