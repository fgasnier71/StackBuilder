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
    public class ConstraintSetPalletTruck : ConstraintSetAbstract
    {
        #region Data members
        private IPackContainer _container;
        static readonly ILog _log = LogManager.GetLogger(typeof(ConstraintSetBoxCase));
        #endregion

        #region Constructor
        public ConstraintSetPalletTruck(IPackContainer container)
        {
            _container = container;
        }
        #endregion

        #region Override ConstraintSetAbstract
        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho)
        { return axisOrtho == HalfAxis.HAxis.AXIS_Z_P; }
        public override string AllowedOrientationsString
        {
            get { return "0,0,1"; }
            set {}
        }
        public override OptDouble OptMaxHeight
        {
            get
            {
                TruckProperties truck = _container as TruckProperties;
                return new OptDouble(true, truck.Height - MinDistanceLoadRoof);
            } 
        }
        public override bool Valid { get { return true; } }
        #endregion

        #region Specific
        public Vector2D MinDistanceLoadWall { get; set; }
        public double MinDistanceLoadRoof { get; set; }
        public bool AllowMultipleLayers { get; set; }
        #endregion
    }
}
