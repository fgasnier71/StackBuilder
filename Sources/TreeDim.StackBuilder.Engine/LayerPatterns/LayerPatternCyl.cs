using System;
using System.Collections.Generic;
using System.Collections.Immutable;

using Sharp3D.Math.Core;
using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Basics.Extensions;

namespace treeDiM.StackBuilder.Engine
{
    internal abstract class LayerPatternCyl : LayerPattern
    {
        // This is OK as long as LayerPatternBox objects are immutable
        public static readonly IReadOnlyList<LayerPatternCyl> All = ImmutableList.CreateRange(new LayerPatternCyl[] {
            new CylinderLayerPatternAligned()
            , new CylinderLayerPatternExpanded()
            , new CylinderLayerPatternStaggered()
            , new CylinderLayerPatternMixed12()
            , new CylinderLayerPatternMixed121()
            , new CylinderLayerPatternMixed212()
        });

        public static LayerPatternCyl GetByName(string patternName)
        {
            return All[GetPatternNameIndex(patternName)];
        }

        public static int GetPatternNameIndex(string patternName)
        {
            int index = All.FindIndex(x => string.Equals(x.Name, patternName, StringComparison.OrdinalIgnoreCase));
            return index != -1
                ? index
                : throw new ArgumentException($"Invalid pattern name = {patternName}", nameof(patternName));
        }
        
        public void AddPosition(ILayer2D layer, Vector2D vPosition)
        {
            Matrix4D matRot = Matrix4D.Identity;
            Vector3D vTranslation = Vector3D.Zero;

            if (layer.Swapped)
            {
                matRot = new Matrix4D(
                    0.0, -1.0, 0.0, 0.0
                    , 1.0, 0.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                vTranslation = new Vector3D(layer.Length, 0.0, 0.0);
            }
            var transfRot = new Transform3D(matRot);

            matRot.M14 = vTranslation[0];
            matRot.M24 = vTranslation[1];
            matRot.M34 = vTranslation[2];

            var transfRotTranslation = new Transform3D(matRot);
            Vector3D vPositionSwapped = transfRotTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0));

            var layerCyl = layer as Layer2DCyl;

            if (!layerCyl.IsValidPosition(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y)))
            {
                _log.Warn(string.Format("Attempt to add an invalid position in pattern = {0}, Swapped = true", Name));
                return;
            }
            layerCyl.Add(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y));
        }

        #region Non-Public Members

        protected static readonly ILog _log = LogManager.GetLogger(typeof(LayerPatternCyl));

        protected double GetRadius(ILayer2D layer)
        {
            return ((Layer2DCyl)layer).CylinderRadius;
        }

        #endregion
    }
}
