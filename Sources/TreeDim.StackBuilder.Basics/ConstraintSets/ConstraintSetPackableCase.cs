using System;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ConstraintSetPackableCase : ConstraintSetAbstract
    {
        public override OptDouble OptMaxHeight
        {
            get
            {
                BoxProperties caseProperties = _container as BoxProperties;
                if (null == caseProperties)
                    throw new Exception("Invalid container");
                double wallThickness = caseProperties.Height - caseProperties.InsideHeight > 0 ? 0.5 * (caseProperties.Height - caseProperties.InsideHeight) : 0.0;
                return new OptDouble(true, caseProperties.InsideHeight + wallThickness);
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
        protected Packable _container;

        protected ConstraintSetPackableCase(Packable container)
        {
            _container = container;
            if (!container.IsCase)
                throw new Exception("Invalid container!");
        }
        #endregion
    }
}
