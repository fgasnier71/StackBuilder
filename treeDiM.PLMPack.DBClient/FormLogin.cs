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
using System.Diagnostics;

using log4net;

using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.PLMPack.DBClient
{
    public partial class FormLogin : Form
    {
        #region Constructor
        public FormLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public string UserName
        {
            set { tbUserName.Text = value; }
            get { return tbUserName.Text; }
        }
        public string Password
        {
            set { tbPassword.Text = value; }
            get { return tbPassword.Text; }
        }
        #endregion

        #region Event handlers
        private void bnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                FormRegister form = new FormRegister();
                if (DialogResult.OK == form.ShowDialog())
                {
                    UserName = form.UserName;
                    Password = form.UserPassword;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void onForgotPassword(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Properties.Settings.Default.ForgotPasswordURL);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Data members
        protected static ILog _log = LogManager.GetLogger(typeof(FormLogin));
        #endregion
    }
}
