using System;
using System.Collections.Generic;
using System.Linq;

using Sharp3D.Math.Core;
using log4net;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    public class SolverBoxCase : ISolver
    {
        public SolverBoxCase(PackableBrick packable, BoxProperties bProperties)
        {
            _packable = packable;
            _caseProperties = bProperties;
        }

        public Layer2DBrickDef BuildBestLayer(ConstraintSetAbstract constraintSet)
        {
            // build layer list
            var solver = new LayerSolver();
            List<Layer2DBrickDef> layers = solver.BuildLayers(
                    _packable.OuterDimensions
                    , new Vector2D(_caseProperties.InsideLength, _caseProperties.InsideWidth)
                    , 0.0 /* offsetZ */
                    , constraintSet
                    , true
                );
            if (layers.Count > 0)
                return layers[0];
            return null;
        }

        public List<AnalysisHomo> BuildAnalyses(ConstraintSetAbstract constraintSet, bool allowMultipleLayerOrientations)
        {
            var analyses = new List<AnalysisHomo>();
 
            // get best set of layers
            if (allowMultipleLayerOrientations)
            {
               var listLayerEncap = new List<KeyValuePair<LayerEncap, int>>();
                LayerSolver.GetBestCombination(
                    _packable.OuterDimensions,
                    _caseProperties.GetStackingDimensions(constraintSet),
                    constraintSet,
                    ref listLayerEncap);

                var layerEncaps = new List<LayerEncap>();
                foreach (var vp in listLayerEncap)
                    layerEncaps.Add(vp.Key);

                var analysis = new AnalysisBoxCase(null, _packable, _caseProperties, constraintSet as ConstraintSetBoxCase);
                analysis.AddSolution(layerEncaps);
                // only add analysis if it has a valid solution
                if (analysis.Solution.ItemCount > 0)
                    analyses.Add(analysis);
            }
            else
            {
                // build layer list
                var solver = new LayerSolver();
                List<Layer2DBrickDef> layers = solver.BuildLayers(
                     _packable.OuterDimensions
                     , new Vector2D(_caseProperties.InsideLength, _caseProperties.InsideWidth)
                     , 0.0 /* offsetZ */
                     , constraintSet
                     , true
                 );
                Solution.SetSolver(solver);
                // loop on layers
                foreach (Layer2DBrickDef layer in layers)
                {
                    var layerDescs = new List<LayerDesc> { layer.LayerDescriptor };
                    var analysis = new AnalysisBoxCase(null, _packable, _caseProperties, constraintSet as ConstraintSetBoxCase);
                    analysis.AddSolution(layerDescs);
                    // only add analysis if it has a valid solution
                    if (analysis.Solution.ItemCount > 0)
                        analyses.Add(analysis);
                }
            }
            return analyses;
        }

        #region Non-Public Members

        private PackableBrick _packable;
        private BoxProperties _caseProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(SolverBoxCase));

        #endregion

    }
}
