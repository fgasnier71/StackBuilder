#region Using directive
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

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

        #region Override ComboBox
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            DropDownItem item = new DropDownItem(Items[e.Index].ToString());
            // Draw the colored 100 x 100 square
            e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top);
            // Draw the value (in this case, the color name)
            e.Graphics.DrawString(item.Value, e.Font,
                    new SolidBrush(e.ForeColor), e.Bounds.Left + item.Image.Width, e.Bounds.Top + 2);

            base.OnDrawItem(e);
        }
        #endregion
    }

    public class DropDownItem
    {
        #region Constructor
        public DropDownItem()
            : this("")
        {
        }
        public DropDownItem(string val)
        {
            value = val;
            this.img = new Bitmap(100, 100);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img);
            Brush b = new SolidBrush(Color.FromName(val));
            g.DrawRectangle(Pens.White, 0, 0, img.Width, img.Height);
            g.FillRectangle(b, 1, 1, img.Width - 1, img.Height - 1);
        }
        #endregion

        #region Public properties
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
        private string value;

        public Image Image
        {
            get { return img; }
            set { img = value; }
        }
        #endregion

        #region Override object
        public override string ToString()
        {
            return value;
        }
        #endregion

        #region Data members
        private Image img;
        #endregion
    }
}
