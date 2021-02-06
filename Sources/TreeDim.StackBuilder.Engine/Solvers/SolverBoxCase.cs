#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    public class SolverBoxCase : ISolver
    {
        public SolverBoxCase(PackableBrick packable, BoxProperties bProperties, ConstraintSetAbstract constraintSet)
        {
            _packable = packable;
            _caseProperties = bProperties;
            if (constraintSet is ConstraintSetBoxCase constraintSetBoxCase)
                ConstraintSet = constraintSetBoxCase;
            else
                throw new InvalidConstraintSetException();
        }

        public Layer2DBrickImp BuildBestLayer()
        {
            // build layer list
            var solver = new LayerSolver();
            List<Layer2DBrickImp> layers = solver.BuildLayers(
                    _packable.OuterDimensions
                    , _packable.Bulge
                    , new Vector2D(_caseProperties.InsideLength, _caseProperties.InsideWidth)
                    , 0.0 /* offsetZ */
                    , ConstraintSet
                    , true
                );
            if (layers.Count > 0)
                return layers[0];
            return null;
        }

        public List<AnalysisLayered> BuildAnalyses(bool allowMultipleLayerOrientations)
        {
            var analyses = new List<AnalysisLayered>();
 
            // get best set of layers
            if (allowMultipleLayerOrientations)
            {
               var listLayerEncap = new List<KeyValuePair<LayerEncap, int>>();
                LayerSolver.GetBestCombination(
                    _packable.OuterDimensions,
                    _packable.Bulge,
                    _caseProperties.GetStackingDimensions(ConstraintSet),
                    ConstraintSet,
                    ref listLayerEncap);

                var layerEncaps = new List<LayerEncap>();
                foreach (var vp in listLayerEncap)
                    layerEncaps.Add(vp.Key);

                var analysis = new AnalysisBoxCase(null, _packable, _caseProperties, ConstraintSet);
                analysis.AddSolution(layerEncaps);
                // only add analysis if it has a valid solution
                if (analysis.Solution.ItemCount > 0)
                    analyses.Add(analysis);
            }
            else
            {
                // build layer list
                var solver = new LayerSolver();
                List<Layer2DBrickImp> layers = solver.BuildLayers(
                     _packable.OuterDimensions
                     , _packable.Bulge
                     , new Vector2D(_caseProperties.InsideLength, _caseProperties.InsideWidth)
                     , 0.0 /* offsetZ */
                     , ConstraintSet
                     , true
                 );
                SolutionLayered.SetSolver(solver);
                // loop on layers
                foreach (Layer2DBrickImp layer in layers)
                {
                    var layerDescs = new List<LayerDesc> { layer.LayerDescriptor };
                    var analysis = new AnalysisBoxCase(null, _packable, _caseProperties, ConstraintSet);
                    analysis.AddSolution(layerDescs);
                    // only add analysis if it has a valid solution
                    if (analysis.Solution.ItemCount > 0)
                        analyses.Add(analysis);
                }
            }
            return analyses;
        }

        #region Non-Public Members
        private PackableBrick _packable { get; set; }
        private BoxProperties _caseProperties { get; set; }
        private ConstraintSetBoxCase ConstraintSet { get; set; }
        #endregion
    }
}
