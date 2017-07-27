using System;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class ItemBaseNamed : ItemBase
    {
        public ItemBaseNamed(Document doc)
            : base(doc)
        {
        }
        public ItemBaseNamed(Document doc, string name, string description)
            : base(doc)
        {
            ID.Name = name; ID.Description = description;
        }

        public override GlobID ID { get { return _id; } }

        #region Non-Public Members

        private GlobID _id = new GlobID();

        #endregion
    }
}
