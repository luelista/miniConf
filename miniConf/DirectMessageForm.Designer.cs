namespace miniConf {
    partial class DirectMessageForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectMessageForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbResources = new System.Windows.Forms.ComboBox();
            this.labChatstate = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.messageView1 = new miniConf.MessageView();
            this.tmrChatstatePaused = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbResources);
            this.panel1.Controls.Add(this.labChatstate);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 90);
            this.panel1.TabIndex = 1;
            // 
            // cmbResources
            // 
            this.cmbResources.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbResources.FormattingEnabled = true;
            this.cmbResources.Location = new System.Drawing.Point(255, 69);
            this.cmbResources.Name = "cmbResources";
            this.cmbResources.Size = new System.Drawing.Size(206, 21);
            this.cmbResources.TabIndex = 2;
            // 
            // labChatstate
            // 
            this.labChatstate.AutoSize = true;
            this.labChatstate.ForeColor = System.Drawing.Color.DarkGray;
            this.labChatstate.Location = new System.Drawing.Point(8, 73);
            this.labChatstate.Name = "labChatstate";
            this.labChatstate.Size = new System.Drawing.Size(31, 13);
            this.labChatstate.TabIndex = 1;
            this.labChatstate.Text = "        ";
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(461, 63);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // messageView1
            // 
            this.messageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageView1.Location = new System.Drawing.Point(0, 0);
            this.messageView1.MinimumSize = new System.Drawing.Size(20, 20);
            this.messageView1.Name = "messageView1";
            this.messageView1.Size = new System.Drawing.Size(461, 414);
            this.messageView1.TabIndex = 0;
            this.messageView1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.messageView1.OnSpecialUrl += new miniConf.MessageView.SpecialUrlEvent(this.messageView1_OnSpecialUrl);
            this.messageView1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.messageView1_DocumentCompleted);
            // 
            // tmrChatstatePaused
            // 
            this.tmrChatstatePaused.Interval = 5000;
            this.tmrChatstatePaused.Tick += new System.EventHandler(this.tmrChatstatePaused_Tick);
            // 
            // DirectMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 504);
            this.Controls.Add(this.messageView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DirectMessageForm";
            this.Text = "DirectMessageForm";
            this.Load += new System.EventHandler(this.DirectMessageForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MessageView messageView1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labChatstate;
        private System.Windows.Forms.Timer tmrChatstatePaused;
        private System.Windows.Forms.ComboBox cmbResources;
    }
}