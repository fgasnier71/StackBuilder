using System;
using System.Collections.Generic;
using System.IO;

namespace Sharp3D.Boxologic
{
    public class BoxItem
    {
        public int Boxx { get; set; }
        public int Boxy { get; set; }
        public int Boxz { get; set; }
        public int N { get; set; }
        public int ID { get; set; }
    }

    public class St_instance
    {
        public long Dim1 { get; set; }
        public long Dim2 { get; set; }
        public long Dim3 { get; set; }
        public long Packx { get; set; }
        public long Packy { get; set; }
        public long Packz { get; set; }
        public long Vol => Dim1 * Dim2 * Dim3;
    }

    public class Cuboid : St_instance
    {
        public void SetPacked(long cboxx, long cboxy, long cboxz)
        {
            Is_packed = true;
            Packx = cboxx;
            Packy = cboxy;
            Packz = cboxz;
        }
        public bool Is_packed { get; set; }
        public long Cox { get; set; }
        public long Coy { get; set; }
        public long Coz { get; set; }
        public int N { get; set; }
        public int ID { get; set; }
        public void Write(int index)
        {
            if (Is_packed)
                Console.WriteLine(string.Format("{0,5:D}{1,5:D}{2,5:D}{3,5:D}{4,5:D}{5,5:D}{6,5:D}", index, Cox, Coy, Coz, Packx, Packy, Packz));
            else
                Console.WriteLine(string.Format("{0,5:D}{1,5:D}{2,5:D}{3,5:D}", index, Cox, Coy, Coz));
        }
        public void WriteToFile(StreamWriter file, int variant, int index)
        {
            long x=0, y=0, z=0, bx=0, by=0, bz=0;
            switch (variant)
            {
                case 1:
                    x = Cox;
                    y = Coy;
                    z = Coz;
                    bx = Packx;
                    by = Packy;
                    bz = Packz;
                    break;
                case 2:
                    x = Coz;
                    y = Coy;
                    z = Cox;
                    bx = Packz;
                    by = Packy;
                    bz = Packx;
                    break;
                case 3:
                    x = Coy;
                    y = Coz;
                    z = Cox;
                    bx = Packy;
                    by = Packz;
                    bz = Packx;
                    break;
                case 4:
                    x = Coy;
                    y = Cox;
                    z = Coz;
                    bx = Packy;
                    by = Packx;
                    bz = Packz;
                    break;
                case 5:
                    x = Cox;
                    y = Coz;
                    z = Coy;
                    bx = Packx;
                    by = Packz;
                    bz = Packy;
                    break;
                case 6:
                    x = Coz;
                    y = Cox;
                    z = Coy;
                    bx = Packz;
                    by = Packx;
                    bz = Packy;
                    break;
                default:
                    break;
            }
            file.WriteLine(
                string.Format(
                "{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}",
                index,
                Is_packed ? 1 : 0,
                Dim1, Dim2, Dim3,
                x, y, z,
                bx, by, bz
                )
                );
            Cox = x;
            Coy = y;
            Coz = z;
            Packx = bx;
            Packy = by;
            Packz = bz;
        }

        public SolItem ToSolItem(int variant)
        {
            long x = 0, y = 0, z = 0, bx = 0, by = 0, bz = 0;
            switch (variant)
            {
                case 1:
                    x = Cox;
                    y = Coy;
                    z = Coz;
                    bx = Packx;
                    by = Packy;
                    bz = Packz;
                    break;
                case 2:
                    x = Coz;
                    y = Coy;
                    z = Cox;
                    bx = Packz;
                    by = Packy;
                    bz = Packx;
                    break;
                case 3:
                    x = Coy;
                    y = Coz;
                    z = Cox;
                    bx = Packy;
                    by = Packz;
                    bz = Packx;
                    break;
                case 4:
                    x = Coy;
                    y = Cox;
                    z = Coz;
                    bx = Packy;
                    by = Packx;
                    bz = Packz;
                    break;
                case 5:
                    x = Cox;
                    y = Coz;
                    z = Coy;
                    bx = Packx;
                    by = Packz;
                    bz = Packy;
                    break;
                case 6:
                    x = Coz;
                    y = Cox;
                    z = Coy;
                    bx = Packz;
                    by = Packx;
                    bz = Packy;
                    break;
                default:
                    break;
            }

            return new SolItem()
            {
                Id = ID 
                , X = x, Y = y, Z = z
                , BX = bx, BY = by, BZ = bz
                , DimX = Dim1, DimY = Dim2, DimZ = Dim3
            };
        }
    }

    public class PalletInfo : St_instance
    {
        public PalletInfo(int dim1, int dim2, int dim3)
        { Dim1 = dim1; Dim2 = dim2; Dim3 = dim3; }
        public int Variant { get; set; }
        public long Pallet_x
        {
            get
            {
                switch (Variant)
                {
                    case 1: return Dim1;
                    case 2: return Dim3;
                    case 3: return Dim3;
                    case 4: return Dim2;
                    case 5: return Dim1;
                    case 6: return Dim2;
                    default: return 0;
                }
            }
        }
        public long Pallet_y
        {
            get
            {
                switch (Variant)
                {
                    case 1: return Dim2;
                    case 2: return Dim2;
                    case 3: return Dim1;
                    case 4: return Dim1;
                    case 5: return Dim3;
                    case 6: return Dim3;
                    default: return 0;
                }
            }
        }
        public long Pallet_z
        {
            get
            {
                switch (Variant)
                {
                    case 1: return Dim3;
                    case 2: return Dim1;
                    case 3: return Dim2;
                    case 4: return Dim3;
                    case 5: return Dim2;
                    case 6: return Dim1;
                    default: return 0;
                }
            }
        }
    }

    public class Layer
    {
        public Layer() { }
        public Layer(int leval, int ldim) { LayerEval = leval; LayerDim = ldim; }
        public long LayerEval { get; set; }
        public long LayerDim { get; set; }
        public override string ToString()
        {
            return string.Format("{0,5:D}, {1,5:D}", LayerDim, LayerEval);
        }
    }

    public class LayerComparer : IComparer<Layer>
    {
        public int Compare(Layer layer0, Layer layer1)
        {
            if (layer0.LayerEval > layer1.LayerEval) return 1;
            else if (layer0.LayerEval < layer1.LayerEval) return -1;
            else return 0;
        }
    }

    public class Scrappad
    {
        public Scrappad() { }
        public Scrappad prev, next;
        public long Cumx { get; set; }
        public long Cumz { get; set; }
    }

}
