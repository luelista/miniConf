using System;
using System.Collections.Generic;

using System.Text;

namespace miniConf {
    public class MucService {

        /// <summary>
        /// Join a Multi-user room
        /// </summary>
        /// <param name="room">room data object</param>
        /// <param name="loadAllHistory">request all history from server (10000 stanzas max)</param>
        public void joinRoom(Roomdata room, bool loadAllHistory = false) {
            //
            
            Program.db.SetOnlineStatus(room.RoomName, "off");

            /// Setup Room
            agsXMPP.protocol.client.Presence MUCpresence = new agsXMPP.protocol.client.Presence();
            //MUCpresence.From = jabber.conn.MyJID;
            MUCpresence.To = room.jid;

            var xMuc = new agsXMPP.protocol.x.muc.Muc();
            MUCpresence.AddChild(xMuc);

            //if (glob.para("notifications__" + roomJid.Bare) == "FALSE") xMuc.SetTag("show", "away");
            if (room.Notify != Roomdata.NotifyMode.Always) xMuc.SetTag("show", "away");

            agsXMPP.protocol.x.muc.History historyChild = new agsXMPP.protocol.x.muc.History(100);
            try {
                string since = room.LastMessageDt; //logs.GetLastmessageDatetime(room.jid.Bare);
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
            Program.Jabber.conn.Send(MUCpresence);

        }

        public void leaveRoom(Roomdata room) {
            Program.db.SetOnlineStatus(room.RoomName, "off");
            room.online = false;

            agsXMPP.protocol.client.Presence MUCpresence = new agsXMPP.protocol.client.Presence();
            //MUCpresence.From = jabber.conn.MyJID;
            MUCpresence.To = room.jid;
            MUCpresence.Type = agsXMPP.protocol.client.PresenceType.unavailable;
            Program.Jabber.conn.Send(MUCpresence);
        }

    }
}
