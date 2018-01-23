using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Exporters
{
    public abstract class Exporter
    {
        public abstract void Export(Analysis analysis, string filePath);
        public abstract string Filter { get; }
        public abstract string Extension { get; }
    }

    public class ExporterFactory
    {
        static Exporter[] All { get => new Exporter[] { new ExporterCollada(), new ExporterXML(), new ExporterCSV(), new ExporterJSON() }; }
        public static Exporter GetExporterByExt(string extension)
        {
            foreach (Exporter exp in All)
            {
                if (string.Equals(exp.Extension, extension, System.StringComparison.CurrentCultureIgnoreCase))
                    return exp;
            }
            throw new ExceptionInvalidExtension(extension);
        }
    }
}
