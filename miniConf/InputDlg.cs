using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UgbDatabaseConnection {
    public partial class InputDlg : Form {
        public InputDlg() {
            InitializeComponent();
        }

        public String GetInput() {
            return textBox1.Text;
        }

        public static string InputBox(string title, string defValue) {
            var f = new InputDlg();
            f.Text = title;
            f.textBox1.Text = defValue;
            if (f.ShowDialog() == DialogResult.OK) {
                return f.textBox1.Text;
            } else {
                return null;
            }
        }
        public static string InputBoxForced(string title, string defValue, Form parent = null) {
            var f = new InputDlg();
            f.ControlBox = false;
            f.button2.Visible = false;
            f.button1.Left = f.button2.Left;
            f.Text = title;
            f.textBox1.Text = defValue;
            f.TopMost = true;
            if (f.ShowDialog(parent) == DialogResult.OK) {
                return f.textBox1.Text;
            } else {
                return null;
            }
        }

        private void InputDlg_Load(object sender, EventArgs e) {

        }
    }
}
