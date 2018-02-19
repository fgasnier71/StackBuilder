#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFAppServ
{
    [DataContract]
    public class DCSBLayerDescriptor
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string PatternName { get; set; }
        [DataMember]
        public int AxisDir { get; set; }
        [DataMember]
        public bool Swapped { get; set; }
    }
    [DataContract]
    public class DCSBSolutionItem
    {
        [DataMember]
        public int LayerDescId { get; set; }
        [DataMember]
        public int LayerIndex { get; set; }
        [DataMember]
        public bool SymmetryX { get; set; }
        [DataMember]
        public bool SymmetryY { get; set; }
    }
    [DataContract]
    public class DCSBPalletLayouts
    {
        [DataMember]
        public int PalletID { get; set; }
        [DataMember]
        public int CaseID { get; set; }
        [DataMember]
        public double OverhangX {get; set;}
        [DataMember]
        public double OverhangY {get; set;}
        [DataMember]
        public double MaximumHeight {get; set;}
        [DataMember]
        public DCSBLayerDescriptor[] LayerDescriptors {get; set;}
        [DataMember]
        public DCSBSolutionItem[] SolutionItems;
    }
}