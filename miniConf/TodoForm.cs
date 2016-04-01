using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class TodoForm : Form {
        public string lastcheck = "";

        public TodoForm() {
            InitializeComponent();

            timer1_Tick(null, null);
        }

        void LoadItems() {
            System.Data.SQLite.SQLiteCommand cmd;
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            listView1.Items.Clear();
            listView1.Groups.Clear();
            var gDue = listView1.Groups.Add("b", "Due");
            var gUnk = listView1.Groups.Add("a", "New");
            var gLater = listView1.Groups.Add("c", "Later");
            var gDone = listView1.Groups.Add("d", "Done");
            if (checkBox2.Checked) {
                cmd = Program.db.BuildCommand("SELECT *,rowid FROM messages WHERE wvl <> '' order by wvl asc,datedt asc", new object[]{});
            } else {
                object[] p= new object[]{ now };
                cmd = Program.db.BuildCommand("SELECT *,rowid FROM messages WHERE wvl = '1' OR (wvl <> '' AND wvl <= ?) order by wvl asc,datedt asc", p);
            }
            using (var reader = cmd.ExecuteReader()) {
                while (reader.Read()) {
                    var r = listView1.Items.Add((string)reader["room"]);
                    r.SubItems.Add(((string)reader["datedt"]).Substring(0,10));
                    r.SubItems.Add((string)reader["sender"]);
                    r.SubItems.Add((string)reader["messagebody"]);
                    string wvl = (string)reader["wvl"];
                    
                    object due;
                    if (wvl == "1") {
                        due = null; wvl = "(none)"; r.Group = gUnk;
                    } else if (wvl == "X") {
                        due = null; wvl = "(done)"; r.Group = gDone;
                        r.Checked = true;
                    } else {
                        DateTime duedate;
                        DateTime.TryParseExact(wvl, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out duedate);
                        due = duedate;
                        wvl = duedate.ToString("ddd dd.MM. HH:mm");

                        if (duedate < DateTime.Now) {
                            r.Group = gDue;
                        } else {
                            r.Group = gLater;
                        }
                    }
                    r.SubItems.Add(wvl).Tag = due;
                    r.Tag = (long)reader["rowid"];
                }

            }

        }

        private void button1_Click(object sender, EventArgs e) {
            foreach (ListViewItem row in listView1.Items) {
                row.Selected = true;
            }
        }

        void setDueDate(ListViewItem row, DateTime date) {
            long id = (long)row.Tag;
            Program.db.ExecSQL("UPDATE messages SET wvl = ? WHERE rowid = ?", date.ToString("yyyy-MM-dd HH:mm"), id);
            row.SubItems[4].Text = date.ToString("ddd dd.MM. HH:mm");
            row.SubItems[4].Tag = date;
        }
        private void button2_Click(object sender, EventArgs e) {
            DateTime tomorrow = DateTime.Today.AddDays(1).AddHours(8);
            //MessageBox.Show(tomorrow);
            foreach (ListViewItem row in listView1.SelectedItems) {
                setDueDate(row, tomorrow);
            }
        }
        private void button3_Click(object sender, EventArgs e) {
            foreach (ListViewItem row in listView1.SelectedItems) {
                long id = (long)row.Tag;
                Program.db.ExecSQL("UPDATE messages SET wvl = '' WHERE rowid = ?", id);
                row.Remove();
            }
            LoadItems();
        }


        private void TodoForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                this.Hide();
                e.Cancel = true;
            }
            Program.glob.saveFormPos(this);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            object[] p = new object[] { lastcheck, now };
            var cmd = Program.db.BuildCommand("SELECT count(*) C FROM messages WHERE wvl <> '' AND wvl > ? AND wvl < ?", p);
            int number = Convert.ToInt32(cmd.ExecuteScalar());
            if (number > 0) {
                ShowMe();
            }
            lastcheck = now;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
            LoadItems();
        }

        public void ShowMe() {
            this.TopMost = true; this.WindowState = FormWindowState.Normal;
            LoadItems();
            this.Show(); this.BringToFront(); this.Activate();
            this.TopMost = checkBox1.Checked;
        }

        private void TodoForm_Load(object sender, EventArgs e) {
            checkBox1.Checked = ApplicationPreferences.TodoListTopmost;
            Program.glob.readFormPos(this);
            TodoForm_ResizeEnd(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            TopMost = checkBox1.Checked;
            ApplicationPreferences.TodoListTopmost = checkBox1.Checked;
        }

        private void TodoForm_ResizeEnd(object sender, EventArgs e) {
            try {
                listView1.Columns[3].Width = listView1.Width - 27
                    - listView1.Columns[0].Width
                    - listView1.Columns[1].Width
                    - listView1.Columns[2].Width
                    - listView1.Columns[4].Width;
            } catch { }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e) {
            ListViewHitTestInfo item = listView1.HitTest(e.X, e.Y);
            if (item.Item == null || item.SubItem==null) return;
            
            switch (item.Item.SubItems.IndexOf(item.SubItem)) {
                case 4://due date
                    
                    if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                        var f = new Form();
                        var monthCalendar1 = new MonthCalendar();
                        var tx = new TextBox();
                        f.Controls.Add(tx);
                        f.Controls.Add(monthCalendar1); monthCalendar1.Top = 17;
                        f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        f.Width = monthCalendar1.Width; f.Height = monthCalendar1.Height + 23;
                        monthCalendar1.DateSelected += monthCalendar1_DateSelected;
                        f.Deactivate += monthCalendar1_Leave;
                        f.Owner = this;

                        DateTime date;
                        if (item.Item.SubItems[4].Tag == null) date = DateTime.Today.AddDays(1).AddHours(8);
                        else date = (DateTime)item.Item.SubItems[4].Tag;

                        monthCalendar1.SetDate(date);
                        tx.Text = date.ToString("HH:mm");
                        Point loc = listView1.PointToScreen(item.SubItem.Bounds.Location);
                        loc.Offset(0, 16);
                        f.Location = loc;
                        f.TopMost = this.TopMost;
                        f.StartPosition = FormStartPosition.Manual;
                        f.Show(); f.Activate();
                        tx.Focus();
                    }
                    break;
                case 3://message
                    if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                        //MessageBox.Show(item.SubItem.Text);
                    }
                    break;
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e) {
            Form form = ((Control)sender).FindForm();
            try {
                DateTime date = e.Start.Date;
                DateTime time;
                if (DateTime.TryParseExact(form.Controls[0].Text, new string[]{"HH:mm","H:mm"}, null, System.Globalization.DateTimeStyles.AssumeLocal, out time)) {
                    date = date.AddHours(time.Hour).AddMinutes(time.Minute);
                }
                setDueDate(listView1.SelectedItems[0], date);
            } catch { }
            form.Close();
        }

        private void monthCalendar1_Leave(object sender, EventArgs e) {
            ((Form)sender).Close();
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            richTextBox1.Text = "";
            foreach (ListViewItem item in listView1.SelectedItems) {
                richTextBox1.Text += "[" + item.SubItems[1].Text + "] " + item.SubItems[2].Text + ":\n" + item.SubItems[3].Text + "\n";
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e) {
            var row = listView1.Items[e.Index];
            if (row.Tag == null) return;
            long id = (long)row.Tag;
            if (e.NewValue == CheckState.Checked) {
                Program.db.ExecSQL("UPDATE messages SET wvl = 'X' WHERE rowid = ?", id);
                row.SubItems[4].Text = "(done)";
                row.SubItems[4].Tag = null;
            } else {
                Program.db.ExecSQL("UPDATE messages SET wvl = '1' WHERE rowid = ?", id);
                row.SubItems[4].Text = "(none)";
                row.SubItems[4].Tag = null;
            }
        }

        private void TodoForm_KeyUp(object sender, KeyEventArgs e) {
            
        }

        private void TodoForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F10) {
                Program.MainWnd.ShowMe();
            }
            if (e.KeyCode == Keys.Escape) {
                this.Hide();
            }
        }

    }
}
