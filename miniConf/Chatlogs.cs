using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace miniConf
{
    class Chatlogs
    {
        SQLiteConnection dataBase;

        public Chatlogs(string dbfile)
        {
            var connString = new SQLiteConnectionStringBuilder();
            connString.DataSource = dbfile;

            dataBase = new SQLiteConnection(connString.ConnectionString);
            dataBase.Open();

            this.CreateSchema();

        }

        public void ExecSQL(string sql)
        {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

        }

        public void ExecSQL(string sql, params object[] args)
        {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = sql;
            foreach (var o in args)
            {
                cmd.Parameters.Add(new SQLiteParameter(System.Data.DbType.Object, o));
            }
            cmd.ExecuteNonQuery();

        }

        public void CreateSchema()
        {
            this.ExecSQL("CREATE TABLE IF NOT EXISTS messages (room TEXT, xmppid TEXT, sender TEXT, messagebody TEXT, datedt TEXT, CONSTRAINT message_unique UNIQUE ( room,xmppid,sender,datedt ) ON CONFLICT REPLACE ); ");
            this.ExecSQL("CREATE TABLE IF NOT EXISTS roommates (room TEXT, nickname TEXT, lastseendt INTEGER, onlinestate TEXT, CONSTRAINT mate_unique UNIQUE (room,nickname) ON CONFLICT FAIL ); ");
            this.ExecSQL("CREATE TABLE IF NOT EXISTS room (room TEXT, lastmessagedt TEXT, subject TEXT, CONSTRAINT room_unique UNIQUE (room) ON CONFLICT IGNORE); ");

        }

        public int InsertMessage(string room, string id, string sender, string body, string date_dt)
        {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "INSERT INTO messages VALUES (@room, @id, @sender, @body, @ts)";
            cmd.Parameters.Add(new SQLiteParameter("@room", String.IsNullOrEmpty(room) ? "" : room));
            cmd.Parameters.Add(new SQLiteParameter("@id", String.IsNullOrEmpty(id) ? "" : id));
            cmd.Parameters.Add(new SQLiteParameter("@sender", String.IsNullOrEmpty(sender) ? "" : sender));
            cmd.Parameters.Add(new SQLiteParameter("@body", String.IsNullOrEmpty(body) ? "" : body));
            cmd.Parameters.Add(new SQLiteParameter("@ts", String.IsNullOrEmpty(date_dt) ? "" : date_dt));
            return cmd.ExecuteNonQuery();
        }

        public void SetLastmessageDatetime(string room, string lastmessage_dt)
        {
            this.ExecSQL("INSERT OR IGNORE INTO room VALUES (?, ?, '') ", room, lastmessage_dt);
            this.ExecSQL("UPDATE room SET lastmessagedt = ? WHERE room = ? ", lastmessage_dt, room);
        }
        public void SetSubject(string room, string subject)
        {
            this.ExecSQL("INSERT OR IGNORE INTO room VALUES (?, '', '') ", room);
            this.ExecSQL("UPDATE room SET subject = ? WHERE room = ? ", subject, room);
        }

        public string GetLastmessageDatetime(string room)
        {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT lastmessagedt FROM room WHERE room = @name;";
            cmd.Parameters.AddWithValue("@name", room);
            return (string)cmd.ExecuteScalar();
        }
        public string GetSubject(string room)
        {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT subject FROM room WHERE room = @name;";
            cmd.Parameters.AddWithValue("@name", room);
            return (string)cmd.ExecuteScalar();
        }
        public void SetOnlineStatus(string room, string nickname, string onlinestate)
        {
            this.ExecSQL("INSERT OR REPLACE INTO roommates VALUES (?, ?, ?, ?)", room, nickname, GetNowString(), onlinestate);
        }
        public void SetOnlineStatus(string room, string onlinestate)
        {
            this.ExecSQL("UPDATE roommates SET onlinestate = ? WHERE room = ? ", onlinestate, room);
        }

        public SQLiteDataReader GetMembers(string room)
        {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT nickname,lastseendt,onlinestate FROM roommates WHERE room = @name;";
            cmd.Parameters.AddWithValue("@name", room);
            return cmd.ExecuteReader();
        }

        public SQLiteDataReader GetLogs(string room, int maxcount)
        {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = "SELECT * FROM (SELECT sender,messagebody,datedt FROM messages WHERE room = @name ORDER BY datedt DESC LIMIT @count) ORDER BY datedt ASC;";
            cmd.Parameters.AddWithValue("@name", room);
            cmd.Parameters.AddWithValue("@count", maxcount);
            return cmd.ExecuteReader();
        }

        public static String GetNowString()
        {
            return DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ss.FFFZ");
        }
    }
}
