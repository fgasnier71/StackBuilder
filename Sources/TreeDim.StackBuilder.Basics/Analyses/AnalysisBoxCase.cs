using System;
using System.Collections.Generic;
using System.Linq;

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisBoxCase : AnalysisPackableCase
    {
        public AnalysisBoxCase(
            Document doc,
            Packable packable,
            BoxProperties caseProperties,
            ConstraintSetBoxCase constraintSet)
            : base(doc, packable, caseProperties, constraintSet)
        {
        }
    }
}
