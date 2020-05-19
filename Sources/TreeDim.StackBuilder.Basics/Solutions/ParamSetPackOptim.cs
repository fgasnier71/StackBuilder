#region Using directives

using System.Drawing;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class ParamSetPackOptim
    {
        public ParamSetPackOptim(
            int noBoxes
            , Vector3D caseLimitMin, Vector3D caseLimitMax
            , bool forceVerticalCaseOrientation
            , bool hasWrapper, Color wrapperColor, int[] noWrapperWalls, double wrapperThickness, double wrapperSurfMass, PackWrapper.WType wType
            , bool hasTray, Color trayColor, int[] noTrayWalls, double trayThickness, double traySurfMass, double trayHeight
            )
        {
            NoBoxes = noBoxes;
            CaseLimitMin = caseLimitMin;
            CaseLimitMax = caseLimitMax;
            ForceVerticalcaseOrientation = forceVerticalCaseOrientation;

            HasWrapper = hasWrapper;
            WrapperType = wType;
            NoWrapperWalls = noWrapperWalls;
            WrapperThickness = wrapperThickness;
            WrapperSurfMass = wrapperSurfMass;
            WrapperColor = wrapperColor;

            HasTray = hasTray;
            TrayHeight = trayHeight;
            NoTrayWalls = noTrayWalls;
            TrayThickness = trayThickness;
            TraySurfMass = traySurfMass;
            TrayColor = trayColor;
        }

        public double WrapperWeight(Vector3D dims)
        {
            return WrapperSurfMass * (
                NoWrapperWalls[0] * dims.Y * dims.Z
                + NoWrapperWalls[1] * dims.X * dims.Z
                + NoWrapperWalls[2] * dims.X * dims.Y);
        }
        public double TrayWeight(Vector3D dims)
        {
            return TraySurfMass * (
                NoWrapperWalls[0] * dims.Y * TrayHeight
                + NoWrapperWalls[1] * dims.X * TrayHeight
                + NoWrapperWalls[2] * dims.X * dims.Y);
        }
        public int NoBoxes { get; set; }
        public Vector3D CaseLimitMin { get; set; }
        public Vector3D CaseLimitMax { get; set; }
        public PackWrapper.WType WrapperType { get; }

        public bool HasWrapper { get; set; }
        public bool HasTray { get; set; }
        public int[] NoWrapperWalls { get; private set; } = new int[3];
        public int[] NoTrayWalls { get; private set; } = new int[3];
        public double WrapperThickness { get; set; }
        public double TrayThickness { get; set; }
        public double WrapperSurfMass { get; set; }
        public double TraySurfMass { get; set; }
        public Color WrapperColor { get; set; }
        public Color TrayColor { get; set; }

        public double TrayHeight { get; set; }
        public bool ForceVerticalcaseOrientation { get; set; }
    }
}
