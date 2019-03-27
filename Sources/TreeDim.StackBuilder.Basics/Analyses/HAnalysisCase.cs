#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class HAnalysisCase : AnalysisHetero
    {
        #region Constructor
        public HAnalysisCase(Document doc) : base(doc)
        {
        }
        #endregion

        #region Override HAnalysis
        public override Vector3D DimContainer(int index)
        {
            BoxProperties bProperties = _containers[index] as BoxProperties;
            return bProperties.InsideDimensions;
        }
        public override double WeightContainer(int index)
        {
            return index < _containers.Count && _containers[index] is BoxProperties boxProperties
                ? boxProperties.Weight : 0.0;
        }
        public override Vector3D Offset(int index)
        {
            BoxProperties bProperties = _containers[index] as BoxProperties;
            return bProperties.OuterDimensions - bProperties.InsideDimensions;
        }
        public override BBox3D AdditionalBoudingBox(int index)
        {
            BoxProperties bProperties = _containers[index] as BoxProperties;
            return new BBox3D(Vector3D.Zero, bProperties.OuterDimensions);
        }
        #endregion
    }
}
