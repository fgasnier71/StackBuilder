#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Sharp3D.Math.Core;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    #region ILayerSolver
    public interface ILayerSolver
    {
        List<Layer2D> BuildLayers(Vector3D dimBox, Vector2D dimContainer, double offsetZ, ConstraintSetAbstract constraintSet, bool keepOnlyBest);
        Layer2D BuildLayer(Vector3D dimBox, Vector2D actualDimensions, LayerDescBox layerDesc);
        Layer2D BuildLayer(Vector3D dimBox, Vector2D dimContainer, LayerDescBox layerDesc, Vector2D actualDimensions);
        ILayer2D BuildLayer(Packable packable, Vector2D dimContainer, LayerDesc layerDesc);
        ILayer2D BuildLayer(Packable packable, Vector2D dimContainer, LayerDesc layerDesc, Vector2D actualDimensions);
        bool GetDimensions(List<LayerDesc> layers, Packable packable, Vector2D dimContainer, out Vector2D actualDimensions);
    }
    #endregion

    #region SolutionItem
    public class SolutionItem
    {
        #region Data members
        private int _indexLayer = 0, _indexInterlayer = -1;
        private bool _symetryX = false, _symetryY = false;
        #endregion

        #region Constructors
        public SolutionItem(int indexLayer, int indexInterlayer, bool symetryX, bool symetryY)
        {
            _indexLayer = indexLayer;
            _indexInterlayer = indexInterlayer;
            _symetryX = symetryX;
            _symetryY = symetryY;
        }
        public SolutionItem(SolutionItem solItem)
        {
            _indexLayer = solItem._indexLayer;
            _indexInterlayer = solItem._indexInterlayer;
            _symetryX = solItem._symetryX;
            _symetryY = solItem._symetryY;
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
        public int InterlayerIndex { get { return _indexInterlayer; } set { _indexInterlayer = value; } }
        public int LayerIndex { get { return _indexLayer; } set { _indexLayer = value; } }
        #endregion

        #region Public methods
        public void SetInterlayer(int indexInterlayer)
        {
            _indexInterlayer = indexInterlayer;
        }
        public void InverseSymetry(int axis)
        {
            if (axis == 0) _symetryX = !_symetryX;
            else if (axis == 1) _symetryY = !_symetryY;
            else throw new Exception("Invalid axis of symetry");
        }
        #endregion

        #region Object overrides
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}"
                , _indexLayer
                , _indexInterlayer
                , _symetryX ? 1 : 0
                , _symetryY ? 1 : 0);
        }
        #endregion

        #region Public static parse methods
        public static SolutionItem Parse(string value)
        {
            Regex r = new Regex(@"(?<l>.*),(?<i>.*),(?<x>.*),(?<y>.*)", RegexOptions.Singleline);
            Match m = r.Match(value);
            if (m.Success)
            {
                return new SolutionItem(
                    int.Parse(m.Result("${l}"))
                    , int.Parse(m.Result("${i}"))
                    , int.Parse(m.Result("${x}")) == 1
                    , int.Parse(m.Result("${y}")) == 1);
            }
            else
                throw new Exception("Failed to parse SolutionItem!");
        }
        public static bool TryParse(string value, out SolutionItem solItem)
        {
            Regex r = new Regex(@"(?<l>),(?<i>),(?<x>),(?<y>)", RegexOptions.Singleline);
            Match m = r.Match(value);
            if (m.Success)
            {
                solItem = new SolutionItem(
                    int.Parse(m.Result("${l}"))
                    , int.Parse(m.Result("${i}"))
                    , int.Parse(m.Result("${x}")) == 1
                    , int.Parse(m.Result("${y}")) == 1);
                return true;
            }
            solItem = null;
            return false;
        }
        #endregion
    }
    #endregion

    #region LayerSummary
    public class LayerSummary
    {
        #region Data members
        private Solution _sol;
        private bool _symetryX, _symetryY;
        private int _indexLayer;
        private List<int> _layerIndexes = new List<int>();
        #endregion

        #region Constructor
        public LayerSummary(Solution sol, int indexLayer, bool symetryX, bool symetryY)
        {
            _sol = sol;
            _indexLayer = indexLayer;
            _symetryX = symetryX;
            _symetryY = symetryY;
        }
        #endregion

        #region Public properties
        public int ItemCount
        { get { return _sol.LayerBoxCount(_indexLayer); } }
        public Vector3D LayerDimensions
        { get { return new Vector3D(_sol._layers[_indexLayer].Length, _sol._layers[_indexLayer].Width, _sol._layers[_indexLayer].LayerHeight); } }
        public double LayerWeight
        { get { return _sol.LayerWeight(_indexLayer); } }
        public double LayerNetWeight
        { get { return _sol.LayerNetWeight(_indexLayer); } }
        public double Space
        { get { return _sol.LayerMaximumSpace(_indexLayer); } }
        public List<int> LayerIndexes
        { get { return _layerIndexes; } }
        public string LayerIndexesString
        { get { return string.Join(",", _layerIndexes.ToArray()); } }
        public ILayer Layer3D
        {
            get
            {
                return _sol.GetILayer(_indexLayer, _symetryX, _symetryY);
            }
        }
        #endregion

        #region Public methods
        public bool IsLayerTypeOf(SolutionItem solItem)
        {
            return _indexLayer == solItem.LayerIndex
                && _symetryX == solItem.SymetryX
                && _symetryY == solItem.SymetryY;
        }
        public void AddIndex(int index)
        {
            _layerIndexes.Add(index);
        }
        #endregion
    }
    #endregion

    #region Solution
    public class Solution
    {
        #region Data members
        private List<LayerDesc> _layerDescriptors;
        private List<SolutionItem> _solutionItems;
        private Analysis _analysis;

        private int _selectedIndex;

        internal List<ILayer2D> _layers;
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
            _layerDescriptors = layerDescs;

            _solutionItems = new List<SolutionItem>();

            RebuildLayers();
            InitializeSolutionItemList();
        }
        #endregion

        #region Reprocessing
        private void RebuildLayers()
        {
            // sanity checks
            if (null == _solver)
                throw new Exception("Solver not initialized");
            if (0 == _layerDescriptors.Count)
                throw new Exception("No layer descriptors available");

            _layers = new List<ILayer2D>();
            // build list of used layers
            List<LayerDesc> usedLayers = new List<LayerDesc>();
            if (null != _solutionItems && _solutionItems.Count > 0)
            {
                foreach (SolutionItem item in _solutionItems)
                {
                    if (!usedLayers.Contains(_layerDescriptors[item.LayerIndex]))
                        usedLayers.Add(_layerDescriptors[item.LayerIndex]);
                }
            }
            if (0 == usedLayers.Count)
                usedLayers.Add(_layerDescriptors[0]);
            // get dimensions
            Vector2D actualDimensions = Vector2D.Zero;
            _solver.GetDimensions(usedLayers, _analysis.Content, _analysis.ContainerDimensions, out actualDimensions);

            // actually build layers
            foreach (LayerDesc layerDesc in _layerDescriptors)
                _layers.Add(_solver.BuildLayer(_analysis.Content, _analysis.ContainerDimensions, layerDesc, actualDimensions));
        }
        private void InitializeSolutionItemList()
        { 
            _solutionItems = new List<SolutionItem>();

            bool criterionReached = false;
            double zTop = _analysis.Offset.Z;
            double weight = _analysis.ContainerWeight;
            bool symetryX = false, symetryY = false;
            while (!criterionReached)
            {
                weight += _layers[0].Count * _analysis.ContentWeight;
                zTop += _layers[0].LayerHeight;
                ConstraintSetAbstract constraintSet = _analysis.ConstraintSet;
                criterionReached = (ConstraintSet.OptMaxHeight.Activated && zTop >= constraintSet.OptMaxHeight.Value)
                    || (ConstraintSet.OptMaxWeight.Activated && weight >= constraintSet.OptMaxWeight.Value);
                if (criterionReached)
                    break;
                else
                    _solutionItems.Add(new SolutionItem(0, -1, symetryX, symetryY));

                symetryX = _analysis.AlternateLayersPref ? !symetryX : symetryX;
                symetryY = _analysis.AlternateLayersPref ? !symetryY : symetryY;
            }
        }
        public void RebuildSolutionItemList()
        {
            bool criterionReached = false;
            double zTop = _analysis.Offset.Z;
            double weight = _analysis.ContainerWeight;

            List<SolutionItem> solutionItems = new List<SolutionItem>();
            foreach (SolutionItem solItem in _solutionItems)
            {
                weight += _layers[solItem.LayerIndex].Count * _analysis.ContentWeight;
                zTop += _layers[solItem.LayerIndex].LayerHeight + ((-1 != solItem.InterlayerIndex) ? _analysis.Interlayer(solItem.InterlayerIndex).Thickness : 0.0);

                ConstraintSetAbstract constraintSet = _analysis.ConstraintSet;
                criterionReached = (ConstraintSet.OptMaxHeight.Activated && zTop >= constraintSet.OptMaxHeight.Value)
                    || (ConstraintSet.OptMaxWeight.Activated && weight >= constraintSet.OptMaxWeight.Value);

                solutionItems.Add(solItem);

                if (criterionReached)
                    break;
            }

            // add layers until 
            while (!criterionReached)
            {
                SolutionItem solItem = null;
                if (solutionItems.Count > 0)
                    solItem = solutionItems.Last();
                else
                    solItem = new SolutionItem(0, -1, false, false);

                if (solItem.LayerIndex >= _layers.Count)
                    throw new Exception(string.Format("Layer index out of range!"));

                weight += _layers[solItem.LayerIndex].Count * _analysis.ContentWeight;
                zTop += _layers[solItem.LayerIndex].LayerHeight + ((-1 != solItem.InterlayerIndex) ? _analysis.Interlayer(solItem.InterlayerIndex).Thickness : 0.0);

                solutionItems.Add(new SolutionItem(solItem));

                ConstraintSetAbstract constraintSet = _analysis.ConstraintSet;
                criterionReached = (ConstraintSet.OptMaxHeight.Activated && zTop >= constraintSet.OptMaxHeight.Value)
                    || (ConstraintSet.OptMaxWeight.Activated && weight >= constraintSet.OptMaxWeight.Value);
            }

            // remove unneeded layer 
            while (criterionReached)
            {
                SolutionItem solItem = null;
                if (solutionItems.Count > 0)
                    solItem = solutionItems.Last();
                else
                    solItem = new SolutionItem(0, -1, false, false);

                if (solItem.LayerIndex >= _layers.Count)
                    throw new Exception(string.Format("Layer index out of range!"));

                weight -= _layers[solItem.LayerIndex].Count * _analysis.ContentWeight;
                zTop -= _layers[solItem.LayerIndex].LayerHeight + ((-1 != solItem.InterlayerIndex) ? _analysis.Interlayer(solItem.InterlayerIndex).Thickness : 0.0);

                ConstraintSetAbstract constraintSet = _analysis.ConstraintSet;
                criterionReached = (ConstraintSet.OptMaxHeight.Activated && zTop >= constraintSet.OptMaxHeight.Value)
                    || (ConstraintSet.OptMaxWeight.Activated && weight >= constraintSet.OptMaxWeight.Value);

                solutionItems.Remove(solItem);
            }
            _solutionItems.Clear();
            _solutionItems = solutionItems;

            // reset bounding box to force recompute
            _bbox.Reset();
        }
        private int GetInterlayerIndex(InterlayerProperties interlayer)
        {
            return _analysis.GetInterlayerIndex(interlayer);
        }
        #endregion

        #region Apply selection
        public void SelectLayer(int index)
        {
            _selectedIndex = index;
            // rebuild layers
            RebuildLayers();
            // rebuild solution item list
            RebuildSolutionItemList();
        }
        public SolutionItem SelectedSolutionItem
        {
            get
            {
                if (!HasValidSelection) return null;
                return _solutionItems[_selectedIndex];
            }
        }
        public void SetLayerTypeOnSelected(int iLayerType)
        {
            // check selected layer
            if (!HasValidSelection) return;
            if (SelectedLayerIndex < 0 || SelectedLayerIndex >= _solutionItems.Count)
            {
                _log.Error(string.Format("Calling SetLayerTypeOnSelected() with SelectedLayerIndex = {0}", SelectedLayerIndex));
                return;
            }
            // get selected solution item
            SolutionItem item = _solutionItems[SelectedLayerIndex];
            item.LayerIndex = iLayerType;
            // rebuild layers
            RebuildLayers();
            // rebuild solution item list
            RebuildSolutionItemList();
        }
        public void SetInterlayerOnSelected(InterlayerProperties interlayer)
        {
            // check selected layer
            if (!HasValidSelection) return;
            // get solution item
            SolutionItem item = _solutionItems[SelectedLayerIndex];
            item.SetInterlayer(GetInterlayerIndex(interlayer));
            // rebuild solution item list
            RebuildSolutionItemList();
        }
        public void ApplySymetryOnSelected(int axis)
        { 
            // check selected layer
            if (!HasValidSelection) return;
            // get solution item
            SolutionItem item = _solutionItems[SelectedLayerIndex];
            item.InverseSymetry(axis);
        }
        public InterlayerProperties SelectedInterlayer
        {
            get
            {
                if (!HasValidSelection) return null;
                if (-1 == _solutionItems[_selectedIndex].InterlayerIndex) return null;
                if (_solutionItems[_selectedIndex].InterlayerIndex >= _analysis.Interlayers.Count) return null;
                return _analysis.Interlayer( _solutionItems[_selectedIndex].InterlayerIndex ); 
            }
        }
        #endregion

        #region Public properties
        public int SelectedLayerIndex
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
        public List<LayerDesc> LayerDescriptors
        {
            get { return _layerDescriptors; }
        }
        public List<InterlayerProperties> Interlayers
        {
            get { return _analysis.Interlayers; } 
        }
        public List<SolutionItem> SolutionItems
        {
            get { return _solutionItems; }
            set
            {
                _solutionItems = value;
                _bbox.Reset();
            }
        }
        /// <summary>
        /// returns 3D layer. This is only used in LayerSummary
        /// </summary>
        internal ILayer GetILayer(int layerIndex, bool symX, bool symY)
        {
            ILayer2D currentLayer = _layers[layerIndex];

            if (currentLayer is Layer2D)
            {
                Layer2D layer2DBox = currentLayer as Layer2D;
                Layer3DBox boxLayer = new Layer3DBox(0.0, layerIndex);
                foreach (LayerPosition layerPos in layer2DBox)
                {
                    LayerPosition layerPosTemp = AdjustLayerPosition(layerPos, symX, symY);
                    boxLayer.Add(new BoxPosition(
                        layerPosTemp.Position + Analysis.Offset
                        , layerPosTemp.LengthAxis
                        , layerPosTemp.WidthAxis
                        ));
                }
                return boxLayer;
            }

            if (currentLayer is Layer2DCyl)
            {
                Layer2DCyl layer2DCyl = currentLayer as Layer2DCyl;
                Layer3DCyl cylLayer = new Layer3DCyl(0.0);
                foreach (Vector2D vPos in layer2DCyl)
                {
                    cylLayer.Add(
                        AdjustPosition(new Vector3D(vPos.X, vPos.Y, 0.0), symX, symY)
                        + Analysis.Offset);
                }
                return cylLayer;
            }
            return null;
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

                    ILayer2D currentLayer = _layers[solItem.LayerIndex];

                    if (currentLayer is Layer2D)
                    {
                        Layer2D layer2DBox = currentLayer as Layer2D;
                        Layer3DBox boxLayer = new Layer3DBox(zLayer, solItem.LayerIndex);
                        foreach (LayerPosition layerPos in layer2DBox)
                        {
                            LayerPosition layerPosTemp = AdjustLayerPosition(layerPos, solItem.SymetryX, solItem.SymetryY);
                            boxLayer.Add(new BoxPosition(
                                layerPosTemp.Position + Analysis.Offset + zLayer * Vector3D.ZAxis
                                , layerPosTemp.LengthAxis
                                , layerPosTemp.WidthAxis
                                ));

                            ++iBoxCount;
                        }
                        llayers.Add(boxLayer);
                    }
                    if (currentLayer is Layer2DCyl)
                    {
                        Layer2DCyl layer2DCyl = currentLayer as Layer2DCyl;
                        Layer3DCyl cylLayer = new Layer3DCyl(zLayer);
                        foreach (Vector2D vPos in layer2DCyl)
                        {
                            cylLayer.Add(
                                AdjustPosition(new Vector3D(vPos.X, vPos.Y, zLayer), solItem.SymetryX, solItem.SymetryY)
                                + Analysis.Offset);
                            ++iBoxCount;
                        }
                        llayers.Add(cylLayer);
                    }

                    zLayer += currentLayer.LayerHeight;
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
                        _bbox.Extend(layer.BoundingBox(Analysis.Content));
                    // sanity check
                    if (!_bbox.IsValid)
                        _bbox.Extend(Vector3D.Zero);
                }
                return _bbox.Clone();
            }
        }

        public BBox3D BBoxLoadWDeco
        {
            get
            {
                return Analysis.BBoxLoadWDeco(BBoxLoad); 
            }
        }
        public BBox3D BBoxGlobal
        {   get { return Analysis.BBoxGlobal(BBoxLoad); } }
        public int InterlayerCount
        {
            get
            {
                int layerCount = 0, interlayerCount = 0, boxCount = 0;
                GetCounts(ref layerCount, ref interlayerCount, ref boxCount);
                return interlayerCount;
            }
        }
        public int ItemCount
        {
            get
            {
                int layerCount = 0, interlayerCount = 0, itemCount = 0;
                GetCounts(ref layerCount, ref interlayerCount, ref itemCount);
                return itemCount;
            }
        }
        public int LayerCount
        {
            get
            {
                int layerCount = 0, interlayerCount = 0, itemCount = 0;
                GetCounts(ref layerCount, ref interlayerCount, ref itemCount);
                return layerCount; 
            }
        }
        private void GetCounts(ref int layerCount, ref int interlayerCount, ref int itemCount)
        {
            layerCount = 0;
            interlayerCount = 0;
            itemCount = 0;
            foreach (ILayer layer in Layers)
            {
                Layer3DBox blayer = layer as Layer3DBox;
                if (null != blayer)
                {
                    ++layerCount;
                    itemCount += blayer.BoxCount;
                }
                Layer3DCyl clayer = layer as Layer3DCyl;
                if (null != clayer)
                {
                    ++layerCount;
                    itemCount += clayer.CylinderCount;
                }
                InterlayerPos iLayer = layer as InterlayerPos;
                if (null != iLayer)
                    ++interlayerCount;
            }
        }
        public bool HasNetWeight
        {
            get
            {
                return false;
            }
        }
        public OptDouble NetWeight
        {
            get
            {
                return ItemCount * _analysis.Content.NetWeight;
            }
        }
        public double LoadWeight
        {
            get
            {
                return ItemCount * _analysis.ContentWeight;
            }
        }
        public double Weight
        {
            get
            {
                return LoadWeight + _analysis.ContainerWeight;
            }
        }
        public double VolumeEfficiency
        {
            get
            {
                return 100.0 * (ItemCount * _analysis.ContentVolume) / _analysis.ContainerLoadingVolume;
            }
        }
        #endregion

        #region Layer type methods
        public List<int> LayerTypeUsed(int layerTypeIndex)
        {
            List<int> solItemIndexes = new List<int>();
            int index = 0;
            foreach (SolutionItem solItem in _solutionItems)
            {
                if (solItem.LayerIndex == layerTypeIndex)
                    solItemIndexes.Add(index+1);
                ++index;
            }
            return solItemIndexes;            
        }
        public int NoLayerTypesUsed
        {
            get
            {
                int noLayerTypesUsed = 0;
                for (int i = 0; i < Layers.Count; ++i)
                    noLayerTypesUsed += Layers[i].BoxCount > 0 ? 1 : 0; 
                return noLayerTypesUsed;
            }
        }
        public string LayerCaption(int layerTypeIndex)
        {
            if (LayerCount == NoLayerTypesUsed)
                return Properties.Resources.ID_LAYERSALL;

            List<int> layerIndexes = LayerTypeUsed(layerTypeIndex);
            StringBuilder sb = new StringBuilder();
            sb.Append(layerIndexes.Count > 1 ? Properties.Resources.ID_LAYERS : Properties.Resources.ID_LAYER);
            int iCountIndexes = layerIndexes.Count;
            for (int j = 0; j < iCountIndexes; ++j)
            {
                sb.AppendFormat("{0}", layerIndexes[j]);
                if (j != iCountIndexes - 1)
                {
                    sb.Append(",");
                    if (j != 0 && 0 == j % 10)
                        sb.Append("\n");
                }
            }
            return sb.ToString();
        }
        public int LayerBoxCount(int layerTypeIndex)
        {
            return _layers[layerTypeIndex].Count;
        }
        public double LayerWeight(int layerTypeIndex)
        {
            return LayerBoxCount(layerTypeIndex) * _analysis.ContentWeight;
        }
        public double LayerNetWeight(int layerTypeIndex)
        {
            return LayerBoxCount(layerTypeIndex) * _analysis.Content.NetWeight.Value;
        }
        public double LayerMaximumSpace(int LayerTypeIndex)
        {
            return _layers[LayerTypeIndex].MaximumSpace;
        }

        #endregion

        #region Helpers
        /// <summary>
        /// if box bottom oriented to Z+, reverse box
        /// </summary>
        private LayerPosition AdjustLayerPosition(LayerPosition layerPos, bool reflectionX, bool reflectionY)
        {
            
            Vector3D dimensions = Analysis.ContentDimensions;
            Vector2D containerDims = Analysis.ContainerDimensions;

            // implement change
            LayerPosition layerPosTemp = new LayerPosition(layerPos);

            // apply symetry in X
            if (reflectionX)
            {
                Matrix4D matRot = new Matrix4D(
                  1.0, 0.0, 0.0, 0.0
                  , 0.0, -1.0, 0.0, 0.0
                  , 0.0, 0.0, 1.0, 0.0
                  , 0.0, 0.0, 0.0, 1.0
                  );
                Vector3D vTranslation = new Vector3D(0.0, containerDims.Y, 0.0);
                layerPosTemp = ApplyReflection(layerPosTemp, matRot, vTranslation);
            }
            // apply symetry in Y
            if (reflectionY)
            {
                Matrix4D matRot = new Matrix4D(
                    -1.0, 0.0, 0.0, 0.0
                    , 0.0, 1.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                Vector3D vTranslation = new Vector3D(containerDims.X, 0.0, 0.0);
                layerPosTemp = ApplyReflection(layerPosTemp, matRot, vTranslation);
            }
            return layerPosTemp.Adjusted(dimensions);
        }

        private Vector3D AdjustPosition(Vector3D v, bool reflectionX, bool reflectionY)
        {
            Vector2D containerDims = Analysis.ContainerDimensions;
            Vector3D posTemp = new Vector3D(v);
            // apply symetry in X
            if (reflectionX)
            {
                Matrix4D matRot = new Matrix4D(
                  1.0, 0.0, 0.0, 0.0
                  , 0.0, -1.0, 0.0, 0.0
                  , 0.0, 0.0, 1.0, 0.0
                  , 0.0, 0.0, 0.0, 1.0
                  );
                Vector3D vTranslation = new Vector3D(0.0, containerDims.Y, 0.0);
                posTemp = ApplyReflection(posTemp, matRot, vTranslation);
            }
            // apply symetry in Y
            if (reflectionY)
            {
                Matrix4D matRot = new Matrix4D(
                    -1.0, 0.0, 0.0, 0.0
                    , 0.0, 1.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                Vector3D vTranslation = new Vector3D(containerDims.X, 0.0, 0.0);
                posTemp = ApplyReflection(posTemp, matRot, vTranslation);
            }
            return posTemp;
        }

        private LayerPosition ApplyReflection(LayerPosition layerPos, Matrix4D matRot, Vector3D vTranslation)
        {
            Vector3D dimensions = Analysis.ContentDimensions;
            Transform3D transfRot = new Transform3D(matRot);
            HalfAxis.HAxis axisLength = HalfAxis.ToHalfAxis(transfRot.transform(HalfAxis.ToVector3D(layerPos.LengthAxis)));
            HalfAxis.HAxis axisWidth = HalfAxis.ToHalfAxis(transfRot.transform(HalfAxis.ToVector3D(layerPos.WidthAxis)));
            matRot.M14 = vTranslation[0];
            matRot.M24 = vTranslation[1];
            matRot.M34 = vTranslation[2];
            Transform3D transfRotTranslation = new Transform3D(matRot);

            Vector3D transPos = transfRotTranslation.transform( new Vector3D(layerPos.Position.X, layerPos.Position.Y, layerPos.Position.Z) );
            return new LayerPosition(
                new Vector3D(transPos.X, transPos.Y, transPos.Z)
                    - dimensions.Z * Vector3D.CrossProduct(HalfAxis.ToVector3D(axisLength), HalfAxis.ToVector3D(axisWidth))
                , axisLength
                , axisWidth);
        }

        private Vector3D ApplyReflection(Vector3D vPos, Matrix4D matRot, Vector3D vTranslation)
        {
            Transform3D transfRot = new Transform3D(matRot);
            matRot.M14 = vTranslation[0];
            matRot.M24 = vTranslation[1];
            matRot.M34 = vTranslation[2];
            Transform3D transfRotTranslation = new Transform3D(matRot);
            return transfRotTranslation.transform(vPos);  
        }

        private bool HasValidSelection
        {
            get { return _selectedIndex >= 0 && _selectedIndex < _solutionItems.Count; }
        }

        public List<LayerSummary> ListLayerSummary
        {
            get
            {
                List<LayerSummary> _layerSummaries = new List<LayerSummary>();
                int layerCount = 0;
                foreach (SolutionItem solItem in _solutionItems)
                {
                    LayerSummary layerSum = _layerSummaries.Find(delegate(LayerSummary lSum) { return lSum.IsLayerTypeOf(solItem); });
                    if (null == layerSum)
                    {
                        layerSum = new LayerSummary(this, solItem.LayerIndex, solItem.SymetryX, solItem.SymetryY);
                        _layerSummaries.Add(layerSum);
                    }
                    layerSum.AddIndex(++layerCount);
                }
                return _layerSummaries;
            }
        }
        #endregion

        #region Static members
        private static ILog _log = LogManager.GetLogger(typeof(Solution));
        #endregion
    }
    #endregion
}
