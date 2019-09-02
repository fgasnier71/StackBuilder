#region Using directives
using System;
using System.Collections.Generic;

using treeDiM.EdgeCrushTest.Properties;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public partial class McKeeFormula
    {
        #region Enums
        public enum FormulaType
        {
            MCKEE_CLASSIC
            , MCKEE_IMPROVED
        }
        #endregion

        #region Formula implementation
        private static double ComputeBCT_ECT(double length, double width, double thickness, double ect)
        { 
        	double L1 = length / 25.4;
			double B1 = width / 25.4;
			double e1 = thickness / 25.4;
            double ect1 = ect / 0.1751;
			double rcv = 5.87 * ect1 * Math.Pow(2 * (L1 + B1), 0.4924) * Math.Pow(e1, 0.5076);
            return rcv * 0.45359;
        }
        private static double ComputeBCT_Stiffness(
            double length, double width, double height
            , double thickness
            , double stiffnessX, double stiffnessY
            , double ect)
        {
            double L1 = length / 25.4;
			double B1 = width / 25.4;
			double H1 = height / 25.4;
			double ECT1 = ect / 0.1751;
			double Dx1 = stiffnessX / 0.113;
			double Dy1 = stiffnessY / 0.113;
			
			double D = 1.593 / Math.Pow(H1, 0.236);
			double k = 1.014 * Math.Pow(ECT1, 0.746) * Math.Pow((Dx1 * Dy1), 0.127) * (2 * (Math.Pow(L1, 0.492) + Math.Pow(B1, 0.492)));
			double rcv = k * D;
            return rcv * 0.45359;
        }
        /// <summary>
        /// Compute static BCT
        /// </summary>
        public static double ComputeStaticBCT(
            double length, double width, double height, string caseType, bool dblWall
            , string cardboardId
            , FormulaType mcKeeFormulaType)
        {
           return ComputeStaticBCT(length, width, height, caseType, dblWall, CardboardQualityAccessor.Instance.GetQualityDataByName(cardboardId), mcKeeFormulaType);
        }
        public static double ComputeStaticBCT(
            double length, double width, double height, string caseType, bool dblWall
            , QualityData qualityData
            , FormulaType mcKeeFormulaType)
        {
            if (!CaseTypeDictionary.ContainsKey(caseType))
                throw new ECTException(ECTException.ErrorType.ERROR_INVALIDCASETYPE, caseType);
            double caseTypeCoef = CaseTypeDictionary[caseType];

            switch (mcKeeFormulaType)
            {
                case FormulaType.MCKEE_CLASSIC:
                    return ComputeBCT_ECT(length, width*(dblWall?2:1), qualityData.Thickness, qualityData.ECT) * caseTypeCoef;
                case FormulaType.MCKEE_IMPROVED:
                    return ComputeBCT_Stiffness(length, width*(dblWall?2:1), height,
                        qualityData.Thickness, qualityData.RigidityDX, qualityData.RigidityDY,
                        qualityData.ECT) * caseTypeCoef;
                default:
                    throw new ECTException(ECTException.ErrorType.ERROR_INVALIDFORMULATYPE, string.Empty);
            }
        }
        #endregion

        #region Dynamic BCT
        public static Dictionary<KeyValuePair<string, string>, double> EvaluateEdgeCrushTestMatrix(
            double L, double B, double H,
            string caseType, bool dblWall, string printType,
            string cardboardId,
            FormulaType mcKeeFormulaType)
        {
            return EvaluateEdgeCrushTestMatrix(L, B, H, caseType, dblWall, printType, CardboardQualityAccessor.Instance.GetQualityDataByName(cardboardId), mcKeeFormulaType);
        }
        public static Dictionary<KeyValuePair<string, string>, double> EvaluateEdgeCrushTestMatrix(
            double L, double B, double H,
            string caseType, bool dblWall, string printType,
            QualityData qualityData,
            FormulaType mcKeeFormulaType)
        {
            // get dictionnaries
            Dictionary<string, double> humidityCoefDictionary = HumidityCoefDictionary;
            Dictionary<string, double> stockCoefDictionary = StockCoefDictionary;
            double printCoef = PrintCoefDictionary[printType];
            // get cardboard quality data
            double bct_static = ComputeStaticBCT(L, B, H, caseType, dblWall, qualityData, mcKeeFormulaType);

            Dictionary<KeyValuePair<string, string>, double> edgeCrushTestMatrix = new Dictionary<KeyValuePair<string, string>, double>();
            foreach (string humidityRange in HumidityCoefDictionary.Keys)
                foreach (string stockDuration in StockCoefDictionary.Keys)
                {
                    edgeCrushTestMatrix.Add(new KeyValuePair<string, string>(stockDuration, humidityRange)
                        , bct_static * printCoef * stockCoefDictionary[stockDuration] * humidityCoefDictionary[humidityRange]);
                }
            return edgeCrushTestMatrix;
        }
        #endregion

        #region Coefficient dictionary
        /// <summary>
        /// Convert to McKeeFormula to string
        /// </summary>
        public static string ModeText(FormulaType type)
        {
            switch (type)
            {
                case FormulaType.MCKEE_CLASSIC: return Resources.MCKEEFORMULA_CLASSIC;
                case FormulaType.MCKEE_IMPROVED: return Resources.MCKEEFORMULA_IMPROVED;
                default: return "";
            }
        }
        /// <summary>
        /// Convert string to McKeeFormula
        /// </summary>
        public static FormulaType TextToMode(string sMode)
        {
            if (string.Equals(sMode, Resources.MCKEEFORMULA_CLASSIC))
                return FormulaType.MCKEE_CLASSIC;
            else if (string.Equals(sMode, Resources.MCKEEFORMULA_IMPROVED))
                return FormulaType.MCKEE_IMPROVED;
            else
                return FormulaType.MCKEE_CLASSIC;
        }
        /// <summary>
        /// Case type dictionary
        /// </summary>
        public static Dictionary<string, double> CaseTypeDictionary
        {
            get
            {
                Dictionary<string, double> caseTypeDictionary = new Dictionary<string,double>()
                {
                    { Resources.CASETYPE_AMERICANCASE, 1.0 }
                };
                return caseTypeDictionary;
            }
        }
        /// <summary>
        /// Humidity coefficient dictionary
        /// </summary>
        public static Dictionary<string, double> HumidityCoefDictionary
        {
            get
            {
                Dictionary<string, double> humidityCoefs = new Dictionary<string, double>()
                {
                    {"0-45%", 1.1}
                    , {"46-55%", 1.0}
                    , {"56-65%", 0.9}
                    , {"66-75%", 0.8}
                    , {"76-85%", 0.7}
                    , {"86-100%", 0.5}
                };
                return humidityCoefs;
            }
        }
        /// <summary>
        /// Stock coefficient dictionary
        /// </summary>
        public static Dictionary<string, double> StockCoefDictionary
        {
            get
            {
                Dictionary<string, double> jStockCoef = new Dictionary<string, double>()
                {
                    {Resources.STORAGEDURATION_0DAY, 1.0}
                    , {Resources.STORAGEDURATION_1_3DAYS, 0.7}
                    , {Resources.STORAGEDURATION_4_10DAYS, 0.65}
                    , {Resources.STORAGEDURATION_11_30DAYS, 0.6}
                    , {Resources.STORAGEDURATION_1_3MONTHES, 0.55}
                    , {Resources.STORAGEDURATION_3_4MONTHES, 0.5}
                    , {Resources.STORAGEDURATION_4_MONTHES, 0.45}
                };
                return jStockCoef;
            }
        }
        /// <summary>
        /// Print surface dictionary
        /// </summary>
        public static Dictionary<string, double> PrintCoefDictionary
        {
            get
            {
                var printCoefDictionary = new Dictionary<string,double>()
                {
                    {Resources.PRINTEDSURFACE_SIMPLE, 1.0}
                    , {Resources.PRINTEDSURFACE_DISTRIBUTED, 0.9}
                    , {Resources.PRINTEDSURFACE_COMPLEX, 0.8}
                    , {Resources.PRINTEDSURFACE_COVERED, 0.7}
                };
                return printCoefDictionary;
            }
        }
        #endregion
    }
}
