using System;

using log4net;

using treeDiM.Basics;

namespace treeDiM.StackBuilder.Basics
{
    public class ConstraintSetPalletTruck : ConstraintSetPackableTruck
    {
        public ConstraintSetPalletTruck(IPackContainer container)
            : base(container)
        {
        }
        public override bool AllowOrientation(HalfAxis.HAxis axisOrtho) => axisOrtho == HalfAxis.HAxis.AXIS_Z_P;
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
        public override OptDouble OptMaxWeight
        {
            get
            {
                TruckProperties truck = _container as TruckProperties;
                return new OptDouble(true, truck.AdmissibleLoadWeight);
            }
        }
        public override bool AllowUncompleteLayer => true;
        public override bool Valid => true;

        public bool AllowMultipleLayers { get; set; }
        public override bool CritLayerNumberReached(int layerNumber)
        {
            return AllowMultipleLayers ? false : layerNumber > 1;
        }

        #region Non-Public Members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(ConstraintSetPalletTruck));
        #endregion
    }
}
