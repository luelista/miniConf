using System;
using System.Collections.Generic;

using System.Text;

namespace miniConf {
    static class ApplicationPreferences {

        public static string[] getUsername() {
            string[] username = AccountJID.Split('@');
            if (username.Length != 2) return null;
            if (String.IsNullOrEmpty(ApplicationPreferences.Nickname))
                ApplicationPreferences.Nickname = username[0];
            //if (!string.IsNullOrEmpty(ApplicationPreferences.AccountServer)) username[1] = ApplicationPreferences.AccountServer;
            return username;
        }

        public static string FileUploadServiceUrl {
            get { return Program.glob.para("Form1__cmbFileUploadService", "https://chat2.teamwiki.de"); }
            set { Program.glob.setPara("Form1__cmbFileUploadService", value); }
        }
        public static int FileUploadMaxSize {
            get { try { return int.Parse(Program.glob.para("FileUploadMaxSize", "1048576")); } catch { return 1048576; } }
            set { Program.glob.setPara("FileUploadMaxSize", value.ToString()); }
        }

        public static bool FiletransferAutoAccept {
            get { return Program.glob.para("Form1__chkFiletransferAutoAccept", "TRUE") == "TRUE"; }
            set {     Program.glob.setPara("Form1__chkFiletransferAutoAccept", value ? "TRUE" : "FALSE"); }
        }

        public static string AccountJID {
            get { return Program.glob.para("account__JID", ""); }
            set {     Program.glob.setPara("account__JID", value); }
        }
        
        public static string AccountPassword {
            get { return Program.glob.para("account__Password", ""); }
            set {     Program.glob.setPara("account__Password", value); }
        }

        public static string AccountPort {
            get { return Program.glob.para("account__Port", "5222"); }
            set {     Program.glob.setPara("account__Port", value); }
        }

        public static string AccountServer {
            get { return Program.glob.para("account__Server", ""); }
            set {     Program.glob.setPara("account__Server", value); }
        }

        public static string Nickname {
            get { return Program.glob.para("Form1__txtNickname", ""); }
            set {     Program.glob.setPara("Form1__txtNickname", value); }
        }


        public static bool RememberPassword {
            get { return Program.glob.para("account__RememberPassword", "TRUE") == "TRUE"; }
            set { Program.glob.setPara("account__RememberPassword", value ? "TRUE" : "FALSE"); }
        }
        public static bool AlwaysAskForNickname {
            get { return Program.glob.para("account__AlwaysAskForNickname", "FALSE") == "TRUE"; }
            set { Program.glob.setPara("account__AlwaysAskForNickname", value ? "TRUE" : "FALSE"); }
        }
        public static bool Sternchen {
            get { return Program.glob.para("Form1__chkSternchen", "FALSE") == "TRUE"; }
            set { Program.glob.setPara("Form1__chkSternchen", value ? "TRUE" : "FALSE"); }
        }
        public static bool DisplayOccupantStatus {
            get { return Program.glob.para("Form1__chkDisplayOccupantStatus", "FALSE") == "TRUE"; }
            set {     Program.glob.setPara("Form1__chkDisplayOccupantStatus", value ? "TRUE" : "FALSE"); }
        }
        public static bool EnableImagePreview {
            get { return Program.glob.para("Form1__chkEnableImagePreview", "TRUE") == "TRUE"; }
            set { Program.glob.setPara("Form1__chkEnableImagePreview", value ? "TRUE" : "FALSE"); }
        }
        /**
         * <summary>Enable Workarounds for better Wine compatibility</summary>
         **/
        public static bool WineTricks {
            get { return Program.glob.para("WineTricks", "FALSE") == "TRUE"; }
            set { Program.glob.setPara("WineTricks", value ? "TRUE" : "FALSE"); }
        }
        
        
        public static string ChatTheme {
            get { return Program.glob.para("Form1__comboMessageTheme", "Default"); }
            set {     Program.glob.setPara("Form1__comboMessageTheme", value); }
        }

        public static string SmileyTheme {
            get { return Program.glob.para("Form1__cmbSmileyTheme", ""); }
            set {     Program.glob.setPara("Form1__cmbSmileyTheme", value); }
        }

        public static bool TodoListTopmost {
            get { return Program.glob.para("TodoListTopmost", "TRUE") == "TRUE"; }
            set { Program.glob.setPara("TodoListTopmost", value ? "TRUE" : "FALSE"); }
        }
        
    }
}
