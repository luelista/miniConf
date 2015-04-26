using agsXMPP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public partial class InvitationForm : Form {

        public enum InvitationType {
            ChatroomInvite,
            FriendRequest
        }

        public InvitationType type;
        public Jid invitedTo;
        public Jid invitedBy;

        public void setChatroomInvite(Jid sender, Jid roomJid) {
            type = InvitationType.ChatroomInvite;
            invitedTo = roomJid;
            invitedBy = sender;
            Text = "Conference invitation";
            label1.Text = roomJid.Bare;
            label2.Text = sender.Bare + " invited you to join this conference.";

        }
        public void setContactRequest(Jid contact) {
            type = InvitationType.FriendRequest;
            invitedTo = contact;
            Text = "Contact request";
            label1.Text = contact.Bare;
            label2.Text = contact.Bare + " sent you a request to add them to your contact list.";
        }
        public void setContactSubscriptionApproved(Jid contact) {
            Text = "Request approved";
            label1.Text = contact.Bare + " accepted";
            label2.Text = contact.Bare + " accepted your contact request. You'll be able to see their online status now.";
            btnAccept.Visible = false; button2.Text = "OK";
        }
        public void setContactSubscriptionCancelled(Jid contact) {
            Text = "Subscription cancelled";
            label1.Text = contact.Bare + " cancelled your subscription";
            label2.Text = "You will no longer see the online status of "+contact.Bare + ".";
            btnAccept.Visible = false; button2.Text = "OK";
        }
        public void setContactUnsubscribe(Jid contact) {
            Text = "Removal from contact list";
            label1.Text = contact.Bare + " ";
            label2.Text = "unsubscribed from your online status. The reason could be that they removed you from their contact list.";
            btnAccept.Visible = false; button2.Text = "OK";
        }

        public InvitationForm() {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            switch (type) {
                case InvitationType.ChatroomInvite:
                    Program.MainWnd.joinChatroom(invitedTo.Bare);
                    this.Close();
                    break;
                case InvitationType.FriendRequest:
                    Program.Jabber.addContact(invitedTo);
                    this.Close();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void InvitationForm_Load(object sender, EventArgs e) {

        }
    }
}
