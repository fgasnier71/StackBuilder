#region Using directives
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

using WeifenLuo.WinFormsUI.Docking;
using log4net;
using Utilities;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Reporting;

using treeDiM.StackBuilder.Desktop.Properties;
using treeDiM.StackBuilder.ColladaExporter;

using treeDiM.StackBuilder.Plugin;

using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;

#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormMain
        : Form, IDocumentFactory, IMRUClient, IDocumentListener
    {
        #region Data members
        /// <summary>
        /// Docking manager
        /// </summary>
        private DockContentDocumentExplorer _documentExplorer = new DockContentDocumentExplorer();
        private DockContentLogConsole _logConsole = new DockContentLogConsole();
        private DockContentStartPage _dockStartPage = new DockContentStartPage();
        private ToolStripProfessionalRenderer _defaultRenderer = new ToolStripProfessionalRenderer(new PropertyGridEx.CustomColorScheme());
        private DeserializeDockContent _deserializeDockContent;
        /// <summary>
        /// List of document instance
        /// The document class holds data (boxes/pallets/interlayers/anslyses)
        /// </summary>
        private List<IDocument> _documents = new List<IDocument>();
        static readonly ILog _log = LogManager.GetLogger(typeof(FormMain));
        private static FormMain _instance;
        private MruManager _mruManager;
        #endregion

        #region Constructor
        public FormMain()
        {
            // set static instance
            _instance = this;
            // set analysis solver
            CasePalletAnalysis.Solver = new treeDiM.StackBuilder.Engine.CasePalletSolver();
            PackPalletAnalysis.Solver = new treeDiM.StackBuilder.Engine.PackPalletSolver();
            CylinderPalletAnalysis.Solver = new treeDiM.StackBuilder.Engine.CylinderSolver();
            HCylinderPalletAnalysis.Solver = new treeDiM.StackBuilder.Engine.HCylinderSolver();
            BoxCasePalletAnalysis.Solver = new treeDiM.StackBuilder.Engine.BoxCasePalletSolver();
            // load content
            _deserializeDockContent = new DeserializeDockContent(ReloadContent);

            InitializeComponent();

            // plugins
            if (Properties.Settings.Default.HasPluginINTEX)
                this.toolStripSplitButtonNew.DropDownItems.Add(this.ToolStripMenuNewFileINTEX); // add new menu item in "New" ToolStripSplitButton

            // load file passed as argument
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2)
            {
                string joinedString = string.Empty;
                for (int i = 1; i < args.Length; ++i)
                    joinedString += (i > 1 ? " " : "") + args[i];
                if (File.Exists(args[1]))
                    OpenDocument(args[1]);
                else if (File.Exists(joinedString))
                    OpenDocument(joinedString);
            }
            // or show splash sceen 
            else
            {
                bool multithreaded = false;
                if (multithreaded)
                {
                    // --- instantiate and start splach screen thread
                    Thread th = new Thread(new ThreadStart(DoSplash));
                    th.Start();
                    // ---
                }
                else
                    DoSplash();
            }
        }
        void PalletSolutionDBModified(object sender, PalletSolutionEventArgs eventArg)
        {
            UpdateToolbarState();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

            // Apply a gray professional renderer as a default renderer
            ToolStripManager.Renderer = _defaultRenderer;
            _defaultRenderer.RoundedEdges = true;

            // Set DockPanel properties
            var theme = new VS2015BlueTheme();
            dockPanel.Theme = theme;

            dockPanel.ActiveAutoHideContent = null;
            dockPanel.Parent = this;

            dockPanel.SuspendLayout(true);
            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, _deserializeDockContent);
            else
                timerLogin.Start();
            dockPanel.ResumeLayout(true, true);

            // initialize database events
            PalletSolutionDatabase.Instance.SolutionAppended += new PalletSolutionDatabase.SolutionMoveHandler(PalletSolutionDBModified);
            PalletSolutionDatabase.Instance.SolutionDeleted += new PalletSolutionDatabase.SolutionMoveHandler(PalletSolutionDBModified);

            // MRUManager
            _mruManager = new MruManager();
            _mruManager.Initialize(
             this,                              // owner form
             mnuFileMRU,                        // Recent Files menu item
             "Software\\TreeDim\\StackBuilder"); // Registry path to keep MRU list

            UpdateToolbarState();

            // windows settings
            if (null != Settings.Default.FormMainPosition)
                Settings.Default.FormMainPosition.Restore(this);

            // connection/disconnection event handling
            WCFClientSingleton.Connected += OnConnected;
            WCFClientSingleton.Disconnected += OnDisconnected;

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (null == Settings.Default.FormMainPosition)
                Settings.Default.FormMainPosition = new WindowSettings();
            Settings.Default.FormMainPosition.Record(this);
            Settings.Default.Save();

            CloseAllDocuments(e);
            base.OnClosing(e);
        }
        #endregion

        #region SplashScreen
        public void DoSplash()
        {
            using (FormSplashScreen sp = new FormSplashScreen(this))
            {
                sp.TimerInterval = 2000;
                sp.ShowDialog();
            }
        }
        #endregion

        #region Start page
        public bool IsWebSiteReachable
        {
            get
            {
                try
                {
                    System.Uri uri = new System.Uri(Settings.Default.StartPageUrl);
                    System.Net.IPHostEntry objIPHE = System.Net.Dns.GetHostEntry(uri.DnsSafeHost);
                    return true;
                }
                catch (System.Net.Sockets.SocketException /*ex*/)
                {
                    _log.Info(
                        string.Format(
                        "Url '{0}' could not be accessed : is the computer connected to the web?"
                        , Settings.Default.StartPageUrl
                        ));
                    return false;
                }
                catch (Exception ex)
                {
                    _log.Error(ex.ToString());
                    return false;
                }
            }
        }
        private string StartPageURL
        {
            get { return Settings.Default.StartPageUrl; }
        }
        public void ShowStartPage(object sender, EventArgs e)
        {
            if (!IsWebSiteReachable) return;
            _dockStartPage.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
            _dockStartPage.Url = new System.Uri(StartPageURL);

            _log.InfoFormat("Showing start page (URL : {0})", StartPageURL);
        }
        private void CloseStartPage()
        {
            if (null != _dockStartPage)
                _dockStartPage.Hide();
        }
        private void timerLogin_Tick(object sender, EventArgs e)
        {
            timerLogin.Stop();
            // show login form
            if (!WCFClientSingleton.IsConnected)
            {
                WCFClientSingleton clientSingleton = WCFClientSingleton.Instance;
            }
            // note : CreateBasicLayout now called by OnConnected()
            // (a handler for WCFClientSingleton.Connected event handler)
        }
        #endregion

        #region Docking
        private void CreateBasicLayout()
        {
            _documentExplorer.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
            _documentExplorer.DocumentTreeView.AnalysisNodeClicked += new AnalysisTreeView.AnalysisNodeClickHandler(DocumentTreeView_NodeClicked);
            _documentExplorer.DocumentTreeView.SolutionReportMSWordClicked += new AnalysisTreeView.AnalysisNodeClickHandler(DocumentTreeView_SolutionReportNodeClicked);
            _documentExplorer.DocumentTreeView.SolutionReportPdfClicked += new AnalysisTreeView.AnalysisNodeClickHandler(DocumentTreeView_SolutionReportPDFNodeClicked);
            _documentExplorer.DocumentTreeView.SolutionReportHtmlClicked += new AnalysisTreeView.AnalysisNodeClickHandler(DocumentTreeView_SolutionReportHtmlClicked);
            _documentExplorer.DocumentTreeView.SolutionColladaExportClicked += new AnalysisTreeView.AnalysisNodeClickHandler(DocumentTreeView_SolutionColladaExportClicked);
            ShowLogConsole();
            if (AssemblyConf != "debug")
                ShowStartPage(this, null);
        }

        public void ShowLogConsole()
        {
            // show or hide log console ?
            if (AssemblyConf == "debug" || Settings.Default.ShowLogConsole)
            {
                _logConsole = new DockContentLogConsole();
                _logConsole.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockBottom);
            }
            else
            {
                if (null != _logConsole)
                    _logConsole.Close();
                _logConsole = null;
            }
        }

        private IDockContent ReloadContent(string persistString)
        {
            switch (persistString)
            {
                case "frmDocument":
                    return null;
                case "frmSolution":
                    _documentExplorer = new DockContentDocumentExplorer();
                    return _documentExplorer;
                case "frmLogConsole":
                    _logConsole = new DockContentLogConsole();
                    return _logConsole;
                default:
                    return null;
            }
        }
        #endregion

        #region DocumentTreeView event handlers
        // ### AnalysisNodeClicked
        void DocumentTreeView_NodeClicked(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            if (null != eventArg.Analysis)
                CreateOrActivateViewAnalysis(eventArg.Analysis);
            else if (null != eventArg.ItemBase)
            {
                ItemBase itemProp = eventArg.ItemBase;
                if (itemProp.GetType() == typeof(BoxProperties))
                {
                    BoxProperties box = itemProp as BoxProperties;
                    FormNewBox form = new FormNewBox(eventArg.Document, eventArg.ItemBase as BoxProperties);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (!UserAcknowledgeDependancies(box)) return;
                        box.ID.SetNameDesc(form.BoxName, form.Description);
                        box.SetLength(form.BoxLength);
                        box.SetWidth(form.BoxWidth);
                        box.SetHeight(form.BoxHeight);
                        box.SetWeight(form.Weight);
                        box.SetNetWeight(form.NetWeight);
                        box.InsideLength = form.InsideLength;
                        box.InsideWidth = form.InsideWidth;
                        box.InsideHeight = form.InsideHeight;
                        box.SetAllColors(form.Colors);
                        box.TextureList = form.TextureList;
                        box.TapeWidth = form.TapeWidth;
                        box.TapeColor = form.TapeColor;
                        box.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(PackProperties))
                {
                    PackProperties pack = itemProp as PackProperties;
                    FormNewPack form = new FormNewPack(eventArg.Document, eventArg.ItemBase as PackProperties);
                    form.Boxes = eventArg.Document.Boxes;

                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (!UserAcknowledgeDependancies(pack)) return;
                        pack.ID.SetNameDesc(form.ItemName, form.ItemDescription);
                        pack.Box = form.SelectedBox;
                        pack.BoxOrientation = form.BoxOrientation;
                        pack.Arrangement = form.Arrangement;
                        pack.Wrap = form.Wrapper;
                        if (form.HasForcedOuterDimensions)
                            pack.ForceOuterDimensions(form.OuterDimensions);
                        pack.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(CylinderProperties))
                {
                    CylinderProperties cylinderProperties = itemProp as CylinderProperties;
                    FormNewCylinder form = new FormNewCylinder(eventArg.Document, cylinderProperties);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (!UserAcknowledgeDependancies(cylinderProperties)) return;
                        cylinderProperties.ID.SetNameDesc(form.CylinderName, form.Description);
                        cylinderProperties.RadiusOuter = form.RadiusOuter;
                        cylinderProperties.RadiusInner = form.RadiusInner;
                        cylinderProperties.Height = form.CylinderHeight;
                        cylinderProperties.SetWeight(form.Weight);
                        cylinderProperties.ColorTop = form.ColorTop;
                        cylinderProperties.ColorWallOuter = form.ColorWallOuter;
                        cylinderProperties.ColorWallInner = form.ColorWallInner;
                        cylinderProperties.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(CaseOfBoxesProperties))
                {
                    CaseOfBoxesProperties caseOfBoxes = itemProp as CaseOfBoxesProperties;
                    FormNewCaseOfBoxes form = new FormNewCaseOfBoxes(eventArg.Document, caseOfBoxes);
                    form.CaseName = itemProp.Name;
                    form.CaseDescription = itemProp.Description;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (!UserAcknowledgeDependancies(caseOfBoxes)) return;
                        caseOfBoxes.ID.SetNameDesc(form.CaseName, form.CaseDescription);
                        caseOfBoxes.SetAllColors(form.Colors);
                        caseOfBoxes.TextureList = form.TextureList;
                        caseOfBoxes.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(BundleProperties))
                {
                    BundleProperties bundle = itemProp as BundleProperties;
                    FormNewBundle form = new FormNewBundle(eventArg.Document, bundle);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (!UserAcknowledgeDependancies(bundle)) return;
                        bundle.ID.SetNameDesc(form.BundleName, form.Description);
                        bundle.SetLength(form.BundleLength);
                        bundle.SetWidth(form.BundleWidth);
                        bundle.UnitThickness = form.UnitThickness;
                        bundle.UnitWeight = form.UnitWeight;
                        bundle.NoFlats = form.NoFlats;
                        bundle.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(InterlayerProperties))
                {
                    InterlayerProperties interlayer = itemProp as InterlayerProperties;
                    FormNewInterlayer form = new FormNewInterlayer(eventArg.Document, interlayer);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (!UserAcknowledgeDependancies(interlayer)) return;
                        interlayer.ID.SetNameDesc(form.InterlayerName, form.Description);
                        interlayer.Length = form.InterlayerLength;
                        interlayer.Width = form.InterlayerWidth;
                        interlayer.Thickness = form.Thickness;
                        interlayer.Weight = form.Weight;
                        interlayer.Color = form.Color;
                        interlayer.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(PalletProperties))
                {
                    PalletProperties pallet = itemProp as PalletProperties;
                    FormNewPallet form = new FormNewPallet(eventArg.Document, pallet);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (!UserAcknowledgeDependancies(pallet)) return;
                        pallet.ID.SetNameDesc(form.PalletName, form.Description);
                        pallet.Length = form.PalletLength;
                        pallet.Width = form.PalletWidth;
                        pallet.Height = form.PalletHeight;
                        pallet.Weight = form.Weight;
                        pallet.TypeName = form.PalletTypeName;
                        pallet.Color = form.PalletColor;
                        pallet.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(TruckProperties))
                {
                    TruckProperties truck = itemProp as TruckProperties;
                    FormNewTruck form = new FormNewTruck(eventArg.Document, truck);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (!UserAcknowledgeDependancies(truck)) return;
                        truck.ID.SetNameDesc(form.TruckName, form.Description);
                        truck.Length = form.TruckLength;
                        truck.Width = form.TruckWidth;
                        truck.Height = form.TruckHeight;
                        truck.AdmissibleLoadWeight = form.TruckAdmissibleLoadWeight;
                        truck.Color = form.TruckColor;
                        truck.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(PalletCornerProperties))
                {
                    PalletCornerProperties corner = itemProp as PalletCornerProperties;
                    FormNewPalletCorners form = new FormNewPalletCorners(eventArg.Document, corner);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (!UserAcknowledgeDependancies(corner)) return;
                        corner.ID.SetNameDesc(form.ItemName, form.ItemDescription);
                        corner.Length = form.CornerLength;
                        corner.Width = form.CornerWidth;
                        corner.Thickness = form.CornerThickness;
                        corner.Color = form.CornerColor;
                        corner.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(PalletCapProperties))
                {
                    PalletCapProperties cap = itemProp as PalletCapProperties;
                    FormNewPalletCap form = new FormNewPalletCap(eventArg.Document, cap);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (!UserAcknowledgeDependancies(cap)) return;
                        cap.ID.SetNameDesc(form.ItemName, form.ItemDescription);
                        cap.Color = form.CapColor;
                        cap.Length = form.CapLength;
                        cap.Width = form.CapWidth;
                        cap.Height = form.CapHeight;
                        cap.InsideLength = form.CapInnerLength;
                        cap.InsideWidth = form.CapInnerWidth;
                        cap.InsideHeight = form.CapInnerHeight;
                        cap.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(PalletFilmProperties))
                {
                    PalletFilmProperties film = itemProp as PalletFilmProperties;
                    FormNewPalletFilm form = new FormNewPalletFilm(eventArg.Document, film);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        film.ID.SetNameDesc(form.ItemName, form.ItemDescription);
                        film.UseTransparency = form.UseTransparency;
                        film.UseHatching = form.UseHatching;
                        film.HatchSpacing = form.HatchSpacing;
                        film.HatchAngle = form.HatchAngle;
                        film.Color = form.FilmColor;
                        film.EndUpdate();
                    }
                }
                else
                    Debug.Assert(false);
            }
        }
        private bool UserAcknowledgeDependancies(ItemBase item)
        {
            if (item.HasDependingAnalyses)
            {
                if (DialogResult.Cancel == MessageBox.Show(
                    string.Format(Resources.ID_DEPENDINGANALYSES, item.Name)
                    , Application.ProductName
                    , MessageBoxButtons.OKCancel))
                    return false;
            }
            return true;
        }

        private static string CleanString(string name)
        {
            string nameCopy = name;
            char[] specialChars = { ' ', '*', '.', ';', ':' };
            foreach (char c in specialChars)
                nameCopy = nameCopy.Replace(c, '_');
            return nameCopy;
        }

        public void GenerateReportMSWord(Analysis analysis)
        {
            try
            {
                // save file dialog
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.InitialDirectory = Properties.Settings.Default.ReportInitialDirectory;
                dlg.FileName = Path.ChangeExtension(CleanString(analysis.Name), "doc");
                dlg.Filter = Resources.ID_FILTER_MSWORD;
                dlg.DefaultExt = "doc";
                dlg.ValidateNames = true;
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    // build output file path
                    string outputFilePath = dlg.FileName;
                    string htmlFilePath = Path.ChangeExtension(outputFilePath, "html");
                    // save directory
                    Properties.Settings.Default.ReportInitialDirectory = Path.GetDirectoryName(dlg.FileName);
                    // getting current culture
                    string cultAbbrev = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName;
                    // build report
                    ReportData reportObject = new ReportData(analysis);
                    Reporter.ImageSizeSetting = (Reporter.eImageSize)Properties.Settings.Default.ReporterImageSize;
                    ReporterMSWord reporter = new ReporterMSWord(
                        reportObject
                        , Reporter.TemplatePath
                        , dlg.FileName
                        , new Margins());
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                _log.Error("MS Word not installed? : " + ex.Message);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        public void GenerateReportHTML(Analysis analysis)
        {
            try
            {
                // build output file path
                string outputFilePath = Path.ChangeExtension(Path.GetTempFileName(), "html");
                // build report
                ReportData reportObject = new ReportData(analysis);
                Reporter.ImageSizeSetting = (Reporter.eImageSize)Properties.Settings.Default.ReporterImageSize;
                ReporterHtml reporter = new ReporterHtml(
                    reportObject
                    , Reporter.TemplatePath
                    , outputFilePath
                    );
                // logging
                _log.Debug(string.Format("Saved report to {0}", outputFilePath));
                // open resulting report
                DockContentReport dockContent = CreateOrActivateHtmlReport(reportObject, outputFilePath);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void DocumentTreeView_SolutionReportNodeClicked(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            try
            {
                // build analysis name
                string analysisName = string.Empty;
                if (null != eventArg.Analysis) analysisName = eventArg.Analysis.Name;
                else
                {
                    _log.Error("Unsupported analysis type ?");
                    return;
                }
                // save file dialog
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.InitialDirectory = Properties.Settings.Default.ReportInitialDirectory;
                dlg.FileName = Path.ChangeExtension(CleanString(analysisName), "doc");
                dlg.Filter = Resources.ID_FILTER_MSWORD;
                dlg.DefaultExt = "doc";
                dlg.ValidateNames = true;
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    // build output file path
                    string outputFilePath = dlg.FileName;
                    string htmlFilePath = Path.ChangeExtension(outputFilePath, "html");
                    // save directory
                    Properties.Settings.Default.ReportInitialDirectory = Path.GetDirectoryName(dlg.FileName);
                    // getting current culture
                    string cultAbbrev = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName;
                    // build report
                    ReportData reportObject = new ReportData(eventArg.Analysis);
                    Reporter.ImageSizeSetting = (Reporter.eImageSize)Properties.Settings.Default.ReporterImageSize;
                    ReporterMSWord reporter = new ReporterMSWord(
                        reportObject
                        , Reporter.TemplatePath
                        , dlg.FileName
                        , new Margins());
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                _log.Error("MS Word not installed? : "+ ex.Message);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        public static System.Text.StringBuilder ReadHtmlFile(string htmlFileNameWithPath)
        {
            System.Text.StringBuilder htmlContent = new System.Text.StringBuilder();
            string line;
            try
            {
                using (System.IO.StreamReader htmlReader = new System.IO.StreamReader(htmlFileNameWithPath))
                {
                    while ((line = htmlReader.ReadLine()) != null)
                    {
                        htmlContent.Append(line);
                    }
                }
            }
            catch (Exception objError)
            {    throw objError;    }
            return htmlContent;
        }

        public void DocumentTreeView_SolutionReportPDFNodeClicked(object sender, AnalysisTreeViewEventArgs eventArg)
        {
        }
        private void DocumentTreeView_SolutionReportHtmlClicked(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            try
            {
                // build output file path
                string outputFilePath = Path.ChangeExtension(Path.GetTempFileName(), "html");
                // getting current culture
                string cultAbbrev = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName;
                // build report
                ReportData reportObject = new ReportData(eventArg.Analysis);
                Reporter.ImageSizeSetting = (Reporter.eImageSize)Properties.Settings.Default.ReporterImageSize;
                ReporterHtml reporter = new ReporterHtml(
                    reportObject
                    , Reporter.TemplatePath
                    , outputFilePath);
                // logging
                _log.Debug(string.Format("Saved report to {0}", outputFilePath));
                // open resulting report
                DocumentSB parentDocument = eventArg.Document as DocumentSB;
                DockContentReport dockContent = CreateOrActivateHtmlReport(reportObject, outputFilePath);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        void DocumentTreeView_TruckAnalysisNodeClicked(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            try
            {
                if ((null == eventArg.ItemBase) && (null != eventArg.Analysis))
                {
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());  Program.SendCrashReport(ex);
            }
        }

        void DocumentTreeView_SolutionColladaExportClicked(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            try
            {
                DocumentSB doc = eventArg.Document as DocumentSB;
                string htmlFilePath = Path.ChangeExtension(doc.FilePath, "html");

                // get file path
                saveFileDialogWebGL.InitialDirectory = Path.GetDirectoryName(htmlFilePath);
                saveFileDialogWebGL.FileName = htmlFilePath;
                if (DialogResult.OK != saveFileDialogWebGL.ShowDialog())
                    return;
                htmlFilePath = saveFileDialogWebGL.FileName;

                // export collada file
                string colladaFilePath = Path.ChangeExtension(htmlFilePath, "dae");
                try
                {
                    Exporter exporter = new ColladaExporter.Exporter(null);
                    exporter.Export(colladaFilePath);
                }
                catch (Exception ex)
                {
                    _log.Error(ex.ToString()); Program.SendCrashReport(ex);
                    return;
                }

                // browse with google chrome
                if (ColladaExporter.Exporter.ChromeInstalled)
                    ColladaExporter.Exporter.BrowseWithGoogleChrome(colladaFilePath);
                else
                    MessageBox.Show(Resources.ID_CHROMEISNOTINSTALLED, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString()); Program.SendCrashReport(ex);
            }
        }

        void DocumentTreeView_MenuEditAnalysis(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            try
            {
                DocumentSB doc = eventArg.Document as DocumentSB;
                if ((null != doc) && (null != eventArg.Analysis))
                    doc.EditAnalysis(eventArg.Analysis);
                CreateOrActivateViewAnalysis(eventArg.Analysis);                      
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString()); Program.SendCrashReport(ex);
            }
        }
        #endregion

        #region Caption text / toolbar state
        private void UpdateFormUI()
        {
            // get active document
            DocumentSB doc = ActiveDocument as DocumentSB;
            // form text
            string caption = string.Empty;
            if (null != doc)
            {
                caption += System.IO.Path.GetFileNameWithoutExtension(doc.FilePath);
                caption += " - "; 
            }
            caption += Application.ProductName;
            Text = caption;
        }
        /// <summary>
        /// enables / disable menu/toolbar items
        /// </summary>
        private void UpdateToolbarState()
        {
            DocumentSB doc = (DocumentSB)ActiveDocument;
            // save
            toolStripMenuItemSave.Enabled = (null != doc) && (doc.IsDirty);
            toolStripButtonSave.Enabled = (null != doc) && (doc.IsDirty);
            // save all
            toolStripMenuItemSaveAll.Enabled = OneDocDirty;
            toolStripButtonSaveAll.Enabled = OneDocDirty;
            // save as
            toolStripMenuItemSaveAs.Enabled = (null != doc);
            // close
            toolStripMenuItemClose.Enabled = (null != doc);
            // new box
            toolStripMenuItemBox.Enabled = (null != doc);
            toolStripButtonBox.Enabled = (null != doc);
            // new case
            toolStripMenuItemCase.Enabled = (null != doc);
            toolStripButtonCase.Enabled = (null != doc);
            // new pack
            toolStripMenuItemPack.Enabled = (null != doc) && doc.CanCreatePack;
            toolStripButtonPack.Enabled = (null != doc) && doc.CanCreatePack;
            // new bundle
            toolStripMenuItemBundle.Enabled = (null != doc);
            toolStripButtonBundle.Enabled = (null != doc);
            // new cylinder
            toolStripMenuItemCylinder.Enabled = (null != doc);
            toolStripButtonCylinder.Enabled = (null != doc);
            // new pallet
            toolStripMenuItemPallet.Enabled = (null != doc);
            toolStripButtonPallet.Enabled = (null != doc);
            // pallet decoration
            toolStripSBPalletDeco.Enabled = (null != doc);
            toolStripMenuItemInterlayer.Enabled = (null != doc);
            toolStripMenuItemPalletCap.Enabled = (null != doc);
            toolStripMenuItemPalletFilm.Enabled = (null != doc);
            toolStripMenuItemPalletCorners.Enabled = (null != doc);
            toolStripMIInterlayer.Enabled = (null != doc);
            toolStripMIPalletCap.Enabled = (null != doc);
            toolStripMIPalletCorner.Enabled = (null != doc);
            toolStripMIPalletFilm.Enabled = (null != doc);
            // new truck
            toolStripMenuItemTruck.Enabled = (null != doc);
            toolStripButtonTruck.Enabled = (null != doc);
            // new case/pallet analysis
            toolStripMenuItemNewAnalysisCasePallet.Enabled = (null != doc) && doc.CanCreateAnalysisCasePallet;
            toolStripMIAnalysisCasePallet.Enabled = (null != doc) && doc.CanCreateAnalysisCasePallet;
            toolStripMIAnalysisBundlePallet.Enabled = (null != doc) && doc.CanCreateAnalysisCasePallet;
            // new cylinder/pallet analysis
            toolStripMenuItemNewAnalysisCylinderPallet.Enabled = (null != doc) && doc.CanCreateAnalysisCylinderPallet;
            toolStripMIAnalysisCylinderPallet.Enabled = (null != doc) && doc.CanCreateAnalysisCylinderPallet;
            // new box/case analysis
            toolStripMenuItemNewAnalysisBoxCase.Enabled = (null != doc) && doc.CanCreateAnalysisBoxCase;
            toolStripMIAnalysisBoxCase.Enabled = (null != doc) && doc.CanCreateAnalysisBoxCase;
            toolStripMIAnalysisBundleCase.Enabled = (null != doc) && doc.CanCreateAnalysisBoxCase;
            // new cylinder/case analysis
            toolStripMenuItemNewAnalysisCylinderCase.Enabled = (null != doc) && doc.CanCreateAnalysisCylinderCase;
            toolStripMIAnalysisCylinderCase.Enabled = (null != doc) && doc.CanCreateAnalysisCylinderCase;
            // new pallet/truck analysis
            toolStripMenuItemAnalysisPalletTruck.Enabled = (null != doc) && doc.CanCreateAnalysisPalletTruck;
            toolStripSBCreateAnalysisPalletTruck.Enabled = (null != doc) && doc.CanCreateAnalysisPalletTruck;
            // split buttons
            toolStripSBAnalysisPallet.Enabled = (null != doc);
            toolStripSBAnalysesCase.Enabled = (null != doc);
            toolStripSBOptimisations.Enabled = (null != doc);
            toolStripSBPalletDeco.Enabled = (null != doc);
            // optimisations
            toolStripMIBestCase.Enabled         = (null != doc) && doc.CanCreateOptiMulticase;
            toolStripMenuItemBestCase.Enabled   = (null != doc) && doc.CanCreateOptiMulticase;
            toolStripMIBestCasePallet.Enabled   = (null != doc) && doc.CanCreateOptiCasePallet;
            toolStripMenuItemBestCasePallet.Enabled = (null != doc) && doc.CanCreateOptiCasePallet;
            toolStripMIBestPack.Enabled         = (null != doc) && doc.CanCreateOptiPack;
            toolStripMenuItemBestPack.Enabled   = (null != doc) && doc.CanCreateOptiPack;
        }
        #endregion

        #region IDocumentFactory implementation
        public void NewDocument()
        {
            FormNewDocument form = new FormNewDocument();
            if (DialogResult.OK == form.ShowDialog())
            {
                AddDocument(new DocumentSB(form.DocName, form.DocDescription, form.Author, _documentExplorer.DocumentTreeView));
                _log.Debug("New document added!");
            }
            UpdateFormUI();
        }

        public void OpenDocument(string filePath)
        {
            try
            {
                // set solver
                Document.SetSolver(new LayerSolver());
                Solution.SetSolver(new LayerSolver());

                if (!File.Exists(filePath))
                {
                    // update mruFileManager as we failed to load file
                    if (null != _mruManager)
                        _mruManager.Remove(filePath);
                    MessageBox.Show(string.Format(Resources.ID_FILENOTFOUND, filePath));
                    return;
                }
                AddDocument(new DocumentSB(filePath, _documentExplorer.DocumentTreeView));

                // update mruFileManager as file was successfully loaded
                if (null != _mruManager)
                    _mruManager.Add(filePath);

                _log.Debug(string.Format("File {0} loaded!", filePath));
            }
            catch (Exception ex)
            {
                // update mruFileManager as we failed to load file
                if (null != _mruManager)
                    _mruManager.Remove(filePath);

                _log.Error(ex.ToString());   Program.SendCrashReport(ex);
            }
            UpdateFormUI();
        }

        public void AddDocument(IDocument doc)
        {
            // add this form as document listener
            DocumentSB docSB = doc as DocumentSB;
            if (null != docSB)
                docSB.AddListener(this);
            // add document 
            _documents.Add(doc);
            doc.Modified += new EventHandler(documentModified);
            UpdateToolbarState();
        }

        public void SaveDocument()
        {
            IDocument doc = ActiveDocument;
            if (null == doc) return;
            CancelEventArgs e = new CancelEventArgs();
            SaveDocument(doc, e);
        }

        public void SaveDocument(IDocument doc, CancelEventArgs e)
        {
            if (doc.IsNew)
                SaveDocumentAs(doc, e);
            else
                doc.Save();
        }

        public void SaveAllDocuments()
        {
            CancelEventArgs e = new CancelEventArgs();
            SaveAllDocuments(e);
        }

        public void SaveAllDocuments(CancelEventArgs e)
        {
            if (e.Cancel) return;
            foreach (IDocument doc in Documents)
                SaveDocument(doc, e);
        }

        public void CloseAllDocuments(CancelEventArgs e)
        {
            // exit if already canceled
            if (e.Cancel) return;

            // try and close every opened documents
            while (_documents.Count > 0)
            {
                if (e.Cancel) return;

                IDocument doc = _documents[0];
                CloseDocument(doc, e);
            }
        }

        public void CloseDocument(IDocument doc, CancelEventArgs e)
        {
            // exit if already canceled
            if (e.Cancel)
                return;
            if (doc.IsDirty)
            {
                DialogResult res = MessageBox.Show(string.Format(Resources.ID_SAVEMODIFIEDFILE, doc.Name), Application.ProductName, MessageBoxButtons.YesNoCancel);
                if (DialogResult.Yes == res)
                {
                    SaveDocument(doc, e);
                    e.Cancel = false;
                }
                else if (DialogResult.No == res)
                    e.Cancel = false;
                else if (DialogResult.Cancel == res)
                    e.Cancel = true;
            }
            if (e.Cancel)
                return;
            // close document
            doc.Close();
            // remove from document list
            _documents.Remove(doc);
            // handle the case
            _log.Debug(string.Format("Document {0} closed", doc.Name));
            // update toolbar
            UpdateToolbarState();
        }

        public void SaveDocumentAs(IDocument doc, CancelEventArgs e)
        {
            saveFileDialogSB.FileName = doc.Name + ".stb";
            if (saveFileDialogSB.ShowDialog() == DialogResult.OK)
                doc.SaveAs(saveFileDialogSB.FileName);
            else
                e.Cancel = true;
        }

        public void SaveDocumentAs()
        {
            IDocument doc = ActiveDocument;
            if (null == doc) return;
            CancelEventArgs e = new CancelEventArgs();
            SaveDocumentAs(doc, e);
        }

        public void CloseDocument()
        {
            IDocument doc = ActiveDocument;
            if (null == doc) return;

            // close active document
            CancelEventArgs e = new CancelEventArgs();
            CloseDocument(doc, e);
        }
        /// <summary>
        /// Access list of documents
        /// </summary>
        public List<IDocument> Documents { get { return _documents; } }

        /// <summary>
        /// Get active view based on ActiveMdiChild
        /// </summary>
        public IView ActiveView
        {
            get
            {
                // search ammong existing views
                foreach (IDocument doc in Documents)
                    foreach (IView view in doc.Views)
                    {
                        Form form = view as Form;
                        if (this.ActiveMdiChild == form)
                            return view;
                    }
                return null;
            }            
        }

        public IDocument ActiveDocument
        {
            get
            {
                IView view = ActiveView;
                if (view != null)
                    return view.Document;
                else if (_documents.Count == 1)
                    return _documents[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns true if at least one document is dirty
        /// </summary>
        public bool OneDocDirty
        {
            get
            {
                foreach (IDocument doc in Documents)
                    if (doc.IsDirty)
                        return true;
                return false;
            }
        }
        #endregion

        #region IDocumentListener implementation
        // new
        public void OnNewDocument(Document doc) {}
        public void OnNewTypeCreated(Document doc, ItemBase itemBase) { }
        public void OnNewAnalysisCreated(Document doc, Analysis analysis)
        {
            CreateOrActivateViewAnalysis(analysis);
        }
        public void OnAnalysisUpdated(Document doc, Analysis analysis)
        {
            CreateOrActivateViewAnalysis(analysis);
        }
        public void OnNewECTAnalysisCreated(Document doc, CasePalletAnalysis analysis, SelCasePalletSolution selSolution, ECTAnalysis ectAnalysis) {  }
        // remove
        public void OnTypeRemoved(Document doc, ItemBase itemBase) { }
        public void OnAnalysisRemoved(Document doc, ItemBase itemBase) { }
        public void OnECTAnalysisRemoved(Document doc, CasePalletAnalysis analysis, SelCasePalletSolution selSolution, ECTAnalysis ectAnalysis) { }

        // close
        public void OnDocumentClosed(Document doc) { }
        #endregion

        #region Connection / disconnection
        private void OnConnected()
        {
            if (WCFClientSingleton.IsConnected)
            {
                PLMPackServiceClient client = WCFClientSingleton.Instance.Client;
                DCGroup currentGroup = client.GetCurrentGroup();
                // update main frame title
                if (null != currentGroup)
                    Text = Application.ProductName + " - (" + currentGroup.Name + "\\" + WCFClientSingleton.Instance.User.Name + ")";
                // create basic layout
                CreateBasicLayout();
                UpdateDisconnectButton();
            }
        }
        private void OnDisconnected()
        {
            Text = Application.ProductName;
            UpdateDisconnectButton();
        }
        private void UpdateDisconnectButton()
        { 
        }
        #endregion

        #region File menu event handlers
        private void fileClose(object sender, EventArgs e)
        {
            IDocument doc = ActiveDocument;
            CancelEventArgs cea = new CancelEventArgs();
            CloseDocument(doc, cea);
        }
        private void fileNew(object sender, EventArgs e)
        {
            CloseStartPage();
            NewDocument();
        }
        private void fileNewINTEX(object sender, EventArgs e)
        {
            CloseStartPage();

            /*
            // use INTEX plugin to generate document
            Plugin_INTEX plugin = new Plugin_INTEX();
            string fileName = null;
            // change unit system

            // if document can be created, then open
            if (plugin.onFileNew(ref fileName))
                OpenDocument(fileName);
            */ 
        }
        private void fileOpen(object sender, EventArgs e)
        {
            CloseStartPage();
            if (DialogResult.OK == openFileDialogSB.ShowDialog())
                foreach(string fileName in openFileDialogSB.FileNames)
                    OpenDocument(fileName);            
        }
        private void fileSave(object sender, EventArgs e)        {   SaveDocument();                }
        private void fileSaveAs(object sender, EventArgs e)      {   SaveDocumentAs();              }
        private void fileSaveAll(object sender, EventArgs e)     {   SaveAllDocuments();            }
        private void fileExit(object sender, EventArgs e)
        {
            CancelEventArgs cea = new CancelEventArgs();
            CloseAllDocuments(cea);
            Close();
            Application.Exit(); 
        }
        public void OpenMRUFile(string filePath)
        {
            CloseStartPage();

            // instantiate solver
            DocumentSB.SetSolver(new LayerSolver());
            // open file
            OpenDocument(filePath); // -> exception handled in OpenDocument
        }
        #endregion

        #region Tools
        #region User
        private void onUserClicked(object sender, EventArgs e)
        {
            toolStripSBUser.ShowDropDown();
        }
        #endregion
        #region Items
        private void toolAddNewBox(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewBoxUI();    }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void toolAddNewCase(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewCaseUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void toolAddNewPack(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewPackUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void toolAddNewBundle(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewBundleUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void toolAddNewCylinder(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewCylinderUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
         }
        private void toolAddNewPallet(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewPalletUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void toolAddNewTruck(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewTruckUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        #endregion
        #region Pallet decorations
        private void onPalletAccessories(object sender, EventArgs e)
        {
            toolStripSBPalletDeco.ShowDropDown();
        }
        private void toolAddNewInterlayer(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewInterlayerUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void toolAddNewPalletCap(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewPalletCapUI(); }
            catch (Exception ex) { _log.Error(ex.ToString());  Program.SendCrashReport(ex); }
        }
        private void toolAddNewPalletCorners(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewPalletCornersUI(); }
            catch (Exception ex) { _log.Error(ex.ToString());  Program.SendCrashReport(ex); }
        }
        private void toolAddNewPalletFilm(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewPalletFilmUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        #endregion
        #region Analyses
        private void onAnalysisPallet(object sender, EventArgs e)
        {
            toolStripSBAnalysisPallet.ShowDropDown();
        }
        private void onAnalysisCase(object sender, EventArgs e)
        {
            toolStripSBAnalysesCase.ShowDropDown();
        }
        private void onAnalysisOpti(object sender, EventArgs e)
        {
            toolStripSBOptimisations.ShowDropDown();
        }
        private void onNewAnalysisBoxCase(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewAnalysisBoxCaseUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void onNewAnalysisCylinderCase(object sender, EventArgs e)
        { 
            try { ((DocumentSB)ActiveDocument).CreateNewAnalysisCylinderCaseUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void onNewAnalysisPalletTruck(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewAnalysisPalletTruckUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void onNewAnalysisCasePallet(object sender, EventArgs e)
        {
            try { CasePalletAnalysis analysis = ((DocumentSB)ActiveDocument).CreateNewAnalysisCasePalletUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void onNewAnalysisCylinderPallet(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewAnalysisCylinderPalletUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void onNewAnalysisBoxCasePallet(object sender, EventArgs e)
        {
            try { AnalysisBoxCase analysis = ((DocumentSB)ActiveDocument).CreateNewAnalysisBoxCaseUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        #endregion
        #region Optimisation
        private void onOptiBoxCasePallet(object sender, EventArgs e)
        {
            try
            {
                // show optimisation form
                FormOptimizePack form = new FormOptimizePack((DocumentSB)ActiveDocument);
                form.ShowDialog();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void onOptiBoxCasePalletOptimization(object sender, EventArgs e)
        {
            try { BoxCasePalletAnalysis analysis = ((DocumentSB)ActiveDocument).CreateNewBoxCasePalletOptimizationUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void onOptiSelectCase(object sender, EventArgs e)
        {
            try
            {
                FormOptimiseMultiCase form = new FormOptimiseMultiCase();
                form.Document = (DocumentSB)ActiveDocument;
                form.ShowDialog();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        #endregion
        #region Database / settings / excel sheet
        private void onShowDatabase(object sender, EventArgs e)
        {
            try
            {
                // Form show database
                FormShowDatabase form = new FormShowDatabase();
                form.Document = ActiveDocument as Document;
                form.ShowDialog();
                // update toolbar state as database may now be empty
                UpdateToolbarState();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void onShowSettings(object sender, EventArgs e)
        {
            try
            {
                // show OptionsFormSettings
                FormOptionsSettings form = new FormOptionsSettings();
                form.ShowDialog();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        private void onLoadExcelSheet(object sender, EventArgs e)
        {
            try
            {
                DocumentSB doc = ActiveDocument as DocumentSB;
                if (null == doc) return;
                FormExcelLibrary form = new FormExcelLibrary(doc);
                form.ShowDialog();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.SendCrashReport(ex); }
        }
        #endregion
        #endregion

        #region Document / View status change handlers
        void documentModified(object sender, EventArgs e)
        {
            UpdateToolbarState();
        }
        #endregion

        #region Form activation/creation
        public void CreateOrActivateViewAnalysis(Analysis analysis)
        { 
            AnalysisCasePallet analysisCasePallet = analysis as AnalysisCasePallet;
            AnalysisBoxCase analysisBoxCase = analysis as AnalysisBoxCase;
            AnalysisPalletTruck analysisPalletTruck = analysis as AnalysisPalletTruck;
            AnalysisCylinderCase analysisCylinderCase = analysis as AnalysisCylinderCase;
            AnalysisCylinderPallet analysisCylinderPallet = analysis as AnalysisCylinderPallet;

            // ---> search among existing views
            // ---> activate if found
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    if (null != analysisCasePallet)
                    {
                        DockContentAnalysisCasePallet form = view as DockContentAnalysisCasePallet;
                        if (null == form ) continue;
                        if (analysisCasePallet == form.Analysis)
                        {
                            form.Activate();
                            return;
                        }
                    }
                    else if (null != analysisBoxCase)
                    {
                        DockContentAnalysisBoxCase form = view as DockContentAnalysisBoxCase;
                        if (null == form) continue;
                        if (analysisBoxCase == form.Analysis)
                        {
                            form.Activate();
                            return;
                        }
                    }
                    else if (null != analysisPalletTruck)
                    {
                        DockContentAnalysisPalletTruck form = view as DockContentAnalysisPalletTruck;
                        if (null == form) continue;
                        if (analysisPalletTruck == form.Analysis)
                        {
                            form.Activate();
                            return;
                        }
                    }
                    else if (null != analysisCylinderCase)
                    {
                        DockContentAnalysisCylinderCase form = view as DockContentAnalysisCylinderCase;
                        if (null == form) continue;
                        if (analysisCylinderCase == form.Analysis)
                        {
                            form.Activate();
                            return;
                        }
                    }
                    else if (null != analysisCylinderPallet)
                    {
                        DockContentAnalysisCylinderPallet form = view as DockContentAnalysisCylinderPallet;
                        if (null == form) continue;
                        if (analysisCylinderPallet == form.Analysis)
                        {
                            form.Activate();
                            return;
                        }
                    }
                }

            // ---> not found : create new form
            // get document
            DocumentSB parentDocument = (DocumentSB)analysis.ParentDocument;
            // create form and show
            DockContentView formAnalysis = parentDocument.CreateViewAnalysis(analysis);
            if (null != formAnalysis)
                formAnalysis.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }
        /// <summary>
        /// ECT analysis view
        /// </summary>
        public void CreateOrActivateViewECTAnalysis(ECTAnalysis analysis)
        { 
            // search among existing views
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    DockContentECTAnalysis form = view as DockContentECTAnalysis;
                    if (null == form) continue;
                    if (analysis == form.ECTAnalysis)
                    {
                        form.Activate();
                        return;
                    }
                }
            // ---> not found
            // ---> create new form
            // get document
            DocumentSB parentDocument = analysis.ParentDocument as DocumentSB;
            // instantiate form
            DockContentECTAnalysis formECTAnalysis = parentDocument.CreateECTAnalysisView(analysis);
            // show docked
            formECTAnalysis.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }
        /*
        /// <summary>
        /// Creates or activate a truck analysis view
        /// </summary>
        public void CreateOrActivateViewTruckAnalysis(TruckAnalysis analysis)
        {
            // search among existing views
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    DockContentTruckAnalysis form = view as DockContentTruckAnalysis;
                    if (null == form) continue;
                    if (analysis == form.TruckAnalysis)
                    {
                        form.Activate();
                        return;
                    }
                }
            // ---> not found
            // ---> create new form
            // get document
            DocumentSB parentDocument = analysis.ParentDocument as DocumentSB;
            // instantiate form
            DockContentTruckAnalysis formTruckAnalysis = parentDocument.CreateTruckAnalysisView(analysis);
            // show docked
            formTruckAnalysis.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }
        /// <summary>
        /// Creates or activate a case analysis view
        /// </summary>
        public void CreateOrActivateViewCaseAnalysis(BoxCasePalletAnalysis caseAnalysis)
        {
            // search ammong existing views
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    DockContentBoxCasePalletAnalysis form = view as DockContentBoxCasePalletAnalysis;
                    if (null == form) continue;
                    if (caseAnalysis == form.CaseAnalysis)
                    {
                        form.Activate();
                        return;
                    }
                }
            // ---> not found
            // ---> create new form
            DocumentSB parentDocument = (DocumentSB)caseAnalysis.ParentDocument;
            DockContentBoxCasePalletAnalysis formCaseAnalysis = parentDocument.CreateCaseAnalysisView(caseAnalysis);
            formCaseAnalysis.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }
        public void CreateOrActivateViewBoxCaseAnalysis(BoxCaseAnalysis boxCaseAnalysis)
        { 
            // search among existing views
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    DockContentBoxCaseAnalysis form = view as DockContentBoxCaseAnalysis;
                    if (null == form) continue;
                    if (boxCaseAnalysis == form.Analysis)
                    {
                        form.Activate();
                        return;                        
                    }
                }
            // ---> not found
            // ---> create new form
            DocumentSB parentDocument = (DocumentSB)boxCaseAnalysis.ParentDocument;
            DockContentBoxCaseAnalysis formBoxCaseAnalysis = parentDocument.CreateNewBoxCaseAnalysisView(boxCaseAnalysis);
            formBoxCaseAnalysis.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }
        */
        /// <summary>
        /// Create or activate report view
        /// </summary>
        public DockContentReport CreateOrActivateHtmlReport(ReportData reportObject, string htmlFilePath)
        { 
            // search among existing views
            IDocument searchedDoc = null;
            IView searchedView = null;
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    DockContentReport form = view as DockContentReport;
                    if (null == form) continue;
                    if (reportObject.Equals(form.ReportObject))
                    {
                        // close form
                        form.Close();
                        // get doc/view to later remove IView from IDocument
                        searchedDoc = doc;
                        searchedView = view;
                        break;
                    }
                }
            // ---> found view : remove it from document
            if (null != searchedView && null != searchedDoc)
                searchedDoc.RemoveView(searchedView);
            // ---> create DockContentReport form
            DocumentSB parentDocument = reportObject.Document as DocumentSB;
            DockContentReport formReport = parentDocument.CreateReportHtml(reportObject, htmlFilePath);
            formReport.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
            return formReport;
        }
        #endregion

        #region Helpers
        public string AssemblyConf
        {
            get
            {
                object[] attributes = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyConfigurationAttribute confAttribute = (AssemblyConfigurationAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (!string.IsNullOrEmpty(confAttribute.Configuration))
                        return confAttribute.Configuration.ToLower();
                }
                return "release";
            }
        }
        #endregion

        #region Help menu event handlers
        private void onAbout(object sender, EventArgs e)
        {
            AboutBox form = new AboutBox();
            form.CompanyUrl = "https://github.com/treeDiM/StackBuilder/releases";
            form.SupportEmail = "treedim@gmail.com";
            form.ShowDialog();
        }
        private void onOnlineHelp(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start(Properties.Settings.Default.HelpPageUrl); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onDonate(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start(Properties.Settings.Default.DonatePageUrl); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onDisconnect(object sender, EventArgs e)
        {
            try { WCFClientSingleton.DisconnectFull(); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        #endregion

        #region Static instance accessor
        public static FormMain GetInstance()
        {
            return _instance;
        }
        #endregion
    }
}
