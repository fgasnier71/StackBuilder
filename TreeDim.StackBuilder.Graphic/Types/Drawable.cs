#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public abstract class Drawable
    {
        // 3D
        public virtual void DrawBegin(Graphics3D graphics) { }
        public abstract void Draw(Graphics3D graphics);
        public virtual void DrawEnd(Graphics3D graphics) { }
        // 2D
        public virtual void Draw(Graphics2D graphics) { }
    }
}
