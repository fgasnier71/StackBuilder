#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisPalletsOnPallet : FormNewAnalysis, IDrawingContainer, IItemBaseFilter
    {
        #region Constructor
        public FormNewAnalysisPalletsOnPallet(Document doc, AnalysisPalletsOnPallet analysisPalletsOnPallet)
            : base(doc, analysisPalletsOnPallet)
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (null != _item)
            {
                tbName.Text = _item.Name;
                tbDescription.Text = _item.Description;
            }
            else if (null != _document)
            {
                tbName.Text = _document.GetValidNewAnalysisName(ItemDefaultName);
                tbDescription.Text = tbName.Text;
            }
            // graphics3D control
            graphCtrl.DrawingContainer = this;
            // list of pallets
            cbDestinationPallet.Initialize(_document, this, null);
            cbInputPallet1.Initialize(_document, this, null);
            cbInputPallet2.Initialize(_document, this, null);
            cbInputPallet3.Initialize(_document, this, null);
            cbInputPallet4.Initialize(_document, this, null);

            rbHalf.Checked = true;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        public override void UpdateStatus(string message)
        {
            if (!Program.IsSubscribed)
                message = Resources.ID_GOPREMIUMORUNSELECT;
            base.UpdateStatus(message);
        }
        public override void OnNext()
        {
            try
            {
                AnalysisPalletsOnPallet analysis = AnalysisCast;
                if (null == analysis)
                {
                    _item = _document.CreateNewAnalysisPalletsOnPallet(
                        ItemName, ItemDescription
                        , MasterPallet
                        , LoadedPallet0
                        , LoadedPallet1
                        , 1 == Mode ? LoadedPallet2 : null
                        , 1 == Mode ? LoadedPallet3 : null);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            base.OnNext();
            Close();
        }
        #endregion

        #region FormNewBase override
        public override string ItemDefaultName => Resources.ID_PALLET;
        #endregion

        #region IItemBaseFilter
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbDestinationPallet)
                return itemBase is PalletProperties;
            else if (ctrl == cbInputPallet1
                || ctrl == cbInputPallet2
                || ctrl == cbInputPallet3
                || ctrl == cbInputPallet4)
                return itemBase is LoadedPallet;
            return false;
        }
        #endregion

        #region Public properties
        public AnalysisPalletsOnPallet AnalysisCast
        { get => _item as AnalysisPalletsOnPallet;  }
        #endregion

        #region Handlers
        private void OnPalletLayoutChanged(object sender, EventArgs e)
        {
            bool quarter = rbQuarter.Checked;
            lbInputPallet3.Visible = quarter;
            lbInputPallet4.Visible = quarter;
            cbInputPallet3.Visible = quarter;
            cbInputPallet4.Visible = quarter;
        }
        private void OnInputChanged(object sender, EventArgs e)
        {
            graphCtrl.Invalidate();
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (null == MasterPallet || null == LoadedPallet0 || null == LoadedPallet1)
                return;

            var analysis = new AnalysisPalletsOnPallet(null, MasterPallet,
                LoadedPallet0,
                LoadedPallet1,
                1 == Mode ? LoadedPallet2 : null,
                1 == Mode ? LoadedPallet3 : null);

            if (!analysis.HasValidSolution) return;

            var viewer = new ViewerSolutionPalletsOnPallet(analysis.Solution);
            viewer.Draw(graphics, Transform3D.Identity);
        }
        #endregion

        #region Accessors
        private PalletProperties MasterPallet => cbDestinationPallet.SelectedType as PalletProperties;
        private LoadedPallet LoadedPallet0 => cbInputPallet1.SelectedType as LoadedPallet;
        private LoadedPallet LoadedPallet1 => cbInputPallet2.SelectedType as LoadedPallet;
        private LoadedPallet LoadedPallet2 => cbInputPallet3.SelectedType as LoadedPallet;
        private LoadedPallet LoadedPallet3 => cbInputPallet4.SelectedType as LoadedPallet;
        private int Mode => rbHalf.Checked ? 0 : 1;
        #endregion

        #region Data members
        private static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisPalletsOnPallet));
        #endregion
    }
}
