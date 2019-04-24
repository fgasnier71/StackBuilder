#region Using directives
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class Graphics3DImage : Graphics3D
    {
        #region Constructor
        public Graphics3DImage(Size size)
        {
            Bitmap = new Bitmap(size.Width, size.Height);        
        }
        #endregion

        #region Graphics3D abstract method implementation
        public override Size Size
        {
            get { return Bitmap.Size;}
        }
        public override System.Drawing.Graphics Graphics
        {
            get { return System.Drawing.Graphics.FromImage(Bitmap); }
        }
        #endregion

        #region Public methods
        public void SaveAs(string filename)
        {
            ImageFormat format = ImageFormat.Bmp;
            Bitmap.Save(filename, format);
        }
        #endregion

        #region Public properties
        public Bitmap Bitmap { get; }
        #endregion
    }

    public class Graphics3DForm : Graphics3D
    {
        #region Data members
        private System.Drawing.Graphics _g;
        private Control _ctrl;
        #endregion

        #region Constructor
        public Graphics3DForm(Control ctrl, System.Drawing.Graphics g)
        {
            _ctrl = ctrl;
            _g = g;
        }
        #endregion

        #region Graphics3D abstract method implementation
        public override Size Size
        {
            get { return _ctrl.Size; }
        }
        public override System.Drawing.Graphics Graphics
        {
            get { return _g; }
        }
        #endregion
    }
}
