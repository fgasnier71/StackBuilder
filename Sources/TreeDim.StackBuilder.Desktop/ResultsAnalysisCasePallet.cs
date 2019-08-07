#region Data members
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public class ResultsAnalysisCasePallet
    {

        #region Private data members
        private double[] _dimensionsOuter = new double[3], _dimensionsLoad = new double[3];
        private List<KeyValuePair<int, int>> _layers = new List<KeyValuePair<int, int>>();
        #endregion

        #region Properties
        [Browsable(true)]                  // property should be visible
        [ReadOnly(true)]                   // property should be readonly
        [Description("Number of cases")]   // description
        [Category("Loading")]              // belongs to category "Loading"
        [DisplayName("Number of cases")]   // display name
        public int NoCases { get; set; } = 0;
        [Browsable(true)]                   // property should be visible
        [ReadOnly(true)]                    // property should be readonly
        [Description("Number of layers")]   // description
        [Category("Loading")]               // belongs to category "Loading"
        [DisplayName("Number of layers")]   // display name
        public int NoLayers { get; set; } = 0;
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Number of cases per layer")]
        [Category("Loading")]
        [DisplayName("Number of cases / layer")]
        public string NoCasePerLayer
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                return sb.ToString(); 
            }
        }
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Load weight")]
        [Category("Weight")]
        [DisplayName("Load weight")]
        public double WeightLoad { get; set; } = 0.0;
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Total weight")]
        [Category("Weight")]
        [DisplayName("Total pallet weight")]
        public double WeightTotal { get; set; } = 0.0;
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Outer Dimensions")]
        [Category("Dimensions")]
        [DisplayName("Outer Dimensions (mm)")]
        public string DimensionsOuter
        {
            get
            {
                return string.Format(
                    "{0}x{1}x{2}",
                    _dimensionsOuter[0], _dimensionsOuter[1], _dimensionsOuter[2]
                    );
            }
        }
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Outer volume")]
        [Category("Dimensions")]
        [DisplayName("Outer volume (m^3)")]
        public double VolumeOuter
        {
            get { return 1.0E-09 * _dimensionsOuter[0] * _dimensionsOuter[1] * _dimensionsOuter[2]; }
        }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Load Dimensions (mm)")]
        [Category("Dimensions")]
        [DisplayName("Load Dimensions")]
        public string DimensionsLoad
        {
            get
            {
                return string.Format(
                    "{0}x{1}x{2}",
                    _dimensionsLoad[0], _dimensionsLoad[1], _dimensionsLoad[2]
                    );
            }
        }
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Load volume")]
        [Category("Dimensions")]
        [DisplayName("Load volume (m^3)")]
        public double VolumeLoad
        {
            get { return 1.0E-09 * _dimensionsLoad[0] * _dimensionsLoad[1] * _dimensionsLoad[2]; }
        }
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Volume efficiency (%)")]
        [Category("Efficiency")]
        [DisplayName("Volume efficiency (%)")]
        public double EfficiencyVolume { get; set; } = 0.0;
        #endregion
    }
}
