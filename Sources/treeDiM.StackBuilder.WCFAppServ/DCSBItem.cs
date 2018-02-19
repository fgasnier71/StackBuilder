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
    public enum DCSBTypeEnum
    { 
        [EnumMember]
        TPallet,
        [EnumMember]
        TPalletCorner,
        [EnumMember]
        TPalletCap,
        [EnumMember]
        TPalletFilm,
        [EnumMember]
        TInterlayer,
        [EnumMember]
        TCase,
        [EnumMember]
        TBundle,
        [EnumMember]
        TCylinder,
        [EnumMember]
        TTruck
    }

    [DataContract]
    public class DCSBItem
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int UnitSystem { get; set; }
        [DataMember]
        public bool AutoInsert { get; set; }
    }
}