#region Using directives
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFAppServ
{
    [DataContract]
    public class DCSBTruck : DCSBItem
    {
        [DataMember]
        public DCSBDim3D DimensionsInner { get; set; }
        [DataMember]
        public double AdmissibleLoad { get; set; }
        [DataMember]
        public int Color { get; set; }
    }
}