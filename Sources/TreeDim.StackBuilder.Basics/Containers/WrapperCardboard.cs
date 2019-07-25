using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.Basics;

namespace treeDiM.StackBuilder.Basics
{
    public class WrapperCardboard : PackWrapper
    {
        public WrapperCardboard(double thickness, double weight, Color color)
            : base(thickness, weight, color)
        {
            for (int i = 0; i < 3; ++i)
                _walls[i] = 2;
        }

        public void SetNoWalls(int noWallX, int noWallY, int noWallZ)
        {
            _walls[0] = noWallX;
            _walls[1] = noWallY;
            _walls[2] = noWallZ;
        }

        public void SetNoWalls(int[] noWalls)
        {
            for (int i = 0; i < 3; ++i)
                _walls[i] = noWalls[i];
        }

        public int Wall(int index) => _walls[index];

        public override PackWrapper.WType Type => PackWrapper.WType.WT_CARDBOARD;

        public override double Thickness(int dir) => _walls[dir] * _thickness;

        public static double EstimateWeight(
            BoxProperties boxProperties, PackArrangement arrangement, HalfAxis.HAxis orientation
            , int[] noWalls, double thickness, double surfacicMass)
        {
            double length = 0.0, width = 0.0, height = 0.0;
            PackProperties.GetDimensions(boxProperties, orientation, arrangement, ref length, ref width, ref height);
            Vector3D vDimensions = new Vector3D(
                length + noWalls[0] * thickness
                , width + noWalls[1] * thickness
                , height + noWalls[2] * thickness);

            double area = (noWalls[0] * vDimensions.Y * vDimensions.Z
                + noWalls[1] * vDimensions.X * vDimensions.Z
                + noWalls[2] * vDimensions.X * vDimensions.Y) * UnitsManager.FactorSquareLengthToArea;
            return area * surfacicMass;
        }

        private int[] _walls = new int[3];
    }
}
