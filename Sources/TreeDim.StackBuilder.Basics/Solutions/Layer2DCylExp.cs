#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class Layer2DCylExp : Layer2DCylImp
    {
        public Layer2DCylExp(double radius, double height, Vector2D dimContainer)
            : base(radius, height, dimContainer, false)
        { 
        }
    }
}
