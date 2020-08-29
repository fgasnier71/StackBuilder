#region Using directives
using System;
using System.IO;
using System.Reflection;

using treeDiM.StackBuilder.Reporting.Properties;
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

            string pathReportTemplateDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ReportTemplates");
            string pathReportTemplate = Settings.Default.TemplatePath;
            if (string.IsNullOrEmpty(pathReportTemplate) || !File.Exists(pathReportTemplate))
                pathReportTemplate = Path.Combine(pathReportTemplateDir, "ReportTemplateHtml.xsl");
            string pathCompanyLogo = Settings.Default.CompanyLogoPath;
            if (string.IsNullOrEmpty(pathCompanyLogo) || !File.Exists(pathCompanyLogo))
                pathCompanyLogo = Path.Combine(pathReportTemplateDir, "YourLogoHere.png");

            // initialize
            fileSelectCtrlReportTemplate.FileName = pathReportTemplate;
            fileSelectCompanyLogo.FileName = pathCompanyLogo;
            nudTop.Value = (decimal)Settings.Default.MarginTop;
            nudBottom.Value = (decimal)Settings.Default.MarginBottom;
            nudLeft.Value = (decimal)Settings.Default.MarginLeft;
            nudRight.Value = (decimal)Settings.Default.MarginRight;
            uCtrlTimeBeforeDeletion.Value = new treeDiM.Basics.OptInt(Settings.Default.WordDeleteImage, Settings.Default.WordDeleteImageDelay);

            // events
            OptionsForm.OptionsSaving += new EventHandler(OptionsForm_OptionsSaving);
        }
        #endregion

        #region Handlers
        void OptionsForm_OptionsSaving(object sender, EventArgs e)
        {
            Settings.Default.TemplatePath = File.Exists(fileSelectCtrlReportTemplate.FileName) ? fileSelectCtrlReportTemplate.FileName : string.Empty;
            Settings.Default.CompanyLogoPath = File.Exists(fileSelectCompanyLogo.FileName) ? fileSelectCompanyLogo.FileName : string.Empty;
            Settings.Default.MarginTop = (float)nudTop.Value;
            Settings.Default.MarginBottom = (float)nudBottom.Value;
            Settings.Default.MarginLeft = (float)nudLeft.Value;
            Settings.Default.MarginRight = (float)nudRight.Value;
            Settings.Default.WordDeleteImage = uCtrlTimeBeforeDeletion.Value.Activated;
            Settings.Default.WordDeleteImageDelay = uCtrlTimeBeforeDeletion.Value.Value;
            Settings.Default.Save();
        }
        #endregion
    }
}
