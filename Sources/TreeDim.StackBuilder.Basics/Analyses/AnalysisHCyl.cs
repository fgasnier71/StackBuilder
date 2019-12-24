#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public abstract class AnalysisHCyl : AnalysisHomo
    {
        protected AnalysisHCyl(Document doc, CylinderProperties cylinder) : base(doc, cylinder)
        {
        }
        #region Solution
        public void SetSolution(HCylLayout layout)
        {
            Solution = new SolutionHCyl(this, layout.PatternName, layout.Swapped);
        }
        #endregion
    }

    public class AnalysisHCylPallet : AnalysisHCyl
    {
        #region Constructor
        public AnalysisHCylPallet(Document doc, CylinderProperties cylinder, PalletProperties palletProperties, ConstraintSetPackablePallet constraintSet)
            : base(doc, cylinder)
        {
            _palletProperties = palletProperties;
            ConstraintSet = constraintSet;
        }
        #endregion

        #region Public properties
        public PalletProperties PalletProperties
        {
            get { return _palletProperties; }
            set
            {
                if (_palletProperties == value) return;
                if (null != _palletProperties) _palletProperties.RemoveDependancy(this);
                _palletProperties = value;
                if (null != ParentDocument)
                    _palletProperties?.AddDependancy(this);
            }
        }
        #endregion



        #region Override AnalysisHomo
        public override ItemBase Container => PalletProperties;
        public override double ContainerWeight => PalletProperties.Weight;
        public override Vector2D ContainerDimensions
        {
            get
            {
                ConstraintSetPackablePallet constraintSet = ConstraintSet as ConstraintSetPackablePallet;
                return new Vector2D(
                    _palletProperties.Length + 2.0 * constraintSet.Overhang.X,
                    _palletProperties.Width + 2.0 * constraintSet.Overhang.Y);
            }
        }
        public override Vector3D Offset
        {
            get
            {
                ConstraintSetPackablePallet constraintSet = ConstraintSet as ConstraintSetPackablePallet;
                return new Vector3D(
                    -constraintSet.Overhang.X
                    , -constraintSet.Overhang.Y
                    , PalletProperties.Height
                    );
            }
        }
        public override double ContainerLoadingVolume
        {
            get
            {
                ConstraintSetPackablePallet constraintSet = ConstraintSet as ConstraintSetPackablePallet;
                return (_palletProperties.Length + 2.0 * constraintSet.Overhang.X)
                    * (_palletProperties.Width + 2.0 * constraintSet.Overhang.Y)
                    * (constraintSet.OptMaxHeight.Value - _palletProperties.Height);
            }
        }
        public override BBox3D BBoxGlobal(BBox3D loadBBox)
        {
            BBox3D bbox = BBoxLoadWDeco(loadBBox);
            // --- extend for pallet : begin
            bbox.Extend(PalletProperties.BoundingBox);
            // --- extend for pallet : end
            return bbox;
        }
        public override BBox3D BBoxLoadWDeco(BBox3D loadBBox) => loadBBox;
        public override void RecomputeSolution() {}
        #endregion

        #region Data members
        private PalletProperties _palletProperties;
        #endregion
    }

    public class AnalysisHCylTruck : AnalysisHCyl
    {
        #region Constructor
        public AnalysisHCylTruck(Document doc, CylinderProperties cylinder, TruckProperties truckProperties, ConstraintSetPackableTruck constraintSet)
            : base(doc, cylinder)
        {
            TruckProperties = truckProperties;
            ConstraintSet = constraintSet;
        }
        #endregion
        #region Public properties
        public TruckProperties TruckProperties
        {
            get => _truckProperties;
            set
            {
                if (_truckProperties == value) return;
                if (null != _truckProperties) _truckProperties.RemoveDependancy(this);
                _truckProperties = value;
                if (null != ParentDocument)
                    _truckProperties?.AddDependancy(this);
            }
        }
        #endregion
        #region Override AnalysisHCyl
        public override ItemBase Container => TruckProperties;
        public override Vector2D ContainerDimensions => new Vector2D(TruckProperties.Length, TruckProperties.Width);
        public override Vector3D Offset => Vector3D.Zero;
        public override double ContainerWeight => 0.0;
        public override double ContainerLoadingVolume => throw new System.NotImplementedException();
        public override BBox3D BBoxGlobal(BBox3D loadBBox) => TruckProperties.BoundingBox;
        public override BBox3D BBoxLoadWDeco(BBox3D loadBBox) => loadBBox;
        public override void RecomputeSolution() {}
        #endregion
        #region Data members
        private TruckProperties _truckProperties;
        #endregion
    }
}
