#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisPalletsOnPallet : Analysis
    {
        #region Constructor
        public AnalysisPalletsOnPallet(Document doc)
            : base(doc)
        {
            Solution = new SolutionPalletsOnPallet() { Analysis = this };
        }
        #endregion

        #region Analysis override
        public override bool HasValidSolution => true;
        #endregion

        #region Public properties
        public SolutionPalletsOnPallet Solution { get; set; }
        public PalletProperties PalletProperties { get; set; }
        #endregion

        #region Mode
        public enum EMode { PALLET_HALF, PALLET_QUARTER }
        public EMode Mode { get; set; } = EMode.PALLET_HALF;
        public void SetHalfPallets(LoadedPallet loadedPallet0, LoadedPallet loadedPallet1)
        {
            Mode = EMode.PALLET_HALF;
            PalletAnalyses[0] = loadedPallet0;
            PalletAnalyses[1] = loadedPallet1;
            PalletAnalyses[2] = null;
            PalletAnalyses[3] = null;            
        }
        public void SetQuarterPallets(LoadedPallet loadedPallet0, LoadedPallet loadedPallet1, LoadedPallet loadedPallet2, LoadedPallet loadedPallet3)
        {
            Mode = EMode.PALLET_QUARTER;
            PalletAnalyses[0] = loadedPallet0;
            PalletAnalyses[1] = loadedPallet1;
            PalletAnalyses[2] = loadedPallet2;
            PalletAnalyses[3] = loadedPallet3;
        }
        public LoadedPallet ContentTypeByIndex(int index) => PalletAnalyses[index];
        #endregion

        #region Non-public members
        protected override void RemoveItselfFromDependancies()
        {
            base.RemoveItselfFromDependancies();
            foreach (var p in PalletAnalyses)
                p.RemoveDependancy(this);
        }
        private readonly LoadedPallet[] PalletAnalyses = new LoadedPallet[4];
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
    }
}
