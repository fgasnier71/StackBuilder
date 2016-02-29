#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public interface ILayerSolver
    {
        List<Layer2D> BuildLayers(Vector3D dimBox, Vector2D dimContainer, ConstraintSetAbstract constraintSet, bool keepOnlyBest);
        Layer2D BuildLayer(Vector3D dimBox, Vector2D actualDimensions, LayerDesc layerDesc);
    }


    public class SolutionItem
    {
        #region Data members
        private int _indexLayer = 0, _indexInterlayer = -1;
        private bool _symetryX = false, _symetryY = false;
        #endregion

        #region Constructor
        public SolutionItem(int indexLayer, int indexInterlayer, bool symetryX, bool symetryY)
        {
            _indexLayer = indexLayer;
            _indexInterlayer = indexInterlayer;
            _symetryX = symetryX;
            _symetryY = SymetryY;
        }
        #endregion

        #region Public properties
        public bool SymetryX
        {
            get { return _symetryX; }
            set { _symetryX = value; }
        }
        public bool SymetryY
        {
            get { return _symetryY; }
            set { _symetryY = value; }
        }
        public bool HasInterlayer   { get { return _indexInterlayer != -1; } }
        public int InterlayerIndex  { get { return _indexInterlayer; } }
        public int LayerIndex       { get { return _indexLayer;  } }
        #endregion
    }

    public class Solution
    {
        #region Data members
        private List<Layer2D> _layers;
        private List<SolutionItem> _solutionItems;
        private Analysis _analysis;

        private int _selectedIndex;

        private static ILayerSolver _solver;

        // cached data
        private BBox3D _bbox = BBox3D.Initial;
        #endregion

        #region Static methods
        public static void SetSolver(ILayerSolver solver)
        { _solver = solver; }
        #endregion

        #region Constructor
        public Solution(Analysis analysis, List<LayerDesc> layerDescs)
        {
            _analysis = analysis;
            RebuildLayers(layerDescs);
            InitializeSolutionItemList();
        }
        #endregion

        #region Helpers
        private void RebuildLayers(List<LayerDesc> layerDescs)
        {
            _layers = new List<Layer2D>();
            if (null == _solver)
                throw new Exception("Solver not initialized");
            foreach (LayerDesc layerDesc in layerDescs)
                _layers.Add(_solver.BuildLayer(_analysis.ContentDimensions, _analysis.ContainerDimensions, layerDesc));
        }
        private void InitializeSolutionItemList()
        { 
            _solutionItems = new List<SolutionItem>();

            bool criterionReached = false;
            double zTop = _analysis.Offset.Z;
            double weight = _analysis.ContainerWeight;
            while (!criterionReached)
            {
                weight += _layers[0].Count * _analysis.ContentWeight;
                zTop += _layers[0].BoxHeight;
                ConstraintSetAbstract constraintSet = _analysis.ConstraintSet;
                criterionReached = (ConstraintSet.OptMaxHeight.Activated && zTop >= constraintSet.OptMaxHeight.Value)
                    || (ConstraintSet.OptMaxWeight.Activated && weight >= constraintSet.OptMaxWeight.Value);
                if (criterionReached)
                    break;
                else
                    _solutionItems.Add(new SolutionItem(0, -1, false, false));
            }
        }

        public void SelectLayer(int index)
        {
            _selectedIndex = index;
        }
        #endregion

        #region Public properties
        public int Selected
        {
            get { return _selectedIndex; }
        }
        public Analysis Analysis
        {
            get { return _analysis; }
        }
        public ConstraintSetAbstract ConstraintSet
        {
            get { return _analysis.ConstraintSet; }
        }
        public List<ILayer> Layers
        {
            get
            {
                List<ILayer> llayers = new List<ILayer>();

                int iBoxCount = 0;
                int iInterlayerCount = 0;

                // starting height
                double zLayer = 0.0;
                // build layers
                foreach (SolutionItem solItem in _solutionItems)
                {
                    if (solItem.HasInterlayer)
                    {
                        InterlayerProperties interlayer = _analysis.Interlayer(solItem.InterlayerIndex);
                        llayers.Add(new InterlayerPos(zLayer + Analysis.Offset.Z, solItem.InterlayerIndex));
                        zLayer += interlayer.Thickness;
                        ++iInterlayerCount;
                    }

                    BoxLayer bLayer = new BoxLayer(zLayer, solItem.LayerIndex);
                    llayers.Add(bLayer);
                    Layer2D currentLayer = _layers[solItem.LayerIndex];

                   foreach (LayerPosition layerPos in currentLayer)
                   {
                       LayerPosition layerPosTemp = AdjustLayerPosition(layerPos);
                       bLayer.Add(new BoxPosition(
                           layerPosTemp.Position + Analysis.Offset + zLayer * Vector3D.ZAxis
                           , layerPosTemp.LengthAxis
                           , layerPosTemp.WidthAxis                           
                           )); 
                        ++iBoxCount;
                   }
                    zLayer += currentLayer.BoxHeight;
                }
                return llayers;
            }
        }
        public BBox3D BBoxLoad
        {
            get
            {
                if (!_bbox.IsValid)
                {
                    foreach (ILayer layer in Layers)
                    { 
                        BoxLayer blayer = layer as BoxLayer;
                        if (null != blayer)
                            _bbox.Extend(blayer.BoundingBox(Analysis.ContentDimensions));
                    }
                }
                return _bbox;
            }
        }

        public BBox3D BBoxLoadWDeco
        {   get { return Analysis.BBoxLoadWDeco(BBoxLoad); } }
        public BBox3D BBoxGlobal
        {   get { return Analysis.BBoxGlobal(BBoxLoad); } }
        #endregion

        #region Helpers
        /// <summary>
        /// if box bottom oriented to Z+, reverse box
        /// </summary>
        private LayerPosition AdjustLayerPosition(LayerPosition layerPos)
        {
            Vector3D dimensions = Analysis.ContentDimensions;

            LayerPosition layerPosTemp = layerPos;
            if (layerPosTemp.HeightAxis == HalfAxis.HAxis.AXIS_Z_N)
            {
                if (layerPosTemp.LengthAxis == HalfAxis.HAxis.AXIS_X_P)
                {
                    layerPosTemp.WidthAxis = HalfAxis.HAxis.AXIS_Y_P;
                    layerPosTemp.Position += new Vector3D(0.0, -dimensions.Y, -dimensions.Z);
                }
                else if (layerPos.LengthAxis == HalfAxis.HAxis.AXIS_Y_P)
                {
                    layerPosTemp.WidthAxis = HalfAxis.HAxis.AXIS_X_N;
                    layerPosTemp.Position += new Vector3D(dimensions.Y, 0.0, -dimensions.Z);
                }
                else if (layerPos.LengthAxis == HalfAxis.HAxis.AXIS_X_N)
                {
                    layerPosTemp.LengthAxis = HalfAxis.HAxis.AXIS_X_P;
                    layerPosTemp.Position += new Vector3D(-dimensions.X, 0.0, -dimensions.Z);
                }
                else if (layerPos.LengthAxis == HalfAxis.HAxis.AXIS_Y_N)
                {
                    layerPosTemp.WidthAxis = HalfAxis.HAxis.AXIS_X_P;
                    layerPosTemp.Position += new Vector3D(-dimensions.Y, 0.0, -dimensions.Z);
                }
            }
            return layerPosTemp;
        }
        #endregion
    }
}
