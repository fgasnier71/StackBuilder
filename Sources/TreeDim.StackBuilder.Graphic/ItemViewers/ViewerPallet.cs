#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class ViewerPallet : Viewer
    {
        #region Constructor
        public ViewerPallet(PalletProperties palletProperties)
        {
            PalletProperties = palletProperties;
        }
        #endregion

        #region Drawing
        public override void Draw(Graphics3D graphics, Transform3D transform)
        {
            Pallet pallet = new Pallet(PalletProperties);
            pallet.Draw(graphics, transform);
            if (graphics.ShowDimensions)
                graphics.AddDimensions(new DimensionCube(PalletProperties.Dimensions));
        }
        public override void Draw(Graphics2D graphics)
        {
        }
        #endregion

        #region Data members
        private PalletProperties PalletProperties { get; set; }
        #endregion
    }
}
