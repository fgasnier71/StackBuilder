#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using log4net;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Reporting
{
    public partial class FormReportDesign : Form
    {
        #region Constructor
        public FormReportDesign()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // caption
            Text = string.Format("Report {0}", _analysis.Name);
            // initialize root
            _rnRoot = new ReportNode("Report");

            UpdateReport();
        }
        #endregion

        #region Public properties
        public Analysis Analysis
        {
            get { return _analysis; }
            set { _analysis = value; }
        }
        #endregion

        #region Helpers
        private string OutputFilePath
        {   get { return Path.ChangeExtension(Path.GetTempFileName(), "html"); } }

        private void UpdateReport()
        {
            try
            {
                // generate report
                string htmlFilePath = Path.ChangeExtension(Path.GetTempFileName(), "html");
                Reporter.ImageSizeSetting = Reporter.eImageSize.IMAGESIZE_DEFAULT;
                ReporterHtml reporter = new ReporterHtml(new ReportData(_analysis), ref _rnRoot, Reporter.TemplatePath, htmlFilePath);
                // display html
                _webBrowser.Navigate(htmlFilePath, string.Empty, null, string.Empty);
                // update tree view
                FillTree();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void FillTree()
        {
            _treeView.Nodes.Clear();
            _treeView.CheckBoxes = true;

            TreeNode treeNodeRoot = new TreeNode(_rnRoot.Name);
            treeNodeRoot.Checked = true;
            treeNodeRoot.Tag = _rnRoot;
            _treeView.Nodes.Add(treeNodeRoot);

            foreach (ReportNode rn in _rnRoot.Children)
                AddNode(rn, treeNodeRoot);
            treeNodeRoot.Expand();
        }
        private void AddNode(ReportNode rn, TreeNode tnParent)
        {
            TreeNode tn = new TreeNode(rn.Name);
            tn.Checked = rn.Activated;
            tn.Tag = rn;
            tnParent.Nodes.Add(tn);

            foreach (ReportNode rnChild in rn.Children)
                AddNode(rnChild, tn);
            tn.Expand();
        }
        #endregion

        #region Toolbar event handlers
        private void onReportMSWord(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.InitialDirectory = Properties.Settings.Default.ReportInitialDirectory;
                dlg.FileName = Path.ChangeExtension(CleanString(Analysis.Name), "doc");
                dlg.Filter = Properties.Resources.ID_FILTER_MSWORD;
                dlg.DefaultExt = "doc";
                dlg.ValidateNames = true;

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    // save directory
                    Properties.Settings.Default.ReportInitialDirectory = Path.GetDirectoryName(dlg.FileName);
                    // initialize
                    Reporter.ImageSizeSetting = (Reporter.eImageSize)Properties.Settings.Default.ReporterImageSize;
                    // generate report
                    ReporterMSWord reporter = new ReporterMSWord(
                        new ReportData(_analysis)
                        , ref _rnRoot
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
                _log.Error(ex.Message);
            }
        }
        private void onReportHTML(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.InitialDirectory = Properties.Settings.Default.ReportInitialDirectory;
                dlg.FileName = Path.ChangeExtension(CleanString(Analysis.Name), "html");
                dlg.Filter = Properties.Resources.ID_FILTER_HTML;
                dlg.DefaultExt = "html";
                dlg.ValidateNames = true;

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    // save directory
                    Properties.Settings.Default.ReportInitialDirectory = Path.GetDirectoryName(dlg.FileName);
                    // initialize
                    Reporter.ImageSizeSetting = (Reporter.eImageSize)Properties.Settings.Default.ReporterImageSize;
                    // generate report
                    ReporterHtml reporter = new ReporterHtml(
                        new ReportData(_analysis)
                        , ref _rnRoot
                        , Reporter.TemplatePath
                        , dlg.FileName);

                    Process.Start( new ProcessStartInfo(dlg.FileName) ); 
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void onNodeChecked(object sender, TreeViewEventArgs e)
        {
            ReportNode rn = e.Node.Tag as ReportNode;
            if (null != rn)
                rn.Activated = !rn.Activated;
            UpdateReport();
        }

        private static string CleanString(string name)
        {
            string nameCopy = name;
            char[] specialChars = { ' ', '*', '.', ';', ':' };
            foreach (char c in specialChars)
                nameCopy = nameCopy.Replace(c, '_');
            return nameCopy;
        }
        #endregion


        #region Data members
        protected Analysis _analysis;
        protected ReportNode _rnRoot;
        protected static ILog _log = LogManager.GetLogger(typeof(FormReportDesign));
        #endregion

    }
}
