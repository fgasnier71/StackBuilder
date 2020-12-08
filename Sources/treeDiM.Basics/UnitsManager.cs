#region Using directives
using System;
using System.Windows.Forms;

using Cureos.Measures;
using Cureos.Measures.Quantities;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.Basics
{
    public class UnitsManager
    {
        #region Enums
        public enum UnitSystem
        {
            UNIT_METRIC1
            , UNIT_METRIC2
            , UNIT_IMPERIAL
            , UNIT_US
        }
        public enum UnitType
        {
            UT_LENGTH
            , UT_MASS
            , UT_VOLUME
            , UT_SURFACEMASS
            , UT_FORCE
            , UT_LINEARFORCE
            , UT_LINEARMASS
            , UT_STIFFNESS
            , UT_NONE
        }
        #endregion

        #region Private constructor
        private UnitsManager()
        {
        }
        #endregion

        #region Instantiation
        public static UnitsManager Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new UnitsManager();
                return _instance;
            }
        }
        #endregion

        #region Current unit system 
        public static UnitSystem CurrentUnitSystem
        {
            get { return Instance._currentUnitSystem; }
            set { Instance._currentUnitSystem = value; }
        }
        #endregion

        #region Unit strings
        /// <summary>
        /// Length unit string
        /// </summary>
        public static string LengthUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "mm";
                    case UnitSystem.UNIT_METRIC2: return "cm";
                    case UnitSystem.UNIT_IMPERIAL: return "in";
                    case UnitSystem.UNIT_US: return "in";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        /// <summary>
        /// Weight unit string
        /// </summary>
        public static string MassUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "kg";
                    case UnitSystem.UNIT_METRIC2: return "kg";
                    case UnitSystem.UNIT_IMPERIAL: return "lb";
                    case UnitSystem.UNIT_US: return "lb";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        /// <summary>
        /// Volume unit string
        /// </summary>
        public static string VolumeUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "l";
                    case UnitSystem.UNIT_METRIC2: return "l";
                    case UnitSystem.UNIT_IMPERIAL: return "in³";
                    case UnitSystem.UNIT_US: return "in³";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }

        public static string SurfaceMassUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "kg/m²";
                    case UnitSystem.UNIT_METRIC2: return "kg/m²";
                    case UnitSystem.UNIT_IMPERIAL: return "lb/in²";
                    case UnitSystem.UNIT_US: return "lb/in²";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }

        public static string ForceUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "daN";
                    case UnitSystem.UNIT_METRIC2: return "daN";
                    case UnitSystem.UNIT_IMPERIAL: return "daN";
                    case UnitSystem.UNIT_US: return "daN";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static string LinearForceUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "N/m";
                    case UnitSystem.UNIT_METRIC2: return "N/m";
                    case UnitSystem.UNIT_IMPERIAL: return "N/in";
                    case UnitSystem.UNIT_US: return "N/in";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static string LinearMassUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                { 
                    case UnitSystem.UNIT_METRIC1: return "kg/m";
                    case UnitSystem.UNIT_METRIC2: return "kg/m";
                    case UnitSystem.UNIT_IMPERIAL: return "lb/in";
                    case UnitSystem.UNIT_US: return "lb/in";
                    default: throw new Exception("Invalid unit system!");                }
            }
        }

        public static string StiffnessUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "N.m";
                    case UnitSystem.UNIT_METRIC2: return "N.m";
                    case UnitSystem.UNIT_IMPERIAL: return "N.m";
                    case UnitSystem.UNIT_US: return "N.m";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static string SystemUnitString
        {
            get
            {
                return string.Format("{0}, {1}", LengthUnitString, MassUnitString);
            }
        }
        #endregion

        #region Format strings
        public static string LengthFormatString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "{0:0.#}";
                    case UnitSystem.UNIT_METRIC2: return "{0:0.#}";
                    case UnitSystem.UNIT_IMPERIAL: return "{0:0.###}";
                    case UnitSystem.UNIT_US: return "{0:0.###}";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static string MassFormatString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "{0:0.###}";
                    case UnitSystem.UNIT_METRIC2: return "{0:0.###}";
                    case UnitSystem.UNIT_IMPERIAL: return "{0:0.###}";
                    case UnitSystem.UNIT_US: return "{0:0.###}";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static string VolumeFormatString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "{0:0.###}";
                    case UnitSystem.UNIT_METRIC2: return "{0:0.###}";
                    case UnitSystem.UNIT_IMPERIAL: return "{0:0.###}";
                    case UnitSystem.UNIT_US: return "{0:0.###}";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static string SurfaceMassFormatString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "{0:0.###}";
                    case UnitSystem.UNIT_METRIC2: return "{0:0.###}";
                    case UnitSystem.UNIT_IMPERIAL: return "{0:0.###}";
                    case UnitSystem.UNIT_US: return "{0:0.###}";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static string ForceFormatString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "{0:0.###}";
                    case UnitSystem.UNIT_METRIC2: return "{0:0.###}";
                    case UnitSystem.UNIT_IMPERIAL: return "{0:0.###}";
                    case UnitSystem.UNIT_US: return "{0:0.###}";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static string LinearMassFormatString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "{0:0.###}";
                    case UnitSystem.UNIT_METRIC2: return "{0:0.###}";
                    case UnitSystem.UNIT_IMPERIAL: return "{0:0.###}";
                    case UnitSystem.UNIT_US: return "{0:0.###}";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static string LinearForceFormatString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "{0:0.###}";
                    case UnitSystem.UNIT_METRIC2: return "{0.0.###}";
                    case UnitSystem.UNIT_IMPERIAL: return "{0:0.###}";
                    case UnitSystem.UNIT_US: return "{0:0.###}";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static string StiffnessFormatString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return "{0:0.###}";
                    case UnitSystem.UNIT_METRIC2: return "{0.0.###}";
                    case UnitSystem.UNIT_IMPERIAL: return "{0:0.###}";
                    case UnitSystem.UNIT_US: return "{0:0.###}";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        #endregion

        #region Number of decimals
        public static int LengthNoDecimals
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1:   return 1; 
                    case UnitSystem.UNIT_METRIC2:   return 1;
                    case UnitSystem.UNIT_IMPERIAL:  return 2;
                    case UnitSystem.UNIT_US:        return 2;
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static int VolumeNoDecimals
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return 3;
                    case UnitSystem.UNIT_METRIC2: return 3;
                    case UnitSystem.UNIT_IMPERIAL: return 1;
                    case UnitSystem.UNIT_US: return 1;
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static int MassNoDecimals => 3;
        public static int SurfaceMassNoDecimals => 3;
        public static int ForceNoDecimals => 2;
        public static int LinearForceNoDecimals => 3;
        public static int LinearMassNoDecimals => 3;
        public static int StiffnessNoDecimals => 3;
        public static int NoneNoDecimals => 0;
        #endregion

        #region Data members
        private static UnitsManager _instance;
        private UnitSystem _currentUnitSystem;
        #endregion

        #region UI string transformations
        static public string UnitString(UnitType ut)
        {
            switch (ut)
            {
                case UnitType.UT_LENGTH: return LengthUnitString;
                case UnitType.UT_MASS: return MassUnitString;
                case UnitType.UT_VOLUME: return VolumeUnitString;
                case UnitType.UT_SURFACEMASS: return SurfaceMassUnitString;
                case UnitType.UT_FORCE: return ForceUnitString;
                case UnitType.UT_LINEARFORCE: return LinearForceUnitString;
                case UnitType.UT_LINEARMASS: return LinearMassUnitString;
                case UnitType.UT_STIFFNESS: return StiffnessUnitString;
                default: return string.Empty;
            }
        }
        static public string UnitFormat(UnitType ut)
        {
            switch (ut)
            { 
                case UnitType.UT_LENGTH: return LengthFormatString;
                case UnitType.UT_MASS: return MassFormatString;
                case UnitType.UT_VOLUME: return VolumeFormatString;
                case UnitType.UT_SURFACEMASS: return SurfaceMassFormatString;
                case UnitType.UT_FORCE: return ForceFormatString;
                case UnitType.UT_LINEARFORCE: return LinearForceFormatString;
                case UnitType.UT_LINEARMASS: return LinearMassFormatString;
                case UnitType.UT_STIFFNESS: return StiffnessFormatString;
                default: return string.Empty;            
            }
        }
        static public int NoDecimals(UnitType ut)
        {
            switch (ut)
            {
                case UnitType.UT_LENGTH: return LengthNoDecimals;
                case UnitType.UT_MASS: return MassNoDecimals;
                case UnitType.UT_VOLUME: return VolumeNoDecimals;
                case UnitType.UT_SURFACEMASS: return SurfaceMassNoDecimals;
                case UnitType.UT_FORCE: return ForceNoDecimals;
                case UnitType.UT_LINEARFORCE: return LinearForceNoDecimals;
                case UnitType.UT_LINEARMASS: return LinearMassNoDecimals;
                case UnitType.UT_STIFFNESS: return StiffnessNoDecimals;
                case UnitType.UT_NONE: return NoneNoDecimals;
                default: return 3;
            }
        }
        static public string ReplaceUnitStrings(string s)
        { 
            string sText = s;
            sText = sText.Replace("uLength", LengthUnitString);
            sText = sText.Replace("uMass", MassUnitString);
            sText = sText.Replace("uVolume", VolumeUnitString);
            sText = sText.Replace("uSurfaceMass", SurfaceMassUnitString);
            sText = sText.Replace("uLinearForce", LinearForceUnitString);
            sText = sText.Replace("uLinearMass", LinearMassUnitString);
            sText = sText.Replace("uStiffness", StiffnessUnitString);
            return sText;
        }
        public static void AdaptUnitLabels(Control c)
        { 
            foreach (Control ctrl in c.Controls)
            {
                if (ctrl is Label lb)
                {
                    if (lb.Name.Contains("uLength")) lb.Text = LengthUnitString;
                    else if (lb.Name.Contains("uMass")) lb.Text = MassUnitString;
                    else if (lb.Name.Contains("uVolume")) lb.Text = VolumeUnitString;
                    else if (lb.Name.Contains("uSurfaceMass")) lb.Text = SurfaceMassUnitString;
                    else if (lb.Name.Contains("uStiffness")) lb.Text = StiffnessUnitString;
                    else if (lb.Name.Contains("uLinearMass")) lb.Text = LinearMassUnitString;
                }
                if (ctrl is GroupBox gb)
                {
                    AdaptUnitLabels(gb);
                }
            }
        }
        #endregion

        #region Conversions
        public static double FactorSquareLengthToArea
        {
            get
            {
                switch (CurrentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return 1.0E-06; //mm² to m²
                    case UnitSystem.UNIT_METRIC2: return 1.0E-04; //cm² to m²
                    case UnitSystem.UNIT_IMPERIAL: return 1.0; // in² to in²
                    case UnitSystem.UNIT_US: return 1.0; // in² to in²
                    default: throw new Exception("Invalid unit system!");                    
                }
            }
        }
        public static double FactorCubeLengthToVolume
        {
            get
            {
                switch (CurrentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC1: return 10.0E-06; //mm³ to l
                    case UnitSystem.UNIT_METRIC2: return 1.0E-03; //cm³ to l
                    case UnitSystem.UNIT_IMPERIAL: return 1.0; // in³ to in³
                    case UnitSystem.UNIT_US: return 1.0; // in³ to in³
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        public static IUnit<Length> LengthUnitFromUnitSystem(UnitSystem unitSystem)
        {
            switch (unitSystem)
            {
                case UnitSystem.UNIT_METRIC1: return Length.MilliMeter;
                case UnitSystem.UNIT_METRIC2: return Length.CentiMeter;
                case UnitSystem.UNIT_IMPERIAL: return Length.Inch;
                case UnitSystem.UNIT_US: return Length.Inch;
                default: throw new Exception("Invalid unit system!");
            }
        }
        public static IUnit<Mass> MassUnitFromUnitSystem(UnitSystem unitSystem)
        {
            switch (unitSystem)
            {
                case UnitSystem.UNIT_METRIC1: return Mass.KiloGram;
                case UnitSystem.UNIT_METRIC2: return Mass.KiloGram;
                case UnitSystem.UNIT_IMPERIAL: return Mass.Pound;
                case UnitSystem.UNIT_US: return Mass.Pound;
                default: throw new Exception("Invalid unit system!");
            }
        }
        public static IUnit<SurfaceDensity> SurfaceMassUnitFromUnitSystem(UnitSystem unitSystem)
        {
            switch (unitSystem)
            {
                case UnitSystem.UNIT_METRIC1: return SurfaceDensity.KiloGramPerSquareMeter;
                case UnitSystem.UNIT_METRIC2: return SurfaceDensity.KiloGramPerSquareMeter;
                case UnitSystem.UNIT_IMPERIAL: return SurfaceDensity.PoundPerSquareInch;
                case UnitSystem.UNIT_US: return SurfaceDensity.PoundPerSquareInch;
                default: throw new Exception("Invalid unit system!");
            }
        }
        public static double ConvertLengthTo(double value, UnitSystem unitSystem)
        {
            if (unitSystem == CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Length> measure = new StandardMeasure<Length>(value, LengthUnitFromUnitSystem(CurrentUnitSystem));
                return measure.GetAmount(LengthUnitFromUnitSystem(unitSystem));
            }       
        }
        public static double ConvertLengthFrom(double value, UnitSystem unitSystem)
        {
            if (unitSystem == CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Length> measure = new StandardMeasure<Length>(value, LengthUnitFromUnitSystem(unitSystem));
                return measure.GetAmount(LengthUnitFromUnitSystem(CurrentUnitSystem));
            }
        }
        public static double ConvertMassTo(double value, UnitSystem unitSystem)
        {
            if (unitSystem == CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Mass> measure = new StandardMeasure<Mass>(value, MassUnitFromUnitSystem(CurrentUnitSystem));
                return measure.GetAmount(MassUnitFromUnitSystem(unitSystem));
            }
        }
        public static double ConvertMassFrom(double value, UnitSystem unitSystem)
        {
            if (unitSystem == CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Mass> measure = new StandardMeasure<Mass>(value, MassUnitFromUnitSystem(unitSystem));
                return measure.GetAmount(MassUnitFromUnitSystem(CurrentUnitSystem));
            }       
        }
        public static double ConvertSurfaceMassFrom(double value, UnitSystem unitSystem)
        {
            if (unitSystem == CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<SurfaceDensity> measure = new StandardMeasure<SurfaceDensity>(value, SurfaceMassUnitFromUnitSystem(unitSystem));
                return measure.GetAmount(SurfaceMassUnitFromUnitSystem(CurrentUnitSystem));
            }
        }
        public static double ConvertLinearMassFrom(double value, UnitSystem unitSystem)
        {
            if (unitSystem == CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Mass> measure = new StandardMeasure<Mass>(value, MassUnitFromUnitSystem(CurrentUnitSystem));
                StandardMeasure<Length> measureLength = new StandardMeasure<Length>(value, LengthUnitFromUnitSystem(CurrentUnitSystem));
                return measure.GetAmount(MassUnitFromUnitSystem(unitSystem));
            }
        }
        #endregion
    }
}
