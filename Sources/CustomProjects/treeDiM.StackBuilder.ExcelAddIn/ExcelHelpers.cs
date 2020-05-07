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
                return worksheet.Range[cellName, cellName].Value;
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
                return worksheet.Range[cellName, cellName].Value.ToString();
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
            var div = colIndex;
            var colLetter = string.Empty;
            while (div > 0)
            {
                var mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (div - mod) / 26;
            }
            return colLetter;
        }
        public static int ColumnLetterToColumnIndex(string columnLetter, int max = 26)
        {
            string columnLetterUpper = columnLetter.ToUpper();
            int sum = 0;
            foreach (var t in columnLetterUpper)
            {
                sum *= 26;
                sum += t - 'A' + 1;
            }
            if (sum < 0) sum = 0;
            if (sum > max) sum = max; 
            return sum;
        }
    }
}
