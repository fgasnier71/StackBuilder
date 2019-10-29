#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Windows.Forms;
using System.IO;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
#endregion

namespace treeDiM.StackBuilder.Plugin
{
    public class Plugin_INTEX : IPlugin
    {
        #region Constructor
        public Plugin_INTEX()
        {
        }
        #endregion

        #region Implement IPlugin members
        public bool Initialize()
        {
            // change unit system
            UnitsManager.CurrentUnitSystem = UnitsManager.UnitSystem.UNIT_METRIC2;

            return true;
        }
        public bool UpdateToolbar(ToolStripSplitButton toolStripSplitButton)
        {
            try
            {
                // add new ToolStripSplitButton
                ToolStripMenuItem toolStripMI = new ToolStripMenuItem()
                {
                    Name = "Intex New",
                    Text = "Intex",
                    Image = Properties.Resources.Intex,
                    Size = new Size(32, 32)
                };
                toolStripMI.Click += new EventHandler(OnNewIntexProject);
                toolStripSplitButton.DropDownItems.Add(toolStripMI);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return false;
            }
            return true;
        }

        private void OnNewIntexProject(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            OnFileNew(ref filePath);
        }

        public bool OnFileNew(ref string fileName)
        {
            // INTEX data are in cms
            UnitsManager.CurrentUnitSystem = UnitsManager.UnitSystem.UNIT_METRIC2;

            string dbPath = Properties.Settings.Default.DatabasePathINTEX;
            if (string.IsNullOrWhiteSpace(dbPath) || !File.Exists(dbPath))
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.DefaultExt = "xls";
                fd.AddExtension = false;
                fd.Filter = "Microsoft Excel File (*.xls)|*.xls|All files (*.*)|*.*";
                fd.FilterIndex = 0;
                fd.RestoreDirectory = true;
                fd.CheckFileExists = true;
                if (DialogResult.OK != fd.ShowDialog())
                    return false;

                dbPath = fd.FileName;
                Properties.Settings.Default.DatabasePathINTEX = dbPath;
                Properties.Settings.Default.Save();
            }
            // load INTEX excel file
            List<DataItemINTEX> listItems = null;
            List<DataPalletINTEX> listPallets = null;
            List<DataCaseINTEX> listCases = null;
            try
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                // load excel file
                if (!ExcelDataReader.ExcelDataReader.LoadIntexFile(dbPath, ref listItems, ref listPallets, ref listCases))
                {
                    Cursor.Current = Cursors.Default;
                    string message = string.Empty;
                    if (null == listItems || listItems.Count < 1)
                        message = string.Format(Properties.Resources.ID_ERROR_NOITEMFOUND, "article", "Articles");
                    else if (null == listPallets || listPallets.Count < 1)
                        message = string.Format(Properties.Resources.ID_ERROR_NOITEMFOUND, "palette", "Palettes");
                    else
                        message = string.Format(Properties.Resources.ID_ERROR_INVALIDFILE, dbPath);
                    if (!string.IsNullOrEmpty(message))
                        MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                    , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _log.Error(ex.Message);
            }
            finally
            { Cursor.Current = Cursors.Default; }
            // do we have a valid list
            if (null == listItems || 0 == listItems.Count)
                return false;
            // proceed : buid project file
            try
            {
                FormNewINTEX form = new FormNewINTEX()
                {
                    ListItems = listItems,
                    ListPallets = listPallets,
                    ListCases = listCases
                };
                if (DialogResult.OK != form.ShowDialog())
                    return false;
                // create document
                DataItemINTEX item = form._currentItem;
                Document document = new Document(item._ref, item._description, "INTEX", DateTime.Now, null);
                // create box properties
                Color[] colorsCase = new Color[6];
                for (int i = 0; i < 6; ++i) {   colorsCase[i] = Color.Chocolate; }
                BoxProperties itemProperties = null;
                if (!form.UseIntermediatePacking)
                {
                    itemProperties = document.CreateNewCase(
                        item._ref
                        , $"{item._description};EAN14 : {item._gencode};UPC : {item._UPC};PCB : {item._PCB}"
                        , UnitsManager.ConvertLengthFrom(item._length, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._width, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._height, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertMassFrom(item._weight, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , colorsCase);
                }
                else
                {
                    itemProperties = document.CreateNewBox(
                        item._ref
                        , string.Format("{0};EAN14 : {1};UPC : {2};PCB : {3}", item._description, item._gencode, item._UPC, item._PCB)
                        , UnitsManager.ConvertLengthFrom(item._length, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._width, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._height, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertMassFrom(item._weight, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , colorsCase);                
                }
                itemProperties.TapeColor = Color.Beige;
                itemProperties.TapeWidth = new OptDouble(true, 5.0);
                InsertPictogram(ref itemProperties);

                BoxProperties currentCase = null;
                if (form.UseIntermediatePacking)
                { 
                    // create cases
                    foreach (DataCaseINTEX dataCase in listCases)
                    {
                        double lengthInt = dataCase._lengthInt > 0 ? dataCase._lengthInt : dataCase._lengthExt - 2* form.DefaultCaseThickness;
                        double widthInt = dataCase._widthInt > 0 ? dataCase._widthInt : dataCase._widthExt - 2 * form.DefaultCaseThickness;
                        double heightInt = dataCase._heightInt > 0 ? dataCase._heightInt : dataCase._heightExt - 2 * form.DefaultCaseThickness;

                        BoxProperties intercaseProperties = document.CreateNewCase(
                            dataCase._ref
                            , string.Format("{0:0.0}*{1:0.0}*{2:0.0}", dataCase._lengthExt, dataCase._widthExt, dataCase._heightExt)
                            , UnitsManager.ConvertLengthFrom(dataCase._lengthExt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertLengthFrom(dataCase._widthExt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertLengthFrom(dataCase._heightExt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertLengthFrom(lengthInt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertLengthFrom(widthInt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertLengthFrom(heightInt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertMassFrom(dataCase._weight, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , colorsCase);
                        intercaseProperties.TapeColor = Color.Beige;
                        intercaseProperties.TapeWidth = new OptDouble(true, 5.0);

                        if (string.Equals( form._currentCase._ref, intercaseProperties.Name))
                            currentCase = intercaseProperties;
                    }
                }

                // initialize Layer solver
                Solution.SetSolver(new LayerSolver());

                if (form.UseIntermediatePacking)
                { 
                    // Case constraint set
                    ConstraintSetBoxCase constraintSetBoxCase = new ConstraintSetBoxCase(currentCase);
                    constraintSetBoxCase.AllowedOrientationsString = "1,1,1";
                    if (constraintSetBoxCase.Valid)
                    {
                        SolverBoxCase solver = new SolverBoxCase(itemProperties, currentCase);
                        Layer2DBrickImp layer = solver.BuildBestLayer(constraintSetBoxCase);
                        List<LayerDesc> layerDescs = new List<LayerDesc>();
                        if (null != layer)
                            layerDescs.Add(layer.LayerDescriptor);

                        // create case analysis
                        AnalysisHomo analysis = document.CreateNewAnalysisBoxCase(
                            string.Format(Properties.Resources.ID_PACKING, item._ref)
                            , item._description
                            , itemProperties
                            , currentCase
                            , null
                            , constraintSetBoxCase
                            , layerDescs);
                    }
                }

                // create pallets
                PalletProperties currentPallet = null;
                foreach (DataPalletINTEX pallet in listPallets)
                {
                    PalletProperties palletProperties = document.CreateNewPallet(
                        pallet._type, pallet._type, "EUR"
                        , UnitsManager.ConvertLengthFrom(pallet._length, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(pallet._width, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(pallet._height, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertMassFrom(pallet._weight, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , Color.Gold);
                    if (string.Equals(form._currentPallet._type, pallet._type))
                        currentPallet = palletProperties;
                }

                // *** pallet analysis ***
                // constraint set
                ConstraintSetCasePallet constraintSet = new ConstraintSetCasePallet();
                constraintSet.SetMaxHeight( new OptDouble(true, UnitsManager.ConvertLengthFrom(form.PalletHeight, UnitsManager.UnitSystem.UNIT_METRIC2)));
                constraintSet.SetAllowedOrientations(new bool[] { false, false, true } );
                if (constraintSet.Valid)
                {
                    SolverCasePallet solver = new SolverCasePallet(form.UseIntermediatePacking ? currentCase : itemProperties, currentPallet);
                    Layer2DBrickImp layer = solver.BuildBestLayer(constraintSet);
                    List<LayerDesc> layerDescs = new List<LayerDesc>();
                    if (null != layer)
                        layerDescs.Add(layer.LayerDescriptor);                          

                    // create analysis
                    AnalysisHomo palletAnalysis = document.CreateNewAnalysisCasePallet(
                        item._ref, item.ToString()
                        , form.UseIntermediatePacking ? currentCase : itemProperties
                        , currentPallet,
                        null, null,
                        null, null,
                        constraintSet,
                        layerDescs);
                }
                // save document
                fileName = form.FilePath;
                document.Write(form.FilePath);

                if (null != OpenFile)
                    OpenFile(fileName);
                // return true to let application open
                return File.Exists(fileName);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return false;
            }
        }
        #endregion

        #region Insert pictogram
        private void InsertPictogram(ref BoxProperties boxProperties)
        {
            string pictoPath = Properties.Settings.Default.pictoTOP;
            if (File.Exists(pictoPath))
            {
                // load image
                Bitmap bmp = new Bitmap(pictoPath);
                // case dimensions
                double length = boxProperties.Length;
                double width = boxProperties.Width;
                double height = boxProperties.Height;
                // dimensions and margins
                double margin = 2;
                double pictoSize = 10;
                double minDim = Math.Min(Math.Min(length, width), Math.Min(width, height));
                if (minDim < pictoSize) { margin = 0.0; pictoSize = minDim; }
                // top position
                double topPos = boxProperties.Height - margin - pictoSize;
                // insert picto as a texture
                boxProperties.AddTexture(HalfAxis.HAxis.AXIS_X_N
                    , ConvertLengthFrom(new Vector2D(width - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , 0, bmp);
                boxProperties.AddTexture(HalfAxis.HAxis.AXIS_X_P
                    , ConvertLengthFrom(new Vector2D(width - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , 0, bmp);
                boxProperties.AddTexture(HalfAxis.HAxis.AXIS_Y_N
                    , ConvertLengthFrom(new Vector2D(length - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , 0, bmp);
                boxProperties.AddTexture(HalfAxis.HAxis.AXIS_Y_P
                    , ConvertLengthFrom(new Vector2D(length - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , 0, bmp);
            }
        }
        #endregion

        #region Vector conversion
        private Vector2D ConvertLengthFrom(Vector2D v, UnitsManager.UnitSystem us)
        {
            return new Vector2D(UnitsManager.ConvertLengthFrom(v.X, us), UnitsManager.ConvertLengthFrom(v.Y, us));
        }
        #endregion

        #region Event
        public event DoCallbackAction OpenFile;
        #endregion

        #region Logging
        static readonly ILog _log = LogManager.GetLogger(typeof(Plugin_INTEX));
        #endregion
    }
}
