#region Using directives
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormBottleInitialize : Form
    {
        public FormBottleInitialize()
        {
            InitializeComponent();
        }
        public double MaxDiameter   { get => uCtrlMaxDiameter.Value; set => uCtrlMaxDiameter.Value = value; }
        public double MaxHeight     { get => uCtrlHeight.Value; set => uCtrlHeight.Value = value; }
    }
}
