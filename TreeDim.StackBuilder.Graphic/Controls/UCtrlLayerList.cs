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

namespace treeDiM.StackBuilder.Graphics.Controls
{
    public partial class UCtrlLayerList : UserControl
    {
        #region Constants
        private const int cxButton = 150, cyButton = 150;   // image button size
        #endregion

        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(UCtrlLayerList));
        private List<Layer2D> _layerList = new List<Layer2D>();
        private int _index;
        private int _x, _y;
        private ToolTip tooltip = new ToolTip();
        private double _contHeight;
        #endregion

        #region Constructor
        public UCtrlLayerList()
        {
            InitializeComponent();
            AutoScroll = true;
        }
        #endregion

        #region Overrides
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AutoScrollPosition = Point.Empty;
            int x = 0, y = 0;
            foreach (Control cntl in Controls)
            {
                cntl.Location = new Point(x, y) + (Size)AutoScrollPosition;
                AdjustXY(ref x, ref y);
            }
        }
        #endregion

        #region Event handler
        private void onTimerTick(object sender, EventArgs e)
        {
            if (_index == _layerList.Count)
            {
                _timer.Stop();
                return;
            }

            Image image;
            SizeF sizef;
            try
            {
                image = LayerToImage.Draw(_layerList[_index], new Size(cxButton, cyButton));
                sizef = new SizeF(image.Width / image.HorizontalResolution, image.Height / image.VerticalResolution);
                float fScale = Math.Min(cxButton / sizef.Width, cyButton / sizef.Height);
                sizef.Width *= fScale;
                sizef.Height *= fScale;
            }
            catch (Exception ex)
            {
                _log.Debug(ex.ToString());
                ++_index;
                return;
            }
            // convert image to small size for button
            Bitmap bitmap = new Bitmap(image, Size.Ceiling(sizef));
            image.Dispose();

            // create button and add to panel
            Button btn = new Button();
            btn.Image = bitmap;
            btn.Location = new Point(_x, _y) + (Size)AutoScrollPosition;
            btn.Size = new Size(cxButton, cyButton);
            btn.Tag = _layerList[_index];
            btn.Click += onLayerSelected;
            Controls.Add(btn);

            // give button a tooltip
            tooltip.SetToolTip(btn, String.Format("{0}\n{1}", _layerList[_index].BoxCount, _layerList[_index].PerPalletCount(_contHeight)));

            // adjust i, x and y for next image
            AdjustXY(ref _x, ref _y);
            ++_index;       

        }

        void onLayerSelected(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            x += cxButton;
            if (x + cxButton > Width - SystemInformation.VerticalScrollBarWidth)
            {
                x = 0;
                y += cyButton;
            }
        }
        #endregion
    }
}
