#region Using directives
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
                    , cp.Transform(transform * Transform3D.Translation(analysis.Offset)));
                graphics.AddCylinder(c);
            }
        }
        public override void Draw(Graphics2D graphics)
        {
        }
        #endregion

        private SolutionHCyl Solution { get; set; }
    }
}
