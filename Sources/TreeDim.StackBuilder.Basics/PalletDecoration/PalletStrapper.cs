using System.Collections.Generic;

using Sharp3D.Math.Geometry3D;
using Sharp3D.Math.Core;
using MIConvexHull;

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
            Sharp3D.Math.Geometry3D.Pl
            
        }

        private void BuildHull(List<Vector2D> v)
        {
            var vertices = new Vertex[v.Count];
            for (var i = 0; i < v.Count; i++)
                vertices[i] = new Vertex(v[i].X, v[i].Y);
            var convexHull = ConvexHull.Create(vertices).Result.Points;

            foreach (var pt in convexHull)
                _points.Add(new Vector2D(pt.Position[0], pt.Position[1]));
        }

        #region Data members
        public List<Vector2D> _points = new List<Vector2D>();
        #endregion
    }

    #region Vertex
    /// <summary>
    /// A vertex is a simple class that stores the postion of a point, node or vertex.
    /// </summary>
    public class Vertex : IVertex
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vertex"/> class.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        public Vertex(double x, double y)
        {
            Position = new double[2] { x, y };
        }

        public double[] Position { get; set; }
    }
    #endregion
}
