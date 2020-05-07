namespace treeDiM.StackBuilder.TechnologyBSA_ASPNET
{
    public class PalletDetails
    {
        public PalletDetails(string name, string value, string unit)
        {
            Name = name; Value = value; Unit = unit;
        }

        public string Name { get; }
        public string Value { get; }
        public string Unit { get; }
        public string ValueUnit => string.IsNullOrEmpty(Unit) ? Value : $"{Value} ({Unit})";
    }
}
