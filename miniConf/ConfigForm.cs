using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using agsXMPP.Xml.Dom;

namespace miniConf {
    public partial class ConfigForm : Form {
        public ConfigForm() {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e) {
            WindowHelper.SetCueBanner(qq_txtPrefUsername, "jane-doe@example.org");
            updateSmileyThemeList();

            qq_txtPrefUsername.Text = ApplicationPreferences.AccountJID;
            qq_txtPrefPassword.Text = ApplicationPreferences.AccountPassword;
            qq_txtPrefServerPort.Text = ApplicationPreferences.AccountPort;
            qq_txtPrefServer.Text = ApplicationPreferences.AccountServer;

            txtNickname.Text = ApplicationPreferences.Nickname;

            comboMessageTheme.Text = ApplicationPreferences.ChatTheme;
            cmbSmileyTheme.Text = ApplicationPreferences.SmileyTheme;

            chkDisplayOccupantStatus.Checked = ApplicationPreferences.DisplayOccupantStatus;
            chkEnableImagePreview.Checked = ApplicationPreferences.EnableImagePreview;
            chkSternchen.Checked = ApplicationPreferences.Sternchen;

            cmbFileUploadService.Text = ApplicationPreferences.FileUploadServiceUrl;
            chkFiletransferAutoAccept.Checked = ApplicationPreferences.FiletransferAutoAccept;

        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(qq_txtPrefUsername.Text)
                || qq_txtPrefUsername.Text.Length < 4 || qq_txtPrefUsername.Text.Contains("@") == false) {
                qq_txtPrefUsername.Focus();
                MessageBox.Show("Please enter your jabber ID.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (String.IsNullOrEmpty(qq_txtPrefPassword.Text)) {
                qq_txtPrefPassword.Focus();
                MessageBox.Show("Please enter your password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ApplicationPreferences.AccountJID = qq_txtPrefUsername.Text;
            ApplicationPreferences.AccountPassword = qq_txtPrefPassword.Text;
            ApplicationPreferences.AccountPort = qq_txtPrefServerPort.Text;
            ApplicationPreferences.AccountServer = qq_txtPrefServer.Text;

            ApplicationPreferences.Nickname = txtNickname.Text;

            ApplicationPreferences.ChatTheme = comboMessageTheme.Text;
            ApplicationPreferences.SmileyTheme = cmbSmileyTheme.Text;

            ApplicationPreferences.DisplayOccupantStatus = chkDisplayOccupantStatus.Checked;
            ApplicationPreferences.EnableImagePreview = chkEnableImagePreview.Checked;
            ApplicationPreferences.Sternchen = chkSternchen.Checked;

            ApplicationPreferences.FileUploadServiceUrl = cmbFileUploadService.Text;
            ApplicationPreferences.FiletransferAutoAccept = chkFiletransferAutoAccept.Checked;

            this.Close();
        }

        private void qq_txtPrefUsername_TextChanged(object sender, EventArgs e) {
            string nick = qq_txtPrefUsername.Text;
            int at = nick.IndexOf("@");
            if (at > 0) nick = nick.Substring(0, at);
            txtNickname.Text = nick;
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            string[] username = ApplicationPreferences.getUsername();
            var cn = new agsXMPP.XmppClientConnection(username[1]);
            cn.RegisterAccount = true;
            cn.OnRegistered += (object sender2) => {
                MessageBox.Show("Your account is registered now.", "Create Jabber account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close(); /*button2_Click(null, null);*/
            };
            cn.OnRegisterError += (object sender2, Element e2) => {
                MessageBox.Show("Error while registering account: \n" + e2.ToString(), "Create Jabber account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            cn.OnLogin += (object sender2) => {
                MessageBox.Show("This account is already registered.", "Create Jabber account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close(); /*button2_Click(null, null);*/
            };
            cn.OnAuthError += (object sender2, agsXMPP.Xml.Dom.Element e2) => {
                var text = e2.SelectSingleElement("text", true);
                MessageBox.Show("Error while registering account: \n" + (text != null ? text.Value : e2.ToString()), "Create Jabber account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            cn.OnError += (object sender2, Exception e2) => {
                MessageBox.Show("Error while registering account: \n" + e2.ToString(), "Create Jabber account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            cn.OnSocketError += (object sender2, Exception e2) => {
                MessageBox.Show("Error while registering account: \n" + e2.ToString(), "Create Jabber account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            cn.Open(username[0], qq_txtPrefPassword.Text);

        }

        #region Smileys
        private void updateSmileyThemeList() {
            string path = Program.dataDir + "Emoticons\\";
            string[] emoteDirs = Directory.GetDirectories(path);
            cmbSmileyTheme.Items.Clear();
            cmbSmileyTheme.Items.Add("(none)");
            foreach (string dir in emoteDirs)
                cmbSmileyTheme.Items.Add(Path.GetFileName(dir));
        }


        private void lnkInstallSmiley_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("explorer.exe", Program.dataDir + "Emoticons\\");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("http://home.luelista.net/programme/miniconf/smilies/");
        }
        #endregion


    }
}
