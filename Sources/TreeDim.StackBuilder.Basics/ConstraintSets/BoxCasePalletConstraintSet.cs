using System;
using System.Linq;
using System.Collections.Generic;

namespace treeDiM.StackBuilder.Basics
{
    public class BoxCasePalletConstraintSet
    {
        public BoxCasePalletConstraintSet()
        { 
        }

        public bool IsValid
        {
            get
            {
                // stop criterions
                bool hasValidStopCriterion = true;
                // allowed otho axis
                bool allowsAtLeastOneOrthoAxis = false;
                for (int i = 0; i < 6; ++i)
                {
                    if (AllowOrthoAxis((HalfAxis.HAxis)i))
                    {
                        allowsAtLeastOneOrthoAxis = true;
                        break;
                    }
                }
                return hasValidStopCriterion
                    && allowsAtLeastOneOrthoAxis
                    && _allowedPatterns.Count > 0
                    && (!UseNumberOfSolutionsKept || _noSolutionsKept > 0);
            }
        }

        // Allowed layer alignments
        public bool AllowAlignedLayers { get; set; } = false;
        public bool AllowAlternateLayers { get; set; } = true;

        // Allowed patterns
        public void ClearAllowedPatterns()
        {
            _allowedPatterns.Clear();
        }
        public void SetAllowedPattern(string patternName)
        {
            if (patternName == string.Empty) return;
            _allowedPatterns.Add(patternName);
        }
        public bool AllowPattern(string patternName)
        {
            return _allowedPatterns.Contains(patternName);
        }
        public string AllowedPatternString
        {
            set
            {
                string[] patternNames = value.Split(',');
                foreach (string patternName in patternNames)
                    SetAllowedPattern(patternName);
            }
            get
            {
                string sGlobal = string.Empty;
                foreach (string patternName in _allowedPatterns)
                {
                    if (!string.IsNullOrEmpty(sGlobal))
                        sGlobal += ",";
                    sGlobal += patternName;
                }
                return sGlobal;
            }
        }

        // Allowed box axis
        public bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis)
        {
            return _allowedOrthoAxis[(int)orthoAxis];
        }
        public void SetAllowedOrthoAxis(HalfAxis.HAxis axis, bool allowed)
        {
            _allowedOrthoAxis[(int)axis] = allowed;
        }
        public string AllowOrthoAxisString
        {
            get
            {
                // TODO rewrite using String.Join
                string sGlobal = string.Empty;
                for (int i = 0; i < 6; ++i)
                {
                    if (!string.IsNullOrEmpty(sGlobal))
                        sGlobal += ",";
                    HalfAxis.HAxis axis = (HalfAxis.HAxis)i;
                    if (AllowOrthoAxis(axis))
                        sGlobal += HalfAxis.ToString(axis);
                }
                return sGlobal;
            }
            set
            {
                string[] sAxes = value.Split(',');
                foreach (string sAxis in sAxes)
                    SetAllowedOrthoAxis(HalfAxis.Parse(sAxis), true);            
            }
        }

        // Interlayer
        public bool HasInterlayer => false;
        public int InterlayerPeriod => throw new NotImplementedException();
        public bool HasInterlayerAntiSlip => false;

        // TODO consider using int? instead of 2 properties
        public bool UseMinimumNumberOfItems { get; set; }
        public int MinimumNumberOfItems
        {
            get { return _minimumBoxPerCase; }
            // TODO - this pattern normally sets the corresponding UseXXXX property to true...
            set { _minimumBoxPerCase = value; }
        }

        // TODO consider using int? instead of 2 properties
        public bool UseMaximumNumberOfItems { get; set; }
        public int MaximumNumberOfItems
        {
            get { return _maxNumberOfItems; }
            // TODO - this pattern normally sets the corresponding UseXXXX property to true...
            set { _maxNumberOfItems = value; }
        }


        // TODO consider using double? instead of 2 properties
        public bool UseMaximumCaseWeight { get; set; }
        public double MaximumCaseWeight
        {
            get { return _maximumCaseWeight; }
            // TODO - this pattern normally sets the corresponding UseXXXX property to true...
            set { _maximumCaseWeight = value;  }
        }

        // TODO consider using int? instead of 2 properties
        public bool UseNumberOfSolutionsKept { get; set; }
        public int NumberOfSolutionsKept
        {
            get { return _noSolutionsKept; }
            set
            {
                UseNumberOfSolutionsKept = true;
                _noSolutionsKept = value;
            }
        }

        #region Non-Public Members
        private System.Collections.Specialized.StringCollection _allowedPatterns = new System.Collections.Specialized.StringCollection();
        private bool[] _allowedOrthoAxis = new bool[6];
        private int _noSolutionsKept, _minimumBoxPerCase, _maxNumberOfItems;
        private double _maximumCaseWeight;
        #endregion

    }
}
