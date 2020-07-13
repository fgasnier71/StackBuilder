#region Using directives
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    class BoxRounded : BoxGeneric
    {
        #region Constructors
        public BoxRounded(uint pickId, double length, double width, double height, BoxPosition position)
            : base(pickId, length, width, height, position)
        {
        }
        #endregion
        #region Override drawable
        public override void Draw(Graphics3D graphics)
        {
            
        }
        #endregion

        #region Data members
        #endregion
    }
}
