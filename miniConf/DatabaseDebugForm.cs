using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class DatabaseDebugForm : Form {
        public ChatDatabase database;

        public DatabaseDebugForm() {
            InitializeComponent();
            textEditorControl1.ActiveTextAreaControl.TextArea.KeyDown += textEditorControl1_KeyDown;
            textEditorControl1.SetHighlighting("SQL");
        }

        private string getLineOfText(int linum) {
            var lineObj = textEditorControl1.Document.GetLineSegment(linum);
            return textEditorControl1.Document.GetText(lineObj);
        }

        private void textEditorControl1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && e.Control) {
				File.WriteAllText(Program.dataDir+"Temporary Data"+Path.PathSeparator+"lastQuery.sql", textEditorControl1.Text);
                var selMan = textEditorControl1.ActiveTextAreaControl.SelectionManager;
                if (!selMan.HasSomethingSelected) {
                    int lineCount=textEditorControl1.Document.TotalNumberOfLines;
                    int line = textEditorControl1.ActiveTextAreaControl.Caret.Line, endline=line,startline=line;
                    while (line-- > 0) {
                        string t = getLineOfText(line).Trim();
                        if (t == "") continue;
                        if (t.EndsWith(";")) break; else startline = line;
                    }
                    line = endline-1;
                    while (++line < lineCount) {
                        string t = getLineOfText(line).Trim();
                        if (t == "") continue;
                        if (t.EndsWith(";")) { endline = line; break; }
                    }
                    selMan.SetSelection(textEditorControl1.Document.GetLineSegment(startline).CreateAnchor(0).Location,
                        textEditorControl1.Document.GetLineSegment(endline).CreateAnchor(textEditorControl1.Document.GetLineSegment(endline).Length).Location);

                    return;
                }
                try {
                    toolStripStatusLabel1.ForeColor = Color.Black;
                    var sql = selMan.SelectedText;
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
            textEditorControl1.Text = Program.glob.para("DatabaseDebugForm__sql","SELECT * FROM sqlite_master;\n\n");
            

        }

        private void textEditorControl1_Load(object sender, EventArgs e) {

        }

        private void DatabaseDebugForm_FormClosing(object sender, FormClosingEventArgs e) {
            Program.glob.setPara("DatabaseDebugForm__sql", textEditorControl1.Text);
        }
    }
}
