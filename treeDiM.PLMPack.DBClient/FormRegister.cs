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
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

using log4net;

using treeDiM.PLMPack.DBClient.Properties;
using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.PLMPack.DBClient
{
    public partial class FormRegister : Form
    {
        #region Constructor
        public FormRegister()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PopulateCountryComboBox();

            onValueChanged(this, null);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.Cancel)
            {
                try
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback =
                                        ((sender, certificate, chain, sslPolicyErrors) => true);

                    PLMPackServiceClient client = WCFClientSingleton.ClientGuest;
                    if (null != client.Connect())
                        e.Cancel = true;

                    string userName = client.EmailToUserName(Email);
                    string email = client.UserNameToEmail(UserName);

                    if (!string.IsNullOrEmpty(userName))
                    {
                        MessageBox.Show(string.Format(Properties.Resources.ID_EMAILALREADYUSED, Email));
                        e.Cancel = true;
                    }
                    else if (!string.IsNullOrEmpty(email))
                    {
                        MessageBox.Show(string.Format(Properties.Resources.ID_USERNAMEALREADYUSED, UserName));
                        e.Cancel = true;
                    }
                    else if (client.CreateUser(UserName, UserPassword, FirstName, LastName, Email, Country, City, PhoneNumber, Company, WebSiteURL))
                    {
                        MessageBox.Show(string.Format(Properties.Resources.ID_USERSUCCESSFULLYCREATED, UserName));
                        e.Cancel = false;
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message);
                }
            }
 	        base.OnClosing(e);
        }
        #endregion

        #region Public properties
        public string UserName        { get { return tbUserName.Text; } }
        public string UserPassword    { get { return tbPassword.Text; } }
        public string Email           { get { return tbEmail.Text; } }
        public string FirstName       { get { return tbFirstName.Text; } }
        public string LastName        { get { return tbLastName.Text; } }
        public string City            { get { return tbCity.Text; } }
        public string Country         { get { return cbCountry.SelectedText; } }
        public string PhoneNumber     { get { return tbPhoneNumber.Text; } }
        public string Company         { get { return tbCompany.Text; } }
        public string WebSiteURL      { get { return tbWebSite.Text; } }
        #endregion

        #region Helpers
        private bool ValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
        private bool ValidUserName(string userName)
        { 
            return regex.IsMatch(userName);
        }
        private void PopulateCountryComboBox()
        {
            // build list of countries
            RegionInfo country = new RegionInfo(new CultureInfo("en-US", false).LCID);
            List<string> countryNames = new List<string>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                countryNames.Add(country.DisplayName.ToString());
            }
            // get curreent contry
            string currentCountry = new RegionInfo( CultureInfo.CurrentCulture.LCID ).DisplayName.ToString();
            // sort countries
            IEnumerable<string> nameAdded = countryNames.OrderBy(names => names).Distinct();
            int index = -1, i = 0; ;
            // fill combo box
            foreach (string item in nameAdded)
            {
                cbCountry.Items.Add(item);
                if (string.Equals(item, currentCountry, StringComparison.CurrentCultureIgnoreCase))
                    index = i;
                ++i;
            }
            cbCountry.SelectedIndex = index;
        }
        #endregion

        #region Event handlers
        private void onValueChanged(object sender, EventArgs e)
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(Email) || !ValidEmail(Email))
                message = Resources.ID_VALIDEMAILREQUIRED;
            else if (string.IsNullOrEmpty(UserName))
                message = Resources.ID_USERNAMEREQUIRED;
            else if (!ValidUserName(UserName))
                message = Resources.ID_VALIDUSERNAMEREQUIRED;
            else if (string.IsNullOrEmpty(UserPassword) || (UserPassword.Length < 6))
                message = Resources.ID_VALIDPASSWORDREQUIRED;
            else if (!string.Equals(UserPassword, tbPasswordConfirm.Text))
                message = Resources.ID_PASSWORDCONFIRMATIONREQUIRED;

            bool isReady = string.IsNullOrEmpty(message);
            toolStripStatusLabelDef.ForeColor = isReady ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = isReady ? Resources.ID_READY : message;
            bnOK.Enabled = isReady;
        }
        #endregion

        #region Data members
        private static Regex regex = new Regex(
              @"^(?=.{3,32}$)(?!.*[._-]{2})(?!.*[0-9]{5,})[a-z](?:[\w]*|[a-z\d\.]*|[a-z\d-]*)[a-z0-9]$",
            RegexOptions.IgnoreCase
            | RegexOptions.CultureInvariant
            | RegexOptions.IgnorePatternWhitespace
            | RegexOptions.Compiled
            );
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormRegister));
        #endregion
    }
}
