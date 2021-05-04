#region Using directives
using System;
using System.IO;
using System.Text;
using System.Globalization;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Exporters
{
    public class ExporterCSV_FMLogistic : Exporter
    {
        #region Constructor
        public ExporterCSV_FMLogistic()
        {
            PositionCoordinateMode = CoordinateMode.CM_COG;
        }
        #endregion
        #region Override Exporter
        public override string Name => FormatName;
        public override string Extension => "csv";
        public override string Filter => "Comma Separated Values (*.csv) |*.csv";
        public override bool ShowSelectorCoordinateMode => false;
        public override int MaxLayerIndexExporter(AnalysisLayered analysis) => Math.Min(analysis.SolutionLay.LayerCount, 2);


        public override void Export(AnalysisLayered analysis, ref Stream stream)
        {
            var sol = analysis.SolutionLay;
            var layers = sol.Layers;

            // number formatting
            NumberFormatInfo nfi = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = "",
                NumberDecimalDigits = 1
            };

            var pallet = analysis.Container as PalletProperties;

            var csv = new StringBuilder();
            // case dimension
            Vector3D caseDim = analysis.ContentDimensions;
            csv.AppendLine($"{caseDim.X.ToString("0,0.0", nfi)};{caseDim.Y.ToString("0,0.0", nfi)};{caseDim.Z.ToString("0,0.0", nfi)}");
            // number of layers; number of drops
            int noDrops = sol.SolutionItems.Count;
            csv.AppendLine($"{sol.SolutionItems.Count};{noDrops}");
            // interlayers
            int iLayer = 0;
            foreach (var solItem in sol.SolutionItems)
            {
                double xInterlayer = pallet.Length / 2;
                double yInterlayer = pallet.Width / 2;
                csv.AppendLine($"{iLayer + 1};{xInterlayer};{yInterlayer};{(solItem.HasInterlayer ? 1 : 0)};{solItem.InterlayerIndex}");
                ++iLayer;
            }

            // 1 line per block in the 2 first layer
            int iLine = 1;
            int actualLayer = 0;
            iLayer = 0;
            while (actualLayer < MaxLayerIndexExporter(analysis))
            {
                if (layers[iLayer] is Layer3DBox layer0)
                {
                    foreach (var bPos in layer0)
                    {
                        Vector3D vPos = ConvertPosition(bPos, caseDim);
                        int orientation = ConvertPositionAngleToPositionIndex(bPos);
                        int caseNumber = 1;
                        int blockType = 1;

                        csv.AppendLine($"{iLine};{vPos.X};{vPos.Y};{vPos.Z};{orientation};{caseNumber};{blockType}");
                        ++iLine;
                    }
                    ++actualLayer;
                }
                ++iLayer;
            }

            // write to stream
            var writer = new StreamWriter(stream);
            writer.Write(csv.ToString());
            writer.Flush();
            stream.Position = 0;
        }
        public override void Export(RobotPreparation robotPreparation, ref Stream stream)
        {
            // number formatting
            NumberFormatInfo nfi = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = "",
                NumberDecimalDigits = 1
            };
            // string builder
            var csv = new StringBuilder();
            // case dimensions (X;Y;Z)
            // number of layers; number of drops
            // interlayers (layer index;X;Y;0/1;index interlayer)
            // 1 line per block in the 2 first layer
            // write to stream
            var writer = new StreamWriter(stream);
            writer.Write(csv.ToString());
            writer.Flush();
            stream.Position = 0;
        }

        #endregion

        #region Static members
        public static string FormatName => "csv (FM Logistic)";
        #endregion
    }
}
