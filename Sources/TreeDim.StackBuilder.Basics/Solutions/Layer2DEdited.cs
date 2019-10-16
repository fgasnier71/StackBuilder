#region Using directives
using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class Layer2DEditable : List<BoxPosition>, ILayer2D
    {
        #region Constructor
        public Layer2DEditable(Vector3D dimBox, Vector2D dimContainer, string name, HalfAxis.HAxis axisOrtho)
        {
            Name = name;
            DimBox = dimBox;
            DimContainer = dimContainer;
            AxisOrtho = axisOrtho;
        }
        #endregion

        public string PatternName => string.Empty;
        public string Name { get; private set; }
        public bool Swapped => false;
        public double LayerHeight => BoxHeight;
        public double Length => DimContainer.X;
        public double Width => DimContainer.Y;
        public LayerDesc LayerDescriptor => null;
        public double MaximumSpace => 0.0;
        public string Tooltip(double height) => $"{Count} * {NoLayers(height)} = {CountInHeight(height)} | {HalfAxis.ToString(AxisOrtho)} | {Name}";
        public int NoLayers(double height) => (int)Math.Floor(height / LayerHeight);
        public int CountInHeight(double height) => NoLayers(height) * Count;
        public void UpdateMaxSpace(double space, string patternName) {}
        public double BoxHeight
        {
            get
            {
                switch (AxisOrtho)
                {
                    case HalfAxis.HAxis.AXIS_X_N: 
                    case HalfAxis.HAxis.AXIS_X_P: return DimBox.X;
                    case HalfAxis.HAxis.AXIS_Y_N:
                    case HalfAxis.HAxis.AXIS_Y_P: return DimBox.Y;
                    default:
                        return DimBox.Z;
                }
            }
        }
        public HalfAxis.HAxis AxisOrtho { get; private set; } = HalfAxis.HAxis.AXIS_Z_P;
        public Vector3D DimBox { get; private set; }
        public Vector2D DimContainer { get; private set; }
        public override string ToString() => $"{PatternName}_{(Swapped ? "1" : "0")}";
    }
}
