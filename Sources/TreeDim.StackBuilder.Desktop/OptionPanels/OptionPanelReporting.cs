#region Using directives
using System;

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

            // initialize
            fileSelectCtrlReportTemplate.FileName = Settings.Default.TemplatePath;
            fileSelectCompanyLogo.FileName = Settings.Default.CompanyLogoPath;
            nudTop.Value = (decimal)Settings.Default.MarginTop;
            nudBottom.Value = (decimal)Settings.Default.MarginBottom;
            nudLeft.Value = (decimal)Settings.Default.MarginLeft;
            nudRight.Value = (decimal)Settings.Default.MarginRight;
            nudSleepTime.Value = (decimal)Settings.Default.SleepTimeBeforeImageDeletion;

            // events
            OptionsForm.OptionsSaving += new EventHandler(OptionsForm_OptionsSaving);
        }
        #endregion

        #region Handlers
        void OptionsForm_OptionsSaving(object sender, EventArgs e)
        {
            Settings.Default.TemplatePath = fileSelectCtrlReportTemplate.FileName;
            Settings.Default.CompanyLogoPath = fileSelectCompanyLogo.FileName;
            Settings.Default.MarginTop = (float)nudTop.Value;
            Settings.Default.MarginBottom = (float)nudBottom.Value;
            Settings.Default.MarginLeft = (float)nudLeft.Value;
            Settings.Default.MarginRight = (float)nudRight.Value;
            Settings.Default.SleepTimeBeforeImageDeletion = (int)nudSleepTime.Value;
            Settings.Default.Save();
        }
        #endregion
    }
}
