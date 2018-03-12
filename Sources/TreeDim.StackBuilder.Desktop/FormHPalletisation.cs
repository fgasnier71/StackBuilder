#region Using directives
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormHPalletisation : FormNewHAnalysis, IItemBaseFilter
    {
        #region Constructor
        public FormHPalletisation()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbPallets.Initialize(_document, this, AnalysisCast?.Containers.FirstOrDefault());
        }
        #endregion

        #region ItemBaseFilter override
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            return true;
        }
        #endregion

        #region Event handlers
        private void OnInputChanged(object sender, EventArgs e)
        {

        }
        private void OnCaseAdded(object sender, EventArgs e)
        {

        }
        #endregion

        #region Helpers
        #region Public properties
        public HAnalysis AnalysisCast
        {
            get { return _analysis as HAnalysis; }
            set { _analysis = value; }
        }


        #endregion

        private List<BoxProperties> BuildListOfCases()
        {
            List<BoxProperties> listCases = new List<BoxProperties>();
            return listCases;
        }
        #endregion


    }
}
