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
    public partial class FormNewPalletsOnPallet : FormNewBase, IDrawingContainer, IItemBaseFilter
    {
        #region Constructor
        public FormNewPalletsOnPallet(Document doc, PalletsOnPalletProperties palletsOnPalletProperties)
            : base(doc, palletsOnPalletProperties)
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // graphics3D control
            graphCtrl.DrawingContainer = this;
            // list of pallets
            cbDestinationPallet.Initialize(_document, this, null);
            cbInputPallet1.Initialize(_document, this, null);
            cbInputPallet2.Initialize(_document, this, null);
            cbInputPallet3.Initialize(_document, this, null);
            cbInputPallet4.Initialize(_document, this, null);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        public override void UpdateStatus(string message)
        {
            base.UpdateStatus(message);
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

        #region Handlers
        private void OnPalletLayoutChanged(object sender, EventArgs e)
        {
            bool quarter = rbQuarter.Checked;
            lbInputPallet3.Visible = quarter;
            lbInputPallet4.Visible = quarter;
            cbInputPallet3.Visible = quarter;
            cbInputPallet4.Visible = quarter;
        }
        #endregion
        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (null == DestinationPallet)
                return;
            Pallet pallet = new Pallet(DestinationPallet);
            pallet.Draw(graphics, Transform3D.Identity);

            if ()



            graphics.AddDimensions(new DimensionCube(DestinationPallet.Length, DestinationPallet.Width, DestinationPallet.Height));
        }
        #endregion

        #region Accessors
        private PalletProperties DestinationPallet => cbDestinationPallet.SelectedType as PalletProperties;
        private int Mode => rbHalf.Checked ? 0 : 1;
        #endregion

        #region Data members
        private static readonly ILog _log = LogManager.GetLogger(typeof(FormNewPalletsOnPallet));
        #endregion


    }
}
