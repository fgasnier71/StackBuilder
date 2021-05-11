#region Using directives
using System.Collections.Generic;
using System.Linq;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisPalletsOnPallet : Analysis
    {
        #region Constructor
        public AnalysisPalletsOnPallet(Document doc, PalletProperties masterPallet,
            LoadedPallet loadedPallet0, LoadedPallet loadedPallet1,
            LoadedPallet loadedPallet2 = null, LoadedPallet loadedPallet3 = null)
            : base(doc)
        {
            Solution = new SolutionPalletsOnPallet() { Analysis = this };
            PalletProperties = masterPallet;
            if (null == loadedPallet2 && null == loadedPallet3)
                SetHalfPallets(loadedPallet0, loadedPallet1);
            else
                SetQuarterPallets(loadedPallet0, loadedPallet1, loadedPallet2, loadedPallet3);
        }
        #endregion

        #region Analysis override
        public override bool HasValidSolution => null != PalletAnalyses[0] && null != PalletAnalyses[1]
            && ((null != PalletAnalyses[2] && null != PalletAnalyses[3])
            || (null == PalletAnalyses[2] && null == PalletAnalyses[3]));
        #endregion

        #region Public properties
        public SolutionPalletsOnPallet Solution { get; set; }
        public PalletProperties PalletProperties { get; set; }
        public ItemBase Container => PalletProperties;
        #endregion

        #region Mode
        public enum EMode { PALLET_HALF, PALLET_QUARTER }
        public EMode Mode { get; set; } = EMode.PALLET_HALF;
        public void SetHalfPallets(LoadedPallet loadedPallet0, LoadedPallet loadedPallet1)
        {
            Mode = EMode.PALLET_HALF;
            PalletAnalyses[0] = loadedPallet0;
            SetPalletAnalysis(1, loadedPallet1);
            PalletAnalyses[2] = null;
            PalletAnalyses[3] = null;            
        }
        public void SetQuarterPallets(
            LoadedPallet loadedPallet0, LoadedPallet loadedPallet1,
            LoadedPallet loadedPallet2, LoadedPallet loadedPallet3)
        {
            Mode = EMode.PALLET_QUARTER;
            PalletAnalyses[0] = loadedPallet0;
            SetPalletAnalysis(1, loadedPallet1);
            SetPalletAnalysis(2, loadedPallet2);
            SetPalletAnalysis(3, loadedPallet3);
        }

        private void SetPalletAnalysis(int index, LoadedPallet loadedPallet)
        {
            if (null != loadedPallet)
            {
                for (int i = 0; i < index; ++i)
                    if (PalletAnalyses[i].ParentAnalysis == loadedPallet.ParentAnalysis)
                    {
                        PalletAnalyses[index] = PalletAnalyses[i];
                        return;
                    }
            }
            PalletAnalyses[index] = loadedPallet;
        }
        public LoadedPallet ContentTypeByIndex(int index) => PalletAnalyses[index];
        public virtual bool InnerContent(ref List<Pair<Packable, int>> listInnerPackables)
        {
            if (null == listInnerPackables)
                listInnerPackables = new List<Pair<Packable, int>>();

            foreach (var lp in PalletAnalyses)
            {
                if (null == lp) continue;
                var analysis1 = lp.ParentAnalysis;
                
                int iCount = 0;
                int index = -1;
                foreach (var ip in listInnerPackables)
                {
                    var packable = ip.first;
                    if (packable is LoadedPallet lp2 && lp2.ParentAnalysis == analysis1)
                        iCount += ip.second;
                    ++index;
                }
                if (iCount > 0)
                    listInnerPackables.RemoveAt(index);

                listInnerPackables.Add(new Pair<Packable, int>(lp, iCount+1));
            }
            return true;
        }
        public double LoadWeight
        {
            get
            {
                double weight = 0.0;
                for (int i = 0; i < 4; ++i)
                {
                    if (null != PalletAnalyses[i])
                        weight += PalletAnalyses[i].ParentAnalysis.Solution.LoadWeight;
                }
                return weight;
            }
        }
        #endregion

        #region Non-public members
        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
            foreach (var p in PalletAnalyses)
                p?.RemoveDependancy(this);
        }
        public readonly LoadedPallet[] PalletAnalyses = new LoadedPallet[4];
        #endregion
    }

    public class SolutionPalletsOnPallet
    { 
        public AnalysisPalletsOnPallet Analysis { get; set; }
        public List<HSolElement> ContainedElements
        {
            get
            {
                double length = Analysis.PalletProperties.Length;
                double halfLength = 0.5 * Analysis.PalletProperties.Length;
                double halfWidth = 0.5 * Analysis.PalletProperties.Width;
                double height = Analysis.PalletProperties.Height;
                List<HSolElement> list = new List<HSolElement>();
                switch (Analysis.Mode)
                {
                    case AnalysisPalletsOnPallet.EMode.PALLET_HALF:
                        {
                            HalfAxis.HAxis axis0 = HalfAxis.HAxis.AXIS_Y_P, axis1 = HalfAxis.HAxis.AXIS_X_N;
                            list.Add(new HSolElement() { ContentType = 0, Position = new BoxPosition(new Vector3D(halfLength, 0.0, height), axis0, axis1) });
                            list.Add(new HSolElement() { ContentType = 1, Position = new BoxPosition(new Vector3D(length, 0.0, height), axis0, axis1) });
                        }
                        break;
                    case AnalysisPalletsOnPallet.EMode.PALLET_QUARTER:
                        {
                            HalfAxis.HAxis axis0 = HalfAxis.HAxis.AXIS_X_P, axis1 = HalfAxis.HAxis.AXIS_Y_P;
                            list.Add(new HSolElement() { ContentType = 0, Position = new BoxPosition(new Vector3D(0.0, 0.0, height), axis0, axis1) });
                            list.Add(new HSolElement() { ContentType = 1, Position = new BoxPosition(new Vector3D(halfLength, 0.0, height), axis0, axis1) });
                            list.Add(new HSolElement() { ContentType = 2, Position = new BoxPosition(new Vector3D(0.0, halfWidth, height), axis0, axis1) });
                            list.Add(new HSolElement() { ContentType = 3, Position = new BoxPosition(new Vector3D(halfLength, halfWidth, height), axis0, axis1) });
                        }
                        break;
                    default:
                        break;
                }
                return list;
            }
        }
        public BBox3D BBoxLoad
        {
            get
            {
                var bbox = new BBox3D();
                return bbox;
            }
        }
        public double LoadWeight
        {
            get
            {
                return 0.0;
            }
        }
    }
}
