#region Using directives
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class HAnalysisPallet : HAnalysis
    {
        public HAnalysisPallet(Document doc) : base(doc)
        {
            ConstraintSet = new HConstraintSetPallet() { MaximumHeight = 1700.0 };
        }

        public PalletProperties Pallet { set => _containers.Add(value);  }
    }
}
