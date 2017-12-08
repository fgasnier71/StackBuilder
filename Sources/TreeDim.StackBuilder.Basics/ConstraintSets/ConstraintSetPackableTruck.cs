using System;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ConstraintSetPackableTruck : ConstraintSetAbstract
    {
        public override OptDouble OptMaxHeight
        {
            get
            {
                TruckProperties truckProperties = _container as TruckProperties;
                if (null == truckProperties)
                    throw new Exception("Invalid container");
                return new OptDouble(true, truckProperties.InsideHeight);
            }
        }


        public void SetMaxWeight(OptDouble maxWeight)
        {
            OptMaxWeight = maxWeight;
        }
        public void SetMaxNumber(OptInt maxNumber)
        {
            OptMaxNumber = maxNumber;
        }
        public override bool AllowUncompleteLayer => true;
        public override bool Valid => HasSomeAllowedOrientations && (!OptMaxNumber.Activated || OptMaxNumber.Value > 0);

        #region Non-Public Members

        protected IPackContainer _container;

        protected ConstraintSetPackableTruck(IPackContainer container)
        {
            _container = container;
            if (!(_container is TruckProperties))
                throw new ArgumentException("Invalid container!");
        }

        #endregion
    }
}
