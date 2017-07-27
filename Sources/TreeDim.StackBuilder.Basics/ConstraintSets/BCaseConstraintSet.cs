using System;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class BCaseConstraintSet
    {
        protected BCaseConstraintSet() { }

        public abstract bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis);
        public abstract bool IsValid { get; }

        // TODO consider using double? instead of 2 properties
        public bool UseMaximumCaseWeight { get; set; } = false;
        /// <summary>
        /// Maximum case weight
        /// </summary>
        public double MaximumCaseWeight
        {
            get { return _maximumCaseWeight; }
            // TODO - this pattern normally sets the corresponding UseXXXX property to true...
            set { _maximumCaseWeight = value; }
        }

        // TODO consider using double? instead of 2 properties
        public bool UseMaximumNumberOfBoxes { get; set; } = false;
        // TODO - this pattern normally sets the corresponding UseXXXX property to true...
        public int MaximumNumberOfBoxes
        {
            get { return _maximumNumberOfBoxes; }
            set { _maximumNumberOfBoxes = value; }
        }

        #region Non-Public Members

        private double _maximumCaseWeight;
        private int _maximumNumberOfBoxes;

        #endregion
    }
}
