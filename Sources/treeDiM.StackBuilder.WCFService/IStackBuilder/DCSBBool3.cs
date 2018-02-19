#region Using directives
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFService
{
    [DataContract]
    public class DCSBBool3
    {
        public DCSBBool3()
        {
            X = true; Y = true; Z = true;
        }
        public DCSBBool3(bool x, bool y, bool z)
        {
            X = x; Y = y; Z = z;
        }
        [DataMember]
        public bool X { get; set; }
        [DataMember]
        public bool Y { get; set; }
        [DataMember]
        public bool Z { get; set; }
    }
}