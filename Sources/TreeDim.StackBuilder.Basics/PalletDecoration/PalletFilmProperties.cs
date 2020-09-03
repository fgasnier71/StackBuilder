#region Using directives
using System.Drawing;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class PalletFilmProperties : ItemBaseNamed
    {
        #region Constructors
        public PalletFilmProperties(Document doc)
            : base(doc)
        { 
        }

        public PalletFilmProperties(Document doc,
            string name, string description,
            bool useTransparency,
            bool useHatching, double hatchSpacing, double hatchAngle,
            double weight, Color color)
            : base(doc, name, description)
        {
            Weight = weight;
            UseTransparency = useTransparency;
            UseHatching = useHatching;
            HatchSpacing = hatchSpacing;
            HatchAngle = hatchAngle;
            Color = color;
        }
        #endregion

        #region Public properties
        public double Weight { get; set; } = 0.0;
        public bool UseTransparency { get; set; } = true;
        public bool UseHatching { get; set; } = true;
        public double HatchSpacing { get; set; } = 100.0;
        public double HatchAngle { get; set; } = 45.0;
        public Color Color { get; set; } = Color.LightBlue;
        #endregion
    }
}
