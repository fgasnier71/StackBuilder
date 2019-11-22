using System;

using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class AnalysisPackableCase : AnalysisLayered
    {
        public BoxProperties CaseProperties
        {
            get => _caseProperties;
            set
            {
                if (_caseProperties == value) return;
                if (null != _caseProperties) _caseProperties.RemoveDependancy(this);
                _caseProperties = value;
                if (null != ParentDocument)
                    _caseProperties?.AddDependancy(this);
            }
        }

        public override ItemBase Container => _caseProperties;
        public override Vector2D ContainerDimensions => new Vector2D(_caseProperties.InsideLength, _caseProperties.InsideWidth);
        public override double ContainerWeight => _caseProperties.Weight;
        public override double ContainerLoadingVolume => _caseProperties.InsideVolume;
        public override bool HasEquivalentPackable => true;
        public override PackableLoaded EquivalentPackable => new LoadedCase(this);
        public override Vector3D Offset
        {
            get
            {
                return new Vector3D(
                    0.0,
                    0.0,
                    _caseProperties.Height - _caseProperties.InsideHeight > 0 ? 0.5 * (_caseProperties.Height - _caseProperties.InsideHeight) : 0.0
                    );
            }
        }

        public override bool AllowInterlayer(InterlayerProperties interlayer) => interlayer.Length <= _caseProperties.InsideLength  && interlayer.Width <= _caseProperties.InsideWidth;
        public override BBox3D BBoxGlobal(BBox3D loadBBox) => new BBox3D(0.0, 0.0, 0.0, _caseProperties.InsideLength, _caseProperties.InsideWidth, _caseProperties.InsideHeight);
        public override BBox3D BBoxLoadWDeco(BBox3D loadBBox) => loadBBox;

        #region Non-Public Members
        protected BoxProperties _caseProperties;

        protected AnalysisPackableCase(
            Document document,
            Packable packable,
            BoxProperties caseProperties,
            ConstraintSetPackableContainer constraintSet)
            : base(document, packable)
        {
            // sanity checks
            if (null != ParentDocument
                && (null != caseProperties.ParentDocument)
                && caseProperties.ParentDocument != ParentDocument)
                throw new Exception("box & case do not belong to the same document");
            // also add dependancy
            CaseProperties = caseProperties;

            ConstraintSet = constraintSet;
        }

        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
            if (null != _caseProperties)
                _caseProperties.RemoveDependancy(this);
        }
        #endregion
    }
}
