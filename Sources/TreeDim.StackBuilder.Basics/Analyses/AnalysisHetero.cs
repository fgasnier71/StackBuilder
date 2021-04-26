#region Using directives
using System;
using System.Linq;
using System.Collections.Generic;

using Sharp3D.Math.Core;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public abstract class AnalysisHetero : Analysis
    {
        public AnalysisHetero(Document doc)
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
        public uint GetNoContent(Packable p)
        {
            var contentItem = _content.Find(ci => ci.Pack == p);
            if (null != contentItem)
                return contentItem.Number;
            else
                return 0;
        }
        public void ClearContent()
        {
            foreach (ContentItem ci in _content)
                ci.Pack.RemoveDependancy(this);
            _content.Clear();
        }
        public void AddContent(List<ContentItem> contentItems)
        {
            foreach (var ci in contentItems)
            {
                ci.Pack.AddDependancy(this);
                _content.Add(ci);
            }
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

        #region Container
        public IEnumerable<ItemBase> Containers => _containers;
        public abstract Vector3D DimContainer(int index);
        public abstract BBox3D AdditionalBoudingBox(int index);
        public abstract double WeightContainer(int index);
        #endregion

        public HConstraintSet ConstraintSet { get; set; }
        public virtual double ContentTotalVolume => Content.Sum(ci => ci.Pack.Volume * ci.Number);
        public virtual double ContentTotalWeight => Content.Sum(ci => ci.Pack.Weight * ci.Number);

        public abstract Vector3D Offset(int index);
        public bool IsValid => _containers.Count > 0 && _content.Count > 0;
        public HSolution BuildSolution()
        {
            return Solution;
        }
        public override bool HasValidSolution => null != Solution;
        public HSolution Solution { get; set; }
        #region Non-public members
        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
            foreach (ContentItem ci in _content)
                ci.Pack.RemoveDependancy(this);
        }

        private List<ContentItem> _content = new List<ContentItem>();
        protected readonly List<ItemBase> _containers = new List<ItemBase>();
        #endregion
    }

    #region ContentItem
    public class ContentItem
    {
        public ContentItem(Packable p, uint n) { Pack = p; Number = n; }
        public ContentItem(Packable p, uint n, bool[] orientations) { Pack = p; Number = n; Array.Copy(orientations, AllowOrient, 3); }
        public Packable Pack { get; set; }
        public uint Number { get; set; }
        public int PriorityLevel { get; set; } = -1;

        public bool[] AllowedOrientations { get { return new bool[] { AllowOrientX, AllowOrientY, AllowOrientZ }; } set { AllowOrient = value; } }
        public bool AllowOrientX
        {
            get { if (Pack.IsBrick) return AllowOrient[0]; else return false; }
            set { AllowOrient[0] = value; }
        }
        public bool AllowOrientY
        {
            get { if (Pack.IsBrick) return AllowOrient[1]; else return false; }
            set { AllowOrient[1] = value; }
        }
        public bool AllowOrientZ
        {
            get { if (Pack.IsBrick) return AllowOrient[2]; else return true; }
            set { AllowOrient[2] = value; }
        }
        public bool IsValid => null != Pack && Number > 0 && (AllowOrientX || AllowOrientY || AllowOrientZ);
        public bool MatchDimensions(double length, double width, double height)
        {
            double[] dim0 = { length, width, height };
            double[] dim1 = { Pack.OuterDimensions.X, Pack.OuterDimensions.Y, Pack.OuterDimensions.Z };
            Array.Sort(dim0);
            Array.Sort(dim1);
            for (int i = 0; i < 3; ++i)
            {
                if (!MostlyEqual(dim0[i], dim1[i]))
                    return false;
            }
            return true;
        }
        private static bool MostlyEqual(double val0, double val1) => Math.Abs(val1 - val0) < 1.0e-03;
        private bool[] AllowOrient { get; set; } = { true, true, true };
    }

    public class LoadedPalletItem
    {
        public LoadedPalletItem(AnalysisPackablePallet analysis, uint n) { PalletAnalysis = analysis; Number = n; }
        public AnalysisPackablePallet PalletAnalysis { get; private set; }
        public uint Number { get; private set; }
        public bool IsValid => null != PalletAnalysis && 0 != Number;
        public Vector3D Dimensions => PalletAnalysis.Solution.BBoxGlobal.DimensionsVec;
    }
    #endregion
}


