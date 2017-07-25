using System;
using System.Drawing;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class PackWrapper
    {
        public enum WType
        {
            WT_POLYETHILENE
            , WT_PAPER
            , WT_CARDBOARD
            , WT_TRAY
        }
        protected PackWrapper(double thickness, double weight, Color color) { _thickness = thickness; Weight = weight; Color = color; }
        public double Weight { get; set; }
        public Color Color { get; set; }
        public virtual bool Transparent => false;

        public abstract WType Type { get; }
        public virtual double Thickness(int dir) => _thickness;
        public virtual double UnitThickness => _thickness;
        // data members
        protected double _thickness;
    }
}
