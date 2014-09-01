using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using agsXMPP;
using System.Data.SQLite;
using System.Threading;
using System.Text.RegularExpressions;
using System.Media;
using System.IO;

namespace miniConf {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            popupWindow.OnItemClick += popupWindow_OnItemClick;
            icon1 = this.Icon; icon2 = Icon.FromHandle(new Bitmap(imageList1.Images[2]).GetHicon());
        }

        Boolean loginError = true;
        string balloonRoom = null;
        UnreadMessageForm popupWindow = new UnreadMessageForm();
        Dictionary<string, DirectMessageForm> dmSessions = new Dictionary<string, DirectMessageForm>();
        HashSet<string> onlineContacts = new HashSet<string>();

        Icon icon1;
        Icon icon2;


        #region Jabber Connection

        agsXMPP.protocol.x.muc.MucManager muc;
        cls_globPara glob;
        Chatlogs logs;
        Dictionary<string, Roomdata> rooms = new Dictionary<string, Roomdata>();
        Roomdata currentRoom = null;

        private delegate void XmppMessageDelegate(agsXMPP.protocol.client.Message msg);
        private delegate void XmppPresenceDelegate(agsXMPP.protocol.client.Presence msg);

        private void jabberConnect() {
            if (Program.conn == null) {
                Program.conn = new XmppClientConnection();
                Program.conn.OnAuthError += conn_OnAuthError;
                Program.conn.OnXmppConnectionStateChanged += conn_OnXmppConnectionStateChanged;
                Program.conn.OnSocketError += conn_OnSocketError;
                Program.conn.OnError += conn_OnError;
                Program.conn.OnLogin += conn_OnLogin;
                Program.conn.OnIq += conn_OnIq;
                muc = new agsXMPP.protocol.x.muc.MucManager(Program.conn);

                Program.conn.OnPresence += conn_OnPresence;
                Program.conn.OnMessage += conn_OnMessage;
            } else {
                Program.conn.Close(); Application.DoEvents();
                System.Threading.Thread.Sleep(400); Application.DoEvents();
            }

            if (String.IsNullOrEmpty(txtNickname.Text)) txtNickname.Text = txtPrefUsername.Text;

            Program.conn.Server = txtPrefServer.Text;
            Program.conn.Port = 5222;
            Program.conn.Open(txtPrefUsername.Text, txtPrefPassword.Text, "miniConf-" + Environment.MachineName, 0);

        }

        void conn_OnIq(object sender, agsXMPP.protocol.client.IQ iq) {
            Console.WriteLine("IQ: " + iq.ToString());
            if (iq.Type == agsXMPP.protocol.client.IqType.get) {
                var ping = iq.SelectSingleElement("ping", "urn:xmpp:ping");
                if (ping != null) {
                    var pong = new agsXMPP.protocol.client.IQ(agsXMPP.protocol.client.IqType.result, iq.To, iq.From);
                    pong.Id = iq.Id;
                    Program.conn.Send(pong);
                }
            }
        }

        void conn_OnSocketError(object sender, Exception ex) {
            //MessageBox.Show("SOCKET ERR: " + ex.Message);
            this.Invoke(new ParameterizedThreadStart(showConfigPanel),
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

        private void checkReconnect() {
            if (!String.IsNullOrEmpty(txtPrefUsername.Text) && !loginError) {
                pnlErrMes.Show(); labErrMes.Text += "\nConnection closed. Trying to reconnect in 5 sec...";
                tmrReconnect.Stop(); tmrReconnect.Start();
            }
        }

        private void tmrReconnect_Tick(object sender, EventArgs e) {
            tmrReconnect.Stop(); labErrMes.Text = "\nConnection closed. Trying to reconnect ...";
            jabberConnect();
        }

        void conn_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e) {
            //MessageBox.Show("AUTH ERROR: " + e.ToString());
            string errMes = "Error while logging in to the server: " + e.ToString();
            if (e.HasTag("not-authorized")) {
                errMes = "The provided username and password were not accepted by the server. Did you mistype your password? Otherwise, you could create a new acocunt by clicking \"Create Account\".";

            }
            this.Invoke(new ParameterizedThreadStart(showConfigPanel), errMes);
            tmrReconnect.Stop();
        }

        void conn_OnMessage(object sender, agsXMPP.protocol.client.Message msg) {
            Console.WriteLine(msg);
            if (msg.HasAttribute("type") && msg.GetAttribute("type") == "groupchat") {
                this.Invoke(new XmppMessageDelegate(OnMucMessage), msg);
            } else {
                this.Invoke(new XmppMessageDelegate(OnPrivateMessage), msg);
            }
        }

        void conn_OnPresence(object sender, agsXMPP.protocol.client.Presence pres) {
            //Console.WriteLine(pres);

            if (pres.HasTag(typeof(agsXMPP.protocol.x.muc.User), true)) {
                //Console.WriteLine(" ... Is MUC Presence: " + pres.From + " ," + pres.To);
                this.Invoke(new XmppPresenceDelegate(OnMucPresence), pres);
            }
        }

        void conn_OnLogin(object sender) {
            tmrReconnect.Stop();
            var rooms = txtChatrooms.Text.Split('\n');
            foreach (var room in rooms) {
                if (String.IsNullOrEmpty(room) || room.Trim() == "" || room.StartsWith("//") || room.StartsWith("-- ")) continue;
                joinRoom(room.Trim());
            }
            this.Invoke(new ThreadStart(hideConfigPanel));
            loginError = false;
        }

        private void OnMucPresence(agsXMPP.protocol.client.Presence pres) {
            var xChild = pres.SelectSingleElement("x", "http://jabber.org/protocol/muc#user");
            foreach (agsXMPP.Xml.Dom.Element el in xChild.SelectElements("status")) {
                if (el.GetAttribute("code") == "110") {
                    OnMucSelfPresence(pres, xChild);
                    break;
                }
            }

            // this is especially relevant for self presence stanzas... but irc.hackint.org
            // doesn't mark self presences as such, so i moved it here
            var roomname = pres.From.Bare;
            if (!rooms.ContainsKey(roomname)) {
                rooms.Add(roomname, new Roomdata(pres.From));
                this.Invoke(new ThreadStart(updateRoomList));
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
            if (currentRoom != null && pres.From.Bare == currentRoom.jid.Bare) {
                updateMemberList();
            }
        }
        private void OnMucSelfPresence(agsXMPP.protocol.client.Presence pres, agsXMPP.Xml.Dom.Element xChild) {
        }

        private void OnMucMessage(agsXMPP.protocol.client.Message msg) {
            string dt;
            if (msg.HasTag("delay")) {
                dt = msg.SelectSingleElement("delay").GetAttribute("stamp");
            } else {
                dt = Chatlogs.GetNowString();
            }
            if (msg.HasTag("subject")) {
                string subject = msg.GetTag("subject");
                logs.SetSubject(msg.From.Bare, subject);
                if (currentRoom != null && msg.From.Bare == currentRoom.jid.Bare) {
                    webBrowser1.addNoticeToView("The subject was set by " + msg.From.Resource + ": " + subject);
                    txtSubject.Text = subject;
                }
            } else if (msg.HasTag("body")) {
                string messageBody = msg.GetTag("body");
                logs.InsertMessage(msg.From.Bare, msg.GetAttribute("id"), msg.From.Resource, messageBody, dt);
                logs.SetLastmessageDatetime(msg.From.Bare, dt);
                if (currentRoom != null && msg.From.Bare == currentRoom.jid.Bare) {
                    webBrowser1.addMessageToView(msg.From.Resource, messageBody, DateTime.Parse(dt));
                }
                if (!msg.HasTag("delay") && (glob.para("notifications__" + msg.From.Bare) != "FALSE" || IsMention(messageBody))) {
                    if (enableSoundToolStripMenuItem.Checked) {
                        SoundPlayer dingdong = new SoundPlayer("C:\\Windows\\Media\\chimes.wav");
                        dingdong.Play();
                    }
                    if (!WindowHelper.IsActive(this) || currentRoom == null || currentRoom.roomName() != msg.From.Bare) {
                        if (rooms.ContainsKey(msg.From.Bare)) rooms[msg.From.Bare].unreadMsgCount++;
                        if (enablePopupToolStripMenuItem.Checked) {
                            popupWindow.Show(); popupWindow.Activate(); popupWindow.updateRooms(rooms);
                        }
                        if (enableNotificationsToolStripMenuItem.Checked && !String.IsNullOrEmpty(messageBody)) {
                            balloonRoom = msg.From.Bare;
                            notifyIcon1.ShowBalloonTip(30000, msg.From.Resource + " in " + msg.From.User + ":", messageBody, ToolTipIcon.Info);
                        }

                    }
                    if (!WindowHelper.IsActive(this)) tmrBlinky.Start();
                }
            }
        }

        private DirectMessageForm MakeDmForm(Jid from) {
            DirectMessageForm dmfrm;
            if (dmSessions.ContainsKey(from.Bare)) {
                dmfrm = dmSessions[from.Bare];
            } else {
                dmfrm = new DirectMessageForm();
                dmSessions[from.Bare] = dmfrm;
                dmfrm.Text = from; dmfrm.otherEnd = from;
                dmfrm.Show(); dmfrm.Activate();
                dmfrm.FormClosed += dmfrm_FormClosed;
            }
            return dmfrm;
        }
        
        private void OnPrivateMessage(agsXMPP.protocol.client.Message msg) {
            if (msg.HasTag("body")) {
                DirectMessageForm dmfrm = MakeDmForm(msg.From);
                dmfrm.onMessage(msg); dmfrm.Show(); dmfrm.Activate();
            }
        }

        void dmfrm_FormClosed(object sender, FormClosedEventArgs e) {
            dmSessions.Remove(((DirectMessageForm)sender).otherEnd.Bare);
        }

        private bool IsMention(string text) {
            text = text.ToLower(); string nick = txtNickname.Text.ToLower();
            return text.Contains("@" + nick) || text.Contains(nick+":");
        }

        private void joinRoom(string roomName, bool loadAllHistory = false) {
            Jid roomJid = new Jid(roomName);
            if (String.IsNullOrEmpty(roomJid.Resource)) roomJid.Resource = txtNickname.Text;

            logs.SetOnlineStatus(roomJid.Bare, "off");

            /// Setup Room
            agsXMPP.protocol.client.Presence MUCpresence = new agsXMPP.protocol.client.Presence();
            //MUCpresence.From = Program.conn.MyJID;
            MUCpresence.To = roomJid;

            var xMuc = new agsXMPP.protocol.x.muc.Muc();
            MUCpresence.AddChild(xMuc);

            if (glob.para("notifications__" + roomJid.Bare) == "FALSE") xMuc.SetTag("show", "away");

            agsXMPP.protocol.x.muc.History historyChild = new agsXMPP.protocol.x.muc.History(100);
            try {
                string since = logs.GetLastmessageDatetime(roomJid.Bare);
                if (!String.IsNullOrEmpty(since)) {
                    historyChild.RemoveAttribute("maxstanzas");
                    historyChild.SetAttribute("since", since);
                    //addNoticeToView("Requesting since " + since);
                }
            } catch (Exception e) {
            }

            if (loadAllHistory)
                historyChild = new agsXMPP.protocol.x.muc.History(10000);

            xMuc.AddChild(historyChild);

            //MUCpresence.SetAttribute("type", "groupchat");

            Console.WriteLine("-> " + MUCpresence.ToString());
            Program.conn.Send(MUCpresence);

        }

        private void sendMessage(string text) {
            var msg = new agsXMPP.protocol.client.Message(currentRoom.roomName(), Program.conn.MyJID, agsXMPP.protocol.client.MessageType.groupchat, text);
            msg.Id = Guid.NewGuid().ToString();

            Program.conn.Send(msg);
        }

        void conn_OnError(object sender, Exception ex) {
            //MessageBox.Show("ERROR: " + ex.Message);
            Console.WriteLine("conn_OnError:" + ex.Message);
        }


        #endregion







        #region GUI

        private void Form1_Load(object sender, EventArgs e) {
            WinSparkle.win_sparkle_set_appcast_url("http://downloads.luelista.net/miniconf/miniconf.xml");
            //WinSparkle.win_sparkle_set_app_details("Company","App", "Version"); // THIS CALL NOT IMPLEMENTED YET
            WinSparkle.win_sparkle_init();

            glob = new cls_globPara(Program.dataDir + "miniConf.ini");
            glob.readFormPos(this);
            glob.readTuttiFrutti(this);

            enableNotificationsToolStripMenuItem.Checked = glob.para("enableNotifications") != "FALSE";
            enableSoundToolStripMenuItem.Checked = glob.para("enableSound") != "FALSE";
            enablePopupToolStripMenuItem.Checked = glob.para("enablePopup") == "TRUE";

            logs = new Chatlogs(Program.dataDir + "chatlogs.db");

            if (txtPrefUsername.Text != "") {
                jabberConnect();
            } else {
                pnlConfig.Visible = true;
            }
        }


        private void updateWinTitle() {

            this.Text = (chkSternchen.Checked ? "*" : "") + Application.ProductName + " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2) +
                (currentRoom != null ? " | " + currentRoom.roomName() : "") + " | " + (Program.conn != null ? (Program.conn.XmppConnectionState == XmppConnectionState.SessionStarted ? Program.conn.MyJID.ToString() : Program.conn.XmppConnectionState.ToString()) : "NoConnection");
        }

        private void button1_Click(object sender, EventArgs e) {
            pnlConfig.Visible = !pnlConfig.Visible;
        }

        private void button2_Click(object sender, EventArgs e) {
            loginError = true;
            jabberConnect();

            pnlConfig.Visible = false;
        }
        private void hideConfigPanel() {
            pnlConfig.Visible = false;
            pnlErrMes.Visible = false;
        }
        private void showConfigPanel(object errmes) {
            pnlConfig.Visible = true;
            if (!String.IsNullOrEmpty((string)errmes)) {
                pnlErrMes.Show();
                labErrMes.Text = (string)errmes;
            }
        }


        #region Form Events
        protected override void WndProc(ref Message m) {
            if (m.Msg == WindowHelper.WM_SHOWME) {
                ShowMe();
            }
            base.WndProc(ref m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            glob.saveFormPos(this);
            glob.saveTuttiFrutti(this);
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                this.Hide();
            }
        }
        #endregion


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


        private void updateRoomList() {
            lbChatrooms.Items.Clear();
            foreach (var r in rooms) {
                lbChatrooms.Items.Add(r.Key);
                if (glob.para("notifications__" + r.Key, "TRUE") == "TRUE") lbChatrooms.SetItemChecked(lbChatrooms.Items.Count - 1, true);
            }
            try {
                lbChatrooms.SelectedItem = glob.para("currentRoom");
                if (currentRoom == null) lbChatrooms_Click(null, null);
            } catch (Exception ex) { }
        }

        private void lbChatrooms_ItemCheck(object sender, ItemCheckEventArgs e) {
            glob.setPara("notifications__" + lbChatrooms.Items[e.Index], (e.NewValue == CheckState.Checked) ? "TRUE" : "FALSE");
        }

        private void lbChatrooms_Click(object sender, EventArgs e) {
            try {
                currentRoom = rooms[(string)lbChatrooms.SelectedItem];
            } catch (Exception ex) {
                currentRoom = null;
            }

            updateMemberList();
            histAmount = 0;
            clearMessageView();
            showLastMessages(30);
            if (currentRoom != null) {
                txtSubject.Text = logs.GetSubject(currentRoom.roomName());
                glob.setPara("currentRoom", currentRoom.roomName());
                currentRoom.unreadMsgCount = 0;
                popupWindow.updateRooms(rooms);
                webBrowser1.addNoticeToView("Subject is: " + logs.GetSubject(currentRoom.roomName()));
                updateWinTitle();
            }
            webBrowser1.scrollDown();
        }

        private void updateMemberList() {
            lvOnlineStatus.Items.Clear();
            if (currentRoom == null) return;
            var onlines = logs.GetMembers(currentRoom.roomName());
            foreach (System.Data.Common.DbDataRecord k in onlines) {
                string nick = k.GetString(0);
                var item = lvOnlineStatus.Items.Add(nick, k.GetString(2));
                string statusStr = (k.IsDBNull(5)) ? "" : k.GetString(5);
                string jid = (k.IsDBNull(6)) ? "" : k.GetString(6);
                item.ToolTipText = k.GetString(2) + " - last seen: " + DateTime.FromBinary(k.GetInt64(1)).ToString() + " - affiliation: " + k.GetString(3) + " - role: " + k.GetString(4) + " - jid: " + jid + " - status: " + statusStr;
                item.SubItems.Add(statusStr);
                item.Tag = jid;
                item.Group = lvOnlineStatus.Groups[k.GetString(2) == "off" ? 1 : 0];
            }
        }
        private void clearMessageView() {
            webBrowser1.Document.GetElementById("m").InnerHtml = "";
            webBrowser1.Document.GetElementById("tb").InnerHtml = "history: <a href='special:show_more_history'> 25 more</a> | <a href='special:show_more_more_history'> 100 more</a>";

        }
        int histAmount = 0;
        private void showLastMessages(int count) {
            if (currentRoom == null) return;
            var length = logs.GetLogLength(currentRoom.roomName());
            if (histAmount + count > length) {
                webBrowser1.Document.GetElementById("tb").InnerHtml = "End of local history | <a href='special:load_all'>Try loading server history</a>";
            }
            var msgs = logs.GetLogs(currentRoom.roomName(), histAmount, count);
            foreach (System.Data.Common.DbDataRecord k in msgs) {
                webBrowser1.addMessageToView(k.GetString(0), k.GetString(1), DateTime.Parse(k.GetString(2)), HtmlElementInsertionOrientation.AfterBegin);
            }
            histAmount += count;
        }


        private void txtSendmessage_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !e.Control && !e.Shift && !e.Alt) {

                if (String.IsNullOrEmpty(txtSendmessage.Text.Trim())) return;
                sendMessage(txtSendmessage.Text.TrimEnd());
                txtSendmessage.Text = "";
            }
        }
        private void txtSendmessage_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !e.Control && !e.Shift && !e.Alt) {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.A && e.Control) {
                txtSendmessage.SelectAll();
            }
            if (e.Control) e.SuppressKeyPress = true;
        }


        private void chkToggleSidebar_CheckedChanged(object sender, EventArgs e) {
            splitContainer1.Panel2Collapsed = chkToggleSidebar.Checked;
            //chkToggleSidebar.Text = splitContainer1.Panel2Collapsed ? "<" : ">";
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            WinSparkle.win_sparkle_cleanup();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to exit miniConf?", "miniConf", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void webBrowser1_OnSpecialUrl(string url) {
            switch (url) {
                case "special:show_more_history":
                    showLastMessages(30);
                    //webBrowser1.Document.Body.ScrollTop = 0;
                    break;
                case "special:show_more_more_history":
                    showLastMessages(100);
                    //webBrowser1.Document.Body.ScrollTop = 0;
                    break;
                case "special:load_all":
                    if (MessageBox.Show("Loading the server-side history can take several minutes depending on your internet connection. Do you want to start downloading?", "History", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK) {
                        joinRoom(currentRoom.jid.ToString(), true);
                    }
                    break;
            }
        }

        private void webBrowser1_OnRealKeyDown(object sender, HtmlElementEventArgs e) {
            OnFormKeydown((Keys)(e.KeyPressedCode
                            | (e.CtrlKeyPressed ? (int)Keys.Control : 0)
                            | (e.ShiftKeyPressed ? (int)Keys.Shift : 0)));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            OnFormKeydown(e.KeyCode | (e.Control ? Keys.Control : 0) | (e.Shift ? Keys.Shift : 0));
        }

        private bool OnFormKeydown(Keys keyData) {
            Console.WriteLine("OnFormKeydown ; key=" + keyData);
            
            switch (keyData) {
                case Keys.Control | Keys.Q:
                    beendenToolStripMenuItem_Click(null, null);
                    return true;
                case Keys.Escape:
                    if (filterBarPanel.Visible) filterBarCloseBtn_Click(null, null);
                    else this.Close();
                    return true;
                case Keys.F1:
                    try { if (lbChatrooms.SelectedIndex > 0) lbChatrooms.SelectedIndex -= 1; lbChatrooms_Click(null, null); } catch (Exception ex) { }
                    return true;
                case Keys.F2:
                    try { lbChatrooms.SelectedIndex += 1; lbChatrooms_Click(null, null); } catch (Exception ex) { }
                    return true;
                case Keys.Control | Keys.F:
                    filterBarPanel.Show();
                    filterTextbox.Focus(); filterTextbox.SelectAll();
                    return true;
                case Keys.Control | Keys.B:
                case Keys.F4:
                    chkToggleSidebar.Checked = !chkToggleSidebar.Checked;
                    break;
                case Keys.Control | Keys.Oemcomma:
                    pnlConfig.Visible = !pnlConfig.Visible;
                    break;
                case Keys.Control | Keys.Shift | Keys.R:
                    webBrowser1.loadStylesheet(Program.appDir, Program.dataDir);
                    break;
                case Keys.Control | Keys.Shift | Keys.E:
                    if (!File.Exists(Program.dataDir + "style.txt")) {
                        File.Copy(Program.appDir + "style.txt", Program.dataDir + "style.txt");
                    }
                    System.Diagnostics.Process.Start(Program.dataDir + "style.txt");
                    break;
            }
            return false;
        }


        private void openMiniConfToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowMe();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) {
            openMiniConfToolStripMenuItem.Visible = true;
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                openMiniConfToolStripMenuItem_Click(null, null);
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            openMiniConfToolStripMenuItem.Visible = false;
            contextMenuStrip1.Show((Control)sender, 0, ((Control)sender).Height);
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
                if (e.X < 16) {
                    string jid = (string)lvOnlineStatus.SelectedItems[0].Tag;
                    if (!String.IsNullOrEmpty(jid)) {
                        var frm = MakeDmForm(new Jid(jid));
                        frm.Activate(); frm.textBox1.Focus();
                    }
                } else {
                    string prefix = "/msg \"" + lvOnlineStatus.SelectedItems[0].Text + "\" ";
                    prefixSendmessageBox(prefix);
                }
            }
        }
        private void lvOnlineStatus_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (lvOnlineStatus.SelectedItems.Count == 0) return;
            string prefix = lvOnlineStatus.SelectedItems[0].Text + ": ";
            prefixSendmessageBox(prefix);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://home.luelista.net/programme/miniconf/hilfe/");
        }

        private void btnCancelReconnect_Click(object sender, EventArgs e) {
            tmrReconnect.Stop(); pnlErrMes.Hide();
        }

        #region Preferences

        private void btnRegister_Click(object sender, EventArgs e) {
            var cn = new agsXMPP.XmppClientConnection(txtPrefServer.Text);
            cn.RegisterAccount = true;

            cn.OnLogin += (object sender2) => {
                MessageBox.Show("Your account is registered now.", "Create Jabber account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            };
            cn.OnAuthError += (object sender2, agsXMPP.Xml.Dom.Element e2) => {
                MessageBox.Show("Error while registering acocunt: " + e2.ToString(), "Create Jabber account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            cn.OnError += (object sender2, Exception e2) => {
                MessageBox.Show("Error while registering acocunt: " + e2.ToString(), "Create Jabber account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            cn.OnSocketError += (object sender2, Exception e2) => {
                MessageBox.Show("Error while registering acocunt: " + e2.ToString(), "Create Jabber account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            cn.Open(txtPrefUsername.Text, txtPrefPassword.Text);

        }

        private void chkSternchen_CheckedChanged(object sender, EventArgs e) {
            updateWinTitle();
        }

        private void chkDisplayOccupantStatus_CheckedChanged(object sender, EventArgs e) {
            lvOnlineStatus.View = (chkDisplayOccupantStatus.Checked ?
                View.Tile : View.SmallIcon);
        }

        private void chkEnableImagePreview_CheckedChanged(object sender, EventArgs e) {
            webBrowser1.imagePreview = chkEnableImagePreview.Checked;
        }

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

        #region Notifications
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e) {
            ShowMe(); lbChatrooms.SelectedItem = balloonRoom; lbChatrooms_Click(null, null);
        }

        private void Form1_Activated(object sender, EventArgs e) {
            if (currentRoom != null) currentRoom.unreadMsgCount = 0;
            stopBlinky();
        }

        void popupWindow_OnItemClick(object sender, MouseEventArgs e, string chatroom) {
            ShowMe(); lbChatrooms.SelectedItem = chatroom; lbChatrooms_Click(null, null);
        }

        private void tmrBlinky_Tick(object sender, EventArgs e) {
            notifyIcon1.Icon = (DateTime.Now.Second % 2 == 0) ? icon1 : icon2;
            this.Icon = notifyIcon1.Icon;
        }
        private void stopBlinky() {
            tmrBlinky.Stop(); notifyIcon1.Icon = icon1; this.Icon = icon1;
        }
        #endregion

        private void txtNickname_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                jabberConnect();
            }
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
                var reader = logs.GetFilteredLogs(this.currentRoom.roomName(), filterTextbox.Text, 0, 250);
                clearMessageView();
                webBrowser1.Document.GetElementById("tb").InnerHtml = "Search results, press ESC to quit filter mode";
                
                foreach (System.Data.Common.DbDataRecord k in reader) {
                    webBrowser1.addMessageToView(k.GetString(0), k.GetString(1), DateTime.Parse(k.GetString(2)), HtmlElementInsertionOrientation.AfterBegin);
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












    }
}
