#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using treeDiM.StackBuilder.Basics;

using Sharp3D.Math.Core;
using log4net;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    #region CylinderLayerPattern
    internal abstract class CylinderLayerPattern
    {
        #region Abstract methods
        abstract public string Name { get; }
        abstract public bool GetLayerDimensions(Layer2DCyl layer, out double length, out double width);
        abstract public void GenerateLayer(Layer2DCyl layer, double actualLength, double actualWidth);
        abstract public bool CanBeSwapped { get; }
        #endregion

        #region Public properties
        #endregion

        #region Private methods
        protected double GetPalletLength(Layer2DCyl layer)
        {
            if (!layer.Swapped)
                return layer.Length;
            else
                return layer.Width;
        }

        protected double GetPalletWidth(Layer2DCyl layer)
        {
            if (!layer.Swapped)
                return layer.Width;
            else
                return layer.Length;
        }

        public void AddPosition(Layer2DCyl layer, Vector2D vPosition)
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
            Transform3D transfRot = new Transform3D(matRot);

            matRot.M14 = vTranslation[0];
            matRot.M24 = vTranslation[1];
            matRot.M34 = vTranslation[2];

            Transform3D transfRotTranslation = new Transform3D(matRot);
            Vector3D vPositionSwapped = transfRotTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0));

            if (!layer.IsValidPosition(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y)))
            {
                _log.Warn(string.Format("Attempt to add an invalid position in pattern = {0}, Swapped = true", this.Name));
                return;
            }
            layer.Add(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y));
        }
        #endregion

        #region Static methods
        public static CylinderLayerPattern[] All
        { get { return _allPatterns; } }
        public static CylinderLayerPattern GetByName(string patternName)
        {
            foreach (CylinderLayerPattern pattern in CylinderLayerPattern.All)
            {
                if (string.Equals(pattern.Name, patternName, StringComparison.CurrentCultureIgnoreCase))
                    return pattern;
            }
            // no pattern found!
            throw new Exception(string.Format("Invalid pattern name = {0}", patternName));
        }
        public static int GetPatternNameIndex(string patternName)
        {
            int index = 0;
            foreach (CylinderLayerPattern pattern in CylinderLayerPattern.All)
            {
                if (string.Equals(pattern.Name, patternName, StringComparison.CurrentCultureIgnoreCase))
                    return index;
            }
            // no pattern found!
            throw new Exception(string.Format("Invalid pattern name = {0}", patternName));
        }
        #endregion

        #region Data members
        private static CylinderLayerPattern[] _allPatterns = {
            new CylinderLayerPatternAligned()
            , new CylinderLayerPatternExpanded()
            , new CylinderLayerPatternStaggered()
            , new CylinderLayerPatternMixed12()
            , new CylinderLayerPatternMixed121()
            , new CylinderLayerPatternMixed212()
        };
        protected static readonly ILog _log = LogManager.GetLogger(typeof(CylinderLayerPattern));
        #endregion
    }
    #endregion
}
