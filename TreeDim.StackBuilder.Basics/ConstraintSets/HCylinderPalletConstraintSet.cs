using System;
using System.Collections.Generic;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class HCylinderPalletConstraintSet
    {
        public HCylinderPalletConstraintSet() { }

        // Overhang / underhang
        public double OverhangX { get; set; }
        public double OverhangY { get; set; }

        // Allowed patterns
        public void SetAllowedPatterns(bool patternDefault, bool patternStaggered, bool patternColumn)
        {
            _allowPatternDefault = patternDefault;
            _allowPatternStaggered = patternStaggered;
            _allowPatternColumn = patternColumn;
        }
        public bool IsPatternDefaultAllowed() => _allowPatternDefault;
        public bool IsPatternStaggeredAllowed() => _allowPatternStaggered;
        public bool IsPatternColumnAllowed() => _allowPatternColumn;
        public bool AllowPattern(string name)
        {
            switch (name.ToLower())
            {
                case "default": return _allowPatternDefault;
                case "staggered": return _allowPatternStaggered;
                case "column": return _allowPatternColumn;
                default: return false;
            }
        }
        public double RowSpacing { get; set; } = 0.0;

        public bool IsValid
        {
            get
            {
                return UseMaximumNumberOfItems
                    || UseMaximumPalletHeight
                    || UseMaximumPalletWeight;
            }
        }

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

        // TODO consider using int? instead of 2 properties
        public bool UseMaximumNumberOfItems { get; set; } = false;
        public int MaximumNumberOfItems
        {
            get { return _maxNumberOfItems; }
            set { UseMaximumNumberOfItems = true; _maxNumberOfItems = value; }
        }

        #region Non-Public Members
        private int _maxNumberOfItems;
        private double _maximumPalletWeight;
        private double _maximumHeight;
        private bool _allowPatternDefault = true;
        private bool _allowPatternColumn = false;
        private bool _allowPatternStaggered = false;
        #endregion

    }
}
