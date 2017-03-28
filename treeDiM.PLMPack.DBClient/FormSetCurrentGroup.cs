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

using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.PLMPack.DBClient
{
    public partial class FormSetCurrentGroup : Form
    {
        #region Constructor
        public FormSetCurrentGroup()
        {
            InitializeComponent();
        }
        #endregion

        #region Load / Close
        protected override void OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);

            PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
            // initialize combobox
            cbCurrentGroup.Items.Clear();
            DCGroup[] groups = client.GetUserGroups();
            foreach (DCGroup gp in groups)
            {
                cbCurrentGroup.Items.Add(gp);
                if (gp.ID == client.GetUser().GroupID)
                    cbCurrentGroup.SelectedItem = gp;
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // set current group
            PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
            // initialize combobox
            DCGroup gp = cbCurrentGroup.SelectedItem as DCGroup;
            client.SetCurrentGroup(gp);
 
        }
        #endregion
    }
}
