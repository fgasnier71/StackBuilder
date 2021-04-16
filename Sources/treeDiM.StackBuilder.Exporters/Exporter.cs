#region Using directives
using System;
using System.IO;
using System.Collections.Generic;

using treeDiM.StackBuilder.Basics;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Exporters
{
    public abstract class Exporter
    {
        public abstract void Export(AnalysisLayered analysis, ref Stream stream);
        public virtual void ExportIndexed(AnalysisLayered analysis, int layerDesignMode, ref Stream stream) { }
        public abstract string Name { get; }
        public abstract string Extension { get; }
        public abstract string Filter { get; }
        public virtual bool ShowSelectorCoordinateMode { get; } = true;
        public CoordinateMode PositionCoordinateMode { get; set; } = CoordinateMode.CM_CORNER;
        public virtual int MaxLayerIndexExporter(AnalysisLayered analysis) => analysis.SolutionLay.LayerCount;

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
        protected int ConvertPositionAngleToPositionIndex(BoxPosition bp)
        {
            if (bp.DirectionHeight != HalfAxis.HAxis.AXIS_Z_P)
                throw new  ExceptionUnexpectedOrientation(bp, this);

            switch (bp.DirectionLength)
            {
                case HalfAxis.HAxis.AXIS_X_P: return 1;
                case HalfAxis.HAxis.AXIS_Y_P: return 2;
                case HalfAxis.HAxis.AXIS_X_N: return 3;
                case HalfAxis.HAxis.AXIS_Y_N: return 4;
                default: throw new ExceptionUnexpectedOrientation(bp, this);
            }
        }
        #endregion
    }
    #region ExporterFactory
    public static class ExporterFactory
    {
        public static Exporter GetExporterByExt(string extension)
        {
            foreach (Exporter exp in All)
            {
                if (string.Equals(exp.Extension, extension, StringComparison.CurrentCultureIgnoreCase))
                    return exp;
            }
            throw new ExceptionInvalidExtension(extension);
        }
        public static Exporter GetExporterByName(string name)
        {
            foreach (Exporter exp in All)
            {
                if (string.Equals(exp.Name, name, StringComparison.CurrentCultureIgnoreCase))
                    return exp;
            }
            throw new ExceptionInvalidName(name);
        }
        #region Data members
        private static Exporter[] All =>
            new Exporter[]
            {
                new ExporterCollada(),
                new ExporterXML(),
                new ExporterCSV(),
                new ExporterCSV_TechBSA(),
                new ExporterCSV_FMLogistic(),
                new ExporterJSON()
            };

        #endregion
    }
    #endregion
}
