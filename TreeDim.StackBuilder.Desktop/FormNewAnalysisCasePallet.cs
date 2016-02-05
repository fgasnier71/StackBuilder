#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisCasePallet : FormNewBase
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisCasePallet));
        #endregion

        #region Constructor
        public FormNewAnalysisCasePallet()
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName
        {   get { return Resources.ID_ANALYSIS; } }
        public override void UpdateStatus(string message)
        {
            base.UpdateStatus(message);
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

           BoxProperties[] cases = _document.Boxes.ToArray();
           PalletProperties[] pallets= _document.Pallets.ToArray();

            // fill combo boxes
            ComboBoxHelpers.FillCombo(cases, cbCases, (null != _analysis) ? _analysis.BProperties : cases[0]);
            ComboBoxHelpers.FillCombo(pallets, cbPallets, (null != _analysis) ? _analysis.PalletProperties : pallets[0]);
        }
        #endregion

        #region Data members
        private CasePalletAnalysis _analysis;
        #endregion

        #region Event handlers
        private void onCaseChanged(object sender, EventArgs e)
        {

        }
        private void onPalletChanged(object sender, EventArgs e)
        {

        }
        private void onOverhangChanged(object sender, EventArgs args)
        {

        }
        #endregion



    }
}
