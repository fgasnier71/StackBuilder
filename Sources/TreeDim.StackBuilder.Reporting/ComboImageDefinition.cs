#region Using directives
using System.Collections.Generic;
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Reporting
{
    public partial class ComboImageDefinition : ComboBox
    {
        #region Constructor
        public ComboImageDefinition()
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
        }
        #endregion
        #region Properties
        private List<string> ImageSizes
        {
            get
            {
                List<string> imageSizes = new List<string>();
                for (int i = 0; i < 19; ++i)
                    imageSizes.Add(string.Format("{0} x {0} p", 100 * (i + 2)));
                return imageSizes;
            }
        }
        public int ImageSize
        {
            get { return 100 * (SelectedIndex + 2); }
        }
        #endregion
    }
}
