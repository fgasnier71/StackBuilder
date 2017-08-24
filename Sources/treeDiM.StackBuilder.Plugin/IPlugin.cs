#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Plugin
{
    public delegate void DoCallbackAction(string s);

    public interface IPlugin
    {
        bool Initialize();
        bool UpdateToolbar(ToolStripSplitButton toolStripSplitButton);
        bool OnFileNew(ref string fileName);

        event DoCallbackAction OpenFile;

    }
}
