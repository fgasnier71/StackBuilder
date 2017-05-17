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
            foreach (Analysis analysis in doc.Analyses)
            {
                PackableLoaded eqvtPackable = analysis.EquivalentPackable;
                if (null == eqvtPackable) continue;
                if (null == filter || filter.Accept(this, eqvtPackable))
                {
                    Items.Add(new ItemBaseWrapper(eqvtPackable));
                    if (initialSelect == analysis)
                        iSelected = index;
                    ++index;
                }
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
