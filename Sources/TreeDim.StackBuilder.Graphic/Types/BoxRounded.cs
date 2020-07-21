#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    internal class Tri
    {
        public Tri(int i0, int i1, int i2) { _indices[0] = i0; _indices[1] = i1; _indices[2] = i2; }
        public int this[int i] => _indices[i];
        private int[] _indices = new int[3];
    }

    public class BoxRounded : BoxGeneric
    {
        #region Constructors
        public BoxRounded(uint pickId, double length, double width, double height, double radius, BoxPosition position)
            : base(pickId, length, width, height, position)
        {
            Create(5, 0.5 * new Vector3D(length, width, height) - new Vector3D(radius, radius, radius),  radius);
        }
        public BoxRounded(uint pickId, BagProperties bagProperties, BoxPosition position)
            : base(pickId, bagProperties.Length, bagProperties.Width, bagProperties.Height, position)
        {
            Create(5, 0.5 * bagProperties.OuterDimensions - new Vector3D(bagProperties.Radius, bagProperties.Radius, bagProperties.Radius), bagProperties.Radius);
            ColorFill = bagProperties.ColorFill;
        }
        #endregion

        #region Public properties
        public Color ColorPath => Color.Black;
        public Color ColorFill { get; set; } = Color.Gray;
        #endregion

        #region Override drawable
        public override void Draw(Graphics3D graphics)
        {
            System.Drawing.Graphics g = graphics.Graphics;
            Vector3D viewDir = graphics.ViewDirection;
            Vector3D offset = new Vector3D(0.5 * Length, 0.5 * Width, 0.5 * Height);

            // draw all triangles
            foreach (var tri in indices)
            {
                try
                {
                    Vector3D[] pts = new Vector3D[3];
                    Vector3D normal = Vector3D.Zero;
                    for (int i = 0; i < 3; ++i)
                    {
                        normal += normals[tri[i]];
                        pts[i] = offset + vertices[tri[i]];
                    }
                    normal /= 3;

                    // visible ?
                    if (Vector3D.DotProduct(viewDir, normal) > 0)
                        continue;

                    // draw polygon
                    Point[] ptsTri = graphics.TransformPoint(pts);
                    g.FillPolygon(new SolidBrush(ColorGraph(graphics, normal)), ptsTri);
                }
                catch (Exception /*ex*/)
                {
                }
            }
        }
        public Color ColorGraph(Graphics3D graphics, Vector3D normal)
        {
            double cosA = Math.Abs(Vector3D.DotProduct(normal, graphics.VLight));
            if (cosA < 0 || cosA > 1) cosA = 1.0;
            return Color.FromArgb((int)(ColorFill.R * cosA), (int)(ColorFill.G * cosA), (int)(ColorFill.B * cosA));
        }
        #endregion

        #region Private mesh creation methods
        private void AddVertex(int i, int j, int k, Vector3D pos, Vector3D base_pos)
        {
            int pidx = k * m_N_edge * m_N_edge + j * m_N_edge + i;
            if (m_index_to_verts[pidx] < 0)
            {
                int next_idx = vertices.Count;
                m_index_to_verts[pidx] = next_idx;

                Vector3D dir = pos - base_pos;
                if (dir.GetLength() > 0.0)
                {
                    dir.Normalize();
                    vertices.Add(base_pos + dir * m_radius);
                    normals.Add(dir);
                }
                else
                {
                    vertices.Add(pos);
                    pos.Normalize();
                    normals.Add(pos);
                }
            }
        }
        private int translateIndices(int i, int j, int k)
        {
            int pidx = k * m_N_edge * m_N_edge + j * m_N_edge + i;
            return m_index_to_verts[pidx];
        }
        private void AddFace(int i, int j, int k, bool inversed)
        {
            if (inversed)
                indices.Add(new Tri(i, k, j));
            else
                indices.Add(new Tri(i, j, k));
        }

        private void Create(int N, Vector3D b, double radius)
        {
            int N_edge = 2 * (N + 1);
            m_N_edge = N_edge;
            while (m_index_to_verts.Count < N_edge * N_edge * N_edge)
                m_index_to_verts.Add(-1);
            m_radius = radius;
            double dx = radius / N;

            double[] sign = new double[2] { -1.0, 1.0 };
            int[] ks = new int[2] { 0, N * 2 + 1 };

            // xy-planes
            for (int kidx = 0; kidx < 2; ++kidx)
            {
                int k = ks[kidx];
                Vector3D origin = new Vector3D(-b[0] - radius, -b[1] - radius, (b[2] + radius) * sign[kidx]);
                for (int j = 0; j <= N; ++j)
                    for (int i = 0; i <= N; ++i)
                    {
                        Vector3D pos = origin + new Vector3D(dx * i, dx * j, 0.0);
                        AddVertex(i, j, k, pos, new Vector3D(-b[0], -b[1], b[2] * sign[kidx]));

                        pos = origin + new Vector3D(dx * i + 2.0 * b[0] + radius, dx * j, 0.0);
                        AddVertex(i + N + 1, j, k, pos, new Vector3D(b[0], -b[1], b[2] * sign[kidx]));

                        pos = origin + new Vector3D(dx * i + 2.0 * b[0] + radius, dx * j + 2.0 * b[1] + radius, 0.0);
                        AddVertex(i + N + 1, j + N + 1, k, pos, new Vector3D(b[0], b[1], b[2] * sign[kidx]));

                        pos = origin + new Vector3D(dx * i, dx * j + 2.0 * b[1] + radius, 0.0);
                        AddVertex(i, j + N + 1, k, pos, new Vector3D(-b[0], b[1], b[2] * sign[kidx]));
                    }
                // corners
                for (int j = 0; j < N; ++j)
                    for (int i = 0; i < N; ++i)
                    {
                        AddFace(translateIndices(i, j, k),
                                translateIndices(i + 1, j + 1, k),
                                translateIndices(i, j + 1, k), kidx == 0);
                        AddFace(translateIndices(i, j, k),
                                translateIndices(i + 1, j, k),
                                translateIndices(i + 1, j + 1, k), kidx == 0);

                        AddFace(translateIndices(i, j + N + 1, k),
                                translateIndices(i + 1, j + N + 2, k),
                                translateIndices(i, j + N + 2, k), kidx == 0);
                        AddFace(translateIndices(i, j + N + 1, k),
                                translateIndices(i + 1, j + N + 1, k),
                                translateIndices(i + 1, j + N + 2, k), kidx == 0);

                        AddFace(translateIndices(i + N + 1, j + N + 1, k),
                                translateIndices(i + N + 2, j + N + 2, k),
                                translateIndices(i + N + 1, j + N + 2, k), kidx == 0);
                        AddFace(translateIndices(i + N + 1, j + N + 1, k),
                                translateIndices(i + N + 2, j + N + 1, k),
                                translateIndices(i + N + 2, j + N + 2, k), kidx == 0);

                        AddFace(translateIndices(i + N + 1, j, k),
                                translateIndices(i + N + 2, j + 1, k),
                                translateIndices(i + N + 1, j + 1, k), kidx == 0);
                        AddFace(translateIndices(i + N + 1, j, k),
                                translateIndices(i + N + 2, j, k),
                                translateIndices(i + N + 2, j + 1, k), kidx == 0);
                    }
                // sides
                for (int i = 0; i < N; ++i)
                {
                    AddFace(translateIndices(i, N, k),
                            translateIndices(i + 1, N + 1, k),
                            translateIndices(i, N + 1, k), kidx == 0);
                    AddFace(translateIndices(i, N, k),
                            translateIndices(i + 1, N, k),
                            translateIndices(i + 1, N + 1, k), kidx == 0);

                    AddFace(translateIndices(N, i, k),
                            translateIndices(N + 1, i + 1, k),
                            translateIndices(N, i + 1, k), kidx == 0);
                    AddFace(translateIndices(N, i, k),
                            translateIndices(N + 1, i, k),
                            translateIndices(N + 1, i + 1, k), kidx == 0);

                    AddFace(translateIndices(i + N + 1, N, k),
                            translateIndices(i + N + 2, N + 1, k),
                            translateIndices(i + N + 1, N + 1, k), kidx == 0);
                    AddFace(translateIndices(i + N + 1, N, k),
                            translateIndices(i + N + 2, N, k),
                            translateIndices(i + N + 2, N + 1, k), kidx == 0);

                    AddFace(translateIndices(N, i + N + 1, k),
                            translateIndices(N + 1, i + N + 2, k),
                            translateIndices(N, i + N + 2, k), kidx == 0);
                    AddFace(translateIndices(N, i + N + 1, k),
                            translateIndices(N + 1, i + N + 1, k),
                            translateIndices(N + 1, i + N + 2, k), kidx == 0);
                }
                // central
                AddFace(translateIndices(N, N, k),
                        translateIndices(N + 1, N + 1, k),
                        translateIndices(N, N + 1, k), kidx == 0);
                AddFace(translateIndices(N, N, k),
                        translateIndices(N + 1, N, k),
                        translateIndices(N + 1, N + 1, k), kidx == 0);
            }

            // xz-planes
            for (int kidx = 0; kidx < 2; ++kidx)
            {
                int k = ks[kidx];
                Vector3D origin = new Vector3D(-b[0] - radius, (b[1] + radius) * sign[kidx], -b[2] - radius);
                for (int j = 0; j <= N; ++j)
                    for (int i = 0; i <= N; ++i)
                    {
                        Vector3D pos = origin + new Vector3D(dx * i, 0.0, dx * j);
                        AddVertex(i, k, j, pos, new Vector3D(-b[0], b[1] * sign[kidx], -b[2]));

                        pos = origin + new Vector3D(dx * i + 2.0 * b[0] + radius, 0.0, dx * j);
                        AddVertex(i + N + 1, k, j, pos, new Vector3D(b[0], b[1] * sign[kidx], -b[2]));

                        pos = origin + new Vector3D(dx * i + 2.0 * b[0] + radius, 0.0, dx * j + 2.0 * b[2] + radius);
                        AddVertex(i + N + 1, k, j + N + 1, pos, new Vector3D(b[0], b[1] * sign[kidx], b[2]));

                        pos = origin + new Vector3D(dx * i, 0.0, dx * j + 2.0 * b[2] + radius);
                        AddVertex(i, k, j + N + 1, pos, new Vector3D(-b[0], b[1] * sign[kidx], b[2]));
                    }
                // corners
                for (int j = 0; j < N; ++j)
                    for (int i = 0; i < N; ++i)
                    {
                        AddFace(translateIndices(i, k, j),
                                translateIndices(i + 1, k, j + 1),
                                translateIndices(i, k, j + 1), kidx == 1);
                        AddFace(translateIndices(i, k, j),
                                translateIndices(i + 1, k, j),
                                translateIndices(i + 1, k, j + 1), kidx == 1);

                        AddFace(translateIndices(i, k, j + N + 1),
                                translateIndices(i + 1, k, j + N + 2),
                                translateIndices(i, k, j + N + 2), kidx == 1);
                        AddFace(translateIndices(i, k, j + N + 1),
                                translateIndices(i + 1, k, j + N + 1),
                                translateIndices(i + 1, k, j + N + 2), kidx == 1);

                        AddFace(translateIndices(i + N + 1, k, j + N + 1),
                                translateIndices(i + N + 2, k, j + N + 2),
                                translateIndices(i + N + 1, k, j + N + 2), kidx == 1);
                        AddFace(translateIndices(i + N + 1, k, j + N + 1),
                                translateIndices(i + N + 2, k, j + N + 1),
                                translateIndices(i + N + 2, k, j + N + 2), kidx == 1);

                        AddFace(translateIndices(i + N + 1, k, j),
                                translateIndices(i + N + 2, k, j + 1),
                                translateIndices(i + N + 1, k, j + 1), kidx == 1);
                        AddFace(translateIndices(i + N + 1, k, j),
                                translateIndices(i + N + 2, k, j),
                                translateIndices(i + N + 2, k, j + 1), kidx == 1);
                    }
                // sides
                for (int i = 0; i < N; ++i)
                {
                    AddFace(translateIndices(i, k, N),
                            translateIndices(i + 1, k, N + 1),
                            translateIndices(i, k, N + 1), kidx == 1);
                    AddFace(translateIndices(i, k, N),
                            translateIndices(i + 1, k, N),
                            translateIndices(i + 1, k, N + 1), kidx == 1);

                    AddFace(translateIndices(N, k, i),
                            translateIndices(N + 1, k, i + 1),
                            translateIndices(N, k, i + 1), kidx == 1);
                    AddFace(translateIndices(N, k, i),
                            translateIndices(N + 1, k, i),
                            translateIndices(N + 1, k, i + 1), kidx == 1);

                    AddFace(translateIndices(i + N + 1, k, N),
                            translateIndices(i + N + 2, k, N + 1),
                            translateIndices(i + N + 1, k, N + 1), kidx == 1);
                    AddFace(translateIndices(i + N + 1, k, N),
                            translateIndices(i + N + 2, k, N),
                            translateIndices(i + N + 2, k, N + 1), kidx == 1);

                    AddFace(translateIndices(N, k, i + N + 1),
                            translateIndices(N + 1, k, i + N + 2),
                            translateIndices(N, k, i + N + 2), kidx == 1);
                    AddFace(translateIndices(N, k, i + N + 1),
                            translateIndices(N + 1, k, i + N + 1),
                            translateIndices(N + 1, k, i + N + 2), kidx == 1);
                }
                // central
                AddFace(translateIndices(N, k, N),
                        translateIndices(N + 1, k, N + 1),
                        translateIndices(N, k, N + 1), kidx == 1);
                AddFace(translateIndices(N, k, N),
                        translateIndices(N + 1, k, N),
                        translateIndices(N + 1, k, N + 1), kidx == 1);
            }

            // yz-planes
            for (int kidx = 0; kidx < 2; ++kidx)
            {
                int k = ks[kidx];
                Vector3D origin = new Vector3D((b[0] + radius) * sign[kidx], -b[1] - radius, -b[2] - radius);
                for (int j = 0; j <= N; ++j)
                    for (int i = 0; i <= N; ++i)
                    {
                        Vector3D pos = origin + new Vector3D(0.0, dx * i, dx * j);
                        AddVertex(k, i, j, pos, new Vector3D(b[0] * sign[kidx], -b[1], -b[2]));

                        pos = origin + new Vector3D(0.0, dx * i + 2.0 * b[1] + radius, dx * j);
                        AddVertex(k, i + N + 1, j, pos, new Vector3D(b[0] * sign[kidx], b[1], -b[2]));

                        pos = origin + new Vector3D(0.0, dx * i + 2.0 * b[1] + radius, dx * j + 2.0 * b[2] + radius);
                        AddVertex(k, i + N + 1, j + N + 1, pos, new Vector3D(b[0] * sign[kidx], b[1], b[2]));

                        pos = origin + new Vector3D(0.0, dx * i, dx * j + 2.0 * b[2] + radius);
                        AddVertex(k, i, j + N + 1, pos, new Vector3D(b[0] * sign[kidx], -b[1], b[2]));
                    }
                // corners
                for (int j = 0; j < N; ++j)
                    for (int i = 0; i < N; ++i)
                    {
                        AddFace(translateIndices(k, i, j),
                                translateIndices(k, i + 1, j + 1),
                                translateIndices(k, i, j + 1), kidx == 0);
                        AddFace(translateIndices(k, i, j),
                                translateIndices(k, i + 1, j),
                                translateIndices(k, i + 1, j + 1), kidx == 0);

                        AddFace(translateIndices(k, i, j + N + 1),
                                translateIndices(k, i + 1, j + N + 2),
                                translateIndices(k, i, j + N + 2), kidx == 0);
                        AddFace(translateIndices(k, i, j + N + 1),
                                translateIndices(k, i + 1, j + N + 1),
                                translateIndices(k, i + 1, j + N + 2), kidx == 0);

                        AddFace(translateIndices(k, i + N + 1, j + N + 1),
                                translateIndices(k, i + N + 2, j + N + 2),
                                translateIndices(k, i + N + 1, j + N + 2), kidx == 0);
                        AddFace(translateIndices(k, i + N + 1, j + N + 1),
                                translateIndices(k, i + N + 2, j + N + 1),
                                translateIndices(k, i + N + 2, j + N + 2), kidx == 0);

                        AddFace(translateIndices(k, i + N + 1, j),
                                translateIndices(k, i + N + 2, j + 1),
                                translateIndices(k, i + N + 1, j + 1), kidx == 0);
                        AddFace(translateIndices(k, i + N + 1, j),
                                translateIndices(k, i + N + 2, j),
                                translateIndices(k, i + N + 2, j + 1), kidx == 0);
                    }
                // sides
                for (int i = 0; i < N; ++i)
                {
                    AddFace(translateIndices(k, i, N),
                            translateIndices(k, i + 1, N + 1),
                            translateIndices(k, i, N + 1), kidx == 0);
                    AddFace(translateIndices(k, i, N),
                            translateIndices(k, i + 1, N),
                            translateIndices(k, i + 1, N + 1), kidx == 0);

                    AddFace(translateIndices(k, N, i),
                            translateIndices(k, N + 1, i + 1),
                            translateIndices(k, N, i + 1), kidx == 0);
                    AddFace(translateIndices(k, N, i),
                            translateIndices(k, N + 1, i),
                            translateIndices(k, N + 1, i + 1), kidx == 0);

                    AddFace(translateIndices(k, i + N + 1, N),
                            translateIndices(k, i + N + 2, N + 1),
                            translateIndices(k, i + N + 1, N + 1), kidx == 0);
                    AddFace(translateIndices(k, i + N + 1, N),
                            translateIndices(k, i + N + 2, N),
                            translateIndices(k, i + N + 2, N + 1), kidx == 0);

                    AddFace(translateIndices(k, N, i + N + 1),
                            translateIndices(k, N + 1, i + N + 2),
                            translateIndices(k, N, i + N + 2), kidx == 0);
                    AddFace(translateIndices(k, N, i + N + 1),
                            translateIndices(k, N + 1, i + N + 1),
                            translateIndices(k, N + 1, i + N + 2), kidx == 0);
                }
                // central
                AddFace(translateIndices(k, N, N),
                        translateIndices(k, N + 1, N + 1),
                        translateIndices(k, N, N + 1), kidx == 0);
                AddFace(translateIndices(k, N, N),
                        translateIndices(k, N + 1, N),
                        translateIndices(k, N + 1, N + 1), kidx == 0);
            }
        }
        #endregion
        #region Data members
        private readonly List<Vector3D> vertices = new List<Vector3D>();
        private readonly List<Vector3D> normals = new List<Vector3D>();
        private readonly List<Tri> indices = new List<Tri>();
        private readonly List<int> m_index_to_verts = new List<int>();
        private double m_radius;
        private int m_N_edge;
        #endregion
    }
}
