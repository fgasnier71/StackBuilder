#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisCasePallet : AnalysisPackablePallet
    {
        #region Constructor
        public AnalysisCasePallet(
            Packable packable,
            PalletProperties palletProperties,
            ConstraintSetCasePallet constraintSet,
            bool temporary = false)
            : base(packable, palletProperties, constraintSet, temporary)
        {
        }
        #endregion

        #region Specific case/pallet decoration 
        public StrapperSet StrapperSet
        {
            get => _strapperSet;
            set
            {
                _strapperSet = value;
                SolutionLay.ClearStrapperSets();
            }
        }
        public PalletCornerProperties PalletCornerProperties
        {
            get { return _palletCornerProperties; }
            set
            {
                if (_palletCornerProperties == value) return;
                _palletCornerProperties?.RemoveDependancy(this);
                _palletCornerProperties = value;
                if (!Temporary && null != ParentDocument)
                    _palletCornerProperties?.AddDependancy(this);
            }
        }
        public PalletCornerProperties PalletCornerTopProperties
        {
            get => _palletCornerTopProperties;
            set
            {
                if (_palletCornerTopProperties == value) return;
                _palletCornerTopProperties?.RemoveDependancy(this);
                _palletCornerTopProperties = value;
                if (!Temporary && null != ParentDocument)
                    _palletCornerTopProperties?.AddDependancy(this);
            }
        }
        public PalletCapProperties PalletCapProperties
        {
            get { return _palletCapProperties; }
            set
            {
                if (_palletCapProperties == value) return;
                _palletCapProperties?.RemoveDependancy(this);
                _palletCapProperties = value;
                if (!Temporary && null != ParentDocument)
                    _palletCapProperties?.AddDependancy(this);
            }
        }
        public PalletFilmProperties PalletFilmProperties
        {
            get { return _palletFilmProperties; }
            set
            {
                if (_palletFilmProperties == value) return;
                _palletFilmProperties?.RemoveDependancy(this);
                _palletFilmProperties = value;
                if (!Temporary && null != ParentDocument)
                    _palletFilmProperties?.AddDependancy(this);
            }
        }
        public bool HasPalletCorners => null != _palletCornerProperties;
        public bool HasPalletCornersTop => null != _palletCornerTopProperties;
        public bool HasPalletCap => null != _palletCapProperties;
        public bool HasPalletFilm => null != _palletFilmProperties;
        public bool HasStrappers => null != StrapperSet;
        #endregion

        #region Override AnalysisHomo
        public override BBox3D BBoxLoadWDeco(BBox3D loadBBox)
        {
            var bbox = new BBox3D(loadBBox);
            // --- extend for pallet corners: begin
            double thickness = System.Math.Max(
                (HasPalletCorners ? PalletCornerProperties.Thickness : 0.0),
                (HasPalletCornersTop ? PalletCornerTopProperties.Thickness : 0.0)
                );
            if (HasPalletCorners || HasPalletCornersTop)
            {
                Vector3D ptMin = bbox.PtMin;
                ptMin.X -= thickness;
                ptMin.Y -= thickness;
                Vector3D ptMax = bbox.PtMax;
                ptMax.X += thickness;
                ptMax.Y += thickness;
                bbox.Extend(ptMin);
                bbox.Extend(ptMax);
            }
            if (HasPalletCornersTop)
            {
                double thicknessTop = PalletCornerTopProperties.Thickness;
                Vector3D ptMax = bbox.PtMax;
                ptMax.Z += thicknessTop;
                bbox.Extend(ptMax);
            }
            // --- extend for pallet corners: end
            // --- extend for pallet cap : begin
            if (HasPalletCap)
            {
                double zMax = bbox.PtMax.Z;
                Vector3D v0 = new Vector3D(
                        0.5 * (PalletProperties.Length - PalletCapProperties.Length),
                        0.5 * (PalletProperties.Width - PalletCapProperties.Width),
                        zMax + PalletCapProperties.Height - PalletCapProperties.InsideHeight);
                bbox.Extend(v0);
                Vector3D v1 = new Vector3D(
                    0.5 * (PalletProperties.Length + PalletCapProperties.Length),
                    0.5 * (PalletProperties.Width + PalletCapProperties.Width),
                    zMax + PalletCapProperties.Height - PalletCapProperties.InsideHeight);
                bbox.Extend(v1);
            }
            // --- extend for pallet cap : end 
            return bbox;
        }
        #endregion

        #region Non-Public Members
        private PalletCornerProperties _palletCornerProperties;
        private PalletCornerProperties _palletCornerTopProperties;
        private PalletCapProperties _palletCapProperties;
        private PalletFilmProperties _palletFilmProperties;
        private StrapperSet _strapperSet = new StrapperSet();
        #endregion
    }
}
