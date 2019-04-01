#region Using directives
using System.IO;

using treeDiM.StackBuilder.Basics;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Exporters
{
    public abstract class Exporter
    {
        public abstract void Export(AnalysisHomo analysis, ref Stream stream);
        public abstract string Filter { get; }
        public abstract string Extension { get; }
        public CoordinateMode PositionCoordinateMode { get; set; } = CoordinateMode.CM_CORNER;

        public enum CoordinateMode { CM_CORNER, CM_COG };
        #region Helpers
        protected Vector3D ConvertPosition(BoxPosition bp, Vector3D boxDim)
        {
            switch (PositionCoordinateMode)
            {
                case CoordinateMode.CM_COG:
                    return bp.Center(boxDim);
                default:
                    return bp.Position;
            }
        }
        #endregion
    }
    #region ExporterFactory
    public class ExporterFactory
    {
        public static Exporter GetExporterByExt(string extension)
        {
            foreach (Exporter exp in All)
            {
                if (string.Equals(exp.Extension, extension, System.StringComparison.CurrentCultureIgnoreCase))
                    return exp;
            }
            throw new ExceptionInvalidExtension(extension);
        }
        #region Data members
        private static Exporter[] All
        {
            get => new Exporter[]
            {
                new ExporterCollada(),
                new ExporterXML(),
                new ExporterCSV(),
                new ExporterJSON()
            };
        }
        #endregion
    }
    #endregion
}
