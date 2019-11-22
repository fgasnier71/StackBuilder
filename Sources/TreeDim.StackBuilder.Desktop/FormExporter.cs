#region Using directives
using System;
using System.Windows.Forms;
using System.IO;

using log4net;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Exporters;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormExporter : Form
    {
        #region Constructor
        public FormExporter()
        {
            InitializeComponent();
            textEditorControl.FoldingStrategy = "XML";
        }
        #endregion

        #region Override form
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            int iFormat = cbFileFormat.FindStringExact(Extension.ToUpper());
            cbFileFormat.SelectedIndex = iFormat > -1 ? iFormat : 0;
            cbCoordinates.SelectedIndex = Properties.Settings.Default.ExportCoordinatesMode;
            Recompute();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Properties.Settings.Default.ExportCoordinatesMode = cbCoordinates.SelectedIndex;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Compute
        private void Recompute()
        {
            UpdateAndCheckFoldings();
            try
            {
                Stream stream = new MemoryStream();
                Exporter exporter = ExporterFactory.GetExporterByExt(cbFileFormat.SelectedItem.ToString());
                exporter.PositionCoordinateMode = cbCoordinates.SelectedIndex == 1 ? Exporter.CoordinateMode.CM_COG : Exporter.CoordinateMode.CM_CORNER;
                exporter.Export(Analysis, ref stream);

                using (StreamReader reader = new StreamReader(stream))
                    textEditorControl.Text = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void UpdateAndCheckFoldings()
        {
            textEditorControl.Document.FoldingManager.UpdateFoldings(null, null);
        }
        #endregion

        #region EventHandler
        private void OnInputChanged(object sender, EventArgs e)
        {
            textEditorControl.SetHighlighting(cbFileFormat.SelectedItem.ToString());
            Recompute();
        }
        private void OnSave(object sender, EventArgs e)
        {
            saveExportFile.CheckFileExists = false;
            switch (SelectedFormatIndex)
            {
                case 0: // XML
                    saveExportFile.Filter = "(*.xml)|*.xml";
                    saveExportFile.DefaultExt = "xml";
                    break;
                case 1:
                    saveExportFile.Filter = "(*.csv)|*.csv";
                    saveExportFile.DefaultExt = "csv";
                    break;
                default:
                    break;
            }
            if (DialogResult.OK == saveExportFile.ShowDialog())
            {
                File.WriteAllLines(saveExportFile.FileName, new string[] { textEditorControl.Text }, System.Text.Encoding.UTF8);
            }
        }
        #endregion

        #region Public properties
        private int SelectedFormatIndex => cbFileFormat.SelectedIndex;
        private string SelectedFormatString => cbFileFormat.SelectedItem.ToString();
        #endregion

        #region Data members
        protected ILog _log = LogManager.GetLogger(typeof(FormExporter));
        public string Extension { get; set; }
        public AnalysisLayered Analysis { get; set; }
        #endregion
    }
}
