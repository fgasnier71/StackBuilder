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
    public class DCSBInterlayer : DCSBItem
    {
        [DataMember]
        public DCSBDim3D Dimensions { get; set; }
        [DataMember]
        public double Weight { get; set; }
        [DataMember]
        public int Color { get; set; }
    }
}