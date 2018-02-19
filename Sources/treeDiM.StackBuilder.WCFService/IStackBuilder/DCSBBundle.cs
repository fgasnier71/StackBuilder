#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFService
{
    [DataContract]
    public class DCSBBundle : DCSBItem
    {
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public DCSBDim3D DimensionsUnit { get; set; }
        [DataMember]
        public double UnitWeight { get; set; }
        [DataMember]
        public int Color { get; set; }
    }
}