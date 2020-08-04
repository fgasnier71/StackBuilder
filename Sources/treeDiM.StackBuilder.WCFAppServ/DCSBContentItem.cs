#region Using directives
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFAppServ
{
    [DataContract]
    public class DCSBContentItem
    {
        [DataMember]
        public DCSBCase Case;
        [DataMember]
        public uint Number;
        [DataMember]
        public DCSBBool3 Orientation { get; set; }
    }
}