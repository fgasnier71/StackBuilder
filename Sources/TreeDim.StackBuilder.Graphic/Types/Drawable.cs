#region Using directives
using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public abstract class Drawable
    {
        // 3D
        public virtual void DrawBegin(Graphics3D graphics) { }
        public abstract void Draw(Graphics3D graphics);
        public virtual void DrawEnd(Graphics3D graphics) { }
        public virtual Vector3D[] Points { get { return null; } }        
        public BBox3D GetBBox(Transform3D transf)
        {
            BBox3D bbox = new BBox3D();
            foreach (var pt in Points)
                bbox.Extend(transf.transform(pt));
            return bbox;
        }
        // 3D wireframe
        public virtual void DrawWireframe(Graphics3D graphics) { }
        // 2D
        public virtual void Draw(Graphics2D graphics) { }
    }
}
