#region Using directives
using System.IO;
using System.Text;
using System.Globalization;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Exporters
{
    public class ExporterCSV_ExcelManutention : Exporter
    {
        #region Override Exporter
        public override string Name => FormatName;
        public override string Extension => "csv";
        public override string Filter => "Comma Separated Values (*.csv) |*.csv";
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

            var csv = new StringBuilder();
            // case dimension
            Vector3D caseDim = analysis.ContentDimensions;
            csv.AppendLine($"{caseDim.X.ToString("0,0.0", nfi)};{caseDim.Y.ToString("0,0.0", nfi)};{caseDim.Z.ToString("0,0.0", nfi)}");
            // number of layers; number of drops
            int noDrops = sol.SolutionItems.Count;
            csv.AppendLine($"{sol.SolutionItems.Count};{noDrops}");
            // interlayers
            foreach (var solItem in sol.SolutionItems)
            {
                csv.AppendLine($"{(solItem.HasInterlayer ? 1 : 0)};{solItem.InterlayerIndex}");
            }
            // boxes layer 0
            if (sol.SolutionItems.Count > 1)
            {
                var solItem = sol.SolutionItems[0];

            }

            // boxes layer 1
            if (sol.SolutionItems.Count > 2)
            {
                var solItem = sol.SolutionItems[1];

            }

            // write to stream
            var writer = new StreamWriter(stream);
            writer.Write(csv.ToString());
            writer.Flush();
            stream.Position = 0;
        }
        #endregion

        #region Static members
        public static string FormatName => "csv (Excel-Manutention)";
        #endregion
    }
}
