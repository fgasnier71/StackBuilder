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
    #region Analysis packable/case
    public abstract class AnalysisPackableCase : Analysis
    {
        #region Data members
        protected BoxProperties _caseProperties;
        #endregion

        #region Constructor
        public AnalysisPackableCase(Document document, Packable packable, BoxProperties caseProperties, ConstraintSetPackableCase constraintSet)
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
        public override ItemBase Container
        {
            get { return _caseProperties; }
        }
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
        public override bool HasEquivalentPackable
        { get { return true; } }
        public override PackableLoaded EquivalentPackable
        { get { return new LoadedCase(this); } }
        #endregion

        #region AnalysisPackableCase specific
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
        #endregion
    }
    #endregion

    #region AnalysisBoxCase
    public class AnalysisBoxCase : AnalysisPackableCase
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(AnalysisBoxCase));
        #endregion

        #region Constructor
        public AnalysisBoxCase(
            Packable packable,
            BoxProperties caseProperties,
            ConstraintSetBoxCase constraintSet)
            : base(packable.ParentDocument, packable, caseProperties, constraintSet)
        {
        }
        #endregion
    }
    #endregion

    #region Analysis cylinder/case
    public class AnalysisCylinderCase : AnalysisPackableCase
    {
        #region Data members
        #endregion

        #region Constructor
        public AnalysisCylinderCase(
            Packable packable,
            BoxProperties caseProperties,
            ConstraintSetCylinderCase constraintSet)
            : base(packable.ParentDocument, packable, caseProperties, constraintSet)
        { 
        }
        #endregion
    }
    #endregion

    #region LoadedCase
    public class LoadedCase : PackableLoaded
    {
        #region Constructor
        internal LoadedCase(AnalysisPackableCase analysis)
            : base(analysis)
        {
        }
        #endregion

        #region ItemBase override
        public override GlobID ID
        {
            get
            {
                return new GlobID(
                    _analysis.ID.IGuid,
                    string.Format("{0}({1})", Properties.Resource.ID_NAMECASE, _analysis.Name),
                    _analysis.Description
                    ); 
            } 
        }
        #endregion

        #region Specific properties
        public Packable Container
        { get { return Analysis.CaseProperties; } }
        #endregion

        #region Override PackableLoaded
        public override double Length
        { get { return Analysis.CaseProperties.Length; } }
        public override double Width
        { get { return Analysis.CaseProperties.Width; } }
        public override double Height
        { get { return Analysis.CaseProperties.Height; } }
        public override bool InnerContent(ref Packable innerPackable, ref int number)
        {
            innerPackable = ParentAnalysis.Content;
            number = ParentSolution.ItemCount;
            return true;
        }
        protected override string TypeName
        { get { return Properties.Resource.ID_LOADEDCASE; } }
        public override bool IsCase
        { get { return true; } }
        #endregion

        #region Helpers
        private AnalysisBoxCase Analysis
        { get { return ParentAnalysis as AnalysisBoxCase; } }
        #endregion
    }
    #endregion
}
