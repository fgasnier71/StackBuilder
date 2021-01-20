#region Using directives
using System.Collections.Generic;
using System;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.TechnologyBSA_ASPNET
{
    public class BoxPositionJS
    {
        #region Public properties
        public int Index { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Angle { get; set; }
        public int NumberCase { get; set; }
        #endregion
    }

    public class PalletDimsJS
    {
        #region Public properties
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        #endregion
    }

    public class CanvasCoordConverter
    {
        public CanvasCoordConverter(int canvasWidth, int canvasHeight, Vector2D ptMin, Vector2D ptMax)
        {
            PtMin = ptMin;
            PtMax = ptMax;
            CanvasWidth = canvasWidth;
            CanvasHeight = canvasHeight;
        }
        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }
        public Vector2D PtMin { get; set; }
        public Vector2D PtMax { get; set; }
        public double Scale => CanvasHeight / (PtMax.Y - PtMin.Y);
        public double LengthCanvasToWorld(double lcanvas) => lcanvas / Scale;
        public double LengthWorldToCanvas(double lworld) => lworld * Scale;
        public Vector2D PtCanvasToWorld(Vector2D vCanvas)
        {
            return new Vector2D(
                PtMin.X + vCanvas.X / Scale,
                PtMax.Y - vCanvas.Y / Scale
                );
        }
        public Vector2D PtWorldToCanvas(Vector2D vWorld)
        {
            return new Vector2D(
                (Scale) * (vWorld.X - PtMin.X),
                (Scale) * (PtMax.Y - vWorld.Y)
                );
        }

        public BoxPositionJS BPosWorldToCanvas(BoxPositionIndexed bposi, int number, Vector3D dimCase)
        {
            // angle
            double angle = 0;
            Vector2D offsetPos = Vector2D.Zero;
            switch (bposi.BPos.DirectionLength)
            {
                case HalfAxis.HAxis.AXIS_X_P: angle = 0.0; offsetPos = new Vector2D(0.0, -dimCase.Y); break;
                case HalfAxis.HAxis.AXIS_Y_P: angle = 90.0; offsetPos = new Vector2D(0.0, -dimCase.X); break;
                case HalfAxis.HAxis.AXIS_X_N: angle = 180.0; offsetPos = new Vector2D(0.0, dimCase.Y); break;
                case HalfAxis.HAxis.AXIS_Y_N: angle = 270.0; offsetPos = new Vector2D(0.0, dimCase.X); break;
                default: break;
            }

            Vector2D canvasPosition = PtWorldToCanvas(new Vector2D(bposi.BPos.Position.X, bposi.BPos.Position.Y) - offsetPos);
            return new BoxPositionJS()
            {
                X = canvasPosition.X,
                Y = canvasPosition.Y,
                Angle = angle,
                NumberCase = number,
                Index = bposi.Index
            };
        }

        public List<BoxPositionIndexed> ToBoxPositionIndexed(BoxPositionJS bposjs, Vector3D dimCase, int relIndex)
        {
            HalfAxis.HAxis axisLength = HalfAxis.HAxis.AXIS_X_P;
            HalfAxis.HAxis axisWidth = HalfAxis.HAxis.AXIS_Y_P;
            Vector2D offsetPos = Vector2D.Zero;
            Vector3D multDir = Vector3D.Zero;

            if (Math.Abs(bposjs.Angle) < 1.0)
            { axisLength = HalfAxis.HAxis.AXIS_X_P; axisWidth = HalfAxis.HAxis.AXIS_Y_P; offsetPos = new Vector2D(0.0, -dimCase.Y); multDir = -Vector3D.YAxis; }
            else if (Math.Abs(bposjs.Angle - 90.0) < 1.0)
            { axisLength = HalfAxis.HAxis.AXIS_Y_P; axisWidth = HalfAxis.HAxis.AXIS_X_N; offsetPos = new Vector2D(0.0, -dimCase.X); multDir = -Vector3D.XAxis; }
            else if (Math.Abs(bposjs.Angle - 180.0) < 1.0)
            { axisLength = HalfAxis.HAxis.AXIS_X_N; axisWidth = HalfAxis.HAxis.AXIS_Y_N; offsetPos = new Vector2D(0.0, dimCase.Y); multDir = Vector3D.YAxis; }
            else if (Math.Abs(bposjs.Angle - 270.0) < 1.0)
            { axisLength = HalfAxis.HAxis.AXIS_Y_N; axisWidth = HalfAxis.HAxis.AXIS_X_P; offsetPos = new Vector2D(0.0, dimCase.X); multDir = Vector3D.XAxis; }

            var boxPositions = new List<BoxPositionIndexed>();
            Vector2D pos2D = PtCanvasToWorld(new Vector2D(bposjs.X, bposjs.Y)) + offsetPos;

            for (int i = 0; i < bposjs.NumberCase; ++i)
            {
                Vector3D position = new Vector3D(pos2D.X, pos2D.Y, 0.0) + i * dimCase.Y * multDir;
                boxPositions.Add(new BoxPositionIndexed(position, axisLength, axisWidth, relIndex));
            }
            return boxPositions;
        }
    }
}