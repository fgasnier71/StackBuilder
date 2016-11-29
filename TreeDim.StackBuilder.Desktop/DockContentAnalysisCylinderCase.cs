#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisCylinderCase : DockContentView
    {
        #region Constructor
        public DockContentAnalysisCylinderCase(IDocument document, AnalysisCylinderCase analysis)
            : base(document)
        {
            InitializeComponent();
        }
        #endregion
    }
}
