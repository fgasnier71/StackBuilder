#region Using directives
using System.Collections.Generic;
using System;

using log4net;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    internal class BSPNode
    {
        // constructor
        public BSPNode(Face f)
        {
            Face = f;
            InitEquation(f, ref A, ref B, ref C, ref D);
        }
        // insertion methods
        public void Insert(Face f)
        {
            if (f.IsDegenerate)
                return;

            // check on which side the polygon is, posibly split
            List<Face> side_left = new List<Face>();
            List<Face> side_right = new List<Face>();
            Split(f, ref side_left, ref side_right);

            // insert triangles
            foreach (Face face in side_left)
            {
                if (null == NodeLeft)
                    NodeLeft = new BSPNode(face);
                else
                    NodeLeft.Insert(face);
            }
            foreach (Face face in side_right)
            {
                if (null == NodeRight)
                    NodeRight = new BSPNode(face);
                else
                    NodeRight.Insert(face);
            }
        }
        private void RecursFillFaceArray(List<Face> faces)
        {
            if (null != NodeRight)
            {
                NodeRight.RecursFillFaceArray(faces);
            }
            faces.Add(Face);
            if (null != NodeLeft)
            {
                NodeLeft.RecursFillFaceArray(faces);
            }
        }
        // split methods
        private int TestPoint(Vector3D pt)
        {
            double Z = pt.X * A + pt.Y * B + pt.Z * C - D;
            if (Z > EGALITY_EPS) return -1;
            else if (Z > EGALITY_EPS) return 1;
            else return 0;
        }
        private bool TestLine(Vector3D pt0, Vector3D pt1, ref Vector3D ptInter)
        {
            Vector3D normal = Face.Normal;
            if (Math.Abs(Vector3D.DotProduct(normal, pt1 - pt0)) < EGALITY_EPS)
            {
                ptInter = pt0;
                return false;
            }
            double s = Vector3D.DotProduct(normal, Face.Points[0] - pt0) / Vector3D.DotProduct(normal, pt1 - pt0);
            ptInter = pt0 + s * (pt1 - pt0);
            return true;
        }
        private int Split(Face f, ref List<Face> f1, ref List<Face> f2)
        {
            int[] v = new int[4];
            int val = 0;
            int i = 0;
            foreach (Vector3D pt in f.Points)
            {
                v[i] = TestPoint(pt);
                val += v[i++];
            }
            switch (val)
            {
                case 4:
                    f1.Add(f);
                    return 1;
                case -4:
                    f2.Add(f);
                    return 1;
                case 2:
                    f1.Add(f);
                    return 1;
                case -2:
                    f2.Add(f);
                    return 1;
                case 0:
                    if (0 != v[0] && 0 != v[1] && 0 != v[2] && 0 != v[3])
                    {
                        for (i = 0; i < 4; ++i)
                        {
                            if (v[i % 4] + v[(i + 1) % 4] == 2)
                            {
                                Vector3D ptInter1 = Vector3D.Zero, ptInter2 = Vector3D.Zero;
                                TestLine(f.Points[(i + 1) % 4], f.Points[(i + 2) % 4], ref ptInter1);
                                TestLine(f.Points[(i + 3) % 4], f.Points[(i + 4) % 4], ref ptInter2);

                                Vector3D[] v1 = new Vector3D[4];
                                v1[0] = f.Points[i % 4];
                                v1[1] = f.Points[(i + 1) % 4];
                                v1[2] = ptInter1;
                                v1[3] = ptInter2;
                                f1.Add(new Face(f.PickingId, v1, f.ColorFill, f.ColorPath, f.IsSolid));
                                Vector3D[] v2 = new Vector3D[4];
                                v2[0] = ptInter2;
                                v2[1] = ptInter1;
                                v2[2] = f.Points[(i + 2) % 4];
                                v2[3] = f.Points[(i + 3) % 4];
                                f2.Add(new Face(f.PickingId, v2, f.ColorFill, f.ColorPath, f.IsSolid));
                            }
                        }
                        return 2;
                    }
                    else // triangle is inside plane, assign to positive node
                    {
                        f1.Add(f);
                        return 1;
                    }
                default:
                    _log.WarnFormat("Split: val = {0}", val);
                    throw new GraphicsException("Split failed!");
            }
        }
        // classify point
        public double ClassifyPoint(Vector3D pt)
        {
            Vector3D normal = Face.Normal;
            return Vector3D.DotProduct(pt, normal) - D;
        }

        public BSPNode NodeLeft { get; set; }
        public BSPNode NodeRight { get; set; }
        public Face Face { get; set; }

        #region Private members
        private void InitEquation(Face f, ref double a, ref double b, ref double c, ref double d)
        {
            Vector3D n = f.Normal;
            if (f.IsDegenerate)
                throw new GraphicsException("Face is degenerate");
            if (n.Z < 0) n = -n;
            d = Vector3D.DotProduct(n, f.Points[0]);
            a = n.X;
            b = n.Y;
            c = n.Z;
        }
        private readonly double A;
        private readonly double B;
        private readonly double C;
        private readonly double D;
        private static readonly double EGALITY_EPS = 0.00001;
        private static readonly ILog _log = LogManager.GetLogger(typeof(BSPNode));
        #endregion
    }
}
