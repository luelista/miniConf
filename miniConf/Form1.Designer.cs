namespace miniConf
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPrefServer = new System.Windows.Forms.TextBox();
            this.txtPrefUsername = new System.Windows.Forms.TextBox();
            this.txtPrefPassword = new System.Windows.Forms.TextBox();
            this.txtChatrooms = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvOnlineStatus = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtSendmessage = new System.Windows.Forms.TextBox();
            this.lbChatrooms = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrefServer
            // 
            this.txtPrefServer.Location = new System.Drawing.Point(74, 6);
            this.txtPrefServer.Name = "txtPrefServer";
            this.txtPrefServer.Size = new System.Drawing.Size(125, 20);
            this.txtPrefServer.TabIndex = 0;
            this.txtPrefServer.Text = "teamwiki.de";
            // 
            // txtPrefUsername
            // 
            this.txtPrefUsername.Location = new System.Drawing.Point(74, 32);
            this.txtPrefUsername.Name = "txtPrefUsername";
            this.txtPrefUsername.Size = new System.Drawing.Size(125, 20);
            this.txtPrefUsername.TabIndex = 1;
            // 
            // txtPrefPassword
            // 
            this.txtPrefPassword.Location = new System.Drawing.Point(74, 58);
            this.txtPrefPassword.Name = "txtPrefPassword";
            this.txtPrefPassword.Size = new System.Drawing.Size(125, 20);
            this.txtPrefPassword.TabIndex = 2;
            // 
            // txtChatrooms
            // 
            this.txtChatrooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChatrooms.Location = new System.Drawing.Point(7, 87);
            this.txtChatrooms.Multiline = true;
            this.txtChatrooms.Name = "txtChatrooms";
            this.txtChatrooms.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChatrooms.Size = new System.Drawing.Size(338, 78);
            this.txtChatrooms.TabIndex = 4;
            this.txtChatrooms.Text = "chat@chat.teamwiki.de";
            this.txtChatrooms.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtChatrooms);
            this.panel1.Controls.Add(this.txtPrefPassword);
            this.panel1.Controls.Add(this.txtPrefUsername);
            this.panel1.Controls.Add(this.txtPrefServer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 172);
            this.panel1.TabIndex = 5;
            this.panel1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server:";
            // 
            // lvOnlineStatus
            // 
            this.lvOnlineStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOnlineStatus.Location = new System.Drawing.Point(0, 0);
            this.lvOnlineStatus.Name = "lvOnlineStatus";
            this.lvOnlineStatus.Size = new System.Drawing.Size(91, 240);
            this.lvOnlineStatus.TabIndex = 8;
            this.lvOnlineStatus.UseCompatibleStateImageBehavior = false;
            this.lvOnlineStatus.View = System.Windows.Forms.View.SmallIcon;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Firebrick;
            this.panel2.Controls.Add(this.txtSubject);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 27);
            this.panel2.TabIndex = 6;
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.BackColor = System.Drawing.Color.Firebrick;
            this.txtSubject.ForeColor = System.Drawing.Color.White;
            this.txtSubject.Location = new System.Drawing.Point(140, 4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(210, 20);
            this.txtSubject.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(87, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 22);
            this.button3.TabIndex = 2;
            this.button3.Text = "history";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(61, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 22);
            this.button2.TabIndex = 1;
            this.button2.Text = "re";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(7, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "config";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 199);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(353, 427);
            this.panel3.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.webBrowser1);
            this.splitContainer1.Panel1.Controls.Add(this.txtSendmessage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvOnlineStatus);
            this.splitContainer1.Panel2.Controls.Add(this.lbChatrooms);
            this.splitContainer1.Size = new System.Drawing.Size(353, 427);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 9;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(1, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(256, 360);
            this.webBrowser1.TabIndex = 5;
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // txtSendmessage
            // 
            this.txtSendmessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendmessage.Location = new System.Drawing.Point(0, 366);
            this.txtSendmessage.Multiline = true;
            this.txtSendmessage.Name = "txtSendmessage";
            this.txtSendmessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendmessage.Size = new System.Drawing.Size(256, 61);
            this.txtSendmessage.TabIndex = 6;
            this.txtSendmessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendmessage_KeyUp);
            // 
            // lbChatrooms
            // 
            this.lbChatrooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbChatrooms.FormattingEnabled = true;
            this.lbChatrooms.Location = new System.Drawing.Point(0, 241);
            this.lbChatrooms.Name = "lbChatrooms";
            this.lbChatrooms.Size = new System.Drawing.Size(91, 186);
            this.lbChatrooms.TabIndex = 4;
            this.lbChatrooms.Click += new System.EventHandler(this.lbChatrooms_Click);
            this.lbChatrooms.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 626);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "miniConf";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrefServer;
        private System.Windows.Forms.TextBox txtPrefUsername;
        private System.Windows.Forms.TextBox txtPrefPassword;
        private System.Windows.Forms.TextBox txtChatrooms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSendmessage;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ListBox lbChatrooms;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView lvOnlineStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtSubject;
    }
}

