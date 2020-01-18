#region Using directives
using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    internal abstract class HCylLoadPattern
    {
        #region Protected constructor
        protected HCylLoadPattern() {}
        #endregion
        #region Acessors
        public virtual bool CanBeSwapped => true;
        #endregion
        #region Public methods
        public virtual void GetDimensions(HCylLayout layout, OptInt maxCount, out double length, out double width)
        {
            // using XP direction
            int noX = Convert.ToInt32(Math.Floor(GetStackingLength(layout) / layout.CylLength)) -1;
            int noY = Convert.ToInt32(Math.Floor(GetStackingWidth(layout) / (2.0 * layout.CylRadius)));

            if (maxCount.Activated && maxCount.Value < noX * (noY-1))
            {
                if (maxCount.Value < noX)
                {
                    noX = maxCount.Value;
                    noY = 1;
                }
                else
                    noY = maxCount.Value / noX + 1;
            }
            length = noX * layout.CylLength;
            width = 2.0 * noY * layout.CylRadius;
        }
        #endregion
        #region Abstract methods
        public abstract string Name { get; }
        public abstract void Generate(HCylLayout layout, OptInt maxCount, double actualLength, double actualWidth, double maxHeight);
        #endregion
        #region Pattern list
        public static HCylLoadPattern[] Patterns => new HCylLoadPattern[]
        {
            new HCylLoadPatternColumn(),
            new HCylLoadPatternStaggered(),
            new HCylLoadPatternPyramid()
        };
        public static HCylLoadPattern PatternByName(string patternName)
        {
            var listPatterns = new List<HCylLoadPattern>(Patterns);
            var pattern = listPatterns.Find(p => p.Name.ToLower() == patternName.ToLower());
            return pattern;
        }
        #endregion
        #region Non-Public Members
        protected double GetStackingLength(HCylLayout layout) => !layout.Swapped ? layout.StackingLength : layout.StackingWidth;
        protected double GetStackingWidth(HCylLayout layout) => !layout.Swapped ? layout.StackingWidth : layout.StackingLength;
        protected void AddPosition(HCylLayout layout, CylPosition pos)
        {
            Transform3D transfRot = Transform3D.Identity;
            if (layout.Swapped)
            {
                Matrix4D matRot = new Matrix4D(
                    0.0, -1.0, 0.0, 0.0
                    , 1.0, 0.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                Vector3D vTranslation = new Vector3D(layout.DimContainer.X, 0.0, 0.0);
                matRot.M14 = vTranslation[0];
                matRot.M24 = vTranslation[1];
                matRot.M34 = vTranslation[2];
                transfRot = new Transform3D(matRot);
            }
            layout.Positions.Add(pos.Transform(Transform3D.Translation(layout.Offset) * transfRot));
        }
        #endregion
    }
}
