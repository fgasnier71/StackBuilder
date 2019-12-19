#region Using directives
using System;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    class HCylLoadPatternPyramid : HCylLoadPattern
    {
        public override string Name => "Default";
        public override void Generate(HCylLayout layout, OptInt maxCount, double actualLength, double actualWidth, double maxHeight)
        {
            layout.Clear();

            double palletLength = GetStackingLength(layout);
            double palletWidth = GetStackingWidth(layout);
            double length = layout.CylLength;
            double radius = layout.CylRadius;
            double diameter = 2.0 * layout.CylRadius;

            int sizeX = Convert.ToInt32(Math.Floor(palletLength / layout.CylLength));
            int sizeY = Convert.ToInt32(Math.Floor(palletWidth / (2.0 * layout.CylRadius)));

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);
            double offsetZ = layout.OffsetZ + radius;

            for (int iLayer = 0; iLayer < sizeY; ++iLayer)
            {
                // max height reached ?
                if (maxHeight > 0 && offsetZ + radius * (1.0 + iLayer * Math.Sqrt(3.0)) > maxHeight)
                {
                    layout.LimitReached = Limit.MAXHEIGHTREACHED;
                    return;
                }
                for (int j = 0; j < sizeY-iLayer; ++j)
                {
                    for (int i = 0; i < sizeX; ++i)
                    {
                        AddPosition(
                            layout
                            , new CylPosition(
                                new Vector3D(
                                    offsetX + i * length - 0.5 * length
                                    , offsetY + (1 + iLayer) * radius + j * diameter
                                    , offsetZ + iLayer * radius * Math.Sqrt(3.0))
                                , HalfAxis.HAxis.AXIS_X_P)
                            );
                        // max number of items reached ?
                        if (maxCount.Activated && layout.Positions.Count >= maxCount.Value)
                        {
                            layout.LimitReached = Limit.MAXNUMBERREACHED;
                            return;
                        }
                    }
                }
            }
            layout.LimitReached = Limit.MAXHEIGHTREACHED;
        }
    }
}
