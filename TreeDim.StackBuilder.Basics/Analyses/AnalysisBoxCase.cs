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
    public class AnalysisBoxCase : Analysis
    {
        #region Data members
        public BoxProperties _caseProperties;

        static readonly ILog _log = LogManager.GetLogger(typeof(AnalysisBoxCase));
        #endregion

        #region Constructor
        public AnalysisBoxCase(
            Packable packable,
            BoxProperties caseProperties,
            ConstraintSetBoxCase constraintSet)
            : base(packable.ParentDocument, packable)
        {
            // sanity checks
            if (caseProperties.ParentDocument != ParentDocument)
                throw new Exception("box & case do not belong to the same document");

            _caseProperties = caseProperties;
            _constraintSet = constraintSet;
        }
        #endregion

        #region Analysis override
        public override Vector2D ContainerDimensions
        {
            get { return new Vector2D(_caseProperties.InsideLength, _caseProperties.InsideWidth); }
        }
        public override Vector3D Offset
        {
            get
            {
                return new Vector3D(
                    0.0, //0.5 * (_caseProperties.Length - _caseProperties.InsideLength),
                    0.0, //0.5 * (_caseProperties.Width - _caseProperties.InsideWidth),
                    0.5 * (_caseProperties.Height - _caseProperties.InsideHeight)
                    );
            }
        }
        public override double ContainerWeight
        {
            get { return _caseProperties.Weight; }
        }
        public override double ContainerLoadingVolume
        {
            get { return _caseProperties.InsideVolume; }
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
        public override bool AllowInterlayer(InterlayerProperties interlayer)
        {
            return interlayer.Length < _caseProperties.InsideLength
                && interlayer.Width < _caseProperties.InsideWidth;
        }
        #endregion

        #region Public properties
        #endregion

        #region Public methods
        #endregion
    }
}
