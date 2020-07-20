#region Using directives
using System;
using System.Text;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Exporters
{
    public class ExporterCSV_TechBSA : Exporter
    {
        #region Static members
        public static string FormatName => "csv (TechnologyBSA)";
        #endregion
        #region Constructor
        public override string Name => FormatName;
        public override string Filter => "Comma Separated Values (*.csv) |*.csv";
        public override string Extension => "csv";
        public override void Export(AnalysisLayered analysis, ref Stream stream)
        {
            if (analysis.SolutionLay.ItemCount > MaximumNumberOfCases)
                throw new ExceptionTooManyItems(Name, analysis.Solution.ItemCount, MaximumNumberOfCases);

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

            // ### CASES ###
            // case counter
            uint iCaseCount = 0;
            var sol = analysis.SolutionLay;
            var layers = sol.Layers;
            foreach (var layer in layers)
            {
                if (layer is Layer3DBox layerBox)
                {
                    layerBox.Sort(analysis.Content, Layer3DBox.SortType.DIST);
                    foreach (var bPosition in layerBox)
                    {
                        var pos = ConvertPosition(bPosition, analysis.ContentDimensions);
                        int angle = 0;
                        switch (bPosition.DirectionLength)
                        {
                            case HalfAxis.HAxis.AXIS_X_P: angle = 0; break;
                            case HalfAxis.HAxis.AXIS_Y_P: angle = 90; break;
                            case HalfAxis.HAxis.AXIS_X_N: angle = 180; break;
                            case HalfAxis.HAxis.AXIS_Y_N: angle = 270; break;
                            default: break;
                        }
                        if (iCaseCount < MaximumNumberOfCases)
                        {
                            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].C;INT;{angle}");
                            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].X;REAL;{pos.X.ToString("0,0.0", nfi)}");
                            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].Y;REAL;{pos.Y.ToString("0,0.0", nfi)}");
                            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount++}].Z;REAL;{pos.Z.ToString("0,0.0", nfi)}");
                        }
                    }
                }
            }
            // up to MaximumNumberOfCases
            while  (iCaseCount < MaximumNumberOfCases)
            {
                csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].C;INT;0");
                csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].X;REAL;0");
                csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount}].Y;REAL;0");
                csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Box[{iCaseCount++}].Z;REAL;0");
            }
            // ### INTERLAYERS ###
            int iLayerCount = 0;
            foreach (var solItem in sol.SolutionItems)
            {
                if (iLayerCount < MaximumNumberOfInterlayers)
                    csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.InterlayerOnOff[{iLayerCount++}];BOOL;{Bool2string(solItem.HasInterlayer)}");
            }
            // pallet cap
            var hasPalletCap = false;
            if (analysis is AnalysisCasePallet analysisCasePallet)
                hasPalletCap = analysisCasePallet.HasPalletCap;
            if (iLayerCount < MaximumNumberOfInterlayers)
                csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.InterlayerOnOff[{iLayerCount++}];BOOL;{Bool2string(hasPalletCap)}");
            // up to MaximumNumberOfInterlayers
            while (iLayerCount < MaximumNumberOfInterlayers)
                csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.InterlayerOnOff[{iLayerCount++}];BOOL;{Bool2string(false)}");


            // ### BOX OUTER DIMENSIONS
            var dimensions = analysis.Content.OuterDimensions;
            double weight = analysis.Content.Weight;

            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.BoxDimension.L;REAL;{dimensions.X.ToString("0,0.0", nfi)}");
            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.BoxDimension.P;REAL;{dimensions.Y.ToString("0,0.0", nfi)}");
            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.BoxDimension.H;REAL;{dimensions.Z.ToString("0,0.0", nfi)}");
            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.BoxDimension.W;REAL;{weight.ToString("0,0.0", nfi)}");
            if (analysis.Container is PalletProperties palletProperties)
            {
                csv.AppendLine(
                    $"Program:StackBuilder;Program:StackBuilder.PalletDimension.L;REAL;{palletProperties.Length.ToString("0,0.0", nfi)}");
                csv.AppendLine(
                    $"Program:StackBuilder;Program:StackBuilder.PalletDimension.P;REAL;{palletProperties.Width.ToString("0,0.0", nfi)}");
                csv.AppendLine(
                    $"Program:StackBuilder;Program:StackBuilder.PalletDimension.H;REAL;{palletProperties.Height.ToString("0,0.0", nfi)}");
                csv.AppendLine(
                    $"Program:StackBuilder;Program:StackBuilder.PalletDimension.W;REAL;{palletProperties.Weight.ToString("0,0.0", nfi)}");
            }

            double maxPalletHeight = analysis.ConstraintSet.OptMaxHeight.Value;
            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.Pallet.MaxPalletHeight;REAL;{maxPalletHeight.ToString("0,0.0", nfi)}");
            bool layersMirrorX = false;
            if (sol.ItemCount > 1)
                layersMirrorX = sol.SolutionItems[0].SymetryX != sol.SolutionItems[1].SymetryX;
            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.LayersMirrorXOnOff;BOOL;{Bool2string(layersMirrorX)}");
            bool layersMirrorY = false;
            if (sol.ItemCount > 1)
                layersMirrorY = sol.SolutionItems[0].SymetryY != sol.SolutionItems[1].SymetryY;
            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.LayersMirrorYOnOff;BOOL;{Bool2string(layersMirrorY)}");
            csv.AppendLine($"Program:StackBuilder;Program:StackBuilder.TotalWeight;REAL;{sol.Weight.ToString("0,0.0", nfi)}");

            var writer = new StreamWriter(stream);
            writer.Write(csv.ToString());
            writer.Flush();
            stream.Position = 0;
        }
        #endregion

        #region Import methods
        public static void Import(Stream csvStream,
            ref List<BoxPosition> boxPositions,
            ref Vector3D dimCase, ref double weightCase,
            ref Vector3D dimPallet, ref double weightPallet,
            ref double maxPalletHeight,
            ref bool layersMirrorX, ref bool layersMirrorY,
            ref List<bool> interlayers)
        {
            using (TextFieldParser csvParser = new TextFieldParser(csvStream))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = false;

                // Skip the row with the column names
                csvParser.ReadLine();
                csvParser.ReadLine();

                double zMin = double.MaxValue;
                maxPalletHeight = 1700.0;

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();

                    string f1 = fields[1];
                    if (f1.Contains("Program:StackBuilder.Box") && f1.EndsWith(".C"))
                    {
                        try
                        {
                            int angle = int.Parse(fields[3]);
                            fields = csvParser.ReadFields();
                            double x = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                            fields = csvParser.ReadFields();
                            double y = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                            fields = csvParser.ReadFields();
                            double z = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                            if (angle == 0 && x == 0 && y == 0 && z == 0)
                                continue;
                            if (z < zMin) zMin = z;

                            HalfAxis.HAxis axisL = HalfAxis.HAxis.AXIS_X_P;
                            HalfAxis.HAxis axisW = HalfAxis.HAxis.AXIS_Y_P;
                            switch (angle)
                            {
                                case 0:
                                    axisL = HalfAxis.HAxis.AXIS_X_P;
                                    axisW = HalfAxis.HAxis.AXIS_Y_P;
                                    break;
                                case 90:
                                    axisL = HalfAxis.HAxis.AXIS_Y_P;
                                    axisW = HalfAxis.HAxis.AXIS_X_N;
                                    break;
                                case 180:
                                    axisL = HalfAxis.HAxis.AXIS_X_N;
                                    axisW = HalfAxis.HAxis.AXIS_Y_N;
                                    break;
                                case 270:
                                    axisL = HalfAxis.HAxis.AXIS_Y_N;
                                    axisW = HalfAxis.HAxis.AXIS_X_P;
                                    break;
                                default:
                                    break;
                            }
                            if (Math.Abs(z - zMin) < 1.0E-06)
                                boxPositions.Add(new BoxPosition(new Vector3D(x, y, z), axisL, axisW));
                        }
                        catch (Exception ex)
                        {
                            _log.Error(ex.ToString());
                        }
                    }
                    else if (f1.Contains("Program:StackBuilder.InterlayerOnOff"))
                    {
                        interlayers.Add(string.Equals(fields[3], "TRUE", StringComparison.InvariantCultureIgnoreCase));
                    }
                    else if (f1.Contains("Program:StackBuilder.BoxDimension.L"))
                    {
                        dimCase.X = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                        fields = csvParser.ReadFields();
                        dimCase.Y = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                        fields = csvParser.ReadFields();
                        dimCase.Z = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                        fields = csvParser.ReadFields();
                        weightCase = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                    }
                    else if (f1.Contains("Program:StackBuilder.PalletDimension"))
                    {
                        dimPallet.X = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                        fields = csvParser.ReadFields();
                        dimPallet.Y = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                        fields = csvParser.ReadFields();
                        dimPallet.Z = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                        fields = csvParser.ReadFields();
                        weightPallet = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);

                    }
                    else if (f1.Contains("Program:StackBuilder.MaxPalletHeight"))
                    {
                        maxPalletHeight = double.Parse(fields[3], NumberFormatInfo.InvariantInfo);
                    }
                    else if (f1.Contains("Program:StackBuilder.LayersMirrorXOnOff"))
                    {
                        layersMirrorX = String2Bool(fields[3]);
                    }
                    else if (f1.Contains("Program:StackBuilder.LayersMirrorYOnOff"))
                    {
                        layersMirrorY = String2Bool(fields[3]);
                    }
                }
            }

            // reset position
            for (int i = 0; i < boxPositions.Count; ++i)
            {
                var bpos = boxPositions[i];
                HalfAxis.HAxis axisLength = bpos.DirectionLength;
                HalfAxis.HAxis axisWidth = bpos.DirectionWidth;
                Vector3D vI = HalfAxis.ToVector3D(axisLength);
                Vector3D vJ = HalfAxis.ToVector3D(axisWidth);
                Vector3D vK = Vector3D.CrossProduct(vI, vJ);
                var v = bpos.Position - 0.5 * dimCase.X * vI - 0.5 * dimCase.Y * vJ - 0.5 * dimCase.Z * vK - dimPallet.Z * Vector3D.ZAxis;
                boxPositions[i] = new BoxPosition(v, axisLength, axisWidth);
            }
        }
        #endregion

        #region Specific properties
        private int MaximumNumberOfCases => 400;
        private int MaximumNumberOfInterlayers => 40;
        #endregion

        #region Helpers
        private static string Bool2string(bool b) => b ? "TRUE" : "FALSE";
        private static bool String2Bool(string s) =>
            string.Equals(s, "TRUE", StringComparison.CurrentCultureIgnoreCase);
        private static ILog _log = LogManager.GetLogger(typeof(ExporterCSV_TechBSA));
        #endregion
    }
}
