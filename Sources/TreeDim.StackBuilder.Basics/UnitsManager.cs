#region Using directives
using Cureos.Measures;
using Cureos.Measures.Quantities;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.Basics
{
    public partial class UnitsManagerEx
    {

        public static Vector2D ConvertLengthFrom(Vector2D value, UnitsManager.UnitSystem unitSystem)
        {
            if (unitSystem == UnitsManager.CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Length> measureX = new StandardMeasure<Length>(value.X, UnitsManager.LengthUnitFromUnitSystem(unitSystem));
                StandardMeasure<Length> measureY = new StandardMeasure<Length>(value.Y, UnitsManager.LengthUnitFromUnitSystem(unitSystem));
                return new Vector2D(
                    measureX.GetAmount(UnitsManager.LengthUnitFromUnitSystem(UnitsManager.CurrentUnitSystem))
                    , measureY.GetAmount(UnitsManager.LengthUnitFromUnitSystem(UnitsManager.CurrentUnitSystem))
                    );
            }        
        }
        public static Vector3D ConvertLengthFrom(Vector3D value, UnitsManager.UnitSystem unitSystem)
        {
            if (unitSystem == UnitsManager.CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Length> measureX = new StandardMeasure<Length>(value.X, UnitsManager.LengthUnitFromUnitSystem(unitSystem));
                StandardMeasure<Length> measureY = new StandardMeasure<Length>(value.Y, UnitsManager.LengthUnitFromUnitSystem(unitSystem));
                StandardMeasure<Length> measureZ = new StandardMeasure<Length>(value.Z, UnitsManager.LengthUnitFromUnitSystem(unitSystem));
                return new Vector3D(
                    measureX.GetAmount(UnitsManager.LengthUnitFromUnitSystem(UnitsManager.CurrentUnitSystem))
                    , measureY.GetAmount(UnitsManager.LengthUnitFromUnitSystem(UnitsManager.CurrentUnitSystem))
                    , measureZ.GetAmount(UnitsManager.LengthUnitFromUnitSystem(UnitsManager.CurrentUnitSystem))
                    );
            }
        }
        public static BoxPosition ConvertLengthFrom(BoxPosition value, UnitsManager.UnitSystem unitSystem)
        {
            if (unitSystem == UnitsManager.CurrentUnitSystem)
                return value;
            else
                return new BoxPosition(
                    ConvertLengthFrom(value.Position, unitSystem), value.DirectionLength, value.DirectionWidth);
        }
    }
}
