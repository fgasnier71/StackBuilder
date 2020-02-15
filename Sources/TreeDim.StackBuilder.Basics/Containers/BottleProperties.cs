#region Using directives
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class BottleProperties : PackableNamed
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
        public double RadiusOuter => 0.0;
        public double Height => 0.0;
        public Color Color { get; set; } = Color.DeepSkyBlue;
        public List<Vector2D> Profile { get; set; } = new List<Vector2D>();
        #endregion

        #region Override PackableNamed
        public override double Volume => 0.0;
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
