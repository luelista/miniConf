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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectMessageForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.messageView1 = new miniConf.MessageView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 284);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 75);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(5, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(470, 63);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // messageView1
            // 
            this.messageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageView1.Location = new System.Drawing.Point(0, 0);
            this.messageView1.MinimumSize = new System.Drawing.Size(20, 20);
            this.messageView1.Name = "messageView1";
            this.messageView1.Size = new System.Drawing.Size(497, 284);
            this.messageView1.TabIndex = 0;
            this.messageView1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.messageView1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.messageView1_DocumentCompleted);
            // 
            // DirectMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 359);
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
    }
}