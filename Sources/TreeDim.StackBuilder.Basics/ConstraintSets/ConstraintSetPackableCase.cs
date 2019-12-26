using System;

using treeDiM.Basics;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ConstraintSetPackableContainer : ConstraintSetAbstract
    {
        public override OptDouble OptMaxHeight
        {
            get
            {
                if (Container is BoxProperties caseProperties)
                {
                    double wallThickness = caseProperties.Height - caseProperties.InsideHeight > 0 ? 0.5 * (caseProperties.Height - caseProperties.InsideHeight) : 0.0;
                    return new OptDouble(true, caseProperties.InsideHeight + wallThickness);
                }
                else if (Container is TruckProperties truckProperties)
                {
                    return new OptDouble(true, truckProperties.InsideHeight);
                }
                else
                    throw new Exception("Invalid container");
            }
        }
        public override bool AllowUncompleteLayer => true;
        public override bool Valid => HasSomeAllowedOrientations && (!OptMaxNumber.Activated || (OptMaxNumber.Value > 0));

        public void SetMaxWeight(OptDouble maxWeight) => OptMaxWeight = maxWeight;
        public void SetMaxNumber(int maxNumber) => OptMaxNumber = new OptInt(true, maxNumber);

        #region Non-Public Members
        protected ConstraintSetPackableContainer(IContainer container)
        {
            Container = container;
        }
        #endregion
    }
}
