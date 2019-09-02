#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Reporting
{
    public class Material
    {
        public string Name { get; set; }
        public string Profile { get; set; }
        public double Thickness { get; set; }
        public double ECT { get; set; }
        public double RigidityDX { get; set; }
        public double RigidityDY { get; set; }
    };



    public class ReportDataPackStress
    {
        // Case
        public BoxProperties Box { get; set; }
        // Material
        public Material Mat { get; set; }
        // 
        public enum McKeeFormulaType { MCKEE_CLASSIC, MCKEE_IMPROVED };
        public McKeeFormulaType FormulaType;
    }
}
