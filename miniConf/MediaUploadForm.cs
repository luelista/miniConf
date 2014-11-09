using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class MediaUploadForm : Form {
        string uploadFilename;
        public FileUploader.UploadFileStatus resultStatus;
        public JObject resultObject;

        public MediaUploadForm(string filename) {
            InitializeComponent();
            this.uploadFilename = filename;
        }

        

        private void MediaUploadForm_Load(object sender, EventArgs e) {

        }


        public void startUpload() {
            try {
                pictureBox1.Image = Image.FromFile(uploadFilename);
            } catch (Exception e) { }
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            var result = FileUploader.UploadFile(uploadFilename);
            resultStatus = result.Key;
            resultObject = result.Value;
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (FileUploader.uploadProgress <= progressBar1.Maximum)
                progressBar1.Value = (int)FileUploader.uploadProgress;
            else
                progressBar1.Value = 0;
            progressBar1.Maximum =(int) (FileUploader.uploadMax*1.3);
            progressBar1.Style = (FileUploader.uploadProgress < FileUploader.uploadMax && FileUploader.uploadProgress > 0)
                ? ProgressBarStyle.Continuous : ProgressBarStyle.Marquee;
        }

        private void button1_Click(object sender, EventArgs e) {
            backgroundWorker1.CancelAsync();
        }
    }
}
