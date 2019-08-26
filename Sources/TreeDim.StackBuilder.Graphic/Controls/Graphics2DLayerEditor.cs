#region Using directives
using System.Collections.Generic;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public partial class Graphics2DLayerEditor : UserControl
    {
        #region Constructor
        public Graphics2DLayerEditor()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public List<BoxPosition> Positions { get; set; } = new List<BoxPosition>();
        #endregion

        #region Data members
        private int SelectedIndex { get; set; } = -1;
        private static readonly ILog _log = LogManager.GetLogger(typeof(Graphics2DLayerEditor));
        #endregion
    }
}
