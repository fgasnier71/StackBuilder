#region Using directives
using System;
using System.Collections.Generic;
#endregion

namespace treeDiM.StackBuilder.Reporting
{
    #region ReportNode
    public class ReportNode
    {
        #region Constructor
        public ReportNode(string name)
        {
            Name = name;
            Activated = true;
        }
        #endregion

        #region Public properties
        public string Name { get; set; }
        public bool Activated { get; set; }
        public ReportNode[] Children { get { return _children.ToArray(); } }
        #endregion

        #region Accessing child by Name
        public ReportNode GetChildByName(string name)
        {
            ReportNode child = _children.Find(
                delegate (ReportNode rn) { return string.Equals(rn.Name, name, StringComparison.CurrentCultureIgnoreCase); }
                );
            if (null == child)
                _children.Add(child = new ReportNode(name));
            return child;
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region Data members
        private List<ReportNode> _children = new List<ReportNode>();
        #endregion
    }
    #endregion
}
