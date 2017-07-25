using System;
using System.Collections.Generic;
using System.Drawing;

using treeDiM.StackBuilder.Basics;
using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Graphics
{
    /// <summary>
    /// This class displays a case layout as generated when performing a case optimisation.
    /// It uses a gdi+ graphics from a control, a memory bitmap
    /// </summary>
    public class CaseDefinitionViewer
    {
        public CaseDefinitionViewer(CaseDefinition caseDefinition, BoxProperties boxProperties, ParamSetPackOptim caseConstraintSet)
        {
            _caseDefinition = caseDefinition;
            _boxProperties = boxProperties;
            _caseOptimConstraintSet = caseConstraintSet;
            Orientation = new Orientation(HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
        }

        public BoxProperties CaseProperties { get; set; }
        public bool ShowDimensions { get; set; } = true;
        public Orientation Orientation { get; set; }

        public void Draw(Graphics3D graphics)
        {
            if (null == _caseDefinition || null == _boxProperties)
                return;

            // get global transformation
            Transform3D transf = Orientation.Transformation;

            // draw case (back faces)
            Case @case = CaseProperties != null ? new Case(CaseProperties, transf) : null;
            if (null != @case)
            {
                // draw case (inside)
                @case.DrawInside(graphics, Transform3D.Identity);
            }
            // add boxes
            uint pickId = 0;
            for (int i=0; i<_caseDefinition.Arrangement.Length; ++i)
                for (int j=0; j<_caseDefinition.Arrangement.Width; ++j)
                    for (int k = 0; k < _caseDefinition.Arrangement.Height; ++k)
                        graphics.AddBox( new Box(pickId++, _boxProperties, GetPosition(i, j, k, _caseDefinition.Dim0, _caseDefinition.Dim1) ) );
            if (ShowDimensions)
            {
                // add external dimensions
                Vector3D outerDimensions = _caseDefinition.OuterDimensions(_boxProperties, _caseOptimConstraintSet);
                graphics.AddDimensions(DimensionCube.Transform(new DimensionCube(Vector3D.Zero, outerDimensions.X, outerDimensions.Y, outerDimensions.Z, Color.Black, true), transf));
                // add inner dimensions
                Vector3D innerOffset = _caseDefinition.InnerOffset(_caseOptimConstraintSet);
                Vector3D innerDimensions = _caseDefinition.InnerDimensions(_boxProperties);
                graphics.AddDimensions(DimensionCube.Transform(new DimensionCube(innerOffset, innerDimensions.X, innerDimensions.Y, innerDimensions.Z, Color.Red, false), transf));
            }
        }

        #region Non-Public Members

        private BoxProperties _boxProperties;
        private CaseDefinition _caseDefinition;
        private ParamSetPackOptim _caseOptimConstraintSet;

        private Transform3D GlobalTransformation => Orientation.Transformation;

        private BoxPosition GetPosition(int i, int j, int k, int dim0, int dim1)
        {
            double boxLength = _caseDefinition.BoxLength(_boxProperties);
            double boxWidth = _caseDefinition.BoxWidth(_boxProperties);
            double boxHeight = _caseDefinition.BoxHeight(_boxProperties);
            HalfAxis.HAxis dirLength = HalfAxis.HAxis.AXIS_X_P;
            HalfAxis.HAxis dirWidth = HalfAxis.HAxis.AXIS_Y_P;

            Vector3D vPosition = Vector3D.Zero;
            if (0 == dim0 && 1 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_X_P;
                dirWidth = HalfAxis.HAxis.AXIS_Y_P;
                vPosition = Vector3D.Zero;
            }
            else if (0 == dim0 && 2 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_X_P;
                dirWidth = HalfAxis.HAxis.AXIS_Z_N;
                vPosition = new Vector3D(0.0, 0.0, _boxProperties.Width);
            }
            else if (1 == dim0 && 0 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Y_P;
                dirWidth = HalfAxis.HAxis.AXIS_X_N;
                vPosition = new Vector3D(_boxProperties.Width, 0.0, 0.0);
            }
            else if (1 == dim0 && 2 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Z_N;
                dirWidth = HalfAxis.HAxis.AXIS_X_P;
                vPosition = new Vector3D(0.0, _boxProperties.Height, _boxProperties.Length);
            }
            else if (2 == dim0 && 0 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Y_P;
                dirWidth = HalfAxis.HAxis.AXIS_Z_N;
                vPosition = new Vector3D(_boxProperties.Height, 0.0, _boxProperties.Width);
            }
            else if (2 == dim0 && 1 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Z_P;
                dirWidth = HalfAxis.HAxis.AXIS_Y_P;
                vPosition = new Vector3D(_boxProperties.Height, 0.0, 0.0);
            }
            // add wall thickness
            vPosition += new Vector3D(
                _caseOptimConstraintSet.NoWalls[0] * _caseOptimConstraintSet.WallThickness * 0.5
                , _caseOptimConstraintSet.NoWalls[1] * _caseOptimConstraintSet.WallThickness * 0.5
                , _caseOptimConstraintSet.NoWalls[2] * _caseOptimConstraintSet.WallThickness * 0.5);

            // apply global transformation using _dir0 / _dir1
            return BoxPosition.Transform(
                new BoxPosition(vPosition + new Vector3D(i * boxLength, j * boxWidth, k * boxHeight), dirLength, dirWidth)
                , GlobalTransformation
                );
        }

        #endregion

    }
}
