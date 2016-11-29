#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisCylinderPallet : FormNewAnalysis, IItemBaseFilter
    {
        #region Data members
        public FormNewAnalysisCylinderPallet()
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase override
        public override string ItemDefaultName
        { get { return Resources.ID_ANALYSIS; } }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
        #endregion

        #region FormNewAnalysis override
        public override void OnNext()
        {
            base.OnNext();
        }
        #endregion

        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            return false;
        }
        #endregion

        #region Event handlers
        #endregion

        #region Private properties
        #endregion

        #region Helpers

        #endregion
    }
}
