using System;
using System.Collections.Generic;
using System.Data.Common;
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


        #region DbNull Helpers

        protected static string ScalarStringOrNull(SQLiteCommand cmd) {
            object result = cmd.ExecuteScalar();
            if (result is DBNull) return null; else return (string)result;
        }
        public static string StringOrNull(object Object) {
            if (Object is DBNull) return null; else return (string)Object;
        }
        public static string StringOrNull(SQLiteDataReader reader, int column) {
            if (reader.IsDBNull(column)) return null; else return reader.GetString(column);
        }
        public static string StringOrNull(DbDataRecord reader, int column) {
            if (reader.IsDBNull(column)) return null; else return reader.GetString(column);
        }
        public static Int32 Int32OrDefault(DbDataRecord reader, int column, int defValue = 0) {
            if (reader.IsDBNull(column)) return defValue; else return reader.GetInt32(column);
        }
        #endregion

    }
}
