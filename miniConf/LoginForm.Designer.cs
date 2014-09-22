namespace miniConf {
    partial class LoginForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pnlPrefConnectAdvanced = new System.Windows.Forms.Panel();
            this.txtPrefServerPort = new System.Windows.Forms.ComboBox();
            this.txtPrefServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkConnectAdvanced = new System.Windows.Forms.LinkLabel();
            this.txtPrefUsername = new System.Windows.Forms.TextBox();
            this.txtPrefPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlPrefConnectAdvanced.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrefConnectAdvanced
            // 
            this.pnlPrefConnectAdvanced.Controls.Add(this.txtPrefServerPort);
            this.pnlPrefConnectAdvanced.Controls.Add(this.txtPrefServer);
            this.pnlPrefConnectAdvanced.Controls.Add(this.label1);
            this.pnlPrefConnectAdvanced.Location = new System.Drawing.Point(15, 122);
            this.pnlPrefConnectAdvanced.Name = "pnlPrefConnectAdvanced";
            this.pnlPrefConnectAdvanced.Size = new System.Drawing.Size(310, 61);
            this.pnlPrefConnectAdvanced.TabIndex = 21;
            this.pnlPrefConnectAdvanced.Visible = false;
            // 
            // txtPrefServerPort
            // 
            this.txtPrefServerPort.FormattingEnabled = true;
            this.txtPrefServerPort.Items.AddRange(new object[] {
            "5222"});
            this.txtPrefServerPort.Location = new System.Drawing.Point(232, 7);
            this.txtPrefServerPort.Name = "txtPrefServerPort";
            this.txtPrefServerPort.Size = new System.Drawing.Size(54, 21);
            this.txtPrefServerPort.TabIndex = 11;
            this.txtPrefServerPort.Text = "5222";
            // 
            // txtPrefServer
            // 
            this.txtPrefServer.Location = new System.Drawing.Point(86, 7);
            this.txtPrefServer.Name = "txtPrefServer";
            this.txtPrefServer.Size = new System.Drawing.Size(140, 20);
            this.txtPrefServer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server/Port:";
            // 
            // lnkConnectAdvanced
            // 
            this.lnkConnectAdvanced.AutoSize = true;
            this.lnkConnectAdvanced.Location = new System.Drawing.Point(22, 120);
            this.lnkConnectAdvanced.Name = "lnkConnectAdvanced";
            this.lnkConnectAdvanced.Size = new System.Drawing.Size(65, 13);
            this.lnkConnectAdvanced.TabIndex = 20;
            this.lnkConnectAdvanced.TabStop = true;
            this.lnkConnectAdvanced.Text = "Advanced...";
            // 
            // txtPrefUsername
            // 
            this.txtPrefUsername.Location = new System.Drawing.Point(101, 35);
            this.txtPrefUsername.Name = "txtPrefUsername";
            this.txtPrefUsername.Size = new System.Drawing.Size(200, 20);
            this.txtPrefUsername.TabIndex = 15;
            // 
            // txtPrefPassword
            // 
            this.txtPrefPassword.Location = new System.Drawing.Point(101, 61);
            this.txtPrefPassword.Name = "txtPrefPassword";
            this.txtPrefPassword.PasswordChar = '*';
            this.txtPrefPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPrefPassword.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Jabber ID:";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConnect.Location = new System.Drawing.Point(317, 305);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(105, 22);
            this.btnConnect.TabIndex = 18;
            this.btnConnect.Text = "Connect >";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Password:";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegister.Location = new System.Drawing.Point(20, 305);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(106, 22);
            this.btnRegister.TabIndex = 19;
            this.btnRegister.Text = "New Account";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(428, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 22);
            this.button1.TabIndex = 22;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlPrefConnectAdvanced);
            this.groupBox1.Controls.Add(this.lnkConnectAdvanced);
            this.groupBox1.Controls.Add(this.txtPrefUsername);
            this.groupBox1.Controls.Add(this.txtPrefPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(20, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 208);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 58);
            this.panel1.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(428, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Welcome to miniConf";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(270, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Log in with your XMPP account or register a new one ...";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(529, 339);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Log in";
            this.pnlPrefConnectAdvanced.ResumeLayout(false);
            this.pnlPrefConnectAdvanced.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrefConnectAdvanced;
        private System.Windows.Forms.ComboBox txtPrefServerPort;
        private System.Windows.Forms.TextBox txtPrefServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkConnectAdvanced;
        private System.Windows.Forms.TextBox txtPrefUsername;
        private System.Windows.Forms.TextBox txtPrefPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}