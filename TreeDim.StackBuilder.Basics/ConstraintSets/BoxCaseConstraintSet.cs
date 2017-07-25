using System;
using System.Collections.Generic;
using System.Linq;
using log4net;

namespace treeDiM.StackBuilder.Basics
{
    public class BoxCaseConstraintSet : BCaseConstraintSet
    {
        public BoxCaseConstraintSet()
        { 
        }

        public override bool IsValid => _allowedOrthoAxis.Any(x => x == true);

        public void SetAllowedOrthoAxisAll()
        { 
            for (int i = 0; i < _allowedOrthoAxis.Length; ++i) _allowedOrthoAxis[i] = true;
        }
        public override bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis)
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
                // TODO replace with String.Join
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

        #region Non-Public Members

        private bool[] _allowedOrthoAxis = new bool[6];
        static readonly ILog _log = LogManager.GetLogger(typeof(BoxCaseConstraintSet));

        #endregion

    }
}
