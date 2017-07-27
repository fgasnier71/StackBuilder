using System;
using System.Text;

namespace treeDiM.StackBuilder.Engine
{
    internal class PrimeMultiple
    {
        public PrimeMultiple(int iPrime, int iMultiple)
        {
            _iPrime = iPrime; _iMultiple = iMultiple;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("({0}, {1})", _iPrime, _iMultiple);
            return sb.ToString(); ;
        }

        public int _iPrime;
        public int _iMultiple;
    }
}
