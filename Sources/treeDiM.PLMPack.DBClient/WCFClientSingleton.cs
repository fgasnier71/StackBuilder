#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// logging
using log4net;
// web service
using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.PLMPack.DBClient
{
    public class WCFClientSingleton
    {
        #region Private constructor (Singleton)
        private WCFClientSingleton()
        {
        }
        #endregion

        #region Accessing singleton instance & properties
        public static WCFClientSingleton Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new WCFClientSingleton();
                    _instance._client = new PLMPackServiceClient();
                    while (!_instance.Connect()) { }
                    if (null == _instance._user)
                        Application.Exit();
                }
                return _instance;
            }
        }
        public PLMPackServiceClient Client
        { get { return _client; } }
        public DCUser User
        { get { return _user; } }
        public Guid CurrentGroupID
        { get { return Guid.Parse(_user.GroupID); } }
        public static PLMPackServiceClient ClientGuest
        {
            get
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
                                ((sender, certificate, chain, sslPolicyErrors) => true);

                PLMPackServiceClient client = new PLMPackServiceClient();
                client.ClientCredentials.UserName.UserName = "guest";
                client.ClientCredentials.UserName.Password = "guest_";
                return client;
            }
        }
        #endregion

        #region Connection
        private bool Connect()
        {
            if (Connect(Properties.Settings.Default.CredentialUserName, Properties.Settings.Default.CredentialPassword))
                return true;

            FormLogin form = new FormLogin();
            form.UserName = Properties.Settings.Default.CredentialUserName;
            form.Password = Properties.Settings.Default.CredentialPassword;
            if (DialogResult.OK == form.ShowDialog())
            {
                string userName = form.UserName;

                // try and convert email to user name
                if (form.UserName.Contains('@'))
                {
                    string email = form.UserName;
                    userName = ClientGuest.EmailToUserName(email);
                    // if userName is null/empty, email does not exist
                    if ( string.IsNullOrEmpty(userName) )
                        MessageBox.Show( string.Format(Properties.Resources.ID_EMAILDOESNOTEXIST, email) );
                }
                return Connect(userName, form.Password);
            }
            else
            {
                _log.Info("User cancelled connection!");
                return true;
            }
        }

        public bool Connect(string userName, string password)
        {
            // check for empty userName or password
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return false;
            // show wait cursor
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                const int maxRetry = 5;
                int retryCount = 0;
                bool success = false;
                // this loop to handle timeout exception
                // that usually occurs when calling the software for the first time in a period of time
                while (!success && retryCount < maxRetry)
                {
                    try
                    {
                        System.Net.ServicePointManager.ServerCertificateValidationCallback =
                            ((sender, certificate, chain, sslPolicyErrors) => true);
                        // try to connect using user credentials
                        _client = new PLMPackServiceClient();
                        _client.ClientCredentials.UserName.UserName = userName;
                        _client.ClientCredentials.UserName.Password = password;
                        _user = _client.Connect();
                        success = true;
                    }
                    catch (System.TimeoutException ex)
                    {
                        ++retryCount;
                        _log.Warn(ex.Message);
                        if (maxRetry == retryCount)
                            if (DialogResult.Yes == MessageBox.Show("Had a timeout exception. Retry?", Application.ProductName, MessageBoxButtons.YesNo))
                                retryCount = 0;
                    }
                    catch (System.ServiceModel.Security.MessageSecurityException ex)
                    {
                        ++retryCount;
                        _log.Error(ex.InnerException.ToString());
                        MessageBox.Show(ex.InnerException.Message);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed!");
                _log.Error(ex.ToString());
                return false;
            }
            // hide wait cursor
            Cursor.Current = Cursors.WaitCursor;

            // login successful -> save user credentials
            Properties.Settings.Default.CredentialUserName = userName;
            Properties.Settings.Default.CredentialPassword = password;
            Properties.Settings.Default.Save();

            if (null != _user)
                _log.Info(string.Format("User connected as {0}", _user.Name));

            if (null != Connected)
                Connected();

            return true;
        }

        public void Reconnect()
        {
            try
            {
                _log.Info("Disconnecting...");
                _client.DisConnect();

                _client = new PLMPackServiceClient();

                // try to connect using user credentials
                _client.ClientCredentials.UserName.UserName = Properties.Settings.Default.CredentialUserName;
                _client.ClientCredentials.UserName.Password = Properties.Settings.Default.CredentialPassword;
                _user = _client.Connect();
                _log.Info(string.Format("Reconnected as {0}", _user.Name));
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        public static void Disconnect()
        {
            try
            {
                _log.Info("Disconnecting...");
                if (null != Disconnected)
                    Disconnected();
                if (null != _instance)
                {
                    _instance._client.DisConnect();
                    _instance = null;
                }
                _log.Info("Disconnected!");
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        public static void DisconnectFull()
        {
            Disconnect();
            // delete userName / password settings
            Properties.Settings.Default.CredentialUserName = string.Empty;
            Properties.Settings.Default.CredentialPassword = string.Empty;
            Properties.Settings.Default.Save();
            // try to instantiate
            WCFClientSingleton singleton = WCFClientSingleton.Instance;
        }
        public static bool IsConnected
        {
            get { return (null != _instance) && (null != Instance.User); }
        }
        #endregion

        #region Delegate
        public delegate void ConnectionHandler();
        #endregion

        #region Data members
        // non static data members
        private PLMPackServiceClient _client;
        private DCUser _user;
        // static data members
        protected static WCFClientSingleton _instance;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(WCFClientSingleton));
        // events
        public static event ConnectionHandler Connected;
        public static event ConnectionHandler Disconnected;
        #endregion
    }
}
