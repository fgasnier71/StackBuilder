#region Using directives
using System;
using System.Collections.Generic;
using Sharp3D.Math.Core;

using treeDiM.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    #region Helper classes
    internal class BoxComparerZ : IComparer<BoxGeneric>
    {
        #region IComparer<Box> implementation
        public int Compare(BoxGeneric b1, BoxGeneric b2)
        {
            double b1ZMin = b1.PtMin.Z;
            double b2ZMin = b2.PtMin.Z;
            if (b1ZMin > b2ZMin)
                return 1;
            else if (b1ZMin == b2ZMin)
                return 0;
            else
                return -1;
        }
        #endregion
    }
    internal class BoxComparerXMin : IComparer<BoxGeneric>
    {
        #region Data members
        private Vector3D Direction { get; set; }
        #endregion

        #region Constructor
        public BoxComparerXMin(Vector3D direction)
        {
            Direction = direction;
        }
        #endregion

        #region IComparer<Box> implementation
        public int Compare(BoxGeneric b1, BoxGeneric b2)
        {
            Vector3D b1PtMin = b1.PtMin, b2PtMin = b2.PtMin;
            if (b1PtMin.X > b2PtMin.X)
                return 1;
            else if (b1PtMin.X == b2PtMin.X)
            {
                if (Direction.Y >= 0)
                {
                    if (b1PtMin.Y > b2PtMin.Y)
                        return 1;
                    else if (b1PtMin.Y == b2PtMin.Y)
                        return 0;
                    else
                        return -1;
                }
                else
                {
                    Vector3D b1PtMax = b1.PtMax, b2PtMax = b2.PtMax; 
                    if (b1PtMax.Y > b2PtMax.Y)
                        return -1;
                    else if (b1PtMax.Y == b2PtMax.Y)
                        return 0;
                    else
                        return 1;
                }
            }
            else
                return -1;
        }
        #endregion
    }
    internal class BoxComparerXMax : IComparer<BoxGeneric>
    {
        #region Data members
        private Vector3D Direction { get; set; }
        #endregion
        #region Constructor
        public BoxComparerXMax(Vector3D direction)
        {
            Direction = direction;
        }
        #endregion
        #region IComparer<Box> implementation
        public int Compare(BoxGeneric b1, BoxGeneric b2)
        {
            Vector3D b1PtMax = b1.PtMax, b2PtMax = b2.PtMax;

            if (b1PtMax.X > b2PtMax.X)
                return -1;
            else if (b1PtMax.X == b2PtMax.X)
            {
                if (Direction.Y >= 0)
                {
                    Vector3D b1PtMin = b1.PtMin, b2PtMin = b2.PtMin;
                    if (b1PtMin.Y > b2PtMin.Y)
                        return 1;
                    else if (b1PtMin.Y == b2PtMin.Y)
                        return 0;
                    else
                        return -1;
                }
                else
                {
                    if (b1PtMax.Y > b2PtMax.Y)
                        return -1;
                    else if (b1PtMax.Y == b2PtMax.Y)
                        return 0;
                    else
                        return 1;
                }
            }
            else
                return 1;
        }
        #endregion
    }
    #endregion

    #region BoxOrderer
    public abstract class BoxOrderer
    {
        #region Data members
        protected List<BoxGeneric> Boxes { get; set; } = new List<BoxGeneric>();
        #endregion

        #region Public methods
        public void Add(BoxGeneric b)
        {
            Boxes.Add(b);
        }
        #endregion

        #region Public abstract methods
        public abstract List<BoxGeneric> GetSortedList();
        #endregion
    }
    #endregion

    #region BoxelOrderer
    public class BoxelOrderer : BoxOrderer
    {
        #region Data members
        private static readonly double _epsilon = 0.0001;
        #endregion

        #region Constructor
        public BoxelOrderer(List<BoxGeneric> boxes, Vector3D direction)
        {
            Boxes.AddRange(boxes);
            Direction = direction;
            TuneParam = UnitsManager.ConvertLengthFrom(1.0, UnitsManager.UnitSystem.UNIT_METRIC1);
        }
        #endregion

        #region Public properties
        public double TuneParam { get; set; } = 1.0;
        #endregion

        #region Public methods
        public override List<BoxGeneric> GetSortedList()
        {
            // first sort by Z
            BoxComparerZ boxComparerZ = new BoxComparerZ();
            Boxes.Sort(boxComparerZ);

            List<BoxGeneric> sortedList = new List<BoxGeneric>();
            if (Boxes.Count == 0)
                return sortedList;

            // build same Z layers
            int index = 0;
            double zCurrent = Boxes[index].PtMin.Z;
            List<BoxGeneric> tempList = new List<BoxGeneric>();
            while (index < Boxes.Count)
            {
                if (Math.Abs(zCurrent - Boxes[index].PtMin.Z) < _epsilon)
                    tempList.Add(Boxes[index]);
                else
                {
                    // sort layer
                    SortLayer(ref tempList);
                    // add to sorted list
                    sortedList.AddRange(tempList);
                    // start new layer
                    zCurrent = Boxes[index].PtMin.Z;
                    tempList.Clear();
                    tempList.Add(Boxes[index]);
                }
                ++index;
            }
            // processing last layer
            SortLayer(ref tempList);
            sortedList.AddRange(tempList);

            return sortedList;
        }
        #endregion

        #region Public properties
        public Vector3D Direction { get; set; }
        #endregion

        #region Private methods
        private void SortLayer(ref List<BoxGeneric> layerList)
        {
            foreach (var b in layerList)
                b.ApplyElong(-TuneParam);

            // build y list
            List<double> yList = new List<double>();
            foreach (BoxGeneric b in layerList)
            {
                if (!yList.Contains(b.PtMin.Y)) yList.Add(b.PtMin.Y);
                if (!yList.Contains(b.PtMax.Y)) yList.Add(b.PtMax.Y);
            }
            yList.Sort();
            if (Direction.Y < 0)
                yList.Reverse();

            List<BoxGeneric> treeList = new List<BoxGeneric>();
            List<BoxGeneric> resList = new List<BoxGeneric>();
            // sweep stage
            foreach (double y in yList)
            {
                // clean treelist
                if (Direction.Y > 0.0)
                {
                    CleanByYMax(treeList, y);
                    // add new 
                    List<BoxGeneric> listYMin = GetByYMin(layerList, y);

                    foreach (var by in listYMin)
                    {
                        treeList.Add(by);
                        if (Direction.X > 0.0)
                            treeList.Sort(new BoxComparerXMin(Direction));
                        else
                            treeList.Sort(new BoxComparerXMax(Direction));

                        // find successor of by
                        int id = treeList.FindIndex(delegate(BoxGeneric b) { return b.PickId == by.PickId; });
                        BoxGeneric successor = null;
                        if (id < treeList.Count - 1)
                            successor = treeList[id + 1];

                        // insert by
                        if (null == successor)
                            resList.Add(by);
                        else
                        {
                            int idBefore = resList.FindIndex(delegate(BoxGeneric b) { return b.PickId == successor.PickId; });
                            resList.Insert(idBefore, by);
                        }
                    }
                }
                else
                {
                    CleanByYMin(treeList, y);
                    // add new 
                    List<BoxGeneric> listYMax = GetByYMax(layerList, y);

                    foreach (var by in listYMax)
                    {
                        treeList.Add(by);
                        if (Direction.X > 0.0)
                            treeList.Sort(new BoxComparerXMin(Direction));
                        else
                            treeList.Sort(new BoxComparerXMax(Direction));

                        // find successor of by
                        int id = treeList.FindIndex(delegate(BoxGeneric b) { return b.PickId == by.PickId; });
                        BoxGeneric successor = null;
                        if (id < treeList.Count - 1)
                            successor = treeList[id + 1];

                        // insert by
                        if (null == successor)
                            resList.Add(by);
                        else
                        {
                            int idBefore = resList.FindIndex(delegate(BoxGeneric b) { return b.PickId == successor.PickId; });
                            resList.Insert(idBefore, by);
                        }
                    }
                }
            }

            layerList.Clear();
            resList.Reverse();
            layerList.AddRange(resList);

            foreach (var b in layerList)
                b.ApplyElong(TuneParam);
        }

        private List<BoxGeneric> GetByYMin(List<BoxGeneric> inList, double y)
        {
            List<BoxGeneric> outList = new List<BoxGeneric>();
            foreach (var b in inList)
                if (Math.Abs(b.PtMin.Y - y) < _epsilon)
                    outList.Add(b);
            return outList;
        }

        private List<BoxGeneric> GetByYMax(List<BoxGeneric> inList, double y)
        {
            List<BoxGeneric> outList = new List<BoxGeneric>();
            foreach (var b in inList)
                if (Math.Abs(y - b.PtMax.Y) < _epsilon)
                    outList.Add(b);
            return outList;
        }

        private void CleanByYMax(List<BoxGeneric> lb, double y)
        {
            bool found = true;
            while (found)
            {
                found = false;
                for (int i = 0; i < lb.Count; ++i)
                {
                    var b = lb[i];
                    if (b.PtMax.Y <= y)
                    {
                        lb.Remove(b);
                        found = true;
                        break;
                    }
                }
            }
        }
        private void CleanByYMin(List<BoxGeneric> lb, double y)
        {
            bool found = true;
            while (found)
            {
                found = false;
                for (int i = 0; i < lb.Count; ++i)
                {
                    var b = lb[i];
                    if (b.PtMin.Y >= y)
                    {
                        lb.Remove(b);
                        found = true;
                        break;
                    }
                }
            }
        }
        #endregion
    }
    #endregion
}
