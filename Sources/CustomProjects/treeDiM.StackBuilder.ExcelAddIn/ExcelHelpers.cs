#region Using directives
using System;
using System.Windows.Forms;
using System.Linq;

using Excel = Microsoft.Office.Interop.Excel;
#endregion

namespace treeDiM.StackBuilder.ExcelAddIn
{
    internal class ExcelHelpers
    {
        public static double ReadDouble(string name, Excel.Worksheet worksheet, string cellName)
        {
            try
            {
                return worksheet.get_Range(cellName, cellName).Value;
            }
            catch (Exception ex)
            {
                throw new ExceptionCellReading(name, cellName, ex.Message);
            }
        }
        public static string ReadString(string name, Excel.Worksheet worksheet, string cellName)
        {
            try
            {
                return worksheet.get_Range(cellName, cellName).Value.ToString();
            }
            catch (Exception ex)
            {
                throw new ExceptionCellReading(name, cellName, ex.Message);
            }
        }

        public static void FillComboWithColumnName(ComboBox cb)
        {
            cb.Items.Clear();
            char[] az = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (char)i).ToArray();
            foreach (var c in az)
            {
                cb.Items.Add(c.ToString());
            }
        }

        public static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = string.Empty;
            while (div > 0)
            {
                int mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (div - mod) / 26;
            }
            return colLetter;
        }
        public static int ColumnLetterToColumnIndex(string columnLetter, int max = 26)
        {
            string columnLetterUpper = columnLetter.ToUpper();
            int sum = 0;
            for (int i = 0; i < columnLetterUpper.Length; i++)
            {
                sum *= 26;
                sum += (columnLetterUpper[i] - 'A' + 1);
            }
            if (sum < 0) sum = 0;
            if (sum > max) sum = max; 
            return sum;
        }
    }
}
