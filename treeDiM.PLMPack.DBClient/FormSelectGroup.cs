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
    public partial class FormSelectGroup : Form
    {
        #region Constructor
        public FormSelectGroup()
        {
            InitializeComponent();
        }
        #endregion

        #region Load & Close
        protected override void OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);

            // disable OK button
            bnOK.Enabled = false;
            // start timer
            timerCheck.Start();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // stop timer
            timerCheck.Stop();
        }
        #endregion

        #region Public properties
        public string GroupName
        {
            get { return tbGroup.Text; }
        }
        #endregion

        #region Event handlers
        private void onTextChanged(object sender, EventArgs e)
        {
            timerTickCount = 0;
            bnOK.Enabled = false;
        }
        private void onTimerTick(object sender, EventArgs e)
        {
            ++timerTickCount;
            if (timerTickCount > 3)
            {
                // enable button OK if GroupName exist
                bnOK.Enabled = (null != WCFClientSingleton.Instance.Client.GetGroupByName(GroupName));
                timerTickCount = 0;
            }
        }
        #endregion

        #region Data members
        private int timerTickCount = 0;
        #endregion

    }
}
