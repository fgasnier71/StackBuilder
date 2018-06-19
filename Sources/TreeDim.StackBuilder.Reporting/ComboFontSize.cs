#region Using directives
using System.Collections.Generic;
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Reporting
{
    public partial class ComboFontSize : ComboBox
    {
        #region Constructor
        public ComboFontSize()
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
            foreach (string s in FontSizes)
                Items.Add(s);
            SelectedIndex = Items.Count > 0 ? 0 : -1;
        }
        private List<string> FontSizes
        {
            get
            {
                List<string> fontSizes = new List<string>();
                for (int i = 0; i < 20; ++i)
                    fontSizes.Add(string.Format("{0:0.#} %", 0.5f * (float)(i + 1)));
                return fontSizes;
            }
        }
        #endregion

        #region Public properties
        public float FontSizeRatio
        {
            get
            {
                if (-1 == SelectedIndex)
                    return 0.01f;
                else
                    return 0.01f * 0.5f * (float)(SelectedIndex+1); 
            }
            set
            {
                int iIndex = (int)(100.0f * 2.0f * value - 1);
                SelectedIndex = iIndex > -1 && iIndex < Items.Count ? iIndex : -1;
            }
        }
        #endregion
    }
}
