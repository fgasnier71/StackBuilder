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
    public class DCSBCylinder : DCSBItem
    {
        [DataMember]
        public double Height { get; set; }
        [DataMember]
        public double RadiusOuter { get; set; }
        [DataMember]
        public double RadiusInner { get; set; }
        [DataMember]
        public int ColorTop { get; set; }
        [DataMember]
        public int ColorOuter { get; set; }
        [DataMember]
        public int ColorInner { get; set; }
        [DataMember]
        public double Weight { get; set; }
        [DataMember]
        public double? NetWeight { get; set; }
    }
} // PLMPack