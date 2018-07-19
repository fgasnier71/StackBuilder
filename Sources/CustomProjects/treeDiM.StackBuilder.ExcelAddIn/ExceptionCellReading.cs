#region Using directives
using System;
using System.Text;
#endregion

namespace treeDiM.StackBuilder.ExcelAddIn
{
    internal class ExceptionCellReading : Exception
    {
        public ExceptionCellReading(string vName, string cellName, string sMessage)
            : base(sMessage)
        {
            VName = vName;
            CellName = cellName;
        }
        public string VName { get; set; }
        public string CellName { get; set; }
        public override string Message { get { return string.Format("{0} expected in cell {1}", VName, CellName); } }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(Message);
            sb.Append(base.ToString());
            return sb.ToString();
        }
    }
}