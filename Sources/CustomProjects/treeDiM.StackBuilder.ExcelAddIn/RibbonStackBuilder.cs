using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace treeDiM.StackBuilder.ExcelAddIn
{
    public partial class RibbonStackBuilder
    {
        private void RibbonStackBuilder_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void onCompute(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Globals.StackBuilderAddIn.Compute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void onParameters(object sender, RibbonControlEventArgs e)
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
    }
}
