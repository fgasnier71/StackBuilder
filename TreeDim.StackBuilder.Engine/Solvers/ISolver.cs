#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine
{
    interface ISolver
    {
        List<Analysis> BuildAnalyses(ConstraintSetAbstract constraintSet);
    }
}
