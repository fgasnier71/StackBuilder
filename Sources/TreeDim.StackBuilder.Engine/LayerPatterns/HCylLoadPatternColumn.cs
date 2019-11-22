#region Using directives
using System;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    internal class HCylLoadPatternColumn : HCylLoadPattern
    {
        public override string Name => "Column";
        public override void Generate(HCylLayout layout, OptInt maxCount, double actualLength, double actualWidth, double maxHeight)
        {
            layout.Clear();

            double palletLength = GetStackingLength(layout);
            double palletWidth = GetStackingWidth(layout);
            double radius = layout.CylRadius;
            double diameter = layout.CylDiameter;
            double length = layout.CylLength;

            int sizeX = Convert.ToInt32(Math.Floor(palletLength / layout.CylLength));
            int sizeY = Convert.ToInt32(Math.Floor(palletWidth / layout.CylDiameter));

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);
            double offsetZ = layout.OffsetZ + radius;

            int iLayer = 0;
            while (true)
            {
                // max height reached ?
                if ((iLayer + 1) * diameter > maxHeight)
                {
                    layout.LimitReached = Limit.MAXHEIGHTREACHED;
                    return;
                }

                for (int j = 0; j < sizeY; ++j)
                {
                    for (int i = 0; i < sizeX; ++i)
                    {
                        AddPosition(
                            layout
                            , new CylPosition(
                                new Vector3D(
                                    offsetX + i * length - 0.5 * length
                                    , offsetY + radius + j * diameter
                                    , offsetZ + iLayer * (diameter + layout.RowSpacing))
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
                ++iLayer;
            }
        }
    }
}
