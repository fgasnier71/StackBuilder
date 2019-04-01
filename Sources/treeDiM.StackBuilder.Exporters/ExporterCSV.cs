using System.Collections.Generic;
using System.Text;
using System.IO;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Exporters
{
    public class ExporterCSV : Exporter
    {
        public ExporterCSV() {}
        public override string Filter => "Comma Separated Values (*.csv)|*.csv";
        public override string Extension => "csv";
        public override void Export(AnalysisHomo analysis, ref Stream stream)
        {
            var csv = new StringBuilder();
            Solution sol = analysis.Solution;
            List<ILayer> layers = sol.Layers;
            foreach (ILayer layer in layers)
            {
                if (layer is Layer3DBox layerBox)
                {
                    foreach (BoxPosition bPosition in layerBox)
                    {
                        Vector3D writtenPosition = ConvertPosition(bPosition, analysis.ContentDimensions);
                        csv.AppendLine(string.Format("{0};{1};{2};{3};{4};{5}",
                            1,
                            writtenPosition.X,
                            writtenPosition.Y,
                            writtenPosition.Z,
                            bPosition.DirectionLength,
                            bPosition.DirectionWidth));
                    }
                }
            }
            var writer = new StreamWriter(stream);
            writer.Write(csv.ToString());
            writer.Flush();
            stream.Position = 0;
        }
    }
}
