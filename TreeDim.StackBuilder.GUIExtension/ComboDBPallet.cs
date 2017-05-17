#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Basics.Controls;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    public partial class ComboDBPallet : ComboBox
    {
        public ComboDBPallet()
        {
            InitializeComponent();
        }

        public void InitializeContent()
        {
            if (this.DesignMode)
                return;
            // sanity check
            Items.Clear();
            if (null == WCFClientSingleton.Instance)
                return;
            // load all pallets from database
            DCSBPallet[] pallets = WCFClientSingleton.Instance.Client.GetAllPallets();
            foreach (DCSBPallet pallet in pallets)
            {
                PalletProperties palletProperties = new PalletProperties(null, pallet.PalletType,
                    pallet.Dimensions.M0, pallet.Dimensions.M1, pallet.Dimensions.M2);
                palletProperties.Weight = pallet.Weight;
                palletProperties.Color = Color.Yellow;
                Items.Add(new ItemBaseWrapper(palletProperties));
            }
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
