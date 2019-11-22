using System;
using System.Linq;

using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class AnalysisPackablePallet : AnalysisLayered
    {
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

        public override ItemBase Container => _palletProperties;
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
        public override double ContainerWeight => PalletProperties.Weight;
        public override bool HasEquivalentPackable => true;
        public override PackableLoaded EquivalentPackable => new LoadedPallet(this);

        public override InterlayerProperties Interlayer(int index)
        {
            return Interlayers[index];
        }
        public override BBox3D BBoxGlobal(BBox3D loadBBox)
        {
            BBox3D bbox = BBoxLoadWDeco(loadBBox);
            // --- extend for pallet : begin
            bbox.Extend(PalletProperties.BoundingBox);
            // --- extend for pallet : end
            return bbox;
        }

        #region Non-Public Members
        // container
        protected PalletProperties _palletProperties;

        protected AnalysisPackablePallet(
            Packable packable,
            PalletProperties palletProperties,
            ConstraintSetAbstract constraintSet,
            bool temporary = false)
            : base(temporary ? null : packable.ParentDocument, packable)
        {
            // sanity checks
            if ( null != ParentDocument
                && (null != packable.ParentDocument)
                && (palletProperties.ParentDocument != ParentDocument))
                    throw new Exception("box & pallet do not belong to the same document");
            PalletProperties = palletProperties;
            ConstraintSet = constraintSet;
        }

        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
            if (null != _palletProperties)
                _palletProperties.RemoveDependancy(this);
        }
        #endregion
    }
}
