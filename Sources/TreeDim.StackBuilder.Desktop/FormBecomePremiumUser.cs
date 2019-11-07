#region Using directives
using System;
using System.Windows.Forms;
using System.Diagnostics;

using log4net;

using treeDiM.PLMPack.DBClient;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormBecomePremiumUser : Form
    {
        #region Constructor
        public FormBecomePremiumUser()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cbPaymentMode.SelectedIndex = 0;
            cbSubscriptionDuration.SelectedIndex = 0;

            using (var wcfClient = new WCFClient())
            {
                Email = wcfClient.User.Email;
            }
        }
        #endregion

        #region Private properties
        private string Email { get => tbEmail.Text; set => tbEmail.Text = value; }
        private int SubscriptionDuration => cbSubscriptionDuration.SelectedIndex;
        private int PaymentMode => cbPaymentMode.SelectedIndex;
        #endregion

        #region Event handler
        private void OnPremiumVsFreeClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            linkLabelPremiumVsFree.LinkVisited = true;
            try { Process.Start(Resources.ID_PREMIUMVERSIONURL); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void OnSendClicked(object sender, EventArgs e)
        {
            try
            {
                // send email via server
                using (var wcfClient = new WCFClient())
                {
                    if (wcfClient.Client.RequestForPremiumAccount(Email, SubscriptionDuration, PaymentMode))
                        Close();
                }
                // ---
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Logging
        private static ILog _log = LogManager.GetLogger(typeof(FormBecomePremiumUser));
        #endregion
    }
}
