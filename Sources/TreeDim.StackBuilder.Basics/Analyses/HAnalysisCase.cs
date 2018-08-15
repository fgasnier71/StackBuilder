#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class HAnalysisCase : HAnalysis
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
        public override Vector3D Offset(int index)
        {
            BoxProperties bProperties = _containers[index] as BoxProperties;
            return bProperties.OuterDimensions - bProperties.InsideDimensions;
        }
        #endregion

    }
}
