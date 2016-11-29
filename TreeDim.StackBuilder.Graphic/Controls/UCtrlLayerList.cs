#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using log4net;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public partial class UCtrlLayerList : UserControl
    {
        #region Constants
        private Size szButtons = new Size(150, 150);
        #endregion

        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(UCtrlLayerList));
        private List<ILayer2D> _layerList = new List<ILayer2D>();
        private Packable _packable;
        private int _index;
        private int _x, _y;
        private ToolTip tooltip = new ToolTip();
        private double _contHeight = 0.0;
        private bool _firstLayerSelected = false;
        private bool _show3D;
        #endregion

        #region Delegate
        public delegate void LayerButtonClicked(object sender, EventArgs e);
        public delegate void RefreshEnded(object sender, EventArgs e);
        #endregion

        #region Event handlers
        public event LayerButtonClicked LayerSelected;
        public event RefreshEnded RefreshFinished;
        #endregion

        #region Constructor
        public UCtrlLayerList()
        {
            InitializeComponent();
            AutoScroll = true;
            // set default value for Show3D from settings
            Show3D = Graphics.Properties.Settings.Default.LayerView3D;
            // set default thumbnail size from settings
            switch (Graphics.Properties.Settings.Default.LayerViewThumbSizeIndex)
            {
                case 0: ButtonSizes = new Size(75, 75); break;
                case 1: ButtonSizes = new Size(100, 100); break;
                case 2: ButtonSizes = new Size(150, 150); break;
                case 3: ButtonSizes = new Size(200, 200); break;
                default: break;
            }
            onButtonSizeChange(null, null);
        }
        #endregion

        #region Public methods
        public bool SelectLayers(List<LayerDesc> layerDescs)
        {
            if (null != LayerSelected)
                LayerSelected(this, new EventArgs());

            return true;
        }
        #endregion

        #region Overrides user control
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AutoScrollPosition = Point.Empty;
            int x = 0, y = 0;
            foreach (Control cntl in Controls)
            {
                if (cntl is CheckBox) continue;
                cntl.Location = new Point(x, y) + (Size)AutoScrollPosition;
                AdjustXY(ref x, ref y);
            }
        }
        #endregion

        #region Public properties
        [Browsable(false),
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FirstLayerSelected
        {
            get { return _firstLayerSelected; }
            set { _firstLayerSelected = value; }
        }
        [Browsable(false),
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ILayer2D> LayerList
        {
            get { return _layerList; }
            set
            {
                _layerList = value;
                Start();
            }
        }
        [Browsable(false),
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ContainerHeight
        {
            get { return _contHeight; }
            set
            {
                _contHeight = value;
                Start();
            }
        }
        public Packable Packable
        {
            set { _packable = value; }
        }
        public Size ButtonSizes
        {
            get { return szButtons; }
            set
            {
                szButtons = value;
                onButtonSizeChange(null, null);
                Start();
            }
        }
        public ILayer2D[] Selected
        {
            get
            {
                List<ILayer2D> layers = new List<ILayer2D>();
                foreach (Control ctrl in this.Controls)
                {
                    Button button = ctrl as Button;
                    if (null != button)
                    {
                        LayerItem item = button.Tag as LayerItem;
                        if (item.Selected)
                            layers.Add(item.Layer);
                    }
                }
                return layers.ToArray();
            }
        }
        public bool Show3D
        {
            get { return _show3D; }
            set
            {
                if (_show3D == value) return;
                _show3D = value;
                toolStripMenuItem3D.Checked = _show3D;
                 Start(); 
            }
        }
        #endregion

        #region Event handler
        private void Start()
        {
            // do not do anything when in design mode
            if (DesignMode)
                return;
            // clear all controls
            Controls.Clear();
            // start timer
            _index = 0; _x = 0; _y = 0;
            _timer.Interval = 50;
            _timer.Start();        
        }
        private void onTimerTick(object sender, EventArgs e)
        {
            if (_index == _layerList.Count)
            {
                _timer.Stop();
                if (null != RefreshFinished)
                    RefreshFinished(this, null);
                return;
            }
            bool selected = (0 == Controls.Count) ? _firstLayerSelected : false;

            ILayer2D layer = _layerList[_index];
            // create button and add to panel
            Button btn = new Button();
            btn.Image = LayerToImage.Draw(
                _layerList[_index], _packable, _contHeight, szButtons, selected
                , Show3D ? LayerToImage.eGraphMode.GRAPH_3D : LayerToImage.eGraphMode.GRAPH_2D );
            btn.Location = new Point(_x, _y) + (Size)AutoScrollPosition;
            btn.Size = new Size(szButtons.Width, szButtons.Height);
            btn.Tag = new LayerItem(layer, selected);
            btn.Click += onLayerSelected;
            Controls.Add(btn);
            // give button a tooltip
            tooltip.SetToolTip(btn, layer.Tooltip(_contHeight));

            // adjust i, x and y for next image
            AdjustXY(ref _x, ref _y);
            ++_index;       
        }
        private void onLayerSelected(object sender, EventArgs e)
        {
            Button bn = sender as Button;
            LayerItem lItem = bn.Tag as LayerItem;
            bool selected = !lItem.Selected;
            bn.Image = LayerToImage.Draw(
                lItem.Layer, _packable, _contHeight, szButtons, selected
                , Show3D ? LayerToImage.eGraphMode.GRAPH_3D : LayerToImage.eGraphMode.GRAPH_2D );
            bn.Tag = new LayerItem(lItem.Layer, selected);
            if (null != LayerSelected)
                LayerSelected(this, e);
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// computes position of next button
        /// </summary>
        /// <param name="x">Abscissa</param>
        /// <param name="y">Ordinate</param>
        private void AdjustXY(ref int x, ref int y)
        {
            x += szButtons.Width;
            if (x + szButtons.Width > Width - SystemInformation.VerticalScrollBarWidth)
            {
                x = 0;
                y += szButtons.Height;
            }
        }
        #endregion

        #region Context menu
        private void onMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStripMBR.Show(this, e.Location);
        }
        private void onButtonSizeChange(object sender, EventArgs e)
        {
            if (sender == toolStripMenuItemX75)
                ButtonSizes = new Size(75, 75);
            else if (sender == toolStripMenuItemX100)
                ButtonSizes = new Size(100, 100);
            else if (sender == toolStripMenuItemX150)
                ButtonSizes = new Size(150, 150);
            else if (sender == toolStripMenuItemX200)
                ButtonSizes = new Size(200, 200);

            toolStripMenuItemX75.Checked = ButtonSizes.Height == 75;
            toolStripMenuItemX100.Checked = ButtonSizes.Height == 100;
            toolStripMenuItemX150.Checked = ButtonSizes.Height == 150;
            toolStripMenuItemX200.Checked = ButtonSizes.Height == 200;
        }
        private void on3DClicked(object sender, EventArgs e)
        {
            Show3D = !Show3D;
            toolStripMenuItem3D.Checked = Show3D;
        }
        #endregion
    }
    #region LayerItem
    internal class LayerItem
    {
        public LayerItem(ILayer2D layer, bool selected) { Layer = layer; Selected = selected; }
        public ILayer2D Layer { get; set; }
        public bool Selected { get; set; }
    }
    #endregion
}
