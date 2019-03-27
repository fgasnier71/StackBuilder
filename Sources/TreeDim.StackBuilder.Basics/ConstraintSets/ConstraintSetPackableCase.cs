using System;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ConstraintSetPackableContainer : ConstraintSetAbstract
    {
        public override OptDouble OptMaxHeight
        {
            get
            {
                if (_container is BoxProperties caseProperties)
                {
                    double wallThickness = caseProperties.Height - caseProperties.InsideHeight > 0 ? 0.5 * (caseProperties.Height - caseProperties.InsideHeight) : 0.0;
                    return new OptDouble(true, caseProperties.InsideHeight + wallThickness);
                }
                else if (_container is TruckProperties truckProperties)
                {
                    return new OptDouble(true, truckProperties.InsideHeight);
                }
                else
                    throw new Exception("Invalid container");
            }
        }
        public override bool AllowUncompleteLayer => true;
        public override bool Valid => HasSomeAllowedOrientations && (!OptMaxNumber.Activated || (OptMaxNumber.Value > 0));

        public void SetMaxWeight(OptDouble maxWeight)
        {
            OptMaxWeight = maxWeight;
        }
        public void SetMaxNumber(int maxNumber)
        {
            OptMaxNumber = new OptInt(true, maxNumber);
        }

        #region Non-Public Members
        protected IPackContainer _container;

        protected ConstraintSetPackableContainer(IPackContainer container)
        {
            _container = container;
            if (!container.HasInsideDimensions)
                throw new Exception("Invalid container!");
        }
        #endregion
    }
}
