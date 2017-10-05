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
                FormSheetSettings form = new FormSheetSettings();
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
    }
}
