namespace treeDiM.StackBuilder.TechnologyBSA_ASPNET
{
    public class LayerDetails
    {
        public LayerDetails(string name, string layerDesc, int noCasesPerLayer, int noLayers, double length, double width, double height)
        {
            Name = name;
            LayerDesc = layerDesc;
            NoCasesPerLayer = noCasesPerLayer;
            NoLayers = noLayers;
            Length = length;
            Width = width;
            Height = height;
        }
        public string Name { get; set; }
        public int NoLayers { get; set; }
        public int NoCasesPerLayer { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int NoCases => NoLayers * NoCasesPerLayer;
        public string LayerDesc { get; set; }
        public string Dimensions => $"{Length}x{Width}x{Height}";
    }
}
