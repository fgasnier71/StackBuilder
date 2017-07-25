using System;
using System.Collections.Generic;
using System.Linq;

using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Engine
{
    public abstract class Solver
    {
        protected Solver() { }
        public abstract Solution BuildSolution();
    }
}
