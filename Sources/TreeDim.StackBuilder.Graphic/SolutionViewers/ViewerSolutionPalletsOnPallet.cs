#region Using directives
using Sharp3D.Math.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class ViewerSolutionPalletsOnPallet : Viewer
    {
        public ViewerSolutionPalletsOnPallet(SolutionPalletsOnPallet solution)
        {
            Solution = solution;
        }

        public override void Draw(Graphics3D graphics, Transform3D transform)
        {
            AnalysisPalletsOnPallet analysis = Solution.Analysis;

            // ### draw pallet
            Pallet pallet = new Pallet(analysis.PalletProperties);

        }

        public override void Draw(Graphics2D graphics) {}

        public SolutionPalletsOnPallet Solution { get; private set; }
    }
}
