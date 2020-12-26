#region Using directives
using System;
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
        private double MaxPalletHeight
        {
            get
            {
                var max = LoadedPallets.Select((n, i) => (Number: n.Height, Index: i)).Max().Number;
                return max;
            }
        }
        #endregion

        #region Public properties
        public PalletProperties DestinationPallet { get; set; }
        public LoadedPallet[] LoadedPallets { get; set; } = new LoadedPallet[4];
        #endregion
    }
}
