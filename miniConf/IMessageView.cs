using System;
using System.Windows.Forms;

namespace miniConf {
	public delegate void SpecialUrlEvent(string url);
	public enum HistoryNoticeState {
		None,
		LocalAvailable,
		Server
	}
	public static class MessageViewUrls {
		public const string ShowHistory = "special:show_more_history";
		public const string ShowMoreHistory = "special:show_more_more_history";
		public const string LoadServerHistory = "special:load_all";
	}
	public interface IMessageView {

		event SpecialUrlEvent OnSpecialUrl;

		void addMessageToView(ChatMessage message, HtmlElementInsertionOrientation where = HtmlElementInsertionOrientation.BeforeEnd);
		void addMessageToView(string from, string text, DateTime time, string editDt, string jabberId, string id, HtmlElementInsertionOrientation where = HtmlElementInsertionOrientation.BeforeEnd);
        void clear();
        void setHistoryNotice (HistoryNoticeState state);
        void setHistoryNotice (string text);
		bool updateMessage(string oldId, string newId, string newBody, DateTime editTimestamp);
		void loadSmileyTheme();
		void loadStylesheet();
		void addNoticeToView(string text);
		string getLastMessageId(string from);
		void scrollDown();
		void setMessageEditing(string id, bool on);

		string selfNickname { get; set; } 
		bool imagePreview { get; set; } 

	}
}

