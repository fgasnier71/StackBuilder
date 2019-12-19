#region Using directives
using System;
using System.Windows.Forms;

using log4net;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisHCylTruck : FormNewAnalysis, IItemBaseFilter
    {
        public FormNewAnalysisHCylTruck() : base() => InitializeComponent();
        public FormNewAnalysisHCylTruck(Document doc, AnalysisHCylTruck analysis) : base(doc, analysis) => InitializeComponent();

        #region IItemBaseFilter
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbCylinders)
                return itemBase is CylinderProperties;
            else if (ctrl == cbTrucks)
                return itemBase is TruckProperties;
            else
                return false;
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbCylinders.Initialize(_document, this, null);
            cbTrucks.Initialize(_document, this, null);

            // event handling
            if (null == AnalysisBase)
            {
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
        #endregion

        #region Data members
        protected ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisHCylTruck));
        #endregion
    }
}
