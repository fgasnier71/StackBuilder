namespace treeDiM.StackBuilder.TechnologyBSA_ASPNET
{
    public class InterlayerDetails
    {
        public InterlayerDetails(string name, bool activated)
        {
            Name = name;
            Activated = activated;
        }

        public string Name { get; set; }
        public bool Activated { get; set; }
    }
}