#region Using directives
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    #region SubContent
    public class SubContent
    {
        // constructors
        public SubContent(AnalysisHomo analysis)
        {
            Analysis = analysis;
        }
        public SubContent(PackProperties pack)
        {
            PackProperties = pack;
        }
        public SubContent(BagProperties bag)
        {
            BagProperties = bag;
        }
        public SubContent(InterlayerProperties interlayer)
        {
            InterlayerProperties = interlayer;
        }
        public void Draw(Graphics3D graphics, Transform3D transf)
        {
            if (Analysis is AnalysisLayered analysisLay)
            {
                using (var viewer = new ViewerSolution(analysisLay.SolutionLay))
                { viewer.Draw(graphics, transf); }
            }
            else if (Analysis is AnalysisHCyl analysisHCyl)
            {
                using (var viewer = new ViewerSolutionHCyl(analysisHCyl.Solution as SolutionHCyl))
                { viewer.Draw(graphics, transf); }
            }
            else if (null != PackProperties)
            {
                Pack pack = new Pack(0, PackProperties, new BoxPosition(Vector3D.Zero).Transform(transf));
                graphics.AddBox(pack);
            }
            else if (null != InterlayerProperties)
            {
                Box box = new Box(0, InterlayerProperties, new BoxPosition(Vector3D.Zero).Transform(transf));
                graphics.AddBox(box);
            }
            else if (null != BagProperties)
            {
                BoxRounded bag = new BoxRounded(0, BagProperties, new BoxPosition(Vector3D.Zero).Transform(transf));
                graphics.AddBox(bag);            
            }
        }
        public BBox3D Bbox
        {
            get
            {
                if (null != Analysis) return Analysis.Solution.BBoxGlobal;
                else if (null != PackProperties) return new BBox3D(Vector3D.Zero, PackProperties.OuterDimensions);
                else if (null != InterlayerProperties) return new BBox3D(Vector3D.Zero, InterlayerProperties.Dimensions);
                else if (null != BagProperties) return new BBox3D(Vector3D.Zero, BagProperties.OuterDimensions);
                else return BBox3D.Initial;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is SubContent contentObj)
                return contentObj.Analysis == Analysis
                    && contentObj.PackProperties == PackProperties
                    && contentObj.InterlayerProperties == InterlayerProperties
                    && contentObj.BagProperties == BagProperties;
            else
                return false;
        }

        private AnalysisHomo Analysis { get; set; }
        private PackProperties PackProperties { get; set; }
        private BagProperties BagProperties { get; set; }
        private InterlayerProperties InterlayerProperties { get; set; }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
    #endregion

    #region ImageInst
    public class ImageInst
    {
        #region Constructor
        public ImageInst(uint pickId, SubContent content, Vector3D dims, BoxPosition boxPosition)
        {
            PickId = pickId;
            Content = content;
            Dimensions = dims;
            BoxPosition = boxPosition;
        }
        #endregion
        #region Private properties
        public uint PickId { get; set; }
        private Vector3D Dimensions { get; set; }
        private BoxPosition BoxPosition { get; set; }
        public BBox3D GetBBox() => new BBox3D(BoxPosition, Dimensions);
        #endregion
        #region Public properties
        public Vector3D PointBase { get { return BoxPosition.Position; } }
        public SubContent Content { get; set; }
        public HalfAxis.HAxis AxisLength { get { return BoxPosition.DirectionLength; } }
        public HalfAxis.HAxis AxisWidth { get { return BoxPosition.DirectionWidth; } }
        #endregion
        #region Box conversion (needed for BoxelOrderer)
        public Box ToBox() => new Box(PickId, Dimensions.X, Dimensions.Y, Dimensions.Z, BoxPosition);
        #endregion
    }
    #endregion

    internal class ImageCached
    {
        #region Constructor
        public ImageCached(SubContent subContent, HalfAxis.HAxis axisLength, HalfAxis.HAxis axisWidth)
        {
            Content = subContent; AxisLength = axisLength; AxisWidth = axisWidth;
        }
        #endregion
        #region Public properties
        public SubContent Content { get; }
        #endregion
        #region Public methods
        public Bitmap Image(Size s, Vector3D vCamera, Vector3D vTarget, ref Point offset)
        {
            if 
                (
                null == Bitmap
                || ((VCamera - vCamera).GetLengthSquared() > 1.0E-06 && (VTarget - vTarget).GetLengthSquared() > 1.0E-06)
                )
            {
                // generate bitmap
                var graphics = new Graphics3DImage(s)
                {
                    BackgroundColor = Color.Transparent,
                    CameraPosition = vCamera,
                    Target = vTarget,
                    MarginPercentage = 0.0,
                    ShowDimensions = false
                };
                Content?.Draw(graphics, RelativeTransf);
                graphics.Flush();

                // save bitmap
                Bitmap = graphics.Bitmap;
                VCamera = vCamera;
                VTarget = vTarget;
                Offset = graphics.Offset;
            }
            offset = Offset;
            return Bitmap;
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
                var v1 = HalfAxis.ToVector3D(AxisLength);
                var v2 = HalfAxis.ToVector3D(AxisWidth);
                var v3 = Vector3D.CrossProduct(v1, v2);
                var v4 = Vector3D.Zero;
                return new Transform3D(new Matrix4D(v1,v2,v3,v4));            
            }
        }
        public bool Matches(ImageInst img) => Content.Equals(img.Content) && AxisLength == img.AxisLength && AxisWidth == img.AxisWidth;
        #endregion
        #region Data members
        private HalfAxis.HAxis AxisLength { get; }
        private HalfAxis.HAxis AxisWidth { get; }
        private Bitmap Bitmap { get; set; }
        private Point Offset { get; set; }
        private Vector3D VTarget { get; set; }
        private Vector3D VCamera { get; set; }
        #endregion
    }
}
