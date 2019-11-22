#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    public class SolverCasePallet : ISolver
    {
        public SolverCasePallet(PackableBrick packable, PalletProperties palletProperties, ConstraintSetAbstract constraintSet)
        {
            Packable = packable;
            PalletProperties = palletProperties;
            if (constraintSet is ConstraintSetCasePallet constraintSetCasePallet)
                ConstraintSet = constraintSetCasePallet;
            else
                throw new InvalidConstraintSetException();
        }
        public Layer2DBrickImp BuildBestLayer()
        {
            // build layer list
            var solver = new LayerSolver();
            List<Layer2DBrickImp> layers = solver.BuildLayers(
                Packable.OuterDimensions
                , new Vector2D(PalletProperties.Length + 2.0 * ConstraintSet.Overhang.X, PalletProperties.Width + 2.0 * ConstraintSet.Overhang.Y)
                , PalletProperties.Height
                , ConstraintSet
                , true
                );
            if (layers.Count > 0)
                return layers[0];
            return null;
        }
        public AnalysisLayered BuildAnalysis(LayerDescBox layerDesc)
        {
            SolutionLayered.SetSolver(new LayerSolver());
            AnalysisLayered analysis = new AnalysisCasePallet(Packable, PalletProperties, ConstraintSet);
            analysis.AddSolution(new List<LayerDesc>() { layerDesc });
            return analysis;
        }
        public List<AnalysisLayered> BuildAnalyses(bool allowMultipleLayerOrientations)
        {
            var analyses = new List<AnalysisLayered>();
            var constraintSetCasePallet = ConstraintSet as ConstraintSetCasePallet;
            if (null == constraintSetCasePallet)
                return analyses;
            Vector2D overhang = constraintSetCasePallet.Overhang;

            if (allowMultipleLayerOrientations)
            {
                var listLayerEncap = new List<KeyValuePair<LayerEncap, int>>();
                LayerSolver.GetBestCombination(
                    Packable.OuterDimensions,
                    PalletProperties.GetStackingDimensions(ConstraintSet),
                    ConstraintSet,
                    ref listLayerEncap);
                SolutionLayered.SetSolver(new LayerSolver());
                var analysis = new AnalysisCasePallet(Packable,
                                                      PalletProperties,
                                                      ConstraintSet);
                analysis.AddSolution(listLayerEncap);
                // only add analysis if it has a valid solution
                if (analysis.Solution.ItemCount > 0)
                    analyses.Add(analysis);
            }
            else
            {
                // build layer list
                var solver = new LayerSolver();
                List<Layer2DBrickImp> layers = solver.BuildLayers(
                    Packable.OuterDimensions
                    , new Vector2D(PalletProperties.Length + 2.0 * overhang.X, PalletProperties.Width + 2.0 * overhang.Y)
                    , PalletProperties.Height
                    , constraintSetCasePallet
                    , true
                    );
                SolutionLayered.SetSolver(solver);
                // loop on layers
                foreach (Layer2DBrickImp layer in layers)
                {
                    var layerDescs = new List<LayerDesc> { layer.LayerDescriptor };
                    var analysis = new AnalysisCasePallet(Packable,
                                                          PalletProperties,
                                                          ConstraintSet);
                    analysis.AddSolution(layerDescs);
                    // only add analysis if it has a valid solution
                    if (analysis.Solution.ItemCount > 0)
                        analyses.Add(analysis);
                }
            }
            return analyses;
        }

        #region Non-Public Members
        private PackableBrick Packable { get; set; }
        private PalletProperties PalletProperties { get; set; }
        private ConstraintSetCasePallet ConstraintSet { get; set; }
        #endregion
    }
}
