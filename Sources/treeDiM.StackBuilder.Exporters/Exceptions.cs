using System;

namespace treeDiM.StackBuilder.Exporters
{
    public class ExceptionInvalidExtension : Exception
    {
        public ExceptionInvalidExtension(string extension)  {  Extension = extension; }
        public override string Message => string.Format("No exporter found for extension = {0}", Extension);
        public string Extension { get; set; }
    }
}
