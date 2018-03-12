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
        public virtual double ContentTotalVolume => Content.Sum(ci => ci.Pack.Volume * ci.Number);
        public virtual double ContentTotalWeight => Content.Sum(ci => ci.Pack.Weight * ci.Number);

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
        private HSolution _solution;
        static readonly ILog _log = LogManager.GetLogger(typeof(Analysis));
        #endregion
    }

    #region ContentItem
    public class ContentItem
    {
        ContentItem(Packable p, uint n) { Pack = p; Number = n; }
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


