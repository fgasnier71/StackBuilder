#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class HAnalysisTruck : AnalysisHetero
    {
        #region Constructor
        public HAnalysisTruck(Document doc) : base(doc)
        {
            ConstraintSet = new HConstraintSetTruck();
        }
        #endregion

        #region Specific properties
        public TruckProperties Truck { set { _containers.Clear(); _containers.Add(value); } }
        #endregion

        #region override HAnalysis
        public override BBox3D AdditionalBoudingBox(int index)
        {
            return index < _containers.Count && _containers[index] is TruckProperties truckProperties
                ? truckProperties.BoundingBox
                : BBox3D.Initial;
        }
        public override Vector3D DimContainer(int index)
        {
            if (index < _containers.Count && _containers[index] is TruckProperties truckProperties)
                return new Vector3D(truckProperties.Length, truckProperties.Width, truckProperties.Height);
            else
                return Vector3D.Zero;
        }
        public override double WeightContainer(int index) => 0.0;
        public override Vector3D Offset(int index)
        {
            return Vector3D.Zero;
        }
        #endregion
    }
}
