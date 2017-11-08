using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxologic.CSharp
{
    public class BoxItem
    {
        public double Boxx { get; set; }
        public double Boxy { get; set; }
        public double Boxz { get; set; }
        public int N { get; set; }
    }

    public class St_instance
    {
        public double Dim1 { get; set; }
        public double Dim2 { get; set; }
        public double Dim3 { get; set; }
        public int Packx { get; set; }
        public int Packy { get; set; }
        public int Packz { get; set; }
        public double Vol => Dim1 * Dim2 * Dim3;
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
        public Pallet(double dim1, double dim2, double dim3)
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
        public Scrappad prev, next;
        public double cumx { get; set; }
        public double cumz { get; set; }
    }

}
