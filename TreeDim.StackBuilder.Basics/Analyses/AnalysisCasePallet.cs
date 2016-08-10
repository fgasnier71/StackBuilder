 #region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sharp3D.Math.Core;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisCasePallet : Analysis
    {
        #region Data members
        public PalletProperties _palletProperties;

        public PalletCornerProperties _palletCornerProperties;
        public PalletCapProperties _palletCapProperties;
        public PalletFilmProperties _palletFilmProperties;

        static readonly ILog _log = LogManager.GetLogger(typeof(AnalysisCasePallet));
        #endregion

        #region Constructor
        public AnalysisCasePallet(
            Packable packable, 
            PalletProperties palletProperties,
            ConstraintSetCasePallet constraintSet)
            : base(packable.ParentDocument, packable)
        {
            // sanity checks
            if (palletProperties.ParentDocument != ParentDocument)
                throw new Exception("box & pallet do not belong to the same document");

            _palletProperties = palletProperties;
            _constraintSet = constraintSet;
         }
        #endregion

        #region Analysis override
        public override Vector2D ContainerDimensions
        {
            get
            {
                ConstraintSetCasePallet constraintSet = _constraintSet as ConstraintSetCasePallet;
                return new Vector2D(_palletProperties.Length + 2.0 * constraintSet.Overhang.X, _palletProperties.Width + 2.0 * constraintSet.Overhang.Y); 
            }
        }
        public override double ContainerLoadingVolume
        {
            get
            {
                ConstraintSetCasePallet constraintSet = _constraintSet as ConstraintSetCasePallet;
                return (_palletProperties.Length + 2.0 * constraintSet.Overhang.X) * (_palletProperties.Width + 2.0 * constraintSet.Overhang.Y) * (constraintSet.OptMaxHeight.Value); 
            }
        }
        public override Vector3D Offset
        {
            get
            {
                ConstraintSetCasePallet constraintSet = _constraintSet as ConstraintSetCasePallet;
                return new Vector3D(
                    -constraintSet.Overhang.X
                    , -constraintSet.Overhang.Y
                    , _palletProperties.Height
                    );
            }
        }
        public override double ContainerWeight
        {
            get { return _palletProperties.Weight; }
        }
        public override InterlayerProperties Interlayer(int index)
        {
            return _interlayers[index];
        }
        public override BBox3D BBoxLoadWDeco(BBox3D loadBBox)
        {
            BBox3D bbox = new BBox3D(loadBBox);
            // --- extend for pallet corners: begin
            if (HasPalletCorners)
            {
                double thickness = PalletCornerProperties.Thickness;
                Vector3D ptMin = bbox.PtMin;
                ptMin.X -= thickness;
                ptMin.Y -= thickness;
                Vector3D ptMax = bbox.PtMax;
                ptMax.X += thickness;
                ptMax.Y += thickness;
                bbox.Extend(ptMin);
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
        public override BBox3D BBoxGlobal(BBox3D loadBBox)
        {
            BBox3D bbox = BBoxLoadWDeco(loadBBox);
            // --- extend for pallet : begin
            bbox.Extend(PalletProperties.BoundingBox);
            // --- extend for pallet : end
            return bbox;
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
                _palletProperties.AddDependancy(this);
            }
        }
        public PalletCornerProperties PalletCornerProperties
        {
            get { return _palletCornerProperties; }
            set
            {
                if (_palletCornerProperties == value) return;
                if (null != _palletCornerProperties) _palletCornerProperties.RemoveDependancy(this);
                _palletCornerProperties = value;
                if (null != _palletCornerProperties) _palletCornerProperties.AddDependancy(this);
            }
        }
        public PalletCapProperties PalletCapProperties
        {
            get { return _palletCapProperties; }
            set
            {
                if (_palletCapProperties == value) return;
                if (null != _palletCapProperties) _palletCapProperties.RemoveDependancy(this);
                _palletCapProperties = value;
                if (null != _palletCapProperties) _palletCapProperties.AddDependancy(this);
            }
        }
        public PalletFilmProperties PalletFilmProperties
        {
            get { return _palletFilmProperties; }
            set
            {
                if (_palletFilmProperties == value) return;
                if (null != _palletFilmProperties) _palletFilmProperties.RemoveDependancy(this);
                _palletFilmProperties = value;
                if (null != _palletFilmProperties) _palletFilmProperties.AddDependancy(this);
            }
        }
        public bool HasPalletCorners
        {
            get { return null != _palletCornerProperties; }
        }
        public bool HasPalletCap
        {
            get { return null != _palletCapProperties; }
        }
        public bool HasPalletFilm
        {
            get { return null != _palletFilmProperties; }
        }
        #endregion
    }
}
