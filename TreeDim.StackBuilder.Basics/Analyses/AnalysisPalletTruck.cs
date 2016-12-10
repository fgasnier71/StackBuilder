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
    public class AnalysisPalletTruck : Analysis
    {
        #region Data members
        private TruckProperties _truckProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(AnalysisPalletTruck));
        #endregion

        #region Constructor
        public AnalysisPalletTruck(
            Packable packable,
            TruckProperties truckProperties,
            ConstraintSetPalletTruck constraintSet)
            : base(packable.ParentDocument, packable)
        {
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

        #region Analysis implementation
        public override ItemBase Container
        {
            get { return _truckProperties; }
        }
        public override double ContainerWeight
        {
            get { return 0.0; }
        }
        public override double ContainerLoadingVolume
        {
            get { return _truckProperties.Volume; }
        }
        public override BBox3D BBoxGlobal(BBox3D loadBox)
        {
            return new BBox3D(
                0.0, 0.0, 0.0,
                _truckProperties.Length, _truckProperties.Width, _truckProperties.Height);
        }
        public override BBox3D BBoxLoadWDeco(BBox3D loadBBox)
        {
            return loadBBox;
        }
        public override Vector2D ContainerDimensions
        {
            get { return new Vector2D(_truckProperties.Length, _truckProperties.Width); }
        }
        public override Vector3D Offset
        {
            get { return Vector3D.Zero; }
        }
        public override bool HasEquivalentPackable
        { get { return false; } }
        public override PackableLoaded EquivalentPackable
        { get { return null; } }
        #endregion

        #region AnalysisPalletTruck specific
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
}
