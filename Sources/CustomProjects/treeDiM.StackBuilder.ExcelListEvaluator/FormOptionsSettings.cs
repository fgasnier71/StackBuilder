namespace treeDiM.StackBuilder.ExcelListEvaluator
{
    public partial class FormOptionsSettings : GLib.Options.OptionsForm
    {
        public FormOptionsSettings()
        {
            InitializeComponent();

            Panels.Add(new OptionsPanelFiltering());
            Panels.Add(new OptionsPanelImageSize());
        }
    }
}
