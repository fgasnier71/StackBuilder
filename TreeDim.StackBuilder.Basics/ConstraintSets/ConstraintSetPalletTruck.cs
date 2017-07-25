using System;
using System.Collections.Generic;
using System.Linq;

using Sharp3D.Math.Core;

using log4net;

namespace treeDiM.StackBuilder.Basics
{
    public class ConstraintSetPalletTruck : ConstraintSetAbstract
    {
        public ConstraintSetPalletTruck(IPackContainer container)
        {
            _container = container;
        }

        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho)
        {
            return axisOrtho == HalfAxis.HAxis.AXIS_Z_P;
        }
        public override string AllowedOrientationsString
        {
            get => "0,0,1";
            set => throw new InvalidOperationException("Setting this property is not supported.");
        }

        public override OptDouble OptMaxHeight
        {
            get
            {
                TruckProperties truck = _container as TruckProperties;
                return new OptDouble(true, truck.Height - MinDistanceLoadRoof);
            } 
        }
        public override bool Valid => true;

        public Vector2D MinDistanceLoadWall { get; set; }
        public double MinDistanceLoadRoof { get; set; }
        public bool AllowMultipleLayers { get; set; }

        #region Non-Public Members

        private IPackContainer _container;
        static readonly ILog _log = LogManager.GetLogger(typeof(ConstraintSetBoxCase));

        #endregion
    }
}
