#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;

using log4net;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewPalletFilm : FormNewBase
    {
        #region Constructor
        public FormNewPalletFilm(Document doc, PalletFilmProperties item)
            : base(doc, item)
        {
            InitializeComponent();

            if (null != item)
            {
                chkbTransparency.Checked = item.UseTransparency;
                chkbHatching.Checked = item.UseHatching;
                HatchSpacing = UnitsManager.ConvertLengthFrom(item.HatchSpacing, UnitsManager.UnitSystem.UNIT_METRIC1);
                HatchAngle = item.HatchAngle;
                FilmColor = item.Color;
                LinearWeight = 0.0;
            }
            else
            {
                chkbTransparency.Checked = true;
                chkbHatching.Checked = true;
                HatchSpacing = UnitsManager.ConvertLengthFrom(150.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                HatchAngle = 45.0;
                FilmColor = Color.LightSkyBlue;
            }
            OnChkbHatchingCheckedChanged(this, null);
            UpdateStatus(string.Empty);
            // units
            UnitsManager.AdaptUnitLabels(this);
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName => Resources.ID_PALLETFILM; 
        public override void UpdateStatus(string message)
        {
            if (!UseTransparency && !UseHatching)
                message = Resources.ID_USETRANSPARENCYORHATCHING;

            base.UpdateStatus(message);
        }
        #endregion

        #region Form overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #endregion

        #region Public properties
        public Color FilmColor
        {
            get { return cbColor.Color; }
            set { cbColor.Color = value; }
        }
        public bool UseTransparency
        {
            get { return chkbTransparency.Checked; }
            set { chkbTransparency.Checked = value; }
        }
        public bool UseHatching
        {
            get { return chkbHatching.Checked; }
            set { chkbHatching.Checked = value; }
        }
        public double HatchSpacing
        {
            get { return (double)uCtrlSpacing.Value; }
            set { uCtrlSpacing.Value = value; }
        }
        public double HatchAngle
        {
            get { return (double)uCtrlAngle.Value; }
            set { uCtrlAngle.Value = value; }
        }
        public double LinearWeight
        {
            get { return (double)uCtrlLinearMass.Value; }
            set { uCtrlLinearMass.Value = value; }
        }
        #endregion

        #region Event handlers
        private void OnChkbHatchingCheckedChanged(object sender, EventArgs e)
        {
            uCtrlSpacing.Enabled = UseHatching;
            uCtrlAngle.Enabled = UseHatching;
            UpdateStatus(string.Empty);
        }
        #endregion

        #region Data members
        protected static ILog _log = LogManager.GetLogger(typeof(FormNewPalletFilm));
        #endregion
    }
}
