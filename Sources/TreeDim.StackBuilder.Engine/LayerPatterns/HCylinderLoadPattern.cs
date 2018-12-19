using System;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    internal abstract class HCylinderLoadPattern
    {
        protected HCylinderLoadPattern() { }

        public abstract string Name { get; }
        public abstract bool CanBeSwapped { get; }
        public bool Swapped { get; set; } = false;

        public abstract void Generate(CylLoad layer, int maxCount, double actualLength, double actualWidth, double maxHeight);

        public void AddPosition(CylLoad load, CylPosition pos)
        {
            Matrix4D matRot = Matrix4D.Identity;
            Vector3D vTranslation = Vector3D.Zero;

            if (Swapped)
            {
                matRot = new Matrix4D(
                    0.0, -1.0, 0.0, 0.0
                    , 1.0, 0.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                vTranslation = new Vector3D(load.PalletLength, 0.0, 0.0);

                matRot.M14 = vTranslation[0];
                matRot.M24 = vTranslation[1];
                matRot.M34 = vTranslation[2];
            }

            load.Add(pos.Transform(new Transform3D(matRot)));
        }

        public virtual void GetDimensions(CylLoad load, int maxCount, out double length, out double width)
        {
            length = 0.0; width = 0.0;
            // using XP direction
            int noX = Convert.ToInt32(Math.Floor(GetPalletLength(load) / load.CylinderLength));
            int noY = Convert.ToInt32(Math.Floor(GetPalletWidth(load) / (2.0 * load.CylinderRadius)));

            if (-1 != maxCount && maxCount < noX * (noY-1))
            {
                if (maxCount < noX)
                {
                    noX = maxCount;
                    noY = 1;
                }
                else
                    noY = maxCount / noX + 1;
            }
            length = noX * load.CylinderLength;
            width = 2.0 * noY * load.CylinderRadius;
        }

        #region Non-Public Members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(HCylinderLoadPattern));

        protected double GetPalletLength(CylLoad load)
        {
            if (!Swapped)
                return load.PalletLength;
            else
                return load.PalletWidth;
        }
        protected double GetPalletWidth(CylLoad load)
        {
            if (!Swapped)
                return load.PalletWidth;
            else
                return load.PalletLength;
        }
        #endregion
    }
}
