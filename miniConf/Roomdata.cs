using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.protocol.extensions.chatstates;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Data.Common;

namespace miniConf {
    public class Roomdata {
        public Jid jid;
        public List<String> users = new List<string>();
        public int unreadMsgCount = 0;
        public int unreadNotifyCount = 0;
        public string unreadNotifyText = "";

        public bool online = false;

        public ErrorCondition errorCondition = (ErrorCondition)(999);

        public Chatstate chatstate;
        public Dictionary<string, Chatstate> users_states = new Dictionary<string, Chatstate>();
        public Dictionary<string, string> users_jid = new Dictionary<string, string>();

        public const int COL_ROOM=0;
        public const int COL_LASTMESSAGEDT  =1;
        public const int COL_SUBJECT =2;
        public const int COL_DO_JOIN=3;
        public const int COL_DISPLAY_NAME=4;
        public const int COL_LASTSEENDT =5;
        public const int COL_NOTIFY = 6;
        public const int COL_DISPLAY_POSITION = 7;
        public const int COL_AUTOTODO = 8;
        public const int COL_ROOMTYPE = 9;

        public enum RoomType {
            XmppDirect = 1,
            XmppMuc = 2
        }

        public enum JoinMode {
            Off = 0,
            AutoJoin = 1
        }
        [Flags()]
        public enum NotifyMode {
            Never,
            OnMention,
            Always
        }

        public String LastMessageDt { get; set; }
        public String Subject { get; set; }
        public JoinMode DoJoin { get; set; }
        public String DisplayName { get; set; }
        public String LastSeenDt { get; set; }
        public NotifyMode Notify { get; set; }
        public int DisplayPosition { get; set; }
        public RoomType Type { get; set; }

        public Roomdata(Jid myjid) {
            jid = myjid;
            this.LastMessageDt = "";
            this.LastSeenDt = "";
            this.DisplayName = myjid;
            this.Notify = NotifyMode.OnMention;
            this.Subject = "";
            this.AutoToDo = "";
            this.Type = RoomType.XmppMuc;
        }
        public static Roomdata FromDbDataRecord(DbDataRecord record) {
            Roomdata r = new Roomdata(record.GetString(COL_ROOM));
            r.LastMessageDt = SqlDatabase.StringOrNull(record, COL_LASTMESSAGEDT);
            r.Subject = SqlDatabase.StringOrNull(record, COL_SUBJECT);
            r.DoJoin = (JoinMode)record.GetInt32(COL_DO_JOIN);
            r.DisplayName = SqlDatabase.StringOrNull(record, COL_DISPLAY_NAME);
            r.LastSeenDt = SqlDatabase.StringOrNull(record, COL_LASTSEENDT);
            r.Notify = (NotifyMode)record.GetInt32(COL_NOTIFY);
            r.DisplayPosition = record.GetInt32(COL_DISPLAY_POSITION);
            r.AutoToDo = record.GetString(COL_AUTOTODO);
            r.Type = (RoomType) record.GetInt32(COL_ROOMTYPE);
            return r;
        }



        public string RoomName {
            get {
                return jid.Bare;
            }
        }

        public void ResetUnread() {
            unreadMsgCount = 0;
            unreadNotifyCount = 0;
        }


        public string editingMessageId = null;
        public string sendMessageText = "";
        public string sendMessageImageUrl = "";
        public Image sendMessageImagePreview = null;

        public Message sendMessage(string text) {
            var msg = new Message(this.RoomName, Program.Jabber.conn.MyJID,
                GetMessageType(), text);
            msg.Id = Guid.NewGuid().ToString();
            if (editingMessageId != null) {
                var replace = new agsXMPP.Xml.Dom.Element("replace", null, JabberService.URN_MESSAGE_CORRECT);
                replace.SetAttribute("id", editingMessageId);
                msg.AddChild(replace);
            }
            msg.Chatstate = agsXMPP.protocol.extensions.chatstates.Chatstate.active;
            this.chatstate = agsXMPP.protocol.extensions.chatstates.Chatstate.active;
            if (!string.IsNullOrEmpty(sendMessageImageUrl)) {
                var oob = new agsXMPP.Xml.Dom.Element("x", null, "jabber:x:oob");
                msg.AddChild(oob);
                oob.AddTag("url", sendMessageImageUrl);
                sendMessageImageUrl = null; sendMessageImagePreview = null;
            }
            Program.Jabber.conn.Send(msg);
            
            return msg;
        }

        public MessageType GetMessageType() {
            return this.Type == Roomdata.RoomType.XmppMuc ?
                MessageType.groupchat :
                MessageType.chat;
        }

        public void sendChatstate(Chatstate state) {
            if (chatstate == state) return;
            chatstate = state;
            var msg = new Message(new Jid(RoomName), Program.Jabber.conn.MyJID);
            msg.Type = GetMessageType();
            msg.Chatstate = state;
            Program.Jabber.conn.Send(msg);
        }
        public bool hasTypingUser() {
            foreach(Chatstate state in users_states.Values) {
                if (state == Chatstate.composing) return true;
            }
            return false;
        }
        public string getTypingNotice() {
            List<String> names = new List<string>();
            foreach (var kvp in users_states) {
                if (kvp.Value == Chatstate.composing && kvp.Key != jid.Resource) names.Add(kvp.Key);
            }
            if (names.Count == 0) return null;
            return String.Join(", ", names.ToArray()) +  (names.Count == 1?" is":" are")+" writing...";
        }
        public bool handleChatstate(Message msg) {
            if (msg.Chatstate == Chatstate.None) return false;
            bool change = true;
            Chatstate old_state;
            if (users_states.TryGetValue(msg.From.Resource, out old_state))
                change = old_state != msg.Chatstate;
            
            users_states[msg.From.Resource] = msg.Chatstate;
            return change;
        }

        public void handlePresence(Presence pres) {
            //agsXMPP.protocol.x.muc.User user = pres.SelectSingleElement(typeof agsXMPP.protocol.x.muc.User);
            //users_jid[pres.From.Resource] = user.Item.Jid.Bare;

        }

        public Color getChatstateColor(string nick) {
            Chatstate state;
            if (!users_states.TryGetValue(nick, out state)) return Color.Black;
            switch (state) {
                case Chatstate.paused: return Color.DarkCyan;
                case Chatstate.composing: return Color.Cyan;
                case Chatstate.active: return Color.DarkGreen;
                default: return Color.Black;
            }
        }
        public string getChatstate(string nick) {
            Chatstate state;
            if (!users_states.TryGetValue(nick, out state)) return "";
            return state.ToString();
        }
        public string getErrorMessage() {
            string msg = "";
            switch(errorCondition) {
                case ErrorCondition.NotAuthorized: msg = "A password is required"; break;
                case ErrorCondition.Forbidden: msg = "You are banned from the room"; break;
                case ErrorCondition.ItemNotFound: msg = "The room does not exist"; break;
                case ErrorCondition.NotAllowed: msg = "Room creation is restricted"; break;
                case ErrorCondition.NotAcceptable: msg = "The reserved roomnick must be used"; break;
                case ErrorCondition.RegistrationRequired: msg = "You are not on the member list"; break;
                case ErrorCondition.Conflict: msg = "Your desired room nickname is in use or registered by another user"; break;
                case ErrorCondition.ServiceUnavailable: msg = "The maximum number of users has been reached"; break;
                case ErrorCondition.JidMalformed: msg = "Your nickname contains invalid characters"; break;
                case (ErrorCondition)(999): return null;
                default: return errorCondition.ToString();
            }
            return msg + " (error code: " + errorCondition.ToString() + ")";
        }


        public List<ChatMessage> GetLogs(int startingfrom, int maxcount) {
            var cmd = Program.db.dataBase.CreateCommand();
            cmd.CommandText = "SELECT * FROM messages WHERE room = @name AND (override IS NULL OR override = '') ORDER BY datedt DESC LIMIT @from, @count;";
            cmd.Parameters.AddWithValue("@name", RoomName);
            cmd.Parameters.AddWithValue("@count", maxcount);
            cmd.Parameters.AddWithValue("@from", startingfrom);
            return readChatMessages(cmd.ExecuteReader());
        }
        public List<ChatMessage> GetFilteredLogs(string filterStr, int startingfrom, int maxcount) {
            var cmd = Program.db.dataBase.CreateCommand();
            cmd.CommandText = "SELECT * FROM messages WHERE room = @name AND messagebody LIKE @filterStr ORDER BY datedt DESC LIMIT @from, @count;";
            cmd.Parameters.AddWithValue("@name", RoomName);
            cmd.Parameters.AddWithValue("@filterStr", "%" + filterStr + "%");
            cmd.Parameters.AddWithValue("@count", maxcount);
            cmd.Parameters.AddWithValue("@from", startingfrom);
            return readChatMessages(cmd.ExecuteReader());
        }
        
        private List<ChatMessage> readChatMessages(DbDataReader reader) {
            var list = new List<ChatMessage>();
            foreach (DbDataRecord record in reader) {
                ChatMessage msg = ChatMessage.FromDbDataRecord(record);
                if (Type == RoomType.XmppMuc && String.IsNullOrEmpty(msg.SenderJid))
                    msg.SenderJid = Program.db.GetUserJid(RoomName, msg.SenderName);
                list.Add(msg);
            }
            return list;
        }


        public static Dictionary<string, Roomdata> MakeDict(List<Roomdata> list) {
            Dictionary<string, Roomdata> dict = new Dictionary<string, Roomdata>();
            foreach (var r in list) dict[r.RoomName] = r;
            return dict;
        }

        public static void legacyImport() {
            Program.glob.setPara("account__JID", Program.glob.para("Form1__txtPrefUsername"));
            Program.glob.setPara("account__Password", Program.glob.para("Form1__txtPrefPassword"));
            Program.glob.setPara("account__Server", Program.glob.para("Form1__txtPrefServer"));

            var rooms = Program.glob.para("Form1__txtChatrooms", "").Split('\n');
            foreach (var room in rooms) {
                if (String.IsNullOrEmpty(room) || room.Trim() == "" || room.StartsWith("//") || room.StartsWith("-- ")) continue;
                Jid jid = new Jid(room.Trim());
                var cmd = Program.db.dataBase.CreateCommand();
                cmd.CommandText = "UPDATE room set do_join=1,display_name=@dispName,notify=@notifyMode WHERE room=@roomName;";
                cmd.Parameters.AddWithValue("@roomName", jid.Bare);
                cmd.Parameters.AddWithValue("@dispName", jid.User);
                cmd.Parameters.AddWithValue("@notifyMode", Roomdata.NotifyMode.Always);
                cmd.ExecuteNonQuery();
            }
        }

        #region auto todo
        private string _autoToDo;
        private string[] autoToDoArray;
        public String AutoToDo { 
            get {
                return _autoToDo;
            }
            set {
                _autoToDo = value;
                if (String.IsNullOrEmpty(value)) {
                    autoToDoArray = new string[]{};
                } else {
                    autoToDoArray = value.Split(new char[]{'\r','\n'}, StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }

        public bool IsAutoToDo(string messageBody) {
            if (String.IsNullOrEmpty(AutoToDo)) return false;
            foreach(string str in autoToDoArray) {
                if (messageBody.IndexOf(str, 0, StringComparison.InvariantCultureIgnoreCase) != -1) return true;
            }
            return false;
        }
#endregion

    }
}
