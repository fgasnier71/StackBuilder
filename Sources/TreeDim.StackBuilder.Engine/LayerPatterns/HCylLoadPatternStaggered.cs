#region Using directives
using System;

using Sharp3D.Math.Core;
using treeDiM.Basics;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    class HCylLoadPatternStaggered : HCylLoadPattern
    {
        public override string Name => "Staggered";
        public override bool CanBeSwapped => true;
        public override void Generate(HCylLayout layout, OptInt maxCount, double actualLength, double actualWidth, double maxHeight)
        {
            layout.Clear();

            double palletLength = GetStackingLength(layout);
            double palletWidth = GetStackingWidth(layout);
            double length = layout.CylLength;
            double radius = layout.CylRadius;
            double diameter = layout.CylDiameter;

            int sizeX = Convert.ToInt32( Math.Floor(palletLength / layout.CylLength) );
            int sizeY = Convert.ToInt32(Math.Floor(palletWidth / diameter));

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);
            double offsetZ = radius + layout.OffsetZ;

            int iLayer = 0;
            while (true)
            {
                if ((iLayer + 1) * diameter >= maxHeight)
                {
                    layout.LimitReached = Limit.MAXHEIGHTREACHED;
                    return;
                }
                for (int j = 0; j < sizeY - (iLayer % 2); ++j)
                {
                    for (int i = 0; i < sizeX; ++i)
                    {
                        AddPosition(
                            layout
                            , new CylPosition(
                                new Vector3D(
                                    offsetX + i * length - 0.5 * length
                                    , offsetY  + radius + (iLayer % 2) * radius + j * diameter
                                    , offsetZ + iLayer * radius * Math.Sqrt(3.0))
                                , HalfAxis.HAxis.AXIS_X_P)
                            );
                        if (maxCount.Activated  && layout.Positions.Count >= maxCount.Value)
                        {
                            layout.LimitReached = Limit.MAXNUMBERREACHED;
                            return;
                        }
                    }
                }
                ++iLayer;
            };
        }
    }
}
