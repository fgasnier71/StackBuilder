#region Using directives
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
#endregion

namespace treeDiM.StackBuilder.WCFService.Test
{
    public partial class DockContentLogConsole : DockContent
    {
        #region Constructor
        public DockContentLogConsole()
        {
            InitializeComponent();
        }
        #endregion
        #region Set rich text box to RichTextBoxAppender
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            log4net.Appender.RichTextBoxAppender.SetRichTextBox(richTextBoxLog, "RichTextBoxAppender");
        }
        #endregion
        #region Public properties
        public RichTextBox RichTextBox => richTextBoxLog;
        #endregion 
    }
}
