using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace miniConf {
    public class ChatMessage {
        
        public const int C_SENDER = 0;
        public const int C_BODY = 1;
        public const int C_DATE = 2;
        public const int C_ID = 3;
        public const int C_EDIT = 4;

        public string Sender, Body, Id, Editdt, SenderJid;
        public DateTime Date;

        public ChatMessage() {

        }
        public ChatMessage(string sender, string body, DateTime date, string id, string editdt) {
            this.Sender = sender; this.Body = body; this.Date = date;
            this.Id = id; this.Editdt = editdt;
        }

        public static ChatMessage FromDbDataRecord(DbDataRecord record) {
            ChatMessage msg = new ChatMessage(record.GetString(C_SENDER), 
                record.GetString(C_BODY), DateTime.Parse(record.GetString(C_DATE)), 
                record.GetString(C_ID), Program.db.StringOrNull(record,C_EDIT));
            return msg;
        }

    }
}
