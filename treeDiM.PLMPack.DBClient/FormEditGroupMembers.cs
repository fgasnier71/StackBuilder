#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// logging
using log4net;

using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.PLMPack.DBClient
{
    public partial class FormEditGroupMembers : Form
    {
        #region Constructor
        public FormEditGroupMembers()
        {
            InitializeComponent();
        }
        #endregion

        #region Load & close
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // fill user list
            FillUserList();
        }

        private void FillUserList()
        {
            // clear all existing items
            listboxUsers.Items.Clear();
            // load all users of group
            PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
            DCGroup gp = client.GetCurrentGroup();
            foreach (DCUser user in gp.Members)
                listboxUsers.Items.Add(user);
            // select first item
            if (listboxUsers.Items.Count > 0)
                listboxUsers.SelectedIndex = 0;
        }
        #endregion

        #region Event handlers
        private void onUserAdd(object sender, EventArgs e)
        {
            try
            {
                // does user belong to group ?
                foreach (object o in listboxUsers.Items)
                {
                    DCUser user = o as DCUser;
                    if (null != user && string.Equals(tbUserToAdd.Text, user.Name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        MessageBox.Show(string.Format("User '{0}' already member of group {1}!", user.Name));
                        return;
                    }
                }
                PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
                // does user exist
                if (!client.UserExists(tbUserToAdd.Text))
                {
                    MessageBox.Show(string.Format("User '{0}' does not exist!"));
                    return;
                }
                // add user to group
                client.AddUserToCurrentGroup(tbUserToAdd.Text);

                tbUserToAdd.Text = string.Empty;
                FillUserList();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void onUserRemove(object sender, EventArgs e)
        {
            PLMPackServiceClient client = WCFClientSingleton.Instance.Client;

            // remove selected user from group
            DCUser user = listboxUsers.SelectedItem as DCUser;
            if (null != user)
                client.RemoveUserFromCurrentGroup(user);

            FillUserList();
        }

        private void onUpdateUI(object sender, EventArgs e)
        {
            bnAdd.Enabled = AddAllowed;
            bnRemove.Enabled = RemoveAllowed;

            lbUserToRemove.Text = SelectedUser != null ? SelectedUser.Name : string.Empty;
        }
        #endregion

        #region Properties
        private bool AddAllowed
        {
            get
            {
                if (string.IsNullOrEmpty(tbUserToAdd.Text))
                    return false;
                foreach (object o in listboxUsers.Items)
                {                
                }
                return true;
            }
        }
        private bool RemoveAllowed
        {
            get
            {
                DCUser user = SelectedUser;
                if (null == user) return false;

                if (string.Equals(user.ID, WCFClientSingleton.Instance.User.ID))
                    return false;
                return true;
            }
        }
        private DCUser SelectedUser
        {
            get { return listboxUsers.SelectedItem as DCUser; }
        }
        #endregion

        #region Data members
        protected ILog _log = LogManager.GetLogger(typeof(FormEditGroupMembers));
        #endregion
    }
}
