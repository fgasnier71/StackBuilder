#region Using directives
using System.Drawing;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics.Controls;

using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;
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
            if (this.DesignMode)
                return;
            // sanity check
            Items.Clear();
            // load all pallets from database
            DCSBPallet[] pallets;
            using (WCFClient wcfClient = new WCFClient())
            {
                pallets = wcfClient.Client.GetAllPallets();
                foreach (DCSBPallet pallet in pallets)
                {
                    PalletProperties palletProperties = new PalletProperties(null, pallet.PalletType,
                        pallet.Dimensions.M0, pallet.Dimensions.M1, pallet.Dimensions.M2);
                    palletProperties.ID.SetNameDesc(pallet.Name, pallet.Description);
                    palletProperties.Weight = pallet.Weight;
                    palletProperties.Color = Color.Yellow;
                    Items.Add(new ItemBaseWrapper(palletProperties));
                }
            }
            // always select first item
            if (Items.Count > 0)
                SelectedIndex = 0;
        }

        public ItemBase SelectedType
        {
            get
            {
                ItemBaseWrapper wrapper = SelectedItem as ItemBaseWrapper;
                return null == wrapper ? null : wrapper.ItemBase;
            }
        }

        public PalletProperties SelectedPallet
        {
            get
            {
                ItemBaseWrapper wrapper = SelectedItem as ItemBaseWrapper;
                return null == wrapper ? null : wrapper.ItemBase as PalletProperties;
            }
        }
    }
}
