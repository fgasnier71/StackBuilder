using System;
using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public class ParamSetPackOptim
    {
        public ParamSetPackOptim(
            int noBoxes
            , Vector3D caseLimitMin, Vector3D caseLimitMax
            , bool forceVerticalCaseOrientation
            , PackWrapper.WType wType
            , int[] noWalls
            , double wallThickness, double wallSurfaceMass
            , double trayHeight
            )
        {
            NoBoxes = noBoxes;
            NoWalls = noWalls;
            WallThickness = wallThickness;
            WallSurfaceMass = wallSurfaceMass;
            CaseLimitMin = caseLimitMin;
            CaseLimitMax = caseLimitMax;
            ForceVerticalcaseOrientation = forceVerticalCaseOrientation;
            _trayHeight = trayHeight;
            _wType = wType;
        }

        public int NoBoxes { get; set; }
        public double WallThickness { get; set; }
        public double WallSurfaceMass { get; set; }
        public Vector3D CaseLimitMin { get; set; }
        public Vector3D CaseLimitMax { get; set; }
        public int[] NoWalls
        {
            get { return _noWalls; }
            set
            {
                for (int i = 0; i < _noWalls.Length; ++i)
                    _noWalls[i] = value[i];
            }
        }
        public bool ForceVerticalcaseOrientation { get; set; }
        public PackWrapper.WType WrapperType => _wType;
        public double TrayHeight => _trayHeight;

        public int GetNoWalls(int iDir)
        {
            return _noWalls[iDir];
        }

        #region Non-Public Members

        /// <summary>
        /// Number of walls in each direction (used to compute outer case dimensions)
        /// </summary>
        private int[] _noWalls = new int[3];

        private PackWrapper.WType _wType;
        private double _trayHeight;

        #endregion
    }
}
