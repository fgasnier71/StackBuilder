#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using treeDiM.UserControls;
using treeDiM.StackBuilder;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class OptionPanelReporting : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionPanelReporting()
        {
            InitializeComponent();

            CategoryPath = Properties.Resources.ID_OPTIONSREPORTING;
            DisplayName = Properties.Resources.ID_DISPLAYREPORTING;

        }
        #endregion

        #region OptionsPanel override
        protected override void OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);

            // initialize
            cbImageSizes.SelectedIndex = Properties.Settings.Default.ReporterImageSize;
            fileSelectCtrlReportTemplate.FileName = Reporting.Properties.Settings.Default.TemplatePath;
            fileSelectCompanyLogo.FileName = Reporting.Properties.Settings.Default.CompanyLogoPath;
            nudTop.Value = (decimal)Reporting.Properties.Settings.Default.MarginTop;
            nudBottom.Value = (decimal)Reporting.Properties.Settings.Default.MarginBottom;
            nudLeft.Value = (decimal)Reporting.Properties.Settings.Default.MarginLeft;
            nudRight.Value = (decimal)Reporting.Properties.Settings.Default.MarginRight;

            // events
            OptionsForm.OptionsSaving += new EventHandler(OptionsForm_OptionsSaving);
        }
        #endregion

        #region Handlers
        void OptionsForm_OptionsSaving(object sender, EventArgs e)
        {
            Properties.Settings.Default.ReporterImageSize = cbImageSizes.SelectedIndex;
            Reporting.Properties.Settings.Default.TemplatePath = fileSelectCtrlReportTemplate.FileName;
            Reporting.Properties.Settings.Default.CompanyLogoPath = fileSelectCompanyLogo.FileName;
            Reporting.Properties.Settings.Default.MarginTop = (float)nudTop.Value;
            Reporting.Properties.Settings.Default.MarginBottom = (float)nudBottom.Value;
            Reporting.Properties.Settings.Default.MarginLeft = (float)nudLeft.Value;
            Reporting.Properties.Settings.Default.MarginRight = (float)nudRight.Value;
            Reporting.Properties.Settings.Default.Save();
        }
        #endregion
    }
}
