namespace treeDiM.StackBuilder.Basics
{
    public abstract class Analysis : ItemBaseNamed
    {
        protected Analysis(Document doc) : base(doc) { }
        public abstract bool HasValidSolution { get; }
        public bool Temporary => null == ParentDocument;
    }
}
