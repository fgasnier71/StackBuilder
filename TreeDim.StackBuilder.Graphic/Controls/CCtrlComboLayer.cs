#region Using directive
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics.Controls
{
    public partial class CCtrlComboLayer : ComboBox
    {
        #region Constructor
        public CCtrlComboLayer()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        #region Public properties
        public BProperties BoxProperties
        {
            set { _bProperties = value; }
        }
        #endregion

        #region Override ComboBox
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            DropDownItem item = new DropDownItem(Items[e.Index] as Layer2D, _bProperties);
            e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top);

            base.OnDrawItem(e);
        }
        #endregion

        private BProperties _bProperties;
    }

    public class DropDownItem
    {
        #region Constructor
        public DropDownItem(Layer2D layer, BProperties bProperties)
        {
            // save layer
            _layer = layer;

            // build image
            Graphics2DImage graphics = new Graphics2DImage(new Size(_imgSize, _imgSize));
            SolutionViewerLayer solViewer = new SolutionViewerLayer(_layer);
            solViewer.Draw(graphics, bProperties, 0.0, false);
            _img = graphics.Bitmap;
        }
        #endregion

        #region Public properties
        private Layer2D _layer;

        public Image Image
        {
            get { return _img; }
            set { _img = value; }
        }
        #endregion

        #region Static properties
        public static int ImageSize
        {
            get { return _imgSize; }
        }
        #endregion

        #region Override object
        public override string ToString()
        {
            return _layer.ToString();
        }
        #endregion

        #region Data members
        private Image _img;
        private static int _imgSize = 100; 
        #endregion
    }
}
