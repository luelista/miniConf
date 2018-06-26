using System;
using System.Collections.Generic;
using System.Data.Common;

using System.Text;

namespace miniConf {
    public class ChatMessage {
        
        public enum MessageFlags {
            SystemNotice = 0x01,
            UnsafeAllowHtml = 0x02,
            Sending = 0x04,
            Delayed = 0x08,
        }

        public enum DbColumns : int {
            Room = 0, // room TEXT   -> Bare JID der Konversation, in der diese Nachricht sich befindet. JID des Raumes bei MUC-Nachricht, JID des Konversationspartners bei Direktnachricht
            XmppMessageId, // xmppid TEXT  -> Nachrichten-ID ("id"-Feld im<message> Tag)
            SenderName, // sender TEXT  -> Name des Absenders der Nachricht.Nickname bei MUC-Nachricht, full-JID bei Direktnachricht
            Body, // messagebody TEXT  -> Nachrichtentext(Inhalt des <body> Tag)
            SendDt, // datedt TEXT   -> Versanddatum der Nachricht, falls in der Nachricht angegeben, sonst Datum wann die Nachricht empfangen wurde
            SenderJid, // jid TEXT   -> wird nicht verwendet(?)
            EditDt, // editdt TEXT  -> wenn diese Nachricht eine andere ersetzt, enthält datedt das Datum der ursprüngl.Nachricht, und editdt das Ersetzungdatum, sonst ist editdt ""
            OverriddenById, // override TEXT   -> wenn diese Nachricht durch eine andere ersetzt wird, enthält dieses Feld die XMPPID der überschreibenden Nachricht, sonst NULL
            Wvl, // TEXT    -> Datum Wiedervorlage
            Flags, // INT   -> 0x1 System Notice, 0x2 Allow HTML, 0x4
        }
        

        public string Room, Id, SenderName, Body, EditDt, SenderJid, OverriddenById, Wvl;
        public DateTime Date;
        public MessageFlags Flags = 0;

        public ChatMessage() {

        }
        public ChatMessage(string room, string msgId, string senderName, string body, DateTime date, string senderJid, string editdt) {
            Room = room; Id = msgId; SenderName = senderName; Body = body;
            Date = date; SenderJid = senderJid; EditDt = editdt;
        }

        public static ChatMessage FromDbDataRecord(DbDataRecord record) {
            ChatMessage msg = new ChatMessage(
                record.GetString((int)DbColumns.Room),
                record.GetString((int)DbColumns.XmppMessageId),
                record.GetString((int)DbColumns.SenderName),
                record.GetString((int)DbColumns.Body),
                DateTime.Parse(record.GetString((int)DbColumns.SendDt)),
                SqlDatabase.StringOrNull(record, (int)DbColumns.SenderJid),
                SqlDatabase.StringOrNull(record, (int)DbColumns.EditDt));
            msg.OverriddenById = SqlDatabase.StringOrNull(record, (int)DbColumns.OverriddenById);
            msg.Wvl = SqlDatabase.StringOrNull(record, (int)DbColumns.Wvl);
            msg.Flags = (MessageFlags) record.GetInt32((int)DbColumns.Flags);
            return msg;
        }

        public string GetNotificationText() {
            return this.SenderName + " in " + this.Room + ":" + this.Body;
        }

        public DateTime GetSendOrEditDate() {
            if (string.IsNullOrEmpty(EditDt)) return Date; else return DateTime.Parse(EditDt);
        }
        public string GetDateString() {
            return ChatDatabase.GetDtString(Date);
        }
        public string GetSendOrEditDateString() {
            if (string.IsNullOrEmpty(EditDt)) return GetDateString(); else return EditDt;
        }

        public bool HasFlag(MessageFlags flag) {
            return (Flags & flag) != 0;
        }
    }
}
