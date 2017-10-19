using System;
using System.Linq;

using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class AnalysisPackableCase : Analysis
    {
        public BoxProperties CaseProperties
        {
            get { return _caseProperties; }
            set
            {
                if (_caseProperties == value) return;
                if (null != _caseProperties) _caseProperties.RemoveDependancy(this);
                _caseProperties = value;
                _caseProperties.AddDependancy(this);
            }
        }

        public override ItemBase Container => _caseProperties;
        public override Vector2D ContainerDimensions =>
            new Vector2D(_caseProperties.InsideLength, _caseProperties.InsideWidth);
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
                    0.5 * (_caseProperties.Height - _caseProperties.InsideHeight)
                    );
            }
        }

        public override bool AllowInterlayer(InterlayerProperties interlayer)
        {
            return interlayer.Length < _caseProperties.InsideLength
                && interlayer.Width < _caseProperties.InsideWidth;
        }

        public override BBox3D BBoxGlobal(BBox3D loadBBox)
        {
            return new BBox3D(
                0.0, 0.0, 0.0,
                _caseProperties.InsideLength, _caseProperties.InsideWidth, _caseProperties.InsideHeight);
        }

        public override BBox3D BBoxLoadWDeco(BBox3D loadBBox)
        {
            return loadBBox;
        }

        #region Non-Public Members
        protected BoxProperties _caseProperties;

        protected AnalysisPackableCase(Document document, Packable packable, BoxProperties caseProperties, ConstraintSetPackableCase constraintSet)
            : base(document, packable)
        {
            // sanity checks
            if ((null != caseProperties.ParentDocument)
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
