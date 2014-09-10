using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public class SqlDatabase {
        
        public SQLiteConnection dataBase { get; private set; }

        public long databaseVersion { get; private set; }

        public SqlDatabase(string dbfile) {
            var connString = new SQLiteConnectionStringBuilder();
            connString.DataSource = dbfile;

            dataBase = new SQLiteConnection(connString.ConnectionString);
            dataBase.Open();

            this.databaseVersion = (long)this.GetScalarSQL("PRAGMA user_version;  ");
        }

        public void ExecSQL(string sql) {
            var cmd = this.BuildCommand(sql, new object[0]);
            cmd.ExecuteNonQuery();
        }

        public void ExecSQL(string sql, params object[] args) {
            var cmd = this.BuildCommand(sql, args);
            cmd.ExecuteNonQuery();
        }

        public object GetScalarSQL(string sql, params object[] args) {
            var cmd = this.BuildCommand(sql, args);
            return cmd.ExecuteScalar();
        }
        public SQLiteCommand BuildCommand(string sql, object[] args) {
            var cmd = dataBase.CreateCommand();
            cmd.CommandText = sql;
            foreach (var o in args) {
                cmd.Parameters.Add(new SQLiteParameter(System.Data.DbType.Object, o));
            }
            return cmd;
        }


        
    }
}
