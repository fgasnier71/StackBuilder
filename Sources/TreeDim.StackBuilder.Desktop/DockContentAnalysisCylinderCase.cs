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
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisCylinderCase : DockContentAnalysisEdit
    {
        #region Constructor
        public DockContentAnalysisCylinderCase(IDocument document, AnalysisCylinderCase analysis)
            : base(document, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region Override DockContentAnalysisEdit
        public override string GridCaption
        { get { return Resources.ID_CASE; } }
        #endregion
    }
}
