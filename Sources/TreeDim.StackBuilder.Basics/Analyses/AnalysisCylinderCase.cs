using System;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisCylinderCase : AnalysisPackableCase
    {
        public AnalysisCylinderCase(
            Document doc,
            Packable packable,
            BoxProperties caseProperties,
            ConstraintSetCylinderContainer constraintSet)
            : base(doc, packable, caseProperties, constraintSet)
        {
        }
    }
}
