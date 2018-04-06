#region Using directives
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFAppServ
{
    [DataContract]
    public class DCSBConstraint
    {
        [DataMember]
        public bool Active { get; set; }
    }
    [DataContract]
    public class DCSBConstraintDouble : DCSBConstraint
    {
        [DataMember]
        public double Value_d { get; set; }
    }
    [DataContract]
    public class DCSBConstraintInt : DCSBConstraint
    {
        [DataMember]
        public int Value_i { get; set; }
    }
    [DataContract]
    public class DCSBConstraintSet 
    {
        [DataMember]
        public DCSBDim2D Overhang { get; set; }
        [DataMember]
        public DCSBBool3 Orientation { get; set; }
        [DataMember]
        public DCSBConstraintDouble MaxHeight { get; set; }
        [DataMember]
        public DCSBConstraintDouble MaxWeight { get; set; }
        [DataMember]
        public DCSBConstraintInt MaxNumber { get; set; }
        [DataMember]
        public bool AllowMultipleLayerOrientations { get; set; }
    }
}