using System;
using System.Collections.Generic;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class CylinderPalletConstraintSet
    {
        public CylinderPalletConstraintSet() { }

        public bool IsValid
        {
            get
            {
                bool hasValidStopCriterion =
                    UseMaximumNumberOfItems
                    || UseMaximumPalletHeight
                    || UseMaximumPalletWeight;
                return hasValidStopCriterion;
            }
        }

        // Overhang / underhang
        public double OverhangX { get; set; }
        public double OverhangY { get; set; }

        // Interlayer
        public bool HasInterlayer { get; set; }
        public bool HasInterlayerAntiSlip { get; set; }
        public int InterlayerPeriod { get; set; }

        // Stop conditions
        // TODO consider using double? instead of 2 properties
        public bool UseMaximumPalletHeight { get; set; } = false;
        public double MaximumPalletHeight
        {
            get { return _maximumHeight; }
            set { UseMaximumPalletHeight = true; _maximumHeight = value; }
        }

        // TODO consider using double? instead of 2 properties
        public bool UseMaximumPalletWeight { get; set; } = false;
        public double MaximumPalletWeight
        {
            get { return _maximumPalletWeight; }
            set { UseMaximumPalletWeight = true; _maximumPalletWeight = value; }
        }
        
        // TODO consider using double? instead of 2 properties
        public bool UseMaximumLoadOnLowerCylinder { get; set; }
        public double MaximumLoadOnLowerCylinder
        {
            get { return _maximumLoadOnLowerCylinder; }
            set { _maximumLoadOnLowerCylinder = value; }
        }

        // TODO consider using double? instead of 2 properties
        public bool UseMaximumNumberOfItems { get; set; } = false;
        public int MaximumNumberOfItems
        {
            get { return _maxNumberOfItems; }
            set { UseMaximumNumberOfItems = true; _maxNumberOfItems = value; }
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            if (UseMaximumPalletHeight) sb.AppendLine(string.Format("Maximum height = {0}", _maximumHeight));
            if (UseMaximumPalletWeight) sb.AppendLine(string.Format("Maximum pallet weight = {0}", _maximumPalletWeight));
            if (UseMaximumNumberOfItems) sb.AppendLine(string.Format("Maximum number of items = {0}", _maxNumberOfItems));
            sb.AppendLine(IsValid ? "=> is valid" : "=> is invalid");
            return sb.ToString();
        }

        #region Non-Public Members
        private int _maxNumberOfItems;
        private double _maximumPalletWeight;
        private double _maximumHeight;
        private double _maximumLoadOnLowerCylinder;

        private System.Collections.Specialized.StringCollection _allowedPatterns = new System.Collections.Specialized.StringCollection();
        #endregion

    }
}
