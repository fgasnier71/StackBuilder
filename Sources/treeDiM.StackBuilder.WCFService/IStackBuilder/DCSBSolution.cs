#region Using directives
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFService
{
    [DataContract]
    public class DCSBSolution
    {
        [DataMember]
        public int LayerCount { get; set; }
        [DataMember]
        public int CaseCount { get; set; }
        [DataMember]
        public int InterlayerCount { get; set; }
        [DataMember]
        public double WeightTotal { get; set; }
        [DataMember]
        public double WeightLoad { get; set; }
        [DataMember]
        public double? NetWeight { get; set; }
        [DataMember]
        public double Efficiency { get; set; }
        [DataMember]
        public DCSBDim3D BBoxTotal { get; set; }
        [DataMember]
        public DCSBDim3D BBoxLoad { get; set; }
        [DataMember]
        public DCCompFileOutput OutFile { get; set; }
        [DataMember]
        public string[] Errors { get; set; }
    }
}