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

        public Layer2D BuildBestLayer(ConstraintSetAbstract constraintSet)
        {
            // build layer list
            var solver = new LayerSolver();
            List<Layer2D> layers = solver.BuildLayers(
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

        public List<Analysis> BuildAnalyses(ConstraintSetAbstract constraintSet)
        {
            var analyses = new List<Analysis>();
            // build layer list
            var solver = new LayerSolver();
            List<Layer2D> layers = solver.BuildLayers(
                    _packable.OuterDimensions
                    , new Vector2D(_caseProperties.InsideLength, _caseProperties.InsideWidth)
                    , 0.0 /* offsetZ */
                    , constraintSet
                    , true
                );
            Solution.SetSolver(solver);
            // loop on layers
            foreach (Layer2D layer in layers)
            { 
                var layerDescs = new List<LayerDesc>();
                layerDescs.Add(layer.LayerDescriptor);
                var analysis = new AnalysisBoxCase(null, _packable, _caseProperties, constraintSet as ConstraintSetBoxCase);
                analysis.AddSolution(layerDescs);
                // only add analysis if it has a valid solution
                if (analysis.Solution.ItemCount > 0)
                    analyses.Add(analysis);
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
