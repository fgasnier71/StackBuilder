#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using treeDiM.StackBuilder.Basics;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    #region ImageInst
    public class ImageInst
    {
        #region Data members
        private Analysis _analysis;
        private BoxPosition _boxPosition;
        #endregion
        #region Constructor
        public ImageInst(Analysis analysis, BoxPosition boxPosition)
        {
            _analysis = analysis; _boxPosition = boxPosition;
        }
        #endregion
        #region Public constructor
        public Vector3D PointBase { get { return _boxPosition.Position; } }
        public Analysis Analysis { get { return _analysis; } }
        public HalfAxis.HAxis AxisLength { get { return _boxPosition.DirectionLength; } }
        public HalfAxis.HAxis AxisWidth { get { return _boxPosition.DirectionWidth; } }
        #endregion
    }
    #endregion

    internal class ImageCached
    {
        #region Data members
        private Analysis _analysis;
        private HalfAxis.HAxis _axisLength, _axisWidth;
        private Bitmap _bitmap;
        private Point _offset;
        private Vector3D _vTarget, _vCamera; 
        #endregion

        #region Constructor
        public ImageCached(Analysis analysis, HalfAxis.HAxis axisLength, HalfAxis.HAxis axisWidth)
        {
            _analysis = analysis; _axisLength = axisLength; _axisWidth = axisWidth;
        }
        #endregion
        #region Public properties
        public Analysis Analysis { get { return _analysis; } }
        #endregion
        #region Public methods
        public Bitmap Image(Size s, Vector3D vCamera, Vector3D vTarget, ref Point offset)
        {

            if (
                (
                null == _bitmap
                || ((_vCamera - vCamera).GetLengthSquared() > 1.0E-06 && (_vTarget - vTarget).GetLengthSquared() > 1.0E-06)
                )
                && null != _analysis)
            {
                // generate bitmap
                Graphics3DImage graphics = new Graphics3DImage(s);
                graphics.BackgroundColor = Color.Transparent;
                graphics.CameraPosition = vCamera;
                graphics.Target = vTarget;
                graphics.MarginPercentage = 0.0;
                graphics.ShowDimensions = false;
                using (ViewerSolution viewer = new ViewerSolution(_analysis.Solution))
                { viewer.Draw(graphics, RelativeTransf); }
                graphics.Flush();

                // save bitmap
                _bitmap = graphics.Bitmap;
                _vCamera = vCamera;
                _vTarget = vTarget;
                _offset = graphics.Offset;
            }
            offset = _offset;
            return _bitmap;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Build transformation based on _axisLength & _axisWidth
        /// </summary>
        public Transform3D RelativeTransf
        {
            get
            { 
                Vector3D v1 = HalfAxis.ToVector3D(_axisLength);
                Vector3D v2 = HalfAxis.ToVector3D(_axisWidth);
                Vector3D v3 = Vector3D.CrossProduct(v1, v2);
                Vector3D v4 = Vector3D.Zero;
                return new Transform3D(new Matrix4D(v1,v2,v3,v4));            
            }
        }
        public bool Matches(ImageInst img)
        {
            return _analysis == img.Analysis && _axisLength == img.AxisLength && _axisWidth == img.AxisWidth;
        }
        #endregion
    }
}
