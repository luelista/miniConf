using System;
using System.Windows.Forms;

namespace miniConf {
	public class MessageViewStub : TextBox, IMessageView{

		public DateTime lastTimeTop=DateTime.MinValue, lastTimeBottom=DateTime.MinValue;

		public MessageViewStub () {
			this.Multiline = true;
			this.ScrollBars = ScrollBars.Vertical;
		}


		protected override void OnKeyDown (KeyEventArgs e) {
			if (e.KeyCode == Keys.F3) {
				if (e.Control || e.Shift || e.Alt) {
					OnSpecialUrl (MessageViewUrls.ShowMoreHistory);
				} else {
					OnSpecialUrl (MessageViewUrls.ShowHistory);
				}
				this.Refresh ();
			}
			base.OnKeyDown (e);
		}


		protected bool updateLastTime(HtmlElementInsertionOrientation where, DateTime newTime) {
			if (lastTimeTop == DateTime.MinValue && lastTimeBottom == DateTime.MinValue) {
				this.Select (this.Lines [0].Length + 1, this.Lines [1].Length);
				this.SelectedText = newTime.ToLongDateString();
				lastTimeBottom = newTime; lastTimeTop = newTime; return true;
			}
			if (where == HtmlElementInsertionOrientation.AfterBegin) {
				if (lastTimeTop.Date != newTime.Date) {
					addDateToView(lastTimeTop.ToLongDateString(), where);
					this.Select (this.Lines [0].Length + 1, this.Lines [1].Length);
					this.SelectedText = newTime.ToLongDateString();
					lastTimeTop = newTime;
					return true;
				} else {
					return false;
				}
			} else {
				if (lastTimeBottom.Date != newTime.Date) {
					addDateToView(newTime.ToLongDateString(), where);
					lastTimeBottom = newTime;
					return true;
				} else {
					return false;
				}
			}
		}

		protected void addText(string text, HtmlElementInsertionOrientation where) {
			switch (where) {
			case HtmlElementInsertionOrientation.BeforeEnd:
				this.AppendText (text + "\n");
				break;
			case HtmlElementInsertionOrientation.AfterBegin:
				this.Select (this.Lines [0].Length + this.Lines [1].Length + 2, 0);
				this.SelectedText = text + "\n";
				break;
			default:
				throw new NotImplementedException ();
			}
		}

		protected void addDateToView(string text, HtmlElementInsertionOrientation where) {
			addText( "* " + text + "", where);
		}

		#region IMessageView implementation

		public event SpecialUrlEvent OnSpecialUrl;

		public string selfNickname { get; set; }
		public bool imagePreview { get; set; } 

		public void addMessageToView (ChatMessage message, System.Windows.Forms.HtmlElementInsertionOrientation where = System.Windows.Forms.HtmlElementInsertionOrientation.BeforeEnd) {
			addMessageToView(message.Sender, message.Body, message.Date, message.Editdt, 
				message.SenderJid, message.Id, where);
		}

		public void addMessageToView (string from, string text, DateTime time, string editDt, string jabberId, string id, System.Windows.Forms.HtmlElementInsertionOrientation where = System.Windows.Forms.HtmlElementInsertionOrientation.BeforeEnd) {
			updateLastTime (where, time);
			string str = "[" + time.ToShortTimeString() + "] " + from + ": " + text;
			if (!String.IsNullOrEmpty (editDt))
				str += " <edited " + editDt + ">";
			addText (str, where);
		}

		public void setHistoryNotice (HistoryNoticeState state) {
			this.Select (0, this.Lines [0].Length);
			switch (state) {
			case HistoryNoticeState.None:
				this.SelectedText = "...";
				break;
			case HistoryNoticeState.LocalAvailable:
				this.SelectedText = "Press [F3] to show history";
				break;
			case HistoryNoticeState.Server:
				this.SelectedText= "End of local history | Press [F3] to try and load history from server";
				break;
			}
		}

		public void clear () {
			this.Text = "Press [F3] to show history\n\n";
			lastTimeTop = DateTime.MinValue;
			lastTimeBottom = DateTime.MinValue;
		}

		public bool updateMessage (string oldId, string newId, string newBody, DateTime editTimestamp) {
			// Not implemented
			return false;
		}

		public void loadSmileyTheme () {
			// Not implemented
		}

		public void loadStylesheet () {
			// Not implemented
		}

		public void addNoticeToView (string text) {
			this.AppendText ("Notice: " + text + "\n");
		}

		public string getLastMessageId (string from) {
			return null;
		}

		public void scrollDown () {
			this.Select (this.TextLength + 1, 0);
			this.ScrollToCaret ();
		}

		public void setMessageEditing (string id, bool on) {
			throw new NotImplementedException ();
		}

		#endregion

	}
}

