#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class LayerSolutionViewer
    {
        #region Data members
        private Layer2D _layer;
        #endregion

        #region Constructor
        public LayerSolutionViewer(Layer2D layer)
        {
            _layer = layer;
        }
        #endregion

        #region Public methods
        public void Draw(Graphics2D graphics)
        {
 
        }
        public void Draw(Graphics3D graphics)
        { 
        }
        #endregion



    }
}
