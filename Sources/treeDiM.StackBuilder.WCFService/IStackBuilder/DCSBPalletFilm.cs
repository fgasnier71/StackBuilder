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
    public class DCSBPalletFilm : DCSBItem
    {
        [DataMember]
        public bool UseHatching { get; set; }
        [DataMember]
        public bool UseTransparency { get; set;}
        [DataMember]
        public double HatchingSpace { get; set; }
        [DataMember]
        public double HatchingAngle { get; set; }
        [DataMember]
        public int Color { get; set; }
    }
}