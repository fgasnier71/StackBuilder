#region Using dirtectives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormSetItemName : Form
    {
        #region Constructor
        public FormSetItemName()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            onItemNameChanged(this, null);
        }
        #endregion

        #region Public properties
        public string ItemName
        {
            get { return tbItemName.Text; }
            set { tbItemName.Text = value; }
        }
        public string TypeName
        {
            get { return "Truck"; }
        }
        #endregion

        #region Event handlers
        private void onItemNameChanged(object sender, EventArgs e)
        {
            string message = string.Empty;

            PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
            if (client.ItemExists(DCSBTypeEnum.TTruck, ItemName))
                message = string.Format(Properties.Resources.ID_NAMEALREADYEXISTSINDB, TypeName, ItemName);

            statusLbl.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            statusLbl.Text = string.IsNullOrEmpty(message) ? Properties.Resources.ID_READY : message;
            bnOK.Enabled = string.IsNullOrEmpty(message);
        }
        #endregion

        #region Data member
        #endregion
    }
}
