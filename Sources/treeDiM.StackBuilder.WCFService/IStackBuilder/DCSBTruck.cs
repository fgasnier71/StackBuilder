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