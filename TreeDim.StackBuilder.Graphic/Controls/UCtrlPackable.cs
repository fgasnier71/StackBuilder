#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics.Controls
{
    public partial class UCtrlPackable : UserControl
    {
        #region Data members
        private Packable _packable;
        #endregion

        #region Constructor
        public UCtrlPackable()
        {
            InitializeComponent();
        }
        #endregion

        #region Event handlers
        private void onPaint(object sender, PaintEventArgs e)
        {
            if (null != _packable)
            {
                BoxToPictureBox.Draw(_packable, pictureBox);
            }
        }
        #endregion

        #region Public properties
        public Packable PackableProperties
        {
            set { _packable = value; Invalidate(); }
        }
        #endregion
    }
}
