#region Using directives
using System.Text;
using System.IO;
using System.Globalization;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Exporters
{
    class ExporterCSV_TechBSA : Exporter
    {
        #region Static members
        public static string FormatName => "csv (TechnologyBSA)";
        #endregion
        #region Constructor
        public ExporterCSV_TechBSA() {}
        public override string Name => FormatName;
        public override string Filter => "Comma Separated Values (*.csv) |*.csv";
        public override string Extension => "csv";
        public override void Export(AnalysisLayered analysis, ref Stream stream)
        {
            if (analysis.SolutionLay.ItemCount > 200)
                throw new ExceptionTooManyItems(Name, analysis.Solution.ItemCount, 200);

            // number formatting
            NumberFormatInfo nfi = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = "",
                NumberDecimalDigits = 1
            };

            // initialize csv file
            var csv = new StringBuilder();
            csv.AppendLine("Parameter; Field; DataType; Value");
            csv.AppendLine("Program:StackBuilder;$Type; STRING; PvParameter");

            // case counter
            uint iCaseCount = 0;
            SolutionLayered sol = analysis.SolutionLay;
            var layers = sol.Layers;
            foreach (ILayer layer in layers)
            {
                if (layer is Layer3DBox layerBox)
                {
                    foreach (var bPosition in layerBox)
                    {
                        Vector3D pos = ConvertPosition(bPosition, analysis.ContentDimensions);
                        int angle = 0;
                        switch (bPosition.DirectionLength)
                        {
                            case HalfAxis.HAxis.AXIS_X_P: angle = 0; break;
                            case HalfAxis.HAxis.AXIS_Y_P: angle = 90; break;
                            case HalfAxis.HAxis.AXIS_X_N: angle = 180; break;
                            case HalfAxis.HAxis.AXIS_Y_N: angle = 270; break;
                            default: break;
                        }
                        csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].C;INT;{angle}");
                        csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].X;REAL;{pos.X.ToString("0,0.0", nfi)}");
                        csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].Y;REAL;{pos.Y.ToString("0,0.0", nfi)}");
                        csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount++}].Z;REAL;{pos.Z.ToString("0,0.0", nfi)}");
                    }
                }
            }
            while  (iCaseCount < 200)
            {
                csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].C;INT;0");
                csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].X;REAL;0");
                csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].Y;REAL;0");
                csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount++}].Z;REAL;0");
            }

            var bProperties = analysis.Content as BoxProperties;
            csv.AppendLine($"Program: StackBuilder; Program: StackBuilder.BoxDimension.L; REAL; {bProperties.Length.ToString("0,0.0", nfi)}");
            csv.AppendLine($"Program: StackBuilder; Program: StackBuilder.BoxDimension.P; REAL; {bProperties.Width.ToString("0,0.0", nfi)}");
            csv.AppendLine($"Program: StackBuilder; Program: StackBuilder.BoxDimension.H; REAL; {bProperties.Height.ToString("0,0.0", nfi)}");
            csv.AppendLine($"Program: StackBuilder; Peogram: StackBuilder.BoxDimension.W; REAL; {bProperties.Weight.ToString("0,0.0", nfi)}");
            var palletProperties = analysis.Container as PalletProperties;
            csv.AppendLine($"Program: StackBuilder; Program: StackBuilder.PalletDimension.L; REAL; {palletProperties.Length.ToString("0,0.0", nfi)}");
            csv.AppendLine($"Program: StackBuilder; Program: StackBuilder.PalletDimension.P; REAL; {palletProperties.Width.ToString("0,0.0", nfi)}");
            csv.AppendLine($"Program: StackBuilder; Program: StackBuilder.PalletDimension.H; REAL; {palletProperties.Height.ToString("0,0.0", nfi)}");
            csv.AppendLine($"Program: StackBuilder; Program: StackBuilder.PalletDimension.W; REAL; {palletProperties.Weight.ToString("0,0.0", nfi)}");

            bool hasInterlayerBottom = sol.Layers.Count > 0 && (sol.Layers[0] is InterlayerPos);
            csv.AppendLine($"Program: StackBuilder; Program: StackBuilder.InterLayerBottomOnOff; BOOL; {Bool2string(hasInterlayerBottom)}");
            bool hasInterlayerMiddle = sol.Layers.Count > 2 && (sol.Layers[2] is InterlayerPos);
            csv.AppendLine($"Program: StackBuilder; Program: StackBuilder.InterLayerIntermediateOnOff; BOOL; {Bool2string(hasInterlayerMiddle) }");
            bool topInterlayer = (analysis is AnalysisCasePallet analysisCasePallet) &&  analysisCasePallet.HasPalletCap;
            csv.AppendLine($"Program: StackBuilder; Program: StackBuilder.InterLayerTopOnOff; BOOL; {Bool2string(topInterlayer)}");
            csv.AppendLine($"Program:StackBuilder; Program: StackBuilder.TotalWeight; REAL; {sol.Weight.ToString("0,0.0", nfi)}");

            var writer = new StreamWriter(stream);
            writer.Write(csv.ToString());
            writer.Flush();
            stream.Position = 0;
        }
        #endregion
        #region Helpers
        private static string Bool2string(bool b) => b ? "TRUE" : "FALSE";
        #endregion
    }
}
