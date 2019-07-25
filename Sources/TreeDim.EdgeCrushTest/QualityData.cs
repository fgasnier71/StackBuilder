#region Using directives
using System;
#endregion

namespace treeDiM.EdgeCrushTest
{
    #region QualityData class
    public class QualityData : ICloneable
    {
        #region Constructor
        public QualityData(QualityData data)
        {
            ID = data.ID;
            Name = data.Name;
            Profile = data.Profile;
            Thickness = data.Thickness;
            ECT = data.ECT;
            RigidityDX = data.RigidityDX;
            RigidityDY = data.RigidityDY;
        }
        public QualityData(int id, string name, string profile, double thickness, double ect, double rigidityDX, double rigidityDY)
        {
            ID = id;
            Name = name;
            Profile = profile;
            Thickness = thickness;
            ECT = ect;
            RigidityDX = rigidityDX;
            RigidityDY = rigidityDY;
        }
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Creates an exact copy of this <see cref="QualityData"/> object.
        /// </summary>
        /// <returns>The <see cref="QualityData"/> object this method creates, cast as an object.</returns>
        object ICloneable.Clone()
        {
            return new QualityData(this);
        }
        /// <summary>
        /// Creates an exact copy of this <see cref="QualityData"/> object.
        /// </summary>
        /// <returns>The <see cref="QualityData"/> object this method creates.</returns>
        public QualityData Clone()
        {
            return new QualityData(this);
        }
        #endregion

        #region Object overrides
        public override string ToString()
        {
            return Name + " - " + Thickness.ToString() + " mm";
        }
        #endregion

        #region Public properties
        public int ID { get; private set; }
        public string Name { get; set; }
        public double Thickness { get; set; }
        public double ECT { get; set; }
        public double RigidityDX { get; set; }
        public double RigidityDY { get; set; }
        public string Profile { get; set; }
        #endregion
    }
    #endregion
}
