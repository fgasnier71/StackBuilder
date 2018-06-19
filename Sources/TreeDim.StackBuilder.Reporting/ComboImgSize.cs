#region Using directives
using System.Collections.Generic;
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Reporting
{
    public partial class ComboImgSize : ComboBox
    {
        #region Constructor
        public ComboImgSize()
        {
            InitializeComponent();
            Sorted = false;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        #region Initialisation
        public void InitializeContent()
        {
            Items.Clear();
            foreach (string s in ImageSizes)
                Items.Add(s);
            SelectedIndex = 0;
        }
        #endregion

        #region Public properties
        private List<string> ImageSizes
        {
            get
            {
                List<string> imagesSizes = new List<string>();
                for (int i=0; i<19; ++i)
                    imagesSizes.Add(string.Format("{0} x {0}", 50 * (i + 2)));
                return imagesSizes;
            }
        }
        public int ImageSize
        {
            get { return 50 * (SelectedIndex + 2); }
        }
        #endregion
    }
}
