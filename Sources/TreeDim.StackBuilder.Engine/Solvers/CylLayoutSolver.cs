#region Using directives
using System;
using System.Collections.Generic;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    public class CylLayoutSolver : ILayoutSolver
    {
        public static List<HCylLayout> BuildLayouts(
            Packable packable
            , IContainer container
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
                            , container.GetStackingDimensions(constraintSet)
                            , pattern.Name
                            , iDir == 1)
                        { OffsetZ = container.OffsetZ };

                        pattern.GetDimensions(layout, constraintSet.OptGlobMaxNumber(packable), out double actualLength, out double actualWidth);
                        pattern.Generate(layout, constraintSet.OptGlobMaxNumber(packable), actualLength, actualWidth, constraintSet.OptMaxHeight.Value);
                        if (layout.Positions.Count > 0)
                            layouts.Add(layout);
                    }
                }
            }
            layouts.Sort(new HCylLayoutComparer());
            return layouts;
        }

        public static HCylLayout BuildLayout(Packable packable
            , IContainer container
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
                , container.GetStackingDimensions(constraintSet)
                , pattern.Name
                , swapped)
            {
                OffsetZ = container.OffsetZ
            };
            pattern.GetDimensions(layout, constraintSet.OptGlobMaxNumber(packable), out double actualLength, out double actualWidth);
            pattern.Generate(layout, constraintSet.OptGlobMaxNumber(packable), actualLength, actualWidth, constraintSet.OptMaxHeight.Value);
            return layout;
        }

        public HCylLayout BuildLayoutNonStatic(Packable packable
            , IContainer container
            , ConstraintSetAbstract constraintSet
            , string patternName
            , bool swapped)
        {
            return BuildLayout(packable, container, constraintSet, patternName, swapped);
        }
    }
}
