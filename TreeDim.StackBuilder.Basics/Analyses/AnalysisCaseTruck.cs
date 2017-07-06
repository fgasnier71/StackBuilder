#region Using directive
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharp3D.Math.Core;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    #region AnalysisPackableTruck
    public abstract class AnalysisPackableTruck : Analysis
    {
        #region Data members
        protected TruckProperties _truckProperties;
        #endregion

        #region Constructor
        public AnalysisPackableTruck(Document document, Packable packable, TruckProperties truckProperties,
            ConstraintSetPackableTruck constraintSet)
            : base(document, packable)
        {
            // sanity checks
            if ((null != truckProperties.ParentDocument)
                && truckProperties.ParentDocument != ParentDocument)
                throw new Exception("case & truck do not belong to the same document");
            // also add dependancy
            TruckProperties = truckProperties;

            _constraintSet = constraintSet;
        }
        #endregion

        #region Override ItemBase
        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
            _truckProperties.RemoveDependancy(this);
        }
        #endregion

        #region Analysis override
        public override ItemBase Container                  { get { return _truckProperties; } }
        public override Vector2D ContainerDimensions
        {
            get
            {
                ConstraintSetCaseTruck constraintSet = _constraintSet as ConstraintSetCaseTruck;
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
                ConstraintSetCaseTruck constraintSet = _constraintSet as ConstraintSetCaseTruck;
                return new Vector3D(
                    constraintSet.MinDistanceLoadWall.X
                    , constraintSet.MinDistanceLoadWall.Y
                    , 0.0); 
            } 
        }
        public override double ContainerWeight              { get { return 0.0; } }
        public override double ContainerLoadingVolume       { get { return _truckProperties.Volume; } }
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
        public override bool HasEquivalentPackable          { get { return false; } }
        public override PackableLoaded EquivalentPackable   { get { return null; } }
        #endregion

        #region AnalysisPackableTruck
        public TruckProperties TruckProperties
        {
            get { return _truckProperties; }
            set
            {
                if (_truckProperties == value) return;
                if (null != _truckProperties) _truckProperties.RemoveDependancy(this);
                _truckProperties = value;
                _truckProperties.AddDependancy(this);
            }
        }
        #endregion
    }
    #endregion

    #region AnalysisCaseTruck
    public class AnalysisCaseTruck : AnalysisPackableTruck
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(AnalysisCaseTruck));
        #endregion

        #region Constructor
        public AnalysisCaseTruck(Document doc, Packable packable, TruckProperties truckProperties, ConstraintSetPackableTruck constraintSet)
            : base(doc, packable, truckProperties, constraintSet)
        { 
        }
        #endregion
    }
    #endregion

}
