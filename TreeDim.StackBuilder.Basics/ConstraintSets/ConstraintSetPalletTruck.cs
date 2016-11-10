#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public override OptDouble OptMaxHeight
        {
            get
            {
                TruckProperties truck = _container as TruckProperties;
                return new OptDouble(true, truck.Height);
            } 
        }
        public override bool Valid { get { return true; } }
        #endregion
    }
}
