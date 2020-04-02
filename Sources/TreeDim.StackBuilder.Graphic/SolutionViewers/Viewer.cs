#region Using directives
using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public abstract class Viewer : IDisposable
    {
        #region Data members
        /// <summary>
        /// list of picking boxes with id
        /// </summary>
        private List<Tuple<BBox3D, uint>> _listPickingBox = new List<Tuple<BBox3D, uint>>();
        #endregion

        #region Abstract methods
        public abstract void Draw(Graphics3D graphics, Transform3D transform);
        public abstract void Draw(Graphics2D graphics);
        #endregion

        #region Picking
        protected void ClearPickingBoxes()
        {
            //_listPickingBox.Clear();
        }
        protected void AddPickingBox(BBox3D bbox, uint id)
        {
            _listPickingBox.Add(new Tuple<BBox3D, uint>(bbox, id));
        }
        protected Ray GetPickingRay(int x, int y)
        {
            if (null == CurrentTransformation)
                throw new Exception("CurrentTransformation is null");
            // normalised_x = 2 * mouse_x / win_width - 1
            // normalised_y = 1 - 2 * mouse_y / win_height
            // note the y pos is inverted, so +y is at the top of the screen
            // unviewMat = (projectionMat * modelViewMat).inverse()
            // near_point = unviewMat * Vec(normalised_x, normalised_y, 0, 1)
            // camera_pos = ray_origin = modelViewMat.inverse().col(4)
            // ray_dir = near_point - camera_pos
            Transform3D eye2worldTransf = CurrentTransformation.Inverse();
            Vector3D vNear = eye2worldTransf.transform(new Vector3D(x, y, 0.0));
            Vector3D vFar = eye2worldTransf.transform(new Vector3D(x, y, 1.0));
            return new Ray(vNear, vFar);
        }
        public Transform3D CurrentTransformation { get; set; }
        public Vector3D ViewDir { get; set; }

        public bool TryPicking(int x, int y, out uint index)
        {
            Ray ray = GetPickingRay(x, y);
            index = 0;
            foreach (Tuple<BBox3D, uint> tBox in _listPickingBox)
            {
                index = tBox.Item2;
                Vector3D ptMin = tBox.Item1.PtMin;
                Vector3D ptMax = tBox.Item1.PtMax;

                Vector3D[] vertices = {
                    new Vector3D(ptMin.X, ptMin.Y, ptMin.Z)       // 0
                    , new Vector3D(ptMax.X, ptMin.Y, ptMin.Z)     // 1
                    , new Vector3D(ptMax.X, ptMax.Y, ptMin.Z)     // 2
                    , new Vector3D(ptMin.X, ptMax.Y, ptMin.Z)     // 3
                    , new Vector3D(ptMin.X, ptMin.Y, ptMax.Z)     // 4
                    , new Vector3D(ptMax.X, ptMin.Y, ptMax.Z)     // 5
                    , new Vector3D(ptMax.X, ptMax.Y, ptMax.Z)     // 6
                    , new Vector3D(ptMin.X, ptMax.Y, ptMax.Z)     // 7
                };
                Face[] faces = new Face[]
                {
                    new Face(0, vertices[0], vertices[1], vertices[5], vertices[4], "PICKING", false),
                    new Face(0, vertices[1], vertices[2], vertices[6], vertices[5], "PICKING", false),
                    new Face(0, vertices[2], vertices[3], vertices[7], vertices[6], "PICKING", false),
                    new Face(0, vertices[3], vertices[0], vertices[4], vertices[7], "PICKING", false),
                };

                foreach (Face f in faces)
                {
                    if (f.IsVisible(ViewDir) && f.RayIntersect(ray, out Vector3D ptInter))
                        return true;
                }
            }
            return false;
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
        }
        #endregion
    }
}
