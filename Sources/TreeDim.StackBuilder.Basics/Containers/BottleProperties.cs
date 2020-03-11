#region Using directives
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class BottleProperties : RevSolidProperties
    {
        #region Constructors
        public BottleProperties(Document document)
            : base(document)
        { 
        }
        public BottleProperties(Document document, string name, string description,
            List<Vector2D> profile, double weight, Color color)
            : base(document, name, description)
        {
            Profile = profile;
            Color = color;
            SetWeight(weight);
        }
        #endregion

        #region Specific public properties
        public override double RadiusOuter { get => 0.5 * Profile.Max(p => p.Y); set {} }
        public override double Height { get => Profile.Max(p => p.X); set { } }
        public Color Color { get; set; } = Color.DeepSkyBlue;
        public List<Vector2D> Profile { get; set; } = new List<Vector2D>();
        #endregion

        #region Override PackableNamed
        public override double Volume
        {
            get
            {
                double vol = 0;
                for (int i = 0; i < Profile.Count - 1; ++i)
                {
                    double h = Profile[i + 1].X - Profile[i].X;
                    double r0 = 0.5 * Profile[i].Y;
                    double r1 = 0.5 * Profile[i + 1].Y;
                    vol += 1.0 / 3.0 * Math.PI * (r0*r0 + r0 * r1 + r1 *r1) * h;
                }
                return vol;
            }
        }
        public override Vector3D OuterDimensions => new Vector3D(2.0*RadiusOuter, 2.0*RadiusOuter, Height);
        public override bool IsBrick => false;
        protected override string TypeName => Properties.Resources.ID_NAMEBOTTLE;
        #endregion

        #region Object override
        public override string ToString()
        {
            var sBuilder = new StringBuilder();
            return sBuilder.ToString();
        }
        #endregion

        #region Data members
        #endregion
    }
}
