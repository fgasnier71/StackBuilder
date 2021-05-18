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
        }
        #endregion
        #region Override form
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textEditorControl.SetFoldingStrategy("XML");

            if (string.IsNullOrEmpty(FormatName))
                FormatName = Properties.Settings.Default.ExportFormatName;

            int iFormat = cbFileFormat.FindStringExact(FormatName);
            cbFileFormat.SelectedIndex = iFormat > -1 ? iFormat : 0;
            cbCoordinates.SelectedIndex = Properties.Settings.Default.ExportCoordinatesMode;

            // analysis to layered
            RobotPreparation = new RobotPreparation(Analysis as AnalysisCasePallet);
            // event handler
            RobotPreparation.LayerModified += RobotPreparationModified;
            // fill combo layer types
            FillLayerComboBox();
        }

        private void FillLayerComboBox()
        { 
            for (int i = 0; i < RobotPreparation.LayerTypes.Count; ++i)
                cbLayers.Items.Add($"{i+1}");
            cbLayers.SelectedIndexChanged += OnSelectedLayerChanged;
            if (RobotPreparation.LayerTypes.Count > 0)
                cbLayers.SelectedIndex = 0;
        }
        private void OnSelectedLayerChanged(object sender, EventArgs e)
        {
            int iSel = cbLayers.SelectedIndex;
            if (-1 != iSel)
                layerEditor.Layer = RobotPreparation.LayerTypes[iSel];
            layerEditor.Invalidate();
            RobotPreparation.Update();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Properties.Settings.Default.ExportFormatName = cbFileFormat.SelectedItem.ToString();
            Properties.Settings.Default.ExportCoordinatesMode = cbCoordinates.SelectedIndex;
            Properties.Settings.Default.Save();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
                return false;
            return base.ProcessDialogKey(keyData);
        }
        #endregion
        #region Compute
        private void Recompute()
        {
            try
            {
                Stream stream = new MemoryStream();
                var exporter = ExporterFactory.GetExporterByName(cbFileFormat.SelectedItem.ToString());
                exporter.PositionCoordinateMode = cbCoordinates.SelectedIndex == 1 ? Exporter.CoordinateMode.CM_COG : Exporter.CoordinateMode.CM_CORNER;
                if (exporter.HandlesRobotPreparation)
                    exporter.Export(RobotPreparation, ref stream);
                else
                    exporter.Export(Analysis, ref stream);

                // to text edit control
                using (StreamReader reader = new StreamReader(stream))
                    textEditorControl.Text = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }

        private void RobotPreparationModified()
        {
            if (null == RobotPreparation)
                return;
            try
            {

                Stream stream = new MemoryStream();
                var exporter = ExporterFactory.GetExporterByName(cbFileFormat.SelectedItem.ToString());
                exporter.Export(RobotPreparation, ref stream);

                // to text edit control
                using (StreamReader reader = new StreamReader(stream))
                    textEditorControl.Text = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion
        #region EventHandler
        private void OnExportFormatChanged(object sender, EventArgs e)
        {
            if (null == CurrentExporter) return;

            layerEditor.Visible = CurrentExporter.HandlesRobotPreparation;
            lbLayers.Visible = CurrentExporter.HandlesRobotPreparation;
            cbLayers.Visible = CurrentExporter.HandlesRobotPreparation;

            lbCoordinates.Visible = CurrentExporter.ShowSelectorCoordinateMode;
            cbCoordinates.Visible = CurrentExporter.ShowSelectorCoordinateMode;

            try
            {
                // set folding strategy to XML ?
                if (string.Equals(CurrentExporter.Extension, "xml", StringComparison.InvariantCultureIgnoreCase))
                {
                    textEditorControl.FoldingStrategy = "XML";
                    textEditorControl.SetHighlighting("XML");
                }
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }

            OnInputChanged(sender, e);
        }
        private void OnInputChanged(object sender, EventArgs e)
        {
            Recompute();
        }
        private void OnExport(object sender, EventArgs e)
        {
            try
            {
                var exporter = CurrentExporter;
                if (null == exporter) return;

                saveExportFile.CheckFileExists = false;
                saveExportFile.Filter = $"(*.{exporter.Extension})|*.{exporter.Extension}|All files (*.*)|*.*";
                saveExportFile.DefaultExt = exporter.Extension;

                if (DialogResult.OK == saveExportFile.ShowDialog())
                    File.WriteAllLines(saveExportFile.FileName, new string[] { textEditorControl.Text }, System.Text.Encoding.UTF8);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        #endregion
        #region Public properties
        private Exporter CurrentExporter => ExporterFactory.GetExporterByName(cbFileFormat.SelectedItem.ToString());
        private int SelectedFormatIndex => cbFileFormat.SelectedIndex;
        private string SelectedFormatString => cbFileFormat.SelectedItem.ToString();
        #endregion
        #region Data members
        protected ILog _log = LogManager.GetLogger(typeof(FormExporter));
        public string FormatName { get; set; }
        public AnalysisLayered Analysis { get; set; }
        public RobotPreparation RobotPreparation { get; set; }
        #endregion


    }
}
