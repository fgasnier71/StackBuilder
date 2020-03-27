using System.Drawing;

namespace treeDiM.StackBuilder.Basics
{
    public class PackTray
    {
        public PackTray(double height, double weight, Color color)
        {
            Height = height;
            Color = color;
            Weight = weight;
            for (int i = 0; i < 3; ++i)
                _walls[i] = 2;
        }
        public Color Color { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double UnitThickness { get; set; }
        public double Thickness(int dir) => _walls[dir] * UnitThickness;
        public int Wall(int index) => _walls[index];
        public void SetNoWalls(int[] noWalls)
        {
            for (int i = 0; i < 3; ++i)
                _walls[i] = noWalls[i];
        }
        private int[] _walls = new int[3];
    }
}
