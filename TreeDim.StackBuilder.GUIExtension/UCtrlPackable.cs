#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    public partial class UCtrlPackable : UserControl
    {
        #region Constructor
        public UCtrlPackable()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public virtual Packable PackableProperties { get { return null; } }
        #endregion
    }
}
