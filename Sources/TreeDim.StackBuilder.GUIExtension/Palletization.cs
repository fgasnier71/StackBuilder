#region Using directives
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    public class Palletization
    {
        public static void StartCasePalletization(string name, double length, double width, double height)
        {
            FormDefineAnalysisCasePallet form = new FormDefineAnalysisCasePallet(FormDefineAnalysisCasePallet.EMode.PACK_CASE, length, width, height)
            {
                CaseName = name
            };
            form.ShowDialog();
        }
        public static void StartCaseOptimization(string name, double length, double width, double height)
        {
            FormDefineCaseOptimization form = new FormDefineCaseOptimization
            {
                BoxName = name,
                BoxLength = length,
                BoxWidth = width,
                BoxHeight = height
            };
            form.ShowDialog();
        }
        public static void StartBundlePalletAnalysis(string name, double length, double width, double height)
        {
            FormDefineAnalysisCasePallet form = new FormDefineAnalysisCasePallet(FormDefineAnalysisCasePallet.EMode.PACK_BUNDLE, length, width, height)
            {
                CaseName = name
            };
            form.ShowDialog();
        }
        public static void StartAnalysisBundleCase(string name, double length, double width, double height)
        {
            FormDefineAnalysisBundleCase form = new FormDefineAnalysisBundleCase
            {
                BundleName = name,
                BundleLength = length,
                BundleWidth = width,
                FlatThickness = height
            };
            form.ShowDialog();
        }
    }
}
