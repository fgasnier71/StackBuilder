#region Using directives
using System.Linq;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class PalletsOnPalletProperties : PackableBrickNamed
    {
        #region Constructor
        public PalletsOnPalletProperties(Document doc) : base(doc)
        {
        }
        #endregion
        #region PackableBrickNamed override
        public override double Length => DestinationPallet.Length;
        public override double Width => DestinationPallet.Width;
        public override double Height => DestinationPallet.Height + MaxPalletHeight;
        protected override string TypeName => Properties.Resources.ID_PALLETSONPALLET;
        #endregion

        #region Helpers
        private double MaxPalletHeight => LoadedPallets.Select((n, i) => (Number: n.Height, Index: i)).Max().Number;
        #endregion

        #region Public properties
        public enum EMode { PALLET_HALF, PALLET_QUARTER }
        public PalletProperties DestinationPallet { get; set; }
        public LoadedPallet[] LoadedPallets { get; set; } = new LoadedPallet[4];
        public EMode Mode { get; set; } = EMode.PALLET_HALF;
        #endregion
    }
}
