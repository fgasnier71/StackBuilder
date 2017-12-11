using System.Collections.Generic;

namespace Boxologic.CSharp
{
    public class BoxItem
    {
        public int Boxx { get; set; }
        public int Boxy { get; set; }
        public int Boxz { get; set; }
        public int N { get; set; }
    }

    public class St_instance
    {
        public int Dim1 { get; set; }
        public int Dim2 { get; set; }
        public int Dim3 { get; set; }
        public int Packx { get; set; }
        public int Packy { get; set; }
        public int Packz { get; set; }
        public int Vol => Dim1 * Dim2 * Dim3;
    }

    public class BoxInfo : St_instance
    {
        public bool Is_packed { get; set; }
        public int Cox { get; set; }
        public int Coy { get; set; }
        public int Coz { get; set; }
        public int N { get; set; }
    }

    public class Pallet : St_instance
    {
        public Pallet(int dim1, int dim2, int dim3)
        { Dim1 = dim1; Dim2 = dim2; Dim3 = dim3; }
        public int Orientation { get; set; }
        public double LayoutLength
        {
            get
            {
                switch (Orientation)
                {
                    case 0: return Dim1;
                    case 1: return Dim2;
                    case 2: return Dim3;
                    case 3: return Dim1;
                    case 4: return Dim3;
                    case 5: return Dim2;
                    default: return 0.0;
                }
            }
        }
        public double LayoutWidth
        {
            get
            {
                switch (Orientation)
                {
                    case 0: return Dim2;
                    case 1: return Dim1;
                    case 2: return Dim1;
                    case 3: return Dim3;
                    case 4: return Dim2;
                    case 5: return Dim3;
                    default: return 0.0;
                }
            }
        }
        public double LayoutHeight
        {
            get
            {
                switch (Orientation)
                {
                    case 0: return Dim3;
                    case 1: return Dim3;
                    case 2: return Dim2;
                    case 3: return Dim2;
                    case 4: return Dim1;
                    case 5: return Dim1;
                    default: return 0.0;
                }
            }
        }
    }

    public class Layer
    {
        public double LayerEval { get; set; }
        public double LayerDim { get; set; }
    }

    public class LayerComparer : IComparer<Layer>
    {
        public int Compare(Layer layer0, Layer layer1)
        {
            if (layer0.LayerDim < layer1.LayerDim) return 1;
            else if (layer1.LayerDim < layer0.LayerDim) return -1;
            else return 0;
        }
    }

    public class Scrappad
    {
        public Scrappad() { }
        public Scrappad prev, next;
        public double cumx { get; set; }
        public double cumz { get; set; }
    }

}
