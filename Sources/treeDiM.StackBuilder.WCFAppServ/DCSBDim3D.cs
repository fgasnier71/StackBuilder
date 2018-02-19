#region Using directives
using System.Runtime.Serialization;
#endregion

namespace treeDiM.StackBuilder.WCFAppServ
{
    [DataContract]
    public class DCSBDim2D
    {
        public DCSBDim2D(double m0, double m1)
        { M0 = m0; M1 = m1; }
        [DataMember]
        public double M0 { get; set; }
        [DataMember]
        public double M1 { get; set; }
    }
    [DataContract]
    public class DCSBDim3D
    {
        public DCSBDim3D(double m0, double m1, double m2)
        { M0 = m0; M1 = m1; M2 = m2; }
        [DataMember]
        public double M0 { get; set; }
        [DataMember]
        public double M1 { get; set; }
        [DataMember]
        public double M2 { get; set; }
    }
}