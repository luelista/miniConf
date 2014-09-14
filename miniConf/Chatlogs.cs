using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public class ChatDatabase : SqlDatabase {

        public const long schemaVersion = 7;

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

        public int InsertMessage(string room, string id, string sender, string body, string date_dt) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "INSERT INTO messages VALUES (@room, @id, @sender, @body, @ts, NULL)";
            cmd.Parameters.Add(new SQLiteParameter("@room", String.IsNullOrEmpty(room) ? "" : room));
            cmd.Parameters.Add(new SQLiteParameter("@id", String.IsNullOrEmpty(id) ? "" : id));
            cmd.Parameters.Add(new SQLiteParameter("@sender", String.IsNullOrEmpty(sender) ? "" : sender));
            cmd.Parameters.Add(new SQLiteParameter("@body", String.IsNullOrEmpty(body) ? "" : body));
            cmd.Parameters.Add(new SQLiteParameter("@ts", String.IsNullOrEmpty(date_dt) ? "" : date_dt));
            return cmd.ExecuteNonQuery();
        }

        public void SetLastmessageDatetime(string room, string lastmessage_dt) {
            this.ExecSQL("INSERT OR IGNORE INTO room VALUES (?, ?, '') ", room, lastmessage_dt);
            this.ExecSQL("UPDATE room SET lastmessagedt = ? WHERE room = ? ", lastmessage_dt, room);
        }
        public void SetSubject(string room, string subject) {
            this.ExecSQL("INSERT OR IGNORE INTO room VALUES (?, '', '') ", room);
            this.ExecSQL("UPDATE room SET subject = ? WHERE room = ? ", subject, room);
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

        //private Dictionary<string, string> userJidCache = new Dictionary<string, string>();
        public string GetUserJid(string room, string nick) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT user_jid FROM roommates WHERE room = @room AND nickname = @nick;";
            cmd.Parameters.AddWithValue("@room", room);
            cmd.Parameters.AddWithValue("@nick", nick);
            object result = cmd.ExecuteScalar();
            if (result is DBNull) return null; else return (string) result;
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

        public SQLiteDataReader GetLogs(string room, int startingfrom, int maxcount) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT sender,messagebody,datedt FROM messages WHERE room = @name ORDER BY datedt DESC LIMIT @from, @count;";
            cmd.Parameters.AddWithValue("@name", room);
            cmd.Parameters.AddWithValue("@count", maxcount);
            cmd.Parameters.AddWithValue("@from", startingfrom);
            return cmd.ExecuteReader();
        }
        public SQLiteDataReader GetFilteredLogs(string room, string filterStr, int startingfrom, int maxcount) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT sender,messagebody,datedt FROM messages WHERE room = @name AND messagebody LIKE @filterStr ORDER BY datedt DESC LIMIT @from, @count;";
            cmd.Parameters.AddWithValue("@name", room);
            cmd.Parameters.AddWithValue("@filterStr", "%"+filterStr+"%");
            cmd.Parameters.AddWithValue("@count", maxcount);
            cmd.Parameters.AddWithValue("@from", startingfrom);
            return cmd.ExecuteReader();
        }

        public static String GetNowString() {
            return DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ss.FFFZ");
        }
    }
}
