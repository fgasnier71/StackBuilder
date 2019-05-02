using System;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    class CylinderLayerPatternStaggered2 : LayerPatternCyl
    {
        public override string Name => "Staggered2";
        public override bool CanBeSwapped => true;
        public override bool GetLayerDimensions(ILayer2D layer, out double actualLength, out double actualWidth)
        {
            layer.Clear();
            Layer2DCyl layerCyl = layer as Layer2DCyl;
            ComputeRowNumberAndLength(layerCyl
                , out int number
                , out int firstRowLength, out int secondRowLength, out int rowNumber
                , out actualLength, out actualWidth);
            return (firstRowLength > 0) && (secondRowLength > 0) && (rowNumber > 0);
        }
        public override void GenerateLayer(ILayer2D layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            double length = GetPalletLength(layer);
            double width = GetPalletWidth(layer);
            double diameter = GetDiameter(layer);
            double radius = 0.5 * diameter;

            Layer2DCyl layerCyl = layer as Layer2DCyl;
            if (!ComputeRowNumberAndLength(layerCyl
                , out int number
                , out int firstRowLength, out int secondRowLength, out int rowNumber
                , out actualLength, out actualWidth))
                return;

            double offsetX = 0.0; //0.5 * (length - actualLength);
            double offsetY = 0.5 * (width - actualWidth);

            if (length < diameter || width < diameter)
            {}
            else if (width < 2 * diameter)
            {
                double Y = width - diameter;
                double X = diameter * Math.Cos(Math.Asin(Y / diameter));
                double stepX = X;
                if (X <= 0.5 * diameter)
                    stepX = diameter;
                else
                    stepX = 2 * X;
                double xpos = 0.5 * diameter, ypos = width - 0.5 * diameter;
                Vector2D pLast = Vector2D.Zero;
                while (offsetX + xpos < length - 0.5 * diameter)
                {
                    Vector2D p0 = new Vector2D(offsetX + xpos, offsetY + ypos);
                    Vector2D p1 = new Vector2D(offsetX + xpos + X, offsetY + 0.5 * diameter);

                    AddPosition(layer, p0);
                    if (p1.X < length - 0.5 * diameter)
                        AddPosition(layer, p1);
                    pLast = 0.5 * (p0 + p1) + 0.5 * Math.Sqrt(3) * new Vector2D(Y, X);
                    xpos += stepX;
                }

                if (pLast.X <= length - 0.5 * diameter && pLast.Y < width - 0.5 * diameter)
                    AddPosition(layer, pLast);
            }
            else if (width < 3 * diameter)
            {
                double Y = width - 2 * diameter;
                double X = 0.0;
                double ydiff = 0.0;
                if (Y >= diameter / 2)
                {
                    Y = (width - diameter) / 3;
                    X = diameter * Math.Cos(Math.Asin(Y / diameter));
                    ydiff = -2.0 * Y;
                }
                else
                {
                    Y = width - 2 * diameter;
                    X = diameter * Math.Cos(Math.Asin(Y / diameter));
                    ydiff = -diameter;
                }

                // initialize positions
                double xpos = 0.5 * diameter, ypos = 0.0;
                int index = 0;
                Vector2D pLast = Vector2D.Zero;
                // add positions until end is reached
                while (xpos < length - 0.5 * diameter)
                {
                    ypos = width - 0.5 * diameter - ((index % 2 == 1) ? Y : 0.0);

                    AddPosition(layer, new Vector2D(offsetX + xpos, offsetY + ypos));
                    AddPosition(layer, new Vector2D(offsetX + xpos, offsetY + ypos + ydiff));

                    pLast = new Vector2D(offsetX + xpos + 0.5 * Math.Sqrt(3.0) * diameter, offsetY + ypos + 0.5 * ydiff);

                    xpos += X;
                    ++index;
                }
                if (pLast.X <= length - 0.5 * diameter)
                    AddPosition(layer, pLast);

            }
            else
            {
                for (int i = 0; i < rowNumber; ++i)
                {
                    double y = (offsetY + radius) + i * radius * Math.Sqrt(3.0);
                    for (int j = 0; j < (i % 2 == 0 ? firstRowLength : secondRowLength); ++j)
                        AddPosition(layer, new Vector2D(offsetX + ((i % 2 == 0) ? 0.0 : radius) + j * 2.0 * radius + radius, y));
                }
            }
        }

        #region Non-public members
        private bool ComputeRowNumberAndLength(Layer2DCyl layer
            , out int number
            , out int firstRowLength, out int secondRowLength, out int rowNumber
            , out double actualLength, out double actualWidth)
        {
            double length = GetPalletLength(layer);
            double width = GetPalletWidth(layer);
            double diameter = GetDiameter(layer);

            number = 0; rowNumber = 0;
            firstRowLength = 0; secondRowLength = 0;
            actualLength = 0.0; actualWidth = 0.0;

            // sanity check
            if (length < diameter || width < diameter)
            {
                number = 0; rowNumber = 0;
                firstRowLength = 0; secondRowLength = 0;
                actualLength = 0.0; actualWidth = 0.0;
                return false;
            }
            else if (width < 2 * diameter)
            {
                double Y = width - diameter;
                double X = diameter * Math.Cos(Math.Asin(Y / diameter));

                if (X <= diameter / 2.0)
                {
                    int noCols = (int)(Math.Floor((length - diameter - X)) / diameter) + 1;
                    number = 2 * (int)(Math.Floor((length - diameter - X)) / diameter) + 2;
                    bool lastRoll = length - 0.5 * diameter * number - diameter * Math.Cos((Math.PI / 6.0) - Math.Asin(width - diameter / diameter)) > 0.0;
                    number += lastRoll ? 1 : 0;
                    actualLength = noCols * diameter + X + (lastRoll ? diameter * Math.Cos((Math.PI / 6.0) + Math.Atan(X / Y)) : 0.0);

                    firstRowLength = secondRowLength = noCols;
                }
                else
                {
                    number = (int)Math.Floor((length-diameter) / X) + 1;
                    actualLength = (number - 1) * X + diameter;

                    firstRowLength = number / 2;
                    secondRowLength = number / 2 + number % 2;
                }
                actualWidth = width;
                rowNumber = 2;
            }
            else if (width < 3.0 * diameter)
            {
                double Y = width - 2.0 * diameter;
                if (Y >= diameter / 2.0)
                {
                    Y = (width - diameter) / 3.0;
                    double X = diameter * Math.Cos(Math.Asin(Y / diameter));
                    number = 2 * (int)Math.Floor(length / X);
                    actualLength = ((number / 2) - 1) * X + diameter;

                    firstRowLength = number / 4;
                    secondRowLength = number / 4 + (number / 2) % 2;
                }
                else
                {
                    Y = width - 2.0 * diameter;
                    double X = diameter * Math.Cos(Math.Asin(Y / diameter));
                    int noCols = (int)Math.Floor(length / X);
                    number = 2 * (int)Math.Floor(length / X);
                    bool lastRoll = length - (X * number / 2.0) - diameter * Math.Cos(Math.PI / 6.0) > 0;
                    number += lastRoll ? 1 : 0;
                    actualLength = (noCols - 1) * X + diameter * (1.0 + Math.Asin(Math.PI / 6.0));

                    firstRowLength = noCols;
                    secondRowLength = noCols + number % 2;
                }
                rowNumber = 4;
                actualWidth = width;
            }
            else
            {
                // first row number
                firstRowLength = (int)Math.Floor(length / diameter);
                // second row
                if ((firstRowLength + 0.5) * diameter < length)
                {
                    secondRowLength = firstRowLength;
                    actualLength = (firstRowLength + 0.5) * diameter;
                }
                else
                {
                    secondRowLength = firstRowLength - 1;
                    actualLength = firstRowLength * diameter;
                }
                // numbers of rows
                rowNumber = (int)Math.Floor(1 + (2.0 * width / diameter - 2.0) / Math.Sqrt(3.0));
                actualWidth = (2.0 + (rowNumber - 1) * Math.Sqrt(3.0)) * 0.5 * diameter;
            }
            return true;
        }
        #endregion
    }
}
// X <= OD / 2 AND W / OD < 2
// Y = W - OD
// X = OD.cos(arcsin(Y/OD)) = OD.cos(arcsin((W-OD)/OD))
// NBstack = (2.rounddown((L-OD-X) / OD)) + 2 = (2.rounddown((L-OD-(OD.cos(arcsin((W-OD)/OD)))) / OD)) + 2
// Last roll(y/n): L - (OD.NB/2) - OD.cos(30°-arcsin((W-OD)/OD) >0

// X > OD / 2 AND W / OD < 2
// Y = W - OD
// X = OD.cos(arcsin(Y/OD)) = OD.cos(arcsin((W-OD)/OD)) 
// NBstack = rounddown(L / X) = rounddown(L / (OD.cos(arcsin((W-OD)/OD))))

// Y >= OD / 2 AND W / OD >= 2
// Y = (W - OD) / 3
// X = OD.cos(arcsin(Y/OD)) = OD.cos(arcsin((W-OD)/(3.OD))) 
// NBstack = 2.rounddown(L / X) = 2.rounddown(L / (OD.cos(arcsin((W-OD)/(3.OD)))))

// Y < OD / 2 AND W / OD >= 2
// X = OD.cos(arcsin(Y/OD)) = OD.cos(arcsin((W-2.OD)/OD)) 
// NBstack = 2.rounddown(L / X) = 2.rounddown(L / (OD.cos(arcsin((W-2.OD)/OD)))))
// Last roll(y/n): L - (X.NB/2) - OD.cos(30°) >0
















