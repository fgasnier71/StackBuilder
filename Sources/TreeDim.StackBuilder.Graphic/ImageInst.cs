#region Using directives
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    #region ImageInst
    public class ImageInst
    {
        #region Constructor
        public ImageInst(AnalysisHomo analysis, Vector3D dims, BoxPosition boxPosition)
        {
            Analysis = analysis; Dims = dims; BoxPosition = boxPosition;
        }
        #endregion
        #region Private properties
        private Vector3D Dims { get; set; }
        private BoxPosition BoxPosition { get; set; }
        #endregion
        #region Public properties
        public Vector3D PointBase { get { return BoxPosition.Position; } }
        public AnalysisHomo Analysis { get; set; }
        public HalfAxis.HAxis AxisLength { get { return BoxPosition.DirectionLength; } }
        public HalfAxis.HAxis AxisWidth { get { return BoxPosition.DirectionWidth; } }
        #endregion
        #region Box conversion (needed for BoxelOrderer)
        public Box ToBox() => new Box(0, Dims.X, Dims.Y, Dims.Z, BoxPosition);
        #endregion
    }
    #endregion

    internal class ImageCached
    {
        #region Data members
        public HalfAxis.HAxis AxisLength { get; private set; }
        public HalfAxis.HAxis AxisWidth { get; private set; }
        private Bitmap _bitmap;
        private Point Offset { get; set; }
        private Vector3D _vTarget, _vCamera; 
        #endregion

        #region Constructor
        public ImageCached(AnalysisHomo analysis, HalfAxis.HAxis axisLength, HalfAxis.HAxis axisWidth)
        {
            Analysis = analysis; AxisLength = axisLength; AxisWidth = axisWidth;
        }
        #endregion
        #region Public properties
        public AnalysisHomo Analysis { get; }
        #endregion
        #region Public methods
        public Bitmap Image(Size s, Vector3D vCamera, Vector3D vTarget, ref Point offset)
        {

            if (
                (
                null == _bitmap
                || ((_vCamera - vCamera).GetLengthSquared() > 1.0E-06 && (_vTarget - vTarget).GetLengthSquared() > 1.0E-06)
                )
                && null != Analysis)
            {
                // generate bitmap
                Graphics3DImage graphics = new Graphics3DImage(s)
                {
                    BackgroundColor = Color.Transparent,
                    CameraPosition = vCamera,
                    Target = vTarget,
                    MarginPercentage = 0.0,
                    ShowDimensions = false
                };
                if (Analysis is AnalysisLayered analysisLay)
                {
                    using (var viewer = new ViewerSolution(analysisLay.SolutionLay))
                    { viewer.Draw(graphics, RelativeTransf); }
                }
                else if (Analysis is AnalysisHCyl analysisHCyl)
                {
                    using (var viewer = new ViewerSolutionHCyl(analysisHCyl.Solution as SolutionHCyl))
                    { viewer.Draw(graphics, RelativeTransf); }
                }
                graphics.Flush();

                // save bitmap
                _bitmap = graphics.Bitmap;
                _vCamera = vCamera;
                _vTarget = vTarget;
                Offset = graphics.Offset;
            }
            offset = Offset;
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
                Vector3D v1 = HalfAxis.ToVector3D(AxisLength);
                Vector3D v2 = HalfAxis.ToVector3D(AxisWidth);
                Vector3D v3 = Vector3D.CrossProduct(v1, v2);
                Vector3D v4 = Vector3D.Zero;
                return new Transform3D(new Matrix4D(v1,v2,v3,v4));            
            }
        }
        public bool Matches(ImageInst img)
        {
            return Analysis == img.Analysis && AxisLength == img.AxisLength && AxisWidth == img.AxisWidth;
        }
        #endregion
    }
}
