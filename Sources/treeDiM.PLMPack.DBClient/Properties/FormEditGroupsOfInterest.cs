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

using PLMPackLibClient.PLMPackSR;
#endregion

namespace PLMPackLibClient
{
    public partial class FormEditGroupsOfInterest : Form
    {
        #region Constructor
        public FormEditGroupsOfInterest()
        {
            InitializeComponent();
        }
        #endregion

        #region Load / Close
        protected override void OnLoad(EventArgs e)
        {
 	         base.OnLoad(e);

             Refill();
        }
        #endregion

        #region Handlers
        private void onToGroups(object sender, EventArgs e)
        {
            int iSel = lbGroupsOfInterest.SelectedIndex;
            if (-1 == iSel) return;
            DCGroup gp = lbGroupsOfInterest.Items[iSel] as DCGroup;

            PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
            client.RemoveInterest(gp.ID);

            Refill();
        }
        private void onToInterest(object sender, EventArgs e)
        {
            int iSel = lbGroups.SelectedIndex;
            if (-1 == iSel) return;
            DCGroup gp = lbGroups.Items[iSel] as DCGroup;

            PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
            client.AddInterest(gp.ID);

            Refill();
        }
        private void onShowAllGroups(object sender, EventArgs e)
        {
            Refill();
        }
        #endregion

        #region Helpers
        private void Refill()
        {
            PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
            // groups of interest
            lbGroupsOfInterest.Items.Clear();
            lbGroups.Items.Clear();
            // get list of groups
            DCGroup[] groupsOfInterest = null, groupsOther = null;
            client.GetGroupsList(chkbAllGroups.Checked, ref groupsOfInterest, ref groupsOther);
            // fill list box
            foreach (DCGroup grp in groupsOfInterest)
                lbGroupsOfInterest.Items.Add(grp);
            foreach (DCGroup grp in groupsOther)
                lbGroups.Items.Add(grp);
        }
        #endregion




    }
}
