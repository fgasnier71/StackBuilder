using System;
using treeDiM.StackBuilder.Basics;

namespace treeDiM.StackBuilder.Exporters
{
    [Serializable]
    public class ExceptionInvalidName : Exception
    { 
        public ExceptionInvalidName(string name)  {  Name = name; }
        public ExceptionInvalidName() {}
        public ExceptionInvalidName(string message, Exception innerException) : base(message, innerException) {}
        protected ExceptionInvalidName(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) {}
        public override string Message => $"No exporter found for name = {Name}";
        public string Name { get; set; }
    }

    [Serializable]
    public class ExceptionInvalidExtension : Exception
    {
        public ExceptionInvalidExtension(string extension)  {  Extension = extension; }
        public ExceptionInvalidExtension() { }
        public ExceptionInvalidExtension(string message, Exception innerException) : base(message, innerException) { }
        protected ExceptionInvalidExtension(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) { }
        public override string Message => $"No exporter found for extension = {Extension}";
        public string Extension { get; set; }
    }

    [Serializable]
    public class ExceptionUnexpectedAnalysisType : Exception
    {
        public ExceptionUnexpectedAnalysisType(Analysis analysis) { InputAnalysis = analysis; }
        public ExceptionUnexpectedAnalysisType() { }
        public ExceptionUnexpectedAnalysisType(string message, Exception innerException) : base(message, innerException) { }
        protected ExceptionUnexpectedAnalysisType(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) { }
        public override string Message => $"Unexpected analysis type = {InputAnalysis.GetType().ToString()}";
        public Analysis InputAnalysis { get; set; }
    }

    [Serializable]
    public class ExceptionTooManyItems : Exception
    {
        public ExceptionTooManyItems(string formatName, int noItems, int maxNoItems)  { FormatName = formatName; NoItems = noItems; MaxNoItems = maxNoItems; }
        public ExceptionTooManyItems() { }
        public ExceptionTooManyItems(string message, Exception innerException) : base(message, innerException) { }
        protected ExceptionTooManyItems(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) { }
        public override string Message => $"Format {FormatName} can only handle {MaxNoItems} < {NoItems}";
        public int NoItems { get; set; }
        public int MaxNoItems { get; set; }
        public string FormatName { get; set; }
    }
}
