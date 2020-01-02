using System;
using Sharp3D.Math.Core;

using treeDiM.Basics;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ConstraintSetAbstract
    {
        public bool[] AllowedOrientations
        {
            get
            {
                return new bool[] {
                    AllowOrientation(HalfAxis.HAxis.AXIS_X_N) || AllowOrientation(HalfAxis.HAxis.AXIS_X_P)
                    , AllowOrientation(HalfAxis.HAxis.AXIS_Y_N) || AllowOrientation(HalfAxis.HAxis.AXIS_Y_P)
                    , AllowOrientation(HalfAxis.HAxis.AXIS_Z_N) || AllowOrientation(HalfAxis.HAxis.AXIS_Z_P)
                };
            }
        }
        public virtual bool HasSomeAllowedOrientations
        {
            get
            {
                foreach (HalfAxis.HAxis axis in HalfAxis.All)
                    if (AllowOrientation(axis))
                        return true;
                return false;
            }
        }
        public abstract bool AllowOrientation(HalfAxis.HAxis axisOrtho);
        public abstract string AllowedOrientationsString { get; set; }
        public abstract OptDouble OptMaxHeight { get; }
        public virtual OptInt OptGlobMaxNumber(Packable packable)
        {
            OptInt optMaxNumberWeight = new OptInt(OptMaxWeight.Activated, (int)Math.Floor((OptMaxWeight.Value - Container.Weight) / packable.Weight));
            return OptInt.Min(optMaxNumberWeight, OptMaxNumber);
        }
        public virtual OptDouble OptMaxWeight { get; set; }
        public virtual OptInt OptMaxNumber { get; set; }
        public virtual OptInt OptMaxLayerNumber { get; set; } = new OptInt(false, 1);
        public virtual OptDouble MinimumSpace { get; set; }
        public virtual bool AllowUncompleteLayer => false;
        public virtual bool Valid => HasSomeAllowedOrientations;
        public IContainer Container { get; set; }

        public virtual bool CritHeightReached(double height) { return OptMaxHeight.Activated && OptMaxHeight.Value < height; }
        public virtual bool CritWeightReached(double weight) { return OptMaxWeight.Activated && OptMaxWeight.Value < weight; }
        public virtual bool CritNumberReached(int number) { return OptMaxNumber.Activated && OptMaxNumber.Value < number; }
        public virtual bool CritLayerNumberReached(int layerNumber) { return OptMaxLayerNumber.Activated && layerNumber >= OptMaxLayerNumber.Value; }
        public bool OneCriterionReached(double height, double weight, int number, int layerNumber)
        { return CritHeightReached(height) || CritWeightReached(weight) || CritNumberReached(number) || CritLayerNumberReached(layerNumber); }
    }
}
