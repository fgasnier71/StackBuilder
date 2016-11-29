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
    public partial class DockContentAnalysisCylinderPallet : DockContentView
    {
        #region Constructor
        public DockContentAnalysisCylinderPallet()
            : base(null)
        {
            InitializeComponent();
        }
        public DockContentAnalysisCylinderPallet(IDocument document, AnalysisCylinderPallet analysis)
            : base(document)
        {
            InitializeComponent();
        }
        #endregion
    }
}
