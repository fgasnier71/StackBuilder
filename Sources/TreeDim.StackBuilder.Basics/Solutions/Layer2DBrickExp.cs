﻿#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class Layer2DBrickExp : Layer2DBrick
    {
        #region Constructor
        public Layer2DBrickExp(Vector3D dimBox, Vector3D bulge, Vector2D dimContainer, string name, HalfAxis.HAxis axisOrtho)
            : base(dimBox, bulge, dimContainer, name, axisOrtho)
        {
        }
        #endregion
        #region Add/Remove methods
        public void AddPosition(BoxPosition position) => Add(position);
        public void RemovePosition(int index) => Positions.RemoveAt(index);
        public void SetPositions(List<BoxPosition> positions) => AddRange(positions);
        #endregion
        #region Layer2DBrick override
        public override string PatternName => string.Empty;
        public override string Tooltip(double height) => $"{Count} * {NoLayers(height)} = {CountInHeight(height)} | {HalfAxis.ToString(AxisOrtho)} | {Name}";
        public override string ToString() => $"{Name}";
        #endregion
    }

    public class Layer2DBrickExpIndexed : Layer2DBrickIndexed
    {
        #region Constructor
        public Layer2DBrickExpIndexed(Vector3D dimBox, Vector2D dimContainer, string name, HalfAxis.HAxis axisOrtho)
            : base(dimBox, dimContainer, name, axisOrtho)
        {
        }
        #endregion
        #region Add/Remove methods
        public void AddPosition(BoxPositionIndexed position) => Add(position);
        public void RemovePosition(int index) => Positions.RemoveAt(index);
        public void SetPositions(List<BoxPositionIndexed> positions) => AddRange(positions);
        #endregion
        #region Layer2DBrick override
        public override string PatternName => string.Empty;
        public override string Tooltip(double height) => $"{Count} * {NoLayers(height)} = {CountInHeight(height)} | {HalfAxis.ToString(AxisOrtho)} | {Name}";
        public override string ToString() => $"{Name}";
        #endregion
    }
}
