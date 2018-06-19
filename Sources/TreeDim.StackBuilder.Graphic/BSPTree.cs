#region Using directives
using System.Collections.Generic;

using log4net;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    internal class BSPTree
    {
        public BSPTree()
        {
            Initialize();
        }
        public void Initialize()
        {
            Root = null;
        }
        public void Insert(Face f)
        {
            if (f.IsDegenerate)
                return;

            if (null == Root)
                Root = new BSPNode(f);
            else
                Root.Insert(f);
        }

        public void Draw(Graphics3D g)
        {
            if (null == Root)
                return;
            List<Face> faces = new List<Face>();
            Draw(Root, g.CameraPosition, ref faces);
            foreach (Face f in faces)
                g.Draw(f, Graphics3D.FaceDir.FRONT);
        }

        private void Draw(BSPNode node, Vector3D ptEye, ref List<Face> faces)
        {
            if (null == node) return;
            double result = node.ClassifyPoint(ptEye);
            if (result > 0)
            {
                Draw(node.NodeLeft, ptEye, ref faces);
                faces.Add(node.Face);
                Draw(node.NodeRight, ptEye, ref faces);
            }
            else if (result < 0)
            {
                Draw(node.NodeRight, ptEye, ref faces);
                faces.Add(node.Face);
                Draw(node.NodeLeft, ptEye, ref faces);
            }
            else // result == 0
            {
                Draw(node.NodeRight, ptEye, ref faces);
                Draw(node.NodeLeft, ptEye, ref faces);
            }
        }

        private BSPNode Root { get; set; }
        private static readonly ILog _log = LogManager.GetLogger(typeof(BSPTree));
    }
}
