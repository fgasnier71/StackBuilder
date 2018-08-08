#region Using directives
using System;
using System.Linq;
using System.Collections.Generic;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public abstract class HAnalysis : ItemBaseNamed
    {
        public HAnalysis(Document doc)
            : base(doc)
        {
            Solution = new HSolution(string.Empty) { Analysis = this };
        }

        #region Content
        public IEnumerable<ContentItem> Content
        {
            get { return _content; }
            set
            {
                if (value == _content) return;
                ClearContent();
                foreach (ContentItem ci in value)
                {
                    if (null != ParentDocument)
                        ci.Pack.AddDependancy(this);
                    _content.Add(ci);
                }
            }
        }
        public Packable ContentTypeByIndex(int index)
        {
            if (index < 0 || index >= _content.Count)
                throw new Exception($"Invalid type index {index}");
            return _content[index].Pack;
        }
        public void ClearContent()
        {
            foreach (ContentItem ci in _content)
                ci.Pack.RemoveDependancy(this);
            _content.Clear();
        }
        public void AddContent(Packable p, uint number, bool[] orientations)
        {
            _content.Add(new ContentItem(p, number) { AllowedOrientations = orientations });
        }
        public void AddContent(Packable p)
        {
            _content.Add(new ContentItem(p, 1) { AllowedOrientations = new bool[] { true, true, true } } );
        }
        #endregion

        public IEnumerable<ItemBase> Containers => _containers;

        public HConstraintSet ConstraintSet { get; set; }
        public virtual double ContentTotalVolume => Content.Sum(ci => ci.Pack.Volume * ci.Number);
        public virtual double ContentTotalWeight => Content.Sum(ci => ci.Pack.Weight * ci.Number);


        public HSolution BuildSolution()
        {
            return Solution;
        }
        #region Non-public members
        public HSolution Solution { get; private set; }

        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
            foreach (ContentItem ci in _content)
                ci.Pack.RemoveDependancy(this);
        }

        private List<ContentItem> _content = new List<ContentItem>();
        protected readonly List<ItemBase> _containers = new List<ItemBase>();
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


