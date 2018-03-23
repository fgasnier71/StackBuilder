#region Using directives
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFAppServ
{
    [DataContract]
    public class DCSBCase : DCSBItem
    {
        [DataMember]
        public DCSBDim3D DimensionsOuter { get; set; }
        [DataMember]
        public bool HasInnerDims { get; set; }
        [DataMember]
        public DCSBDim3D DimensionsInner { get; set; }
        [DataMember]
        public bool ShowTape { get; set; }
        [DataMember]
        public double TapeWidth { get; set; }
        [DataMember]
        public int TapeColor { get; set; }
        [DataMember]
        public double Weight { get; set; }
        [DataMember]
        public double? NetWeight { get; set; }
        [DataMember]
        public double? MaxWeight { get; set; }
        [DataMember]
        public int[] Colors { get; set; }
    }
}