#region Using directives
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.Basics;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    #region Strapper
    public class PalletStrapper
    {
        public int Axis { get; set; }
        public double Abscissa { get; set; }
        public double Width { get; set; }
        public Color Color { get; set; }
    }
    #endregion

    #region StrapperSetDir
    public class StrapperSetDir
    {
        public StrapperSetDir(int dir, double dimension) { Dir = dir; DimStored = dimension; }
        public PackableBrick Packable { get; set; }
        public int Dir { get; private set; }
        public bool EvenlySpaced { get; set; } = true;
        public int Number { get; private set; } = 0;
        public double Spacing { get; set; }
        public List<double> Abscissas = new List<double>();
        public double Dimension
        {
            get => Packable == null ? DimStored : Packable.Dimensions[Dir];
            set => DimStored = value;
        }
        public double DimStored { get; set; }
        public List<double> EvenlySpacedAbscissa
        {
            get
            {
                List<double> abs = new List<double>();
                int no = Number;
                if (0 != no)
                {
                    double sp = Spacing;
                    double length = Dimension;
                    double first = (length - (no - 1) * sp) / 2;

                    for (int i = 0; i < no; ++i)
                        abs.Add(first + i * sp);
                }
                return abs;
            }
        }
        public void SetNumber(int number)
        {
            if (number != Number)
                SetEvenlySpaced(number, ComputeIdealEvenSpace(number));
        }
        public void SetEvenlySpaced(int number, double space, bool vchecked = true)
        {
            EvenlySpaced = true;
            Number = number;
            if (number == 1)
                Spacing = 0.0;
            else if (vchecked && ((number - 1) * space >= Dimension))
                Spacing = MaximumEvenSpace;
            else
                Spacing = space;
        }
        public void SetUnevenlySpaced()
        {
            EvenlySpaced = false;
            Abscissas = EvenlySpacedAbscissa;
        }
        public void SetUnevenlySpaced(List<double> abs)
        {
            EvenlySpaced = false;
            Number = abs.Count;
            Abscissas = abs;
        }
        public double MaximumEvenSpace
        {
            get
            {
                if (Number > 1)
                    return Dimension / (Number - 1);
                else
                    return 0.5 * Dimension;
            }
        }
        public double IdealEvenSpace => ComputeIdealEvenSpace(Number);
        public OptDouble OptSpacing => new OptDouble(EvenlySpaced, Spacing);
        public List<double> ActualAbscissas
        {
            get
            {
                if (EvenlySpaced)
                    return EvenlySpacedAbscissa;
                else
                {
                    return Abscissas;
                }
            }
        }
        public StrapperSetDir Clone()
        {
            StrapperSetDir strapperSetDir = new StrapperSetDir(Dir, DimStored)
            {
                Packable = Packable,
                EvenlySpaced = EvenlySpaced,
                Number = Number,
                Spacing = Spacing
            };
            Abscissas.ForEach((item) => { strapperSetDir.Abscissas.Add(item); });
            return strapperSetDir;
        }
        #region Helpers
        private double ComputeIdealEvenSpace(int number)
        {
            if (number > 1)
                return Dimension / number;
            else
                return 0.5 * Dimension;
        }
        #endregion
    }
    #endregion

    #region StrapperSet
    public class StrapperSet
    {
        #region Constructors
        public StrapperSet()
        {
            Initialize(new double[3]{ 0.0, 0.0, 0.0 });
        }
        public StrapperSet(double[] dims)
        {
            Initialize( dims );
        }
        public StrapperSet(PackableBrick packable)
        {
            Initialize(new double[3] { 0.0, 0.0, 0.0 });
            Packable = packable;
        }
        #endregion

        #region Public properties
        public PackableBrick Packable
        {
            get { return strapperSetDirs[0].Packable; }
            set { for (int i = 0; i < 3; ++i) strapperSetDirs[i].Packable = value; }
        }
        public Color Color { get; set; } = Color.LightGray;
        public double Width { get; set; } = UnitsManager.ConvertLengthFrom(10.0, UnitsManager.UnitSystem.UNIT_METRIC1);
        public IEnumerable<PalletStrapper> Strappers
        {
            get
            {
                List<PalletStrapper> strappers = new List<PalletStrapper>();
                for (int dir = 0; dir < 3; ++dir)
                {
                    foreach (double d in strapperSetDirs[dir].ActualAbscissas)
                        strappers.Add(new PalletStrapper() { Abscissa = d, Axis = dir, Color = Color, Width = Width });
                }
                return strappers;
            }
        }
        #endregion

        #region Setting dimension
        public void SetDimension(double length, double width, double height)
        {
            strapperSetDirs[0].DimStored = length;
            strapperSetDirs[1].DimStored = width;
            strapperSetDirs[2].DimStored = height;
        }
        public void SetDimension(Vector3D dim)
        {
            strapperSetDirs[0].DimStored = dim.X;
            strapperSetDirs[1].DimStored = dim.Y;
            strapperSetDirs[2].DimStored = dim.Z;
        }
        public void SetDimension(double[] dim)
        {
            strapperSetDirs[0].DimStored = dim[0];
            strapperSetDirs[1].DimStored = dim[1];
            strapperSetDirs[2].DimStored = dim[2];
        }
        #endregion

        #region Setting number / spacing
        public void SetNumber(int dir, int number)
        {
            if (number != strapperSetDirs[dir].Number)
                strapperSetDirs[dir].SetNumber(number);
        }
        public int GetNumber(int dir) => strapperSetDirs[dir].Number;
        public void SetEvenlySpaced(int dir, int number, double space, bool vchecked = true)
        {
            strapperSetDirs[dir].SetEvenlySpaced(number, space, vchecked);
        }
        public void SetUnevenlySpaced(int dir, List<double> abs)
        {
            strapperSetDirs[dir].SetUnevenlySpaced(abs);
        }
        public void GetStrapperByDirection(int dir, ref int number, ref bool evenSpaced, ref double space, ref List<double> abs)
        {
            number = strapperSetDirs[dir].Number;
            evenSpaced = strapperSetDirs[dir].EvenlySpaced;
            space = strapperSetDirs[dir].Spacing;
            abs = strapperSetDirs[dir].ActualAbscissas;
        }
        public OptDouble GetSpacing(int dir)
        {
            return strapperSetDirs[dir].OptSpacing;
        }
        public List<double> ActualAbscissa(int dir)
        {
            return strapperSetDirs[dir].ActualAbscissas;
        }
        #endregion

        #region Clone method
        public StrapperSet Clone()
        {
            var strapperSet = new StrapperSet()  { Color = Color, Width = Width };
            for (int i = 0; i < 3; ++i)
                strapperSet.strapperSetDirs[i] = strapperSetDirs[i].Clone();
            return strapperSet;
        }
        #endregion

        #region Private methods
        private void Initialize(double[] dim)
        {
            for (int i = 0; i < 3; ++i)
                strapperSetDirs[i] = new StrapperSetDir(i, dim[i]);
        }
        #endregion

        #region Data members
        private readonly StrapperSetDir[] strapperSetDirs = new StrapperSetDir[3];
        #endregion
    }
    #endregion
}
