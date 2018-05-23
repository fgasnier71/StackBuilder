using System;
using Microsoft.Office.Tools.Ribbon;
using System.IO;
using System.Windows.Forms;

namespace treeDiM.StackBuilder.ExcelAddIn
{
    public partial class RibbonStackBuilder
    {
        private void RibbonStackBuilder_Load(object sender, RibbonUIEventArgs e)
        {
            Globals.StackBuilderAddIn.ModeChanged += OnModeChanged;
            OnModeChanged(Globals.StackBuilderAddIn.CurrentMode);
        }

        private void OnModeChanged(StackBuilderAddIn.Mode mode)
        {
            toggleRowSheet.Checked = mode == StackBuilderAddIn.Mode.ANALYSIS_PERROW;
        }

        private void OnCompute(object sender, RibbonControlEventArgs e)
        {
            try { Globals.StackBuilderAddIn.Compute(); }
            catch (ExceptionCellReading ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        private void OnParameters(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Form form = null;
                switch (Globals.StackBuilderAddIn.CurrentMode)
                {
                    case StackBuilderAddIn.Mode.ANALYSIS_PERROW: form = new FormSettingsPerRow(); break;
                    case StackBuilderAddIn.Mode.ANALYSIS_PERSHEET: form = new FormSettingsPerSheet(); break;
                    default: break;
                }
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void OnShowWebSite(object sender, RibbonControlEventArgs e)
        {
            try { System.Diagnostics.Process.Start(Properties.Settings.Default.StartPageUrl); }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        private void OnOpenSample(object sender, RibbonControlEventArgs e)
        {
            try { Globals.StackBuilderAddIn.OpenSampleFile(); }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        private void OnModeChanged(object sender, RibbonControlEventArgs e)
        {
            try { Globals.StackBuilderAddIn.ChangeMode(toggleRowSheet.Checked ? StackBuilderAddIn.Mode.ANALYSIS_PERROW : StackBuilderAddIn.Mode.ANALYSIS_PERSHEET); }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
