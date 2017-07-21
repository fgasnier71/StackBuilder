using System;
using System.Collections.Generic;
using System.Linq;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    interface ISolver
    {
        List<Analysis> BuildAnalyses(ConstraintSetAbstract constraintSet);
    }
}
