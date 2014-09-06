using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class DatabaseDebugForm : Form {
        public Chatlogs database;

        public DatabaseDebugForm() {
            InitializeComponent();
            textEditorControl1.ActiveTextAreaControl.TextArea.KeyDown += textEditorControl1_KeyDown;
            textEditorControl1.SetHighlighting("SQL");
        }

        

        private void textEditorControl1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && e.Control) {
                try {
                    toolStripStatusLabel1.ForeColor = Color.Black;
                    var sql = textEditorControl1.Text;
                    var sqlCommand = database.BuildCommand(sql, new object[0]);
                    var reader = sqlCommand.ExecuteReader();
                    listView1.BeginUpdate();
                    listView1.Items.Clear();
                    listView1.Columns.Clear();
                    for (int i = 0; i < reader.FieldCount; i++) {
                        listView1.Columns.Add(reader.GetName(i));
                    }
                    foreach (System.Data.Common.DbDataRecord k in reader) {
                        var lvi = listView1.Items.Add(k.GetValue(0).ToString());
                        for (int i = 1; i < reader.FieldCount; i++) lvi.SubItems.Add(k.GetValue(i).ToString());
                    }
                    for (int i = 0; i < listView1.Columns.Count; i++)
                        listView1.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                    listView1.EndUpdate();
                    
                    toolStripStatusLabel1.Text = listView1.Items.Count.ToString() + " rows shown     "+ reader.RecordsAffected.ToString() + " records affected";
                } catch (System.Data.SQLite.SQLiteException sqe) {
                    toolStripStatusLabel1.Text = sqe.Message;
                    toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
        }

        private void DatabaseDebugForm_Load(object sender, EventArgs e) {

        }
    }
}
