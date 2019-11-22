using System;
using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Exporters
{
    public class ExceptionInvalidExtension : Exception
    {
        public ExceptionInvalidExtension(string extension)  {  Extension = extension; }
        public override string Message => $"No exporter found for extension = {Extension}";
        public string Extension { get; set; }
    }

    public class ExceptionUnexpectedAnalysisType : Exception
    {
        public ExceptionUnexpectedAnalysisType(AnalysisLayered analysis) { InputAnalysis = analysis; }
        public override string Message => $"Unexpected analysis type = {InputAnalysis.GetType().ToString()}";
        public AnalysisLayered InputAnalysis { get; set; }
    }
}
