#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.GUIExtension.Properties;
using System.IO;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    public class Palletization
    {
        public static void StartCasePalletization(string name, double length, double width, double height)
        {
            FormDefineAnalysisCasePallet form = new FormDefineAnalysisCasePallet(FormDefineAnalysisCasePallet.eMode.PACK_CASE, length, width, height);
            form.CaseName = name;
            form.ShowDialog();
        }
        public static void StartCaseOptimization(string name, double length, double width, double height)
        {
            FormDefineCaseOptimization form = new FormDefineCaseOptimization();
            form.BoxName = name;
            form.BoxLength = length;
            form.BoxWidth = width;
            form.BoxHeight = height;
            form.ShowDialog();
        }
        public static void StartBundlePalletAnalysis(string name, double length, double width, double height)
        {
            FormDefineAnalysisCasePallet form = new FormDefineAnalysisCasePallet(FormDefineAnalysisCasePallet.eMode.PACK_BUNDLE, length, width, height);
            form.CaseName = name;
            form.ShowDialog();
        }
        public static void StartAnalysisBundleCase(string name, double length, double width, double height)
        {
            FormDefineAnalysisBundleCase form = new FormDefineAnalysisBundleCase();
            form.BundleName = name;
            form.BundleLength = length;
            form.BundleWidth = width;
            form.FlatThickness = height;
            form.ShowDialog();
        }
    }
}
