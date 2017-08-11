#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.IO;

using log4net;

using ExcelDataReader;
#endregion

namespace treeDiM.StackBuilder.ABYATExcelLoader
{
    #region Invalid Row Exception
    internal class InvalidRowException : Exception
    {
        public InvalidRowException(string Type, int rowId, string column, Type expectedType)
        {
        }
    }
    #endregion
    #region DataType
    public class DataType : Object
    { 
       public DataType(int rowId, string name, string description)
        {
            RowId = rowId;
            Name = name;
            Description = description;
        }
        public DataType(int rowId, DataRow dtRow)
        {
            RowId = rowId;
            if (null == dtRow[0]) throw new InvalidRowException("DataType", rowId, "Name", typeof(string));
            Name = dtRow[0].ToString();
            if (!(dtRow[1] is string)) throw new InvalidRowException("DataType", rowId, "Description", typeof(string));
            Description = dtRow[1] as string;
        }
        public int RowId { get; set; }
        public string Name {get; set;}
        public string Description {get; set;}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name             = " + Name);
            sb.AppendLine("Description      = " + Description);
            return sb.ToString();
        }
    }
    #endregion
    #region DataCase
    public class DataCase : DataType
    {
        #region Constructor
        public DataCase(int iRow, DataRow dtRow)
            : base(iRow, dtRow)
        {
            outerDimensions[0] = (double)dtRow[5];
            outerDimensions[1] = (double)dtRow[6];
            outerDimensions[2] = (double)dtRow[7];
            if (DBNull.Value != dtRow[9]) Weight = (double)dtRow[9]; else Weight = 0.0;
        }
        #endregion
        #region Public properties
        public double[] OuterDimensions
        {
            get { return outerDimensions; }
            set { outerDimensions = value; }
        }
        public double Weight {get; set;}
        #endregion
        #region Override DataType
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine(string.Format("Outer dimensions = {0}*{1}*{2}", outerDimensions[0], outerDimensions[1], outerDimensions[2]));
            sb.AppendLine(string.Format("Weight = {0}", Weight));
            return sb.ToString();
        }
        #endregion
        #region Data members
        // DATA MEMBERS
        private double[] outerDimensions = new double[3];
        #endregion
    }
    #endregion
    #region ExcelDataReader
    public class ExcelDataReader_ABYAT
    {
        public static bool LoadFile(string filePath, ref List<DataCase> listCases)
        {
            if (!File.Exists(filePath)) return false;
            FileInfo fi = new FileInfo(filePath);

            if (null != listCases)
                listCases.Clear();
            else
                listCases = new List<DataCase>();
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                IExcelDataReader reader = null;
                if (".xls" == fi.Extension) reader = ExcelReaderFactory.CreateBinaryReader(fs);
                else if (".xlsx" == fi.Extension) reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                // no valid reader created -> exit
                if (reader == null)
                    return false;

                DataSet ds = reader.AsDataSet();

                foreach (DataTable dtTable in ds.Tables)
                {
                    int iRowStart = 1;
                    for (int iRow = iRowStart; iRow < dtTable.Rows.Count; ++iRow)
                    {
                        DataCase dataType = null;
                        try
                        {
                            dataType = BuildDataType(dtTable.TableName, iRow, dtTable.Rows[iRow]);
                        }
                        catch (InvalidRowException ex)
                        {
                            _log.Warn(ex.Message);
                            continue;
                        }
                        catch (Exception ex)
                        {
                            _log.Warn(ex.Message);
                            dataType = null;
                            continue;
                        }
                        if (null != dataType)
                            listCases.Add(dataType);
                    }
                }
            }
            return listCases.Count > 0;
        }
        private static DataCase BuildDataType(string sheetName, int iRow, System.Data.DataRow dtRow)
        {
            if (string.Equals(sheetName, "Sheet1", StringComparison.CurrentCultureIgnoreCase))
                return new DataCase(iRow, dtRow);
            else
                throw new FormatException(string.Format("{0} is not a valid sheet name", sheetName));
        }

        protected static ILog _log = LogManager.GetLogger(typeof(ExcelDataReader_ABYAT));
    }
    #endregion
}
