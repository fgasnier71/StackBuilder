#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        public static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (div - mod) / 26;
            }
            return colLetter;
        }
        public static int ColumnLetterToColumnIndex(string columnLetter)
        {
            string columnLetterUpper = columnLetter.ToUpper();
            int sum = 0;
            for (int i = 0; i < columnLetterUpper.Length; i++)
            {
                sum *= 26;
                sum += (columnLetterUpper[i] - 'A' + 1);
            }
            return sum;
        }
    }
}
