#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class Layer2DEditable : Layer2DBrick
    {
        #region Constructor
        public Layer2DEditable(Vector3D dimBox, Vector2D dimContainer, string name, HalfAxis.HAxis axisOrtho)
            : base(dimBox, dimContainer, name, axisOrtho)
        {
        }
        #endregion

        public void AddPosition(BoxPosition position) => Add(position);

        #region Layer2DBrick override
        public override string PatternName => string.Empty;
        public override string Tooltip(double height) => $"{Count} * {NoLayers(height)} = {CountInHeight(height)} | {HalfAxis.ToString(AxisOrtho)} | {Name}";
        public override string ToString() => $"{PatternName}_{(Swapped ? "1" : "0")}";
        #endregion
    }
}
