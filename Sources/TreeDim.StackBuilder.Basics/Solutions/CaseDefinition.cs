using Sharp3D.Math.Core;

using treeDiM.Basics;

namespace treeDiM.StackBuilder.Basics
{
    public class CaseDefinition
    {
        /// <summary>
        /// Case definition constructor
        /// </summary>
        /// <param name="arrangement">Box arrangement</param>
        /// <param name="dim0">Dim 0 is 0, 1 or 2</param>
        /// <param name="dim1">Dim 1 is 0, 1 or 2</param>
        public CaseDefinition(PackArrangement arrangement, int dim0, int dim1)
        {
            _arrangement = arrangement;
            _dim0 = dim0;
            _dim1 = dim1;
        }

        public PackArrangement Arrangement => _arrangement;
        public int Dim0 { get { return _dim0; } }
        public int Dim1 { get { return _dim1; } }
        public int Dim2 { get { return 3 - _dim0 - _dim1; } }

        public double BoxLength(PackableBrick packable) => packable.Dim(_dim0);
        public double BoxWidth(PackableBrick packable) => packable.Dim(_dim1);
        public double BoxHeight(PackableBrick packable) => packable.Dim(Dim2);
        public double Area(PackableBrick packable, ParamSetPackOptim constraintSet)
        {
            Vector3D outerDim = OuterDimensions(packable, constraintSet);
            return (constraintSet.NoWrapperWalls[0] * outerDim.Y * outerDim.Z
                + constraintSet.NoWrapperWalls[1] * outerDim.X * outerDim.Z
                + constraintSet.NoWrapperWalls[2] * outerDim.X * outerDim.Y) * UnitsManager.FactorSquareLengthToArea;
        }
        public double InnerVolume(PackableBrick packable)
        {
            Vector3D innerDim = InnerDimensions(packable);
            return innerDim.X * innerDim.Y * innerDim.Z;
        }
        public double OuterVolume(PackableBrick packable, ParamSetPackOptim constraintSet)
        {
            Vector3D outerDim = OuterDimensions(packable, constraintSet);
            return outerDim.X * outerDim.Y * outerDim.Z;
        }
        public double EmptyWeight(PackableBrick packable, ParamSetPackOptim constraintSet)
        {
            return Area(packable, constraintSet) * constraintSet.WrapperSurfMass;
        }
        public double InnerWeight(PackableBrick packable)
        {
            return _arrangement.Number * packable.Weight;
        }
        public double TotalWeight(PackableBrick packable, ParamSetPackOptim constraintSet)
        {
            return InnerWeight(packable) + EmptyWeight(packable, constraintSet);
        }

        /// <summary>
        /// Inner dimensions
        /// </summary>
        /// <param name="optimizer">Parent optimizer class</param>
        /// <returns>Inner dimensions stored in Vector3D</returns>
        public Vector3D InnerDimensions(PackableBrick packBrick)
        {
            return new Vector3D(
                _arrangement.Length * packBrick.Dim(Dim0)
                , _arrangement.Width * packBrick.Dim(Dim1)
                , _arrangement.Height * packBrick.Dim(Dim2)
                );
        }
        /// <summary>
        ///  Outer dimensions
        /// </summary>
        /// <param name="optimizer">Parent optimizer class</param>
        /// <returns>Outer dimensions stored in Vector3D</returns>
        public Vector3D OuterDimensions(PackableBrick packBrick, ParamSetPackOptim paramSet)
        {
            return new Vector3D(
                _arrangement.Length * packBrick.Dim(Dim0) + paramSet.WrapperThickness * paramSet.NoWrapperWalls[0]
                , _arrangement.Width * packBrick.Dim(Dim1) + paramSet.WrapperThickness * paramSet.NoWrapperWalls[1]
                , _arrangement.Height * packBrick.Dim(Dim2) + paramSet.WrapperThickness * paramSet.NoWrapperWalls[2]
                );
        }
        public Vector3D InnerOffset(ParamSetPackOptim paramSet)
        {
            return new Vector3D(
                0.5 * paramSet.WrapperThickness * paramSet.NoWrapperWalls[0]
                , 0.5 * paramSet.WrapperThickness * paramSet.NoWrapperWalls[1]
                , 0.5 * paramSet.WrapperThickness * paramSet.NoWrapperWalls[2]);
        }

        public double CaseEmptyWeight(PackableBrick boxProperties, ParamSetPackOptim paramSet)
        {
            return paramSet.WrapperSurfMass * Area(boxProperties, paramSet);
        }

        /// <summary>
        /// Returns true 
        /// </summary>
        /// <param name="optimizer"></param>
        /// <returns></returns>
        public bool IsValid(PackableBrick packable, ParamSetPackOptim paramSet)
        {
            Vector3D outerDim = OuterDimensions(packable, paramSet);
            return outerDim.X <= paramSet.CaseLimitMax.X && outerDim.Y <= paramSet.CaseLimitMax.Y && outerDim.Z <= paramSet.CaseLimitMax.Z
                && outerDim.X >= paramSet.CaseLimitMin.X && outerDim.Y >= paramSet.CaseLimitMin.Y && outerDim.Z >= paramSet.CaseLimitMin.Z
                && ((_dim0 == 0 && _dim1 == 1) || !paramSet.ForceVerticalcaseOrientation);
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendFormat("{0} / ({1}, {2}, {3})", _arrangement, Dim0, Dim1, Dim2);
            return sb.ToString();
        }

        #region Non-Public Members

        private PackArrangement _arrangement;
        private int _dim0, _dim1;

        #endregion
    }
}
