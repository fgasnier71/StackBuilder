#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics.Controls
{
    public interface IItemBaseFilter
    {
        bool Accept(Control ctrl, ItemBase itemBase);
    }

    public class ItemBaseWrapper
    {
        public ItemBaseWrapper(ItemBase itemBase)
        {
            _itemBase = itemBase;
        }
        public ItemBase ItemBase
        {
            get { return _itemBase; }
        }
        public override string ToString()
        {
            return _itemBase.Name;
        }

        private ItemBase _itemBase;
    }

    public partial class CCtrlComboFiltered : ComboBox
    {
        public CCtrlComboFiltered()
        {
            InitializeComponent();
        }

        public void Initialize(Document doc, IItemBaseFilter filter, ItemBase initialSelect)
        {
            Items.Clear();
            int index = 0, iSelected = -1;
            foreach (ItemBase itemBase in doc.TypeList)
                if (null == filter || filter.Accept(this, itemBase))
                {
                    Items.Add(new ItemBaseWrapper(itemBase));
                    if (initialSelect == itemBase)
                        iSelected = index;
                    ++index;
                }
            if (-1 == iSelected && Items.Count > 0)
                SelectedIndex = 0;
            else
                SelectedIndex = iSelected;
        }

        public ItemBase SelectedType
        {
            get
            {
                ItemBaseWrapper  wrapper = SelectedItem as ItemBaseWrapper;
                return null == wrapper ? null : wrapper.ItemBase; 
            }
        }
    }
}
