#region Using directives
using System.Drawing;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Graphics.Controls;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    public partial class CtrlComboDBPallet : ComboBox
    {
        public CtrlComboDBPallet()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (DesignMode)
                return;
            // sanity check
            Items.Clear();
            // load all pallets from database
            foreach (string typeName in PalletData.TypeNames)
            {
                PalletData palletData = PalletData.GetByName(typeName);
                PalletProperties palletProperties = new PalletProperties(null, typeName,
                    palletData.Dimensions.X, palletData.Dimensions.Y, palletData.Dimensions.Z);
                palletProperties.ID.SetNameDesc(typeName, palletData.Description);
                palletProperties.Weight = palletData.Weight;
                palletProperties.Color = Color.Yellow;
                Items.Add(new ItemBaseWrapper(palletProperties));
            }
            // always select first item
            if (Items.Count > 0)
                SelectedIndex = 0;
        }

        public ItemBase SelectedType
        {
            get
            {
                return !(SelectedItem is ItemBaseWrapper wrapper) ? null : wrapper.ItemBase;
            }
        }

        public PalletProperties SelectedPallet
        {
            get
            {
                return !(SelectedItem is ItemBaseWrapper wrapper) ? null : wrapper.ItemBase as PalletProperties;
            }
        }
    }
}
