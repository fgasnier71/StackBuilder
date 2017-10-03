using System;
using System.Text;

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
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0} expected in cell {1}", VName, CellName);
        sb.Append(base.ToString());
        return sb.ToString();
    }
}