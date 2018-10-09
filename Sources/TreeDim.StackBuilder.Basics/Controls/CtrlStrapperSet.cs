#region Using directives
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Basics.Controls
{
    public partial class CtrlStrapperSet : UserControl
    {
        public CtrlStrapperSet()
        {
            InitializeComponent();
        }

        public StrapperSet StrapperSet
        {
            get
            {
                return strapperSet;
            }
            set
            {
                strapperSet = value;
            }
        }

        private StrapperSet strapperSet;
    }
}
