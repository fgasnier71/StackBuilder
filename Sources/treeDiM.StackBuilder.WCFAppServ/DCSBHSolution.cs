#region Using directives
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFAppServ
{
    [DataContract]
    public class DCSBHSolutionList
    { 
        [DataMember]
        public DCSBHSolution[] Solutions { get; set; }
        [DataMember]
        public string[] Errors { get; set; }
    };
    [DataContract]
    public class DCSBHSolution
    {
        [DataMember]
        public int SolIndex { get; set; }
        [DataMember]
        public int PalletCount { get; set; }
        [DataMember]
        public string Algorithm { get; set; }
    }

    [DataContract]
    public class DCSBHSolutionItem
    {
        [DataMember]
        public int SolIndex { get; set; }
        [DataMember]
        public int BinIndex { get; set; }
        [DataMember]
        public DCSBContentItem[] Content { get; set; }
        [DataMember]
        public double WeightTotal { get; set; }
        [DataMember]
        public double WeightLoad { get; set; }
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