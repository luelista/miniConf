using System;
using System.Windows.Forms;

namespace miniConf {
	/**
	 * Implements some methods from Microsoft.VisualBasic namespace for Mono compat.
	 * */
	public class VbHelper {
		private VbHelper () {
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
			Form f = new Form (); f.Text = title;
			f.Width = 200;
			f.Height = 100;
			TextBox t = new TextBox (); t.Text = defaultValue;
			f.Controls.Add (t);
			t.Top = 10; t.Left = 10; t.Width = 180;
			Button ok = new Button (); ok.Text = "  OK  ";
			ok.Click += (object sender, EventArgs e) => {
				result = t.Text;
				f.Hide();
			};
			f.ShowDialog ();
			return result;
		}

	}
}

