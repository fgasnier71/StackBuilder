public class PalletDetails
{
	public PalletDetails(string name, string value, string unit)
	{
		Name = name; Value = value; Unit = unit;
	}
	public string Name { get; set; }
	public string Value { get; set; }
	public string Unit { get; set; }
	public string ValueUnit => string.IsNullOrEmpty(Unit) ? Value : $"{Value} ({Unit})";
}
