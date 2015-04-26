using System;
using System.Windows.Forms;

namespace miniConf {
	/**
	 * Implements some methods from Microsoft.VisualBasic namespace for Mono compat.
	 * */
	public class VbHelper {
		private VbHelper () {
		}


        public static IMessageView createMessageView() {
            if (!runningOnMono()) {
                MessageView browser = new MessageView ();
                browser.imagePreview = true;
                browser.Dock = DockStyle.Fill;
                //browser.Url = new System.Uri("about:blank", System.UriKind.Absolute);
                return browser;
            } else {
                MessageViewStub stub = new MessageViewStub ();
                stub.Dock = DockStyle.Fill;
                return stub;
            }
        }

		public static bool runningOnMono() {
			return Type.GetType ("Mono.Runtime") != null;
		}

		public static string[] Split(string haystack, string needle) {
			if (String.IsNullOrEmpty (haystack))
				return new string[]{ };
			return haystack.Split (new string[]{ needle }, StringSplitOptions.None);
		}

		public static string Replace(string input, string needle, string replacement) {
			if (String.IsNullOrEmpty (input))
				return "";
			return input.Replace (needle, replacement);
		}

		public static string InputBox(string prompt, string title="Input", string defaultValue = "") {
			string result = null;
			Form f = new Form (); f.Text = title; f.FormBorderStyle = FormBorderStyle.FixedDialog; f.StartPosition = FormStartPosition.CenterParent;
			f.Width = 200;
			f.Height = 100;
			TextBox t = new TextBox (); t.Text = defaultValue;
			f.Controls.Add (t);
			t.Top = 10; t.Left = 10; t.Width = 180;
			Button ok = new Button (); ok.Text = "  OK  ";
			ok.Click += (object sender, EventArgs e) => {
				result = t.Text;
				f.Close();
			};
			f.Controls.Add (ok);
			ok.Top = 50; ok.Left = 70;
			f.AcceptButton = ok;
			f.ShowDialog ();
			return result;
		}

	}
}

