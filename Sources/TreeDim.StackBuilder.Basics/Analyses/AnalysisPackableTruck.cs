using System;

using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class AnalysisPackableTruck : AnalysisLayered
    {
        public override ItemBase Container => _truckProperties;
        public override Vector2D ContainerDimensions
        {
            get
            {
                if (ConstraintSet is ConstraintSetCaseTruck constraintSet)
                {
                    return new Vector2D(
                        _truckProperties.InsideLength - 2.0 * constraintSet.MinDistanceLoadWall.X
                        , _truckProperties.InsideWidth - 2.0 * constraintSet.MinDistanceLoadWall.Y
                        );
                }
                else if (ConstraintSet is ConstraintSetCylinderTruck constraintSetCylTruck)
                {
                    return new Vector2D(
                        _truckProperties.InsideLength - 2.0 * constraintSetCylTruck.MinDistanceLoadWall.X
                        , _truckProperties.InsideWidth - 2.0 * constraintSetCylTruck.MinDistanceLoadWall.Y
                        );
                }
                else
                    return Vector2D.Zero;
            }
        }
        public override double ContainerLoadingVolume => _truckProperties.Volume;
        public override double ContainerWeight => 0.0;
        public override bool HasEquivalentPackable { get { return false; } }
        public override PackableLoaded EquivalentPackable { get { return null; } }
        public override Vector3D Offset
        {
            get
            {
                if (ConstraintSet is ConstraintSetCaseTruck constraintSet)
                {
                    return new Vector3D(
                        constraintSet.MinDistanceLoadWall.X
                        , constraintSet.MinDistanceLoadWall.Y
                        , 0.0);
                }
                else if (ConstraintSet is ConstraintSetCylinderTruck constraintSetCyl)
                {
                    return new Vector3D(
                        constraintSetCyl.MinDistanceLoadWall.X
                        , constraintSetCyl.MinDistanceLoadWall.Y
                        , 0.0);
                }
                else
                    return Vector3D.Zero;
            }
        }
        public TruckProperties TruckProperties
        {
            get { return _truckProperties; }
            set
            {
                if (_truckProperties == value) return;
                _truckProperties?.RemoveDependancy(this);
                _truckProperties = value;
                if (null != _truckProperties)
                    _truckProperties?.AddDependancy(this);
            }
        }

        public override BBox3D BBoxGlobal(BBox3D loadBBox)
        {
            return new BBox3D(
                0.0, 0.0, 0.0,
                _truckProperties.Length, _truckProperties.Width, _truckProperties.Height);
        }
        public override BBox3D BBoxLoadWDeco(BBox3D loadBBox)
        {
            return loadBBox;
        }

        #region Non-Public Members
        protected TruckProperties _truckProperties;

        protected AnalysisPackableTruck(Document document, Packable packable, TruckProperties truckProperties,
            ConstraintSetAbstract constraintSet)
            : base(document, packable)
        {
            // sanity checks
            if ( null != ParentDocument
                && null != truckProperties.ParentDocument
                && truckProperties.ParentDocument != ParentDocument)
                throw new Exception("content & truck do not belong to the same document");
            // also add dependancy
            TruckProperties = truckProperties;

            ConstraintSet = constraintSet;
        }

        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
            if (null != _truckProperties)
                _truckProperties.RemoveDependancy(this);
        }
        #endregion
    }
}
