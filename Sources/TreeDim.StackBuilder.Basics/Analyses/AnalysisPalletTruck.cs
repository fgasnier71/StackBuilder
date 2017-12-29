using Sharp3D.Math.Core;
using log4net;

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisPalletTruck : Analysis
    {
        public AnalysisPalletTruck(
            Packable packable,
            TruckProperties truckProperties,
            ConstraintSetPalletTruck constraintSet)
            : base(packable.ParentDocument, packable)
        {
            TruckProperties = truckProperties;
            ConstraintSet = constraintSet;
        }
        public override bool AlternateLayersPref => false;
        public override ItemBase Container => _truckProperties;
        public override double ContainerWeight => 0.0;
        public override double ContainerLoadingVolume => _truckProperties.Volume;
        public override Vector2D ContainerDimensions
        {
            get
            {
                ConstraintSetPalletTruck constraintSet = ConstraintSet as ConstraintSetPalletTruck;
                return new Vector2D(
                    _truckProperties.InsideLength - 2.0 * constraintSet.MinDistanceLoadWall.X
                    , _truckProperties.InsideWidth - 2.0 * constraintSet.MinDistanceLoadWall.Y
                    );
            }
        }
        public override Vector3D Offset
        {
            get
            {
                ConstraintSetPalletTruck constraintSet = ConstraintSet as ConstraintSetPalletTruck;
                return new Vector3D(
                    constraintSet.MinDistanceLoadWall.X
                    , constraintSet.MinDistanceLoadWall.Y
                    , 0.0); 
            }
        }
        public override bool HasEquivalentPackable => false;
        public override PackableLoaded EquivalentPackable => null;

        public TruckProperties TruckProperties
        {
            get { return _truckProperties; }
            set
            {
                if (_truckProperties == value) return;
                _truckProperties?.RemoveDependancy(this);
                _truckProperties = value;
                if (null != ParentDocument)
                    _truckProperties?.AddDependancy(this);
            }
        }

        public override BBox3D BBoxGlobal(BBox3D loadBox)
        {
            return new BBox3D(
                0.0, 0.0, 0.0,
                _truckProperties.Length, _truckProperties.Width, _truckProperties.Height);
        }
        public override BBox3D BBoxLoadWDeco(BBox3D loadBBox) => loadBBox;

        #region Non-Public Members

        private TruckProperties _truckProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(AnalysisPalletTruck));

        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
            if (null != _truckProperties)
                _truckProperties.RemoveDependancy(this);
        }

        #endregion
    }
}
