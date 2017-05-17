#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics.Controls
{
    public class ItemBaseWrapper
    {
        public ItemBaseWrapper(ItemBase itemBase)
        { _itemBase = itemBase; }
        public ItemBase ItemBase
        { get { return _itemBase; } }
        public override string ToString()
        { return _itemBase.ID.Name; }
        private ItemBase _itemBase;
    }

    public interface IItemBaseFilter
    {
        bool Accept(Control ctrl, ItemBase itemBase);
    }
}
