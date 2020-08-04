#region Using directives
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFAppServ
{
    [DataContract]
    public class DCSBHConstraintSet
    {
        [DataMember]
        public DCSBDim2D Overhang { get; set; }
        [DataMember]
        public DCSBConstraintDouble MaxHeight { get; set; }
        [DataMember]
        public DCSBConstraintDouble MaxWeight { get; set; }
    }
}