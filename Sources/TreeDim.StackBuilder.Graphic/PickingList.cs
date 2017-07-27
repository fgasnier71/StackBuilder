#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using treeDiM.StackBuilder.Basics;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class PickItem
    {
        #region Constructors
        public PickItem() { }
        public PickItem(uint id, uint layerId, Box box)
        { _id = id; _layerId = layerId; Box = box; }
        #endregion

        #region Public properties
        public Box Box { get; set; }
        #endregion

        #region Data members
        private uint _id;
        private uint _layerId;
        #endregion
    }

    public class PickResult
    { 
    
    }

    public class PickingList
    {
        #region Constructor
        public PickingList()
        {
        }
        #endregion

        #region Public items
        public void AddItem(uint id, uint layerId, Box box)
        {
            _items.Add( new PickItem( id, layerId, box));
        }
        bool RayIntersect(Ray ray, out uint id, out uint layerId, out Vector3D v)
        {
            id = 0;
            layerId = 0;
            v = new Vector3D();

            List<PickResult> results = new List<PickResult>();

            foreach (PickItem item in _items)
            {
                Vector3D ptInter;
                if (item.Box.RayIntersect(ray, out ptInter))
                {
                    results.Add(new PickResult());
                }
            }
            results.Sort();

            return results.Count > 0;
        }
        #endregion

        #region Data members
        private List<PickItem> _items = new List<PickItem>(); 
        #endregion

    }
}
