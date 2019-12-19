#region Using directives
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class ViewerSolutionHCyl : Viewer
    {
        #region Constructor
        public ViewerSolutionHCyl(SolutionHCyl solution)
        {
            Solution = solution;
        }
        #endregion

        #region Viewer abstract method implementation
        public override void Draw(Graphics3D graphics, Transform3D transform)
        {
            AnalysisHCyl analysis = Solution.AnalysisHCyl;
            if (analysis is AnalysisHCylPallet analysisHCylPallet)
            {
                Pallet pallet = new Pallet(analysisHCylPallet.PalletProperties);
                pallet.Draw(graphics, transform);
            }
            else if (analysis is AnalysisHCylTruck analysisHCylTruck)
            {
                Truck truck = new Truck(analysisHCylTruck.TruckProperties);
                truck.DrawBegin(graphics);
            }
            uint pickId = 0;
            // ### draw solution
            foreach (var cp in Solution.Layout.Positions)
            {
                Cylinder c = new Cylinder(
                    pickId++
                    , analysis.Content as CylinderProperties
                    , cp.Transform(transform));
                graphics.AddCylinder(c);
            }
            // ### dimensions
            graphics.AddDimensions(new DimensionCube(BoundingBoxDim(DimCasePalletSol1), Color.Black, false));
            graphics.AddDimensions(new DimensionCube(BoundingBoxDim(DimCasePalletSol2), Color.Red, true));
            // ###

        }
        public override void Draw(Graphics2D graphics)
        {
        }
        #endregion

        #region Helpers
        private BBox3D BoundingBoxDim(int index)
        {
            PalletProperties palletProperties = null;
            if (Solution.Analysis is AnalysisCasePallet analysisCasePallet)
                palletProperties = analysisCasePallet.PalletProperties;
            if (Solution.Analysis is AnalysisCylinderPallet analysisCylinderPallet)
                palletProperties = analysisCylinderPallet.PalletProperties;

            switch (index)
            {
                case 0: return Solution.BBoxGlobal;
                case 1: return Solution.BBoxLoadWDeco;
                case 2: return palletProperties.BoundingBox;
                case 3: return new BBox3D(0.0, 0.0, 0.0, palletProperties.Length, palletProperties.Width, 0.0);
                default: return Solution.BBoxGlobal;
            }
        }
        #endregion

        #region Public properties
        public static int DimCasePalletSol1 { get; set; } = 0;
        public static int DimCasePalletSol2 { get; set; } = 1;
        #endregion

        #region Private properties
        private SolutionHCyl Solution { get; set; }
        #endregion
    }
}
