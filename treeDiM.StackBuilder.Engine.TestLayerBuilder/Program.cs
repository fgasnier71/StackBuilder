#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.Engine.TestLayerBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            LayerSolver solver = new LayerSolver();

            bool bestLayersOnly = true;
            Vector3D dimBox = new Vector3D();
            Vector2D dimContainer = new Vector2D();
            ConstraintSetAbstract constraintSet = null;
            List<Layer2D> layers = solver.BuildLayers(dimBox, dimContainer, constraintSet, bestLayersOnly);

            int solIndex = 0;
            foreach (Layer2D layer in layers)
            {
                string fileName = string.Format("Pallet_{0}.bmp", solIndex++);
                string filePath = Path.Combine(Path.GetTempPath(), fileName);

                Graphics2DImage graphics = new Graphics2DImage( new Size(150,150) );
                LayerSolutionViewer solViewer = new LayerSolutionViewer(layer);
                solViewer.Draw(graphics);
                graphics.SaveAs(filePath);
            }
        }
    }
}
