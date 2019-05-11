#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics.PalletDecoration
{
    class PalletStrapper
    {
        public void Clear()
        {
            _points.Clear();
        }

        private void ComputePoints()
        {           
        }

        private void BuildHull(List<Vector2D> v)
        {
            /*
            var vertices = new Vertex[v.Count];
            for (var i = 0; i < v.Count; i++)
                vertices[i] = new Vertex(v[i].X, v[i].Y);
            var convexHull = ConvexHull.Create(vertices).Result.Points;

            foreach (var pt in convexHull)
                _points.Add(new Vector2D(pt.Position[0], pt.Position[1]));
            */
        }

        #region Data members
        public List<Vector2D> _points = new List<Vector2D>();
        #endregion
    }
}
