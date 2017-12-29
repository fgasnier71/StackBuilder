using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace treeDiM.StackBuilder.Basics
{
    public class FastEvaluatorLayer2Pallet : IDisposable
    {
        #region Public constructor
        public FastEvaluatorLayer2Pallet(
            ILayer2D layer, Packable packable, PalletProperties palletProperties,
            ConstraintSetAbstract constraintSet)
        {
            Layer = layer;
            Content = packable;
            Container = palletProperties;
            ConstraintSet = constraintSet;
        }
        #endregion
        #region IDisposable implementation
        public void Dispose() {}
        #endregion

        #region Public properties
        public int ItemCount => Math.Min(NoMaxHeight, NoMaxWeight);
        public int NoLayers
        {
            get
            {
                if (NoMaxHeight <= NoMaxWeight)
                    return (int)Math.Floor((ConstraintSet.OptMaxHeight.Value - Container.Height) / Layer.LayerHeight);
                else
                    return (int)Math.Ceiling((decimal)(NoMaxWeight / Layer.Count));

            }
        }
        public int NoItemsPerLayer => Layer.Count;
        public double PalletHeight => Container.Height + NoLayers * Layer.LayerHeight;
        public double PalletWeight => Container.Weight + ItemCount * Content.Weight;
        public double VolumeEfficiency => 100.0 * (ItemCount * Content.Volume) / ContainerLoadingVolume;
        #endregion

        #region Private properties
        private int NoMaxHeight => ConstraintSet.OptMaxHeight.Activated
                    ? (int)Math.Floor((ConstraintSet.OptMaxHeight.Value - Container.Height) / Layer.LayerHeight) * Layer.Count
                    : int.MaxValue;
        private int NoMaxWeight => ConstraintSet.OptMaxWeight.Activated
                    ? (int)Math.Floor((ConstraintSet.OptMaxWeight.Value - Container.Weight) / (Content.Weight>1.0e-3 ? Content.Weight : 1.0e-3))
                    : int.MaxValue;
        private double ContainerLoadingVolume
        {
            get
            {
                ConstraintSetCasePallet constraintSet = ConstraintSet as ConstraintSetCasePallet;
                return (Container.Length + 2.0 * constraintSet.Overhang.X)
                    * (Container.Width + 2.0 * constraintSet.Overhang.Y)
                    * (ConstraintSet.OptMaxHeight.Value - Container.Height);
            }
        }

        #endregion

        #region Data members
        private ILayer2D Layer { get; set; }
        private Packable Content { get; set; }
        private PalletProperties Container { get; set; }
        private ConstraintSetAbstract ConstraintSet { get; set; }
        #endregion
    }
}
 