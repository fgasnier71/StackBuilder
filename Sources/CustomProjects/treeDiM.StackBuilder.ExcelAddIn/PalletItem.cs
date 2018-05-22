#region Using directives
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.ExcelAddIn
{
    internal class PalletItem
    {
        public PalletItem(PalletProperties p)
        {
            PalletProp = p;
        }

        public override string ToString()
        {
            return $"{PalletProp.ID.Name} ({PalletProp.Length}x{PalletProp.Width}x{PalletProp.Height})";
        }

        public PalletProperties PalletProp { get; set; }
    }
}
