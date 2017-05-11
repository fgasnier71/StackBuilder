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
    public class SolverCasePallet : ISolver
    {
        #region Data members
        private PackableBrick _packable;
        private PalletProperties _palletProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(SolverCasePallet));
        #endregion

        #region Constructor
        public SolverCasePallet(PackableBrick packable, PalletProperties palletProperties)
        {
            _packable = packable;
            _palletProperties = palletProperties;
        }
        #endregion

        #region ISolver implementation
        public List<Analysis> BuildAnalyses(ConstraintSetAbstract constraintSet)
        {
            List<Analysis> analyses = new List<Analysis>();
             ConstraintSetCasePallet constraintSetCasePallet = constraintSet as ConstraintSetCasePallet;
             if (null == constraintSetCasePallet)
                 return analyses;
             Vector2D overhang = constraintSetCasePallet.Overhang;
           // build layer list
            LayerSolver solver = new LayerSolver();
            List<Layer2D> layers = solver.BuildLayers(
                _packable.OuterDimensions
                , new Vector2D(_palletProperties.Length + 2.0 * overhang.X, _palletProperties.Width + 2.0 * overhang.Y)
                , _palletProperties.Height
                , constraintSetCasePallet
                , true
                );
            Solution.SetSolver(solver);
            // loop on layers
            foreach (Layer2D layer in layers)
            {
                List<LayerDesc> layerDescs = new List<LayerDesc>();
                layerDescs.Add(layer.LayerDescriptor);
                AnalysisCasePallet analysis = new AnalysisCasePallet(_packable, _palletProperties, constraintSet as ConstraintSetCasePallet);
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
