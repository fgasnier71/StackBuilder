#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharp3D.Math.Core;
using log4net;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    public class SolverBoxCase : ISolver
    {
        #region Data members
        private PackableBrick _packable;
        private BoxProperties _caseProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(SolverBoxCase));
        #endregion

        #region Constructor
        public SolverBoxCase(PackableBrick packable, BoxProperties bProperties)
        {
            _packable = packable;
            _caseProperties = bProperties;
        }
        #endregion

        #region ISolver implementation
        public List<Analysis> BuildAnalyses(ConstraintSetAbstract constraintSet)
        {
            List<Analysis> analyses = new List<Analysis>();
            // build layer list
            LayerSolver solver = new LayerSolver();
            List<Layer2D> layers = solver.BuildLayers(
                    _packable.OuterDimensions
                    , new Vector2D(_caseProperties.InsideLength, _caseProperties.InsideWidth)
                    , 0.0 /* offsetZ */
                    , constraintSet
                    , true
                );
            // loop on layers
            foreach (Layer2D layer in layers)
            { 
                List<LayerDesc> layerDescs = new List<LayerDesc>();
                layerDescs.Add(layer.LayerDescriptor);
                AnalysisBoxCase analysis = new AnalysisBoxCase(null, _packable, _caseProperties, constraintSet as ConstraintSetBoxCase);
                analysis.AddSolution(layerDescs);
                // only add analysis if it has a valid solution
                if (analysis.Solution.ItemCount > 0)
                    analyses.Add(analysis);
            }
            return analyses;
        }
        #endregion
    }
}
