using treeDiM.Basics;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class PackableNamed : Packable
    {
        public PackableNamed(Document parentDocument)
            : base(parentDocument)
        { 
        }

        public PackableNamed(Document parentDocument, string name, string description)
            : base(parentDocument)
        {
            ID.SetNameDesc(name, description);
        }

        public override GlobID ID => _id;
        public override double Weight => _weight;
        public override OptDouble NetWeight => _netWeight;

        public void SetWeight(double weight)
        {
            _weight = weight;
            Modify();
        }

        public void SetNetWeight(OptDouble netWeight)
        {
            _netWeight = netWeight;
            // TODO - no call to Modify() ?
        }

        #region Non-Public Members

        protected GlobID _id = new GlobID();
        protected double _weight;
        protected OptDouble _netWeight = OptDouble.Zero;

        #endregion

    }
}