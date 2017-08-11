using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Codaxy.WkHtmlToPdf;

namespace treeDiM.StackBuilder.Reporting
{
    #region ReporterPDF
    public class ReporterPDF : Reporter
    {
        public ReporterPDF(ReportData inputData, ref ReportNode rnRoot
            , string templatePath, string outputFilePath)
        {
            // absolute output file path
            string absOutputFilePath = string.Empty;
            if (Path.IsPathRooted(outputFilePath))
                absOutputFilePath = outputFilePath;
            else
                absOutputFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), outputFilePath));
            // absolute template path
            string absTemplatePath = string.Empty;
            if (Path.IsPathRooted(templatePath))
                absTemplatePath = templatePath;
            else
                absTemplatePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), templatePath));

            // does output directory exists
            string outDir = Path.GetDirectoryName(absOutputFilePath);
            if (!Directory.Exists(outDir))
            {
                try { Directory.CreateDirectory(outDir); }
                catch (System.UnauthorizedAccessException /*ex*/)
                { throw new UnauthorizedAccessException(string.Format("User not allowed to write under {0}", Directory.GetParent(outDir).FullName)); }
                catch (Exception ex)
                { throw new Exception(string.Format("Directory {0} does not exist, and could not be created.", outDir), ex); }
            }
            // html file path
            string htmlFilePath = Path.ChangeExtension(absOutputFilePath, "html");
            BuildAnalysisReport(inputData, ref rnRoot, absTemplatePath, htmlFilePath);

            PdfConvert.ConvertHtmlToPdf(new PdfDocument() { Url = htmlFilePath }, new PdfOutput() { OutputFilePath = absOutputFilePath });
        }
        public override bool WriteNamespace => false;
        public override bool WriteImageFiles => true;
    }

    #endregion

}
