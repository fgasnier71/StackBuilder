#region Using directives
// docking
using WeifenLuo.WinFormsUI.Docking;
// IView
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentView : DockContent, IView, IItemListener
    {
        #region Constructor
        public DockContentView()
        {
            Document = null;
            InitializeComponent();
        }
        public DockContentView(IDocument document)
        {
            Document = document;
            InitializeComponent();
        }
        #endregion

        #region IItemListener implementation
        public virtual void Update(ItemBase item)
        {
        }
        public virtual void Kill(ItemBase item)
        {
            Close();
        }
        #endregion

        #region IView implementation
        public IDocument Document { get; set; }
        #endregion
    }
}
