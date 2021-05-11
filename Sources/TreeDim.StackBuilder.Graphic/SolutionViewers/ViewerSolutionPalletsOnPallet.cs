#region Using directives
using System;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class ViewerSolutionPalletsOnPallet : Viewer
    {
        #region Constructor
        public ViewerSolutionPalletsOnPallet(SolutionPalletsOnPallet solution)
        {
            Solution = solution;
        }
        #endregion

        #region Viewer override
        public override void Draw(Graphics3D graphics, Transform3D transform)
        {
            if (null == Solution) return;
            AnalysisPalletsOnPallet analysis = Solution.Analysis;

            // ### draw pallet
            Pallet p = new Pallet(analysis.PalletProperties);
            p.Draw(graphics, transform);

            // ### draw loaded pallets
            uint pickId = 0;
            BBox3D bbox = new BBox3D();
            foreach (HSolElement solElt in Solution.ContainedElements)
            {
                if (Analysis.ContentTypeByIndex(solElt.ContentType) is LoadedPallet loadedPallet)
                {
                    BBox3D solBBox = loadedPallet.ParentAnalysis.Solution.BBoxGlobal;
                    graphics.AddImage(++pickId, new SubContent(loadedPallet.ParentAnalysis), solBBox.DimensionsVec, solElt.Position.Transform(transform));
                    // bbox used for picking
                    bbox.Extend(new BBox3D(solElt.Position.Transform(transform), solBBox.DimensionsVec));
                }
            }
        }

        public override void Draw(Graphics2D graphics)
        {
            if (null == Solution) return;
            throw new NotImplementedException();
        }
        #endregion

        #region Accessors
        public SolutionPalletsOnPallet Solution { get; private set; }
        public AnalysisPalletsOnPallet Analysis => Solution.Analysis;
        #endregion
    }
}
