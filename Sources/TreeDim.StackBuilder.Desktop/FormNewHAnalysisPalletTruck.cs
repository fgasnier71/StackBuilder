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

using log4net;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewHAnalysisPalletTruck : FormNewAnalysis, IItemBaseFilter
    {
        #region Constructor
        public FormNewHAnalysisPalletTruck(Document doc, Analysis analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase override
        public override string ItemDefaultName => Resources.ID_ANALYSIS;
        #endregion

        #region Public properties
        public AnalysisHPalletTruck AnalysisCast
        {
            get => _item as AnalysisHPalletTruck;
            set => _item = value;
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbPallets.Initialize(_document, this, null != AnalysisBase ? AnalysisCast.Content[0] : null);
            cbTrucks.Initialize(_document, this, null != AnalysisBase? AnalysisCast.Containers[0] : null);

            if (null == AnalysisBase)
            {
                tbName.Text = _document.GetValidNewAnalysisName(ItemDefaultName);
                tbDescription.Text = tbName.Text;

                uCtrlMinDistanceLoadWall.ValueX = Settings.Default.MinDistancePalletTruckWallX;
                uCtrlMinDistanceLoadWall.ValueY = Settings.Default.MinDistancePalletTruckWallY;
                uCtrlMinDistanceLoadRoof.Value = Settings.Default.MinDistancePalletTruckRoof;
            }
            else
            {
                
            }
        }
        #endregion
        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbPallets)
                return itemBase is LoadedPallet;
            else if (ctrl == cbTrucks)
                return itemBase is TruckProperties;
            return false;
        }
        #endregion
        #region Data members
        private static readonly ILog Log = LogManager.GetLogger(typeof(FormNewHAnalysisPalletTruck));
        #endregion
    }
}
