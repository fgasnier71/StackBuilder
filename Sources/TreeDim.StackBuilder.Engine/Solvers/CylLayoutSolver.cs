#region Using directives
using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    public class CylLayoutSolver : ILayoutSolver
    {
        public static List<HCylLayout> BuildLayout(
            Packable packable
            , Vector3D dimContainer
            , double offsetZ
            , ConstraintSetAbstract constraintSet)
        {
            var layouts = new List<HCylLayout>();
            if (packable is CylinderProperties cylProperties)
            {
                // loop through patterns
                foreach (var pattern in HCylLoadPattern.Patterns)
                {
                    // loop through directions
                    for (int iDir = 0; iDir < (pattern.CanBeSwapped ? 2 : 1); ++iDir)
                    {
                        var layout = new HCylLayout(
                            cylProperties.Diameter
                            , cylProperties.Height
                            , dimContainer
                            , pattern.Name
                            , iDir == 1)
                        { OffsetZ = offsetZ };
                        pattern.GetDimensions(layout, constraintSet.OptMaxNumber, out double actualLength, out double actualWidth);
                        pattern.Generate(layout, constraintSet.OptMaxNumber, actualLength, actualWidth, constraintSet.OptMaxHeight.Value);
                        layouts.Add(layout);
                    }
                }
            }
            return layouts;
        }

        public static HCylLayout BuildLayout(Packable packable
            , Vector3D dimContainer
            , ConstraintSetAbstract constraintSet
            , string patternName, bool swapped)
        {
            if (!(packable is CylinderProperties cylProperties))
                throw new Exception("Invalid type!");

            // get pattern by name
            var pattern = HCylLoadPattern.PatternByName(patternName);
            if (null == pattern) return null;

            var layout = new HCylLayout(
                cylProperties.Diameter
                , cylProperties.Height
                , dimContainer
                , pattern.Name
                , swapped);
            pattern.GetDimensions(layout, constraintSet.OptMaxNumber, out double actualLength, out double actualWidth);
            pattern.Generate(layout, constraintSet.OptMaxNumber, actualLength, actualWidth, constraintSet.OptMaxHeight.Value);
            return layout;
        }

        public HCylLayout BuildLayoutNonStatic(Packable packable
            , Vector3D dimContainer
            , ConstraintSetAbstract constraintSet
            , string patternName
            , bool swapped)
        {
            return CylLayoutSolver.BuildLayout(packable, dimContainer, constraintSet, patternName, swapped);
        }
    }
}
