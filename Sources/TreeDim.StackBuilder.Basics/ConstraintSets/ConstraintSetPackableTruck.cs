using System;
using Sharp3D.Math.Core;

using treeDiM.Basics;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ConstraintSetPackableTruck : ConstraintSetAbstract
    {
        public void SetMaxWeight(OptDouble maxWeight)
        {
            OptMaxWeight = maxWeight;
        }
        public void SetMaxNumber(OptInt maxNumber)
        {
            OptMaxNumber = maxNumber;
        }
        public override bool AllowUncompleteLayer => true;
        public override bool Valid => HasSomeAllowedOrientations
            && (!OptMaxNumber.Activated || OptMaxNumber.Value > 0);

        public Vector2D MinDistanceLoadWall { get; set; }
        public double MinDistanceLoadRoof { get; set; }

        #region ConstraintSetAbstract overrides
        public override OptDouble OptMaxWeight
        {
            get
            {
                if (_container is TruckProperties truckProperties)
                    return new OptDouble(truckProperties.AdmissibleLoadWeight > 0.0, truckProperties.AdmissibleLoadWeight);
                else
                    return OptDouble.Zero;
            }
        }
        public override OptDouble OptMaxHeight
        {
            get
            {
                if (_container is TruckProperties truckProperties)
                    return new OptDouble(true, truckProperties.InsideHeight - MinDistanceLoadRoof);
                else
                    return OptDouble.Zero;
            }
        }
        #endregion

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
