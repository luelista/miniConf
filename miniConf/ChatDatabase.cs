﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using System.Data.SQLite;

using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public class ChatDatabase : SqlDatabase {

        public const long schemaVersion = 12;

        public ChatDatabase(string dbfile)
            : base(dbfile) {

            this.CreateSchema(this.databaseVersion);
        }

        public void CreateSchema(long currentVersion) {
            try {
                
                if (currentVersion < 1) {
                    this.ExecSQL("CREATE TABLE IF NOT EXISTS messages (room TEXT, xmppid TEXT, sender TEXT, messagebody TEXT, datedt TEXT, CONSTRAINT message_unique UNIQUE ( room,xmppid,sender,datedt ) ON CONFLICT REPLACE ); ");
                    this.ExecSQL("CREATE TABLE IF NOT EXISTS roommates (room TEXT, nickname TEXT, lastseendt INTEGER, onlinestate TEXT, CONSTRAINT mate_unique UNIQUE (room,nickname) ON CONFLICT FAIL ); ");
                    this.ExecSQL("CREATE TABLE IF NOT EXISTS room (room TEXT, lastmessagedt TEXT, subject TEXT, CONSTRAINT room_unique UNIQUE (room) ON CONFLICT IGNORE); ");
                }

                if (currentVersion < 2) {
                    this.ExecSQL("ALTER TABLE roommates ADD COLUMN affiliation TEXT; ");
                    this.ExecSQL("ALTER TABLE roommates ADD COLUMN role TEXT; ");
                }

                if (currentVersion < 3) {
                    this.ExecSQL("ALTER TABLE roommates ADD COLUMN status_str TEXT; ");
                }
                if (currentVersion < 4) {
                    this.ExecSQL("ALTER TABLE roommates ADD COLUMN user_jid TEXT; ");
                }

                if (currentVersion < 5) {
                    this.ExecSQL("CREATE TABLE IF NOT EXISTS params (item TEXT, value TEXT); ");
                }

                if (currentVersion < 6) {
                    this.ExecSQL("DROP TABLE IF EXISTS params; CREATE TABLE params (item TEXT, value TEXT, CONSTRAINT para_unique UNIQUE (item) ON CONFLICT REPLACE); ");
                }

                if (currentVersion < 7) {
                    this.ExecSQL("ALTER TABLE messages ADD COLUMN jid TEXT; ");
                }

                if (currentVersion < 8) {
                    this.ExecSQL("ALTER TABLE messages ADD COLUMN editdt TEXT; ");
                    this.ExecSQL("ALTER TABLE messages ADD COLUMN override TEXT; ");
                }

                if (currentVersion < 9) {
                    this.ExecSQL("ALTER TABLE room ADD COLUMN do_join INT DEFAULT 0; ");
                    this.ExecSQL("ALTER TABLE room ADD COLUMN display_name TEXT DEFAULT ''; ");
                    this.ExecSQL("ALTER TABLE room ADD COLUMN lastseendt TEXT DEFAULT ''; ");
                    this.ExecSQL("ALTER TABLE room ADD COLUMN notify INT DEFAULT 0; ");
                    this.ExecSQL("ALTER TABLE room ADD COLUMN display_position INT DEFAULT 0; ");
                }

                if (currentVersion < 10) {
                    this.ExecSQL("CREATE TABLE IF NOT EXISTS mru (mrulist TEXT, value TEXT, useddt INT, CONSTRAINT itemunique UNIQUE (mrulist,value) ON CONFLICT REPLACE); ");

                }

                if (currentVersion < 11) {
                    this.ExecSQL("ALTER TABLE messages ADD COLUMN wvl TEXT DEFAULT ''; ");
                    this.ExecSQL("ALTER TABLE room ADD COLUMN autotodo TEXT DEFAULT ''; ");

                }

                if (currentVersion < 12) {
                    this.ExecSQL("ALTER TABLE room ADD COLUMN roomtype INT DEFAULT 2; ");
                    this.ExecSQL("ALTER TABLE messages ADD COLUMN flags INT DEFAULT 0; ");

                    // update db version number
                    this.ExecSQL("PRAGMA user_version = " + ChatDatabase.schemaVersion.ToString());
                }


            } catch (Exception ex) {
                System.IO.File.AppendAllText(Program.tempDir + "error.log", GetNowString() + "\tDatabase error (schema update):\t" + ex.Message);
                
                switch (MessageBox.Show("Database error\n" + ex.Message, "Updater", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)) {
                    case DialogResult.Abort:
                        return;
                    case DialogResult.Retry:
                        CreateSchema(currentVersion + 1);
                        return;
                    case DialogResult.Ignore:
                        // update db version number
                        this.ExecSQL("PRAGMA user_version = " + ChatDatabase.schemaVersion.ToString());
                        return;
                }
            }
        }

        public int InsertMessage(ChatMessage msg) {
            var cmd = dataBase.CreateCommand();
            //room TEXT, xmppid TEXT, sender TEXT, messagebody TEXT, datedt TEXT, jid TEXT, editdt TEXT, override TEXT, wvl TEXT, flags INT
            cmd.CommandText = "INSERT INTO messages VALUES (@room, @id, @sender, @body, @ts, @senderjid, @editts, @override, @todo, @flags)";
            cmd.Parameters.Add(new SQLiteParameter("@room", String.IsNullOrEmpty(msg.Room) ? "" : msg.Room));
            cmd.Parameters.Add(new SQLiteParameter("@id", String.IsNullOrEmpty(msg.Id) ? "" : msg.Id));
            cmd.Parameters.Add(new SQLiteParameter("@sender", String.IsNullOrEmpty(msg.SenderName) ? "" : msg.SenderName));
            cmd.Parameters.Add(new SQLiteParameter("@body", String.IsNullOrEmpty(msg.Body) ? "" : msg.Body));
            cmd.Parameters.Add(new SQLiteParameter("@ts", GetDtString(msg.Date)));
            cmd.Parameters.Add(new SQLiteParameter("@senderjid", msg.SenderJid));
            cmd.Parameters.Add(new SQLiteParameter("@editts", String.IsNullOrEmpty(msg.EditDt) ? "" : msg.EditDt));
            cmd.Parameters.Add(new SQLiteParameter("@override", String.IsNullOrEmpty(msg.OverriddenById) ? "" : msg.OverriddenById));
            cmd.Parameters.Add(new SQLiteParameter("@todo", String.IsNullOrEmpty(msg.Wvl) ? "" : msg.Wvl));
            cmd.Parameters.Add(new SQLiteParameter("@flags", (int)msg.Flags));
            return cmd.ExecuteNonQuery();
        }
        public bool EditMessage(string room, string xmppid, string newXmppid, string from, string newbody, DateTime edit_dt) {
            ChatMessage oldMessage = GetMessageById(room, xmppid);
            if (oldMessage == null) return false;

            if (from != oldMessage.SenderName) return false;

            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "UPDATE messages SET override=@newid WHERE room=@room AND xmppid= @id";
            cmd.Parameters.Add(new SQLiteParameter("@room", String.IsNullOrEmpty(room) ? "" : room));
            cmd.Parameters.Add(new SQLiteParameter("@id", String.IsNullOrEmpty(xmppid) ? "" : xmppid));
            cmd.Parameters.Add(new SQLiteParameter("@newid", String.IsNullOrEmpty(newXmppid) ? "" : newXmppid));
            var ok1= cmd.ExecuteNonQuery();

            //InsertMessage(room, newXmppid, oldMessage["sender"], newbody, oldMessage["datedt"], edit_dt);
            InsertMessage(new ChatMessage(room, newXmppid, oldMessage.SenderName, newbody, oldMessage.Date, null, GetDtString(edit_dt)));
            

            return true;
        }

        /*
        public void SetLastmessageDatetime(string room, string lastmessage_dt) {
            this.ExecSQL("INSERT OR IGNORE INTO room VALUES (?, ?, '', '', '', '', '', '') ", room, lastmessage_dt);
            this.ExecSQL("UPDATE room SET lastmessagedt = ? WHERE room = ? ", lastmessage_dt, room);
        }
        public void SetSubject(string room, string subject) {
            this.ExecSQL("INSERT OR IGNORE INTO room VALUES (?, '', '', '', '', '', '', '') ", room);
            this.ExecSQL("UPDATE room SET subject = ? WHERE room = ? ", subject, room);
        }*/
        public int StoreRoom(Roomdata room) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "INSERT OR REPLACE INTO room VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)";
            cmd.Parameters.Add(new SQLiteParameter("@p" + Roomdata.COL_SUBJECT, String.IsNullOrEmpty(room.Subject) ? "" : room.Subject));
            cmd.Parameters.Add(new SQLiteParameter("@p" + Roomdata.COL_ROOM, room.jid.Bare));
            cmd.Parameters.Add(new SQLiteParameter("@p" + Roomdata.COL_NOTIFY, (int)room.Notify));
            cmd.Parameters.Add(new SQLiteParameter("@p" + Roomdata.COL_DO_JOIN, (int)room.DoJoin));
            cmd.Parameters.Add(new SQLiteParameter("@p" + Roomdata.COL_DISPLAY_POSITION, (int)room.DisplayPosition));
            cmd.Parameters.Add(new SQLiteParameter("@p" + Roomdata.COL_LASTMESSAGEDT, room.LastMessageDt));
            cmd.Parameters.Add(new SQLiteParameter("@p" + Roomdata.COL_LASTSEENDT, room.LastSeenDt));
            cmd.Parameters.Add(new SQLiteParameter("@p" + Roomdata.COL_DISPLAY_NAME, room.DisplayName));
            cmd.Parameters.Add(new SQLiteParameter("@p" + Roomdata.COL_AUTOTODO, room.AutoToDo));
            cmd.Parameters.Add(new SQLiteParameter("@p" + Roomdata.COL_ROOMTYPE, room.Type));
            return cmd.ExecuteNonQuery();
        }

        public ChatMessage GetMessageById(string room, string xmppid) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT * FROM messages WHERE room = @name AND xmppid = @xmppid;";
            cmd.Parameters.AddWithValue("@name", room); cmd.Parameters.AddWithValue("@xmppid", xmppid);
            var reader = cmd.ExecuteReader();
            foreach (DbDataRecord record in reader)  // loop is cancelled after first match by the return statement
                return ChatMessage.FromDbDataRecord(record);
            // else (no match):
            return null;
        }
        public string GetLastmessageDatetime(string room) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT lastmessagedt FROM room WHERE room = @name;";
            cmd.Parameters.AddWithValue("@name", room);
            return (string)cmd.ExecuteScalar();
        }
        public string GetSubject(string room) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT subject FROM room WHERE room = @name;";
            cmd.Parameters.AddWithValue("@name", room);
            return (string)cmd.ExecuteScalar();
        }
        public void SetOnlineStatus(string room, string nickname, string onlinestate, string affil, string role, string statusStr, string jid) {
            this.ExecSQL("INSERT OR REPLACE INTO roommates VALUES (?, ?, ?, ?, ?, ?, ?, ?)", room, nickname, DateTime.Now.ToBinary(), onlinestate, affil, role, statusStr, jid);
        }
        public void SetOnlineStatus(string room, string onlinestate) {
            this.ExecSQL("UPDATE roommates SET onlinestate = ? WHERE room = ? ", onlinestate, room);
        }
        public void RemoveOnlineStatus(string room, string nickname) {
            this.ExecSQL("DELETE FROM roommates WHERE room = ? AND nickname = ?", room, nickname);
        }

        //private Dictionary<string, string> userJidCache = new Dictionary<string, string>();
        public string GetUserJid(string room, string nick) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT user_jid FROM roommates WHERE room = @room AND nickname = @nick;";
            cmd.Parameters.AddWithValue("@room", room);
            cmd.Parameters.AddWithValue("@nick", nick);
            return SqlDatabase.ScalarStringOrNull(cmd);
        }

        public SQLiteDataReader GetMembers(string room) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT nickname,lastseendt,onlinestate,affiliation,role,status_str,user_jid FROM roommates WHERE room = @name;";
            cmd.Parameters.AddWithValue("@name", room);
            return cmd.ExecuteReader();
        }

        public int GetLogLength(string room) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT count(*) FROM messages WHERE room = @name ;";
            cmd.Parameters.AddWithValue("@name", room);
            return (int)(long)cmd.ExecuteScalar();
        }

        public List<Roomdata> GetRooms(bool joinOnly) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT * FROM room " + (joinOnly ? " WHERE join = 1" : "") + " ORDER BY display_position ; ";
            var reader = cmd.ExecuteReader();
            List<Roomdata> list = new List<Roomdata>();
            foreach (DbDataRecord rec in reader) {
                list.Add(Roomdata.FromDbDataRecord(rec));
            }
            return list;
        }

        public string[] GetMru(string mruid, int maxlength) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT value,rowid FROM mru WHERE mrulist = @id ORDER BY useddt DESC ; ";
            cmd.Parameters.AddWithValue("@id", mruid);
            var reader = cmd.ExecuteReader();
            string[] list = new string[maxlength];
            int count = 0;
            foreach (DbDataRecord rec in reader) {
                count++;
                if (count > maxlength) {
                    ExecSQL("DELETE from mru where rowid = ?", rec.GetInt32(1));
                } else {
                    list[count - 1] = rec.GetString(0);
                }
            }
            if (count < maxlength) Array.Resize(ref list, count);
            return list;
        }

        public void AddToMru(string mruid, string value) {
            ExecSQL("INSERT INTO mru (mrulist,value,useddt) VALUES (?,?,?)", mruid, value, DateTime.Now.Ticks);
        }

        public static String GetNowString() {
            return DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ss.FFFZ");
        }
        public static String GetDtString(DateTime dt) {
            return dt.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ss.FFFZ");
        }
    }
}
