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
    public class DCSBPalletCorner : DCSBItem
    {
        [DataMember]
        public double Length { get; set; }
        [DataMember]
        public double Width { get; set; }
        [DataMember]
        public double Thickness { get; set;}
        [DataMember]
        public double Weight { get; set; }
        [DataMember]
        public int Color { get; set; }
    }
}