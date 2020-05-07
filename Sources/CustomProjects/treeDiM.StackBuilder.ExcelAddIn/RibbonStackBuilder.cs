#region Using directives
using System;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
#endregion

namespace treeDiM.StackBuilder.ExcelAddIn
{
    public partial class RibbonStackBuilder
    {
        private void OnParameters(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Form form;
                switch (Globals.StackBuilderAddIn.CurrentMode)
                {
                    case StackBuilderAddIn.Mode.AnalysisPerRow: form = new FormSettingsPerRow(); break;
                    case StackBuilderAddIn.Mode.AnalysisPerSheet: form = new FormSettingsPerSheet(); break;
                    default: throw new ArgumentOutOfRangeException();
                }
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void OnShowHelpPage(object sender, RibbonControlEventArgs e)
        {
            try { System.Diagnostics.Process.Start(Properties.Settings.Default.HelpPageUrl); }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        private void OnOpenSample(object sender, RibbonControlEventArgs e)
        {
            try { Globals.StackBuilderAddIn.OpenSampleFile(); }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void OnRibbonStackBuilderLoad(object sender, RibbonUIEventArgs e)
        {
            cbMode.SelectedItemIndex = Properties.Settings.Default.Mode;
        }

        private void OnModeChanged(object sender, RibbonControlEventArgs e)
        {
            if (sender is RibbonDropDown ribbonDropDown)
            {
                switch (ribbonDropDown.SelectedItemIndex)
                {
                    case 0: Globals.StackBuilderAddIn.ChangeMode(StackBuilderAddIn.Mode.AnalysisPerSheet); break;
                    case 1: Globals.StackBuilderAddIn.ChangeMode(StackBuilderAddIn.Mode.AnalysisPerRow); break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
    }
}
