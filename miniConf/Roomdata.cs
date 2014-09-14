using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.protocol.extensions.chatstates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace miniConf {
    public class Roomdata {
        public Jid jid;
        public HashSet<String> users = new HashSet<string>();
        public int unreadMsgCount = 0;

        public ErrorCondition errorCondition = (ErrorCondition)(999);

        public Chatstate chatstate;
        public Dictionary<string, Chatstate> users_states = new Dictionary<string, Chatstate>();
        public Dictionary<string, string> users_jid = new Dictionary<string, string>();

        public Roomdata(Jid myjid) {
            jid = myjid;
        }

        public string roomName() {
            return jid.Bare;
        }


        public void sendChatstate(agsXMPP.protocol.extensions.chatstates.Chatstate state) {
            if (chatstate == state) return;
            chatstate = state;
            var msg = new agsXMPP.protocol.client.Message(new Jid(roomName()), Program.Jabber.conn.MyJID);
            msg.Type = MessageType.groupchat;
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



    }
}
