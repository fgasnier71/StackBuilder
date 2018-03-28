#region Using directives
using System.Collections.Generic;
using System.Linq;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public abstract class HAnalysis : ItemBaseNamed
    {
        public HAnalysis(Document doc)
            : base(doc)
        {
        }
        public IEnumerable<ContentItem> Content
        {
            get { return _content; }
            set
            {
                if (value == _content) return;
                foreach (ContentItem ci in _content)
                    ci.Pack.RemoveDependancy(this);
                _content.Clear();
                foreach (ContentItem ci in value)
                {
                    if (null != ParentDocument)
                        ci.Pack.AddDependancy(this);
                    _content.Add(ci);
                }
            }
        }
        public IEnumerable<ItemBase> Containers => _container;

        public HConstraintSet ConstraintSet { get => _constraintSet; set => _constraintSet = value; }
        public virtual double ContentTotalVolume => Content.Sum(ci => ci.Pack.Volume * ci.Number);
        public virtual double ContentTotalWeight => Content.Sum(ci => ci.Pack.Weight * ci.Number);

        public void AddContent(Packable p, uint number, bool[] orientations)
        {
            _content.Add(new ContentItem(p, number) { AllowedOrientations = orientations });
        }
        public void AddContent(Packable p)
        {
            _content.Add(new ContentItem(p, 1) { AllowedOrientations = new bool[] { true, true, true } } );
        }

        public HSolution BuildSolution()
        {
            _solution = new HSolution();
            return _solution;
        }
        #region Non-public members
        protected HSolution Solution => _solution;

        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
            foreach (ContentItem ci in _content)
                ci.Pack.RemoveDependancy(this);
        }

        private List<ContentItem> _content = new List<ContentItem>();
        private List<ItemBase> _container = new List<ItemBase>();
        private HConstraintSet _constraintSet;
        private HSolution _solution;
        static readonly ILog _log = LogManager.GetLogger(typeof(Analysis));
        #endregion
    }

    #region ContentItem
    public class ContentItem
    {
        public ContentItem(Packable p, uint n) { Pack = p; Number = n; }
        public Packable Pack { get; set; }
        public uint Number { get; set; }
        public bool[] AllowedOrientations { get { return new bool[] { AllowOrientX, AllowOrientY, AllowOrientZ }; } set { _allowOrient = value; } }
        public bool AllowOrientX
        {
            get { if (Pack.IsBrick) return _allowOrient[0]; else return false; }
            set { _allowOrient[0] = value; }
        }
        public bool AllowOrientY
        {
            get { if (Pack.IsBrick) return _allowOrient[1]; else return false; }
            set { _allowOrient[1] = value; }
        }
        public bool AllowOrientZ
        {
            get { if (Pack.IsBrick) return _allowOrient[2]; else return true; }
            set { _allowOrient[2] = value; }
        }
        public bool IsValid => null != Pack && Number > 0 && (AllowOrientX || AllowOrientY || AllowOrientZ);

        private bool[] _allowOrient = { true, true, true };
    }
    #endregion
}


