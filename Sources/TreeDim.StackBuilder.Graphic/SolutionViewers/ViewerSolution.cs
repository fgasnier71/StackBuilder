#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class ViewerSolution : Viewer
    {
        #region Constructor
        public ViewerSolution(SolutionLayered solution)
        {
            Solution = solution;
        }
        #endregion

        #region Viewer
        public override void Draw(Graphics3D graphics, Transform3D transform)
        {
            // clear list of picking box
            ClearPickingBoxes();

            if (null == Solution) return;
            AnalysisHomo analysis = Solution.Analysis;

            if (analysis is AnalysisPackablePallet analysisPackablePallet)
            {
                // ### draw pallet
                Pallet pallet = new Pallet(analysisPackablePallet.PalletProperties);
                pallet.Draw(graphics, transform);

                if (analysis is AnalysisCasePallet && -1 == Solution.SelectedLayerIndex)
                {
                    // ### strappers
                    SolutionLayered sol = Solution;
                    foreach (var sd in sol.Strappers)
                    {
                        if (null != sd.Points && sd.Points.Count > 0)
                        {
                            Strapper s = new Strapper(
                                transform.transform(IntToAxis(sd.Strapper.Axis)),
                                sd.Strapper.Width,
                                sd.Strapper.Color,
                                sd.Points.ConvertAll(p => transform.transform(p)).ToList());
                            s.DrawBegin(graphics);
                        }
                    }
                }
            }
            else if (analysis is AnalysisPackableCase analysisPackableCase)
            {
                // ### draw case (inside)
                Case case_ = new Case(analysisPackableCase.CaseProperties);
                case_.DrawInside(graphics, transform);
            }
            else if (analysis is AnalysisPackableTruck analysisPackableTruck)
            {
                // ### draw truck
                Truck truck = new Truck(analysisPackableTruck.TruckProperties);
                truck.DrawBegin(graphics);
            }
            else if (analysis is AnalysisPalletTruck analysisPalletTruck)
            {
                // ### draw truck
                Truck truck = new Truck(analysisPalletTruck.TruckProperties);
                truck.DrawBegin(graphics);
            }
            // ### draw solution
            uint layerId = 0, pickId = 0;
            List<ILayer> layers = Solution.Layers;
            foreach (ILayer layer in layers)
            {
                bool aboveSelectedLayer = (Solution.SelectedLayerIndex != -1) && (layerId > Solution.SelectedLayerIndex);
                Transform3D upTranslation = Transform3D.Translation(new Vector3D(0.0, 0.0, aboveSelectedLayer ? DistanceAboveSelectedLayer : 0.0));
                BBox3D bbox = new BBox3D();
                // ### layer of boxes
                if (layer is Layer3DBox layerBox)
                {
                    if (analysis.Content is LoadedPallet)
                    {
                        LoadedPallet loadedPallet = analysis.Content as LoadedPallet;
                        BBox3D solBBox = loadedPallet.ParentAnalysis.Solution.BBoxGlobal;
                        foreach (BoxPosition bPosition in layerBox)
                        {
                            var dim = solBBox.DimensionsVec;
                            graphics.AddImage(++pickId, new SubContent(loadedPallet.ParentAnalysis), solBBox.DimensionsVec, bPosition.Transform(transform));
                            // bbox used for picking
                            bbox.Extend(new BBox3D(bPosition.Transform(transform), solBBox.DimensionsVec));
                        }
                    }
                    else if (analysis.Content is PackProperties packProperties)
                    {
                        foreach (BoxPosition bPosition in layerBox)
                        {
                            BoxPosition boxPositionModified = bPosition.Transform(transform * upTranslation);
                            graphics.AddImage(++pickId, new SubContent(packProperties), packProperties.OuterDimensions, boxPositionModified);
                            // bbox used for picking
                            bbox.Extend(new BBox3D(boxPositionModified, packProperties.OuterDimensions));
                        }
                    }
                    else if (analysis.Content is BagProperties bagProperties)
                    {
                        foreach (BoxPosition bPosition in layerBox)
                        {
                            BoxPosition boxPositionModified = bPosition.Transform(transform * upTranslation);
                            graphics.AddImage(++pickId, new SubContent(bagProperties), bagProperties.OuterDimensions, boxPositionModified);
                            // bbox used for picking
                            bbox.Extend(new BBox3D(boxPositionModified, bagProperties.OuterDimensions));
                        }
                    }
                    else
                    {
                        foreach (BoxPosition bPosition in layerBox)
                        {
                            BoxPosition boxPositionModified = bPosition.Transform(transform * upTranslation);
                            BoxGeneric b;
                            if (analysis.Content is BagProperties bagProp)

                                b = new BoxRounded(pickId++, bagProp.Length, bagProp.Width, bagProp.Height, bagProp.Radius, boxPositionModified) { ColorFill = bagProp.ColorFill };
                            else
                                b = new Box(pickId++, analysis.Content as PackableBrick, boxPositionModified);
                            graphics.AddBox(b);
                            bbox.Extend(b.BBox);
                        }
                    }
                }
                else if (layer is Layer3DBoxIndexed layerBoxIndexed)
                {
                    foreach (var bpi in layerBoxIndexed)
                    {
                        BoxPosition boxPositionModified = bpi.BPos.Transform(transform * upTranslation);
                        var bProperties = analysis.Content as PackableBrick;
                        BoxGeneric b = new Box(pickId++, analysis.Content as PackableBrick, boxPositionModified);
                        graphics.AddBox(b);
                        // bbox used for picking
                        bbox.Extend(new BBox3D(boxPositionModified, bProperties.OuterDimensions));
                    }
                }
                else if (layer is Layer3DCyl layerCyl)
                {
                    foreach (Vector3D vPos in layerCyl)
                    {
                        CylPosition cylPosition = new CylPosition(transform.transform(vPos), HalfAxis.HAxis.AXIS_Z_P);
                        CylPosition cylPositionModified = cylPosition.Transform(transform * upTranslation);
                        Cyl cyl = null;
                        if (analysis.Content is CylinderProperties cylProp)
                            cyl = new Cylinder(pickId++, cylProp, cylPositionModified);
                        else if (analysis.Content is BottleProperties bottleProperties)
                            cyl = new Bottle(pickId++, bottleProperties, cylPositionModified);
                        graphics.AddCylinder(cyl);
                        bbox.Extend(cyl.BBox);
                    }
                }
                // ### interlayer
                else if (layer is InterlayerPos interlayerPos)
                {
                    InterlayerProperties interlayerProp = Solution.Interlayers[interlayerPos.TypeId];
                    if (null != interlayerProp)
                    {
                        BoxPosition bPosition = new BoxPosition(
                            new Vector3D(
                            analysis.Offset.X + 0.5 * (analysis.ContainerDimensions.X - interlayerProp.Length)
                            , analysis.Offset.Y + 0.5 * (analysis.ContainerDimensions.Y - interlayerProp.Width)
                            , interlayerPos.ZLow
                            ), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                        BoxPosition boxPositionModified = bPosition.Transform(transform * upTranslation);

                        Box box = new Box(pickId++, interlayerProp, boxPositionModified);
                        if (analysis.Content is PackProperties)
                        {
                            graphics.AddImage(pickId, new SubContent(interlayerProp), interlayerProp.Dimensions, boxPositionModified);
                        }
                        else
                            graphics.AddBox(box);
                        bbox.Extend(box.BBox);
                    }
                }

                if (layer is Layer3DBox || layer is Layer3DCyl)
                {
                    // add layer BBox
                    AddPickingBox(bbox, layerId);
                    // draw bounding box around selected layer
                    if (layerId == Solution.SelectedLayerIndex)
                        DrawLayerBoundingBox(graphics, bbox);
                    ++layerId;
                }
            }
            BBox3D loadBBox = Solution.BBoxLoad;
            BBox3D loadBBoxWDeco = Solution.BBoxLoadWDeco;
            if (analysis is AnalysisCasePallet analysisCasePallet)
            {
                #region Top interlayer
                if (analysisCasePallet.HasTopInterlayer)
                {
                    var upTranslation = Transform3D.Translation(new Vector3D(0.0, 0.0, -1 != Solution.SelectedLayerIndex ? DistanceAboveSelectedLayer : 0.0));
                    var interlayerProp = analysisCasePallet.TopInterlayerProperties;
                    BoxPosition bPosition = new BoxPosition(
                            new Vector3D(
                            analysis.Offset.X + 0.5 * (analysis.ContainerDimensions.X - interlayerProp.Length)
                            , analysis.Offset.Y + 0.5 * (analysis.ContainerDimensions.Y - interlayerProp.Width)
                            , loadBBox.PtMax.Z
                            ), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                    BoxPosition boxPositionModified = bPosition.Transform(transform * upTranslation);
                    Box box = new Box(pickId++, interlayerProp, boxPositionModified);
                    graphics.AddBox(box);
                    loadBBox.Extend(box.BBox);
                }
                #endregion

                #region Pallet corners
                // ### pallet corners : Begin
                Corner[] corners = new Corner[4];
                if (analysisCasePallet.HasPalletCorners)
                {
                    // positions
                    Vector3D[] cornerPositions =
                    {
                        loadBBox.PtMin
                        , new Vector3D(loadBBox.PtMax.X, loadBBox.PtMin.Y, loadBBox.PtMin.Z)
                        , new Vector3D(loadBBox.PtMax.X, loadBBox.PtMax.Y, loadBBox.PtMin.Z)
                        , new Vector3D(loadBBox.PtMin.X, loadBBox.PtMax.Y, loadBBox.PtMin.Z)
                    };
                    // length axes
                    HalfAxis.HAxis[] lAxes =
                    {
                        HalfAxis.HAxis.AXIS_X_P,
                        HalfAxis.HAxis.AXIS_Y_P,
                        HalfAxis.HAxis.AXIS_X_N,
                        HalfAxis.HAxis.AXIS_Y_N
                    };
                    // width axes
                    HalfAxis.HAxis[] wAxes =
                    {
                        HalfAxis.HAxis.AXIS_Y_P,
                        HalfAxis.HAxis.AXIS_X_N,
                        HalfAxis.HAxis.AXIS_Y_N,
                        HalfAxis.HAxis.AXIS_X_P
                    };
                    for (int i = 0; i < 4; ++i)
                    {
                        corners[i] = new Corner(0, analysisCasePallet.PalletCornerProperties)
                        {
                            Height = Math.Min(analysisCasePallet.PalletCornerProperties.Length, loadBBox.Height)
                        };
                        corners[i].SetPosition(
                            transform.transform(cornerPositions[i])
                            , HalfAxis.Transform(lAxes[i], transform), HalfAxis.Transform(wAxes[i], transform)
                            );
                        corners[i].DrawBegin(graphics);
                    }
                }
                #endregion

                #region Top corners
                Corner[] cornersTop = new Corner[4];
                if (analysisCasePallet.HasPalletCornersTopX || analysisCasePallet.HasPalletCornersTopY)
                {
                    double cornerWidth = analysisCasePallet.PalletCornerTopProperties.Width;
                    double lengthInLDir = Math.Min(analysisCasePallet.PalletCornerTopProperties.Length, loadBBox.Length - 2.0 * cornerWidth);
                    double widthInWDir = Math.Min(analysisCasePallet.PalletCornerTopProperties.Length, loadBBox.Width - 2.0 * cornerWidth);
                    double offsetInLDir = 0.5 * (loadBBox.Length - lengthInLDir);
                    double offsetInWdir = 0.5 * (loadBBox.Width - widthInWDir);

                    Transform3D upTranslation = Transform3D.Translation(new Vector3D(0.0, 0.0, -1 != Solution.SelectedLayerIndex ? DistanceAboveSelectedLayer : 0.0));


                    // positions
                    Vector3D[] cornerPositions =
                    {
                        new Vector3D(loadBBox.PtMin.X + offsetInLDir , loadBBox.PtMin.Y, loadBBox.PtMax.Z)
                        , new Vector3D(loadBBox.PtMax.X - offsetInLDir, loadBBox.PtMax.Y, loadBBox.PtMax.Z)
                        , new Vector3D(loadBBox.PtMax.X, loadBBox.PtMin.Y + offsetInWdir, loadBBox.PtMax.Z)
                        , new Vector3D(loadBBox.PtMin.X, loadBBox.PtMax.Y - offsetInWdir, loadBBox.PtMax.Z)
                    };
                    // length axes
                    HalfAxis.HAxis[] lAxes =
                    {
                        HalfAxis.HAxis.AXIS_Z_N,
                        HalfAxis.HAxis.AXIS_Z_N,
                        HalfAxis.HAxis.AXIS_Z_N,
                        HalfAxis.HAxis.AXIS_Z_N,
                    };
                    // width axes
                    HalfAxis.HAxis[] wAxes =
                   {
                        HalfAxis.HAxis.AXIS_Y_P,
                        HalfAxis.HAxis.AXIS_Y_N,
                        HalfAxis.HAxis.AXIS_X_N,
                        HalfAxis.HAxis.AXIS_X_P
                    };
                    for (int i = 0; i < 4; ++i)
                    {
                        cornersTop[i] = new Corner(0, analysisCasePallet.PalletCornerTopProperties)
                        {
                            Height = Math.Min(analysisCasePallet.PalletCornerTopProperties.Length, (i<2 ? loadBBox.Length : loadBBox.Width) - 2.0 * cornerWidth )
                        };
                        cornersTop[i].SetPosition(
                            transform.transform(upTranslation.transform( cornerPositions[i] ))
                            , HalfAxis.Transform(lAxes[i], transform), HalfAxis.Transform(wAxes[i], transform)
                            );
                    }
                    // drawing
                    if (analysisCasePallet.HasPalletCornersTopX)
                    {
                        for (int i = 0; i < 2; ++i)
                            cornersTop[i].DrawBegin(graphics);
                    }
                    if (analysisCasePallet.HasPalletCornersTopY)
                    {
                        for (int i = 2; i < 4; ++i)
                            cornersTop[i].DrawBegin(graphics);
                    }
                }
                #endregion

                #region Pallet film
                // ### pallet film
                Film film = null;
                if (analysisCasePallet.HasPalletFilm && -1 == Solution.SelectedLayerIndex)
                {
                    // instantiate film
                    PalletFilmProperties palletFilmProperties = analysisCasePallet.PalletFilmProperties;
                    film = new Film(
                        palletFilmProperties.Color,
                        palletFilmProperties.UseTransparency,
                        palletFilmProperties.UseHatching,
                        palletFilmProperties.HatchSpacing,
                        palletFilmProperties.HatchAngle);
                    film.AddRectangle(new FilmRectangle(transform.transform(loadBBoxWDeco.PtMin)
                        , HalfAxis.Transform(HalfAxis.HAxis.AXIS_X_P, transform), HalfAxis.Transform(HalfAxis.HAxis.AXIS_Z_P, transform)
                        , new Vector2D(loadBBoxWDeco.Length, loadBBoxWDeco.Height), -1.0));
                    film.AddRectangle(new FilmRectangle(transform.transform(loadBBoxWDeco.PtMin + loadBBoxWDeco.Length * Vector3D.XAxis)
                        , HalfAxis.Transform(HalfAxis.HAxis.AXIS_Y_P, transform), HalfAxis.Transform(HalfAxis.HAxis.AXIS_Z_P, transform)
                        , new Vector2D(loadBBoxWDeco.Width, loadBBoxWDeco.Height), -1.0));
                    film.AddRectangle(new FilmRectangle(transform.transform(loadBBoxWDeco.PtMin + loadBBoxWDeco.Length * Vector3D.XAxis + loadBBoxWDeco.Width * Vector3D.YAxis)
                        , HalfAxis.Transform(HalfAxis.HAxis.AXIS_X_N, transform), HalfAxis.Transform(HalfAxis.HAxis.AXIS_Z_P, transform)
                        , new Vector2D(loadBBoxWDeco.Length, loadBBoxWDeco.Height), -1.0));
                    film.AddRectangle(new FilmRectangle(transform.transform(loadBBoxWDeco.PtMin + loadBBoxWDeco.Width * Vector3D.YAxis)
                        , HalfAxis.Transform(HalfAxis.HAxis.AXIS_Y_N, transform), HalfAxis.Transform(HalfAxis.HAxis.AXIS_Z_P, transform)
                        , new Vector2D(loadBBoxWDeco.Width, loadBBoxWDeco.Height), -1.0));
                    film.AddRectangle(new FilmRectangle(transform.transform(loadBBoxWDeco.PtMin + loadBBoxWDeco.Height * Vector3D.ZAxis)
                        , HalfAxis.Transform(HalfAxis.HAxis.AXIS_X_P, transform), HalfAxis.Transform(HalfAxis.HAxis.AXIS_Y_P, transform)
                        , new Vector2D(loadBBoxWDeco.Length, loadBBoxWDeco.Width)
                        , analysisCasePallet.PalletFilmTopCovering));
                    film.DrawBegin(graphics);
                }
                #endregion

                #region Pallet corners
                // pallet corners : End
                if (analysisCasePallet.HasPalletCorners)
                {
                    for (int i = 0; i < 4; ++i)
                        corners[i].DrawEnd(graphics);
                }
                if (analysisCasePallet.HasPalletCornersTopX)
                {
                    for (int i = 0; i < 2; ++i)
                        cornersTop[i].DrawEnd(graphics);
                }
                if (analysisCasePallet.HasPalletCornersTopY)
                {
                    for (int i = 2; i < 4; ++i)
                        cornersTop[i].DrawEnd(graphics);
                }
                #endregion

                #region Pallet sleeves
                // ### pallet sleeve
                if (analysisCasePallet.HasPalletSleeve)
                {
                    var ps = new PalletSleeve(0, loadBBox, analysisCasePallet.PalletSleeveColor);
                    ps.DrawEnd(graphics);
                }
                #endregion

                #region Pallet Cap
                // ### pallet cap
                if (analysisCasePallet.HasPalletCap)
                {
                    PalletCapProperties capProperties = analysisCasePallet.PalletCapProperties;
                    BoxPosition bPosition = new BoxPosition(new Vector3D(
                        0.5 * (analysisCasePallet.PalletProperties.Length - capProperties.Length),
                        0.5 * (analysisCasePallet.PalletProperties.Width - capProperties.Width),
                        loadBBox.PtMax.Z - capProperties.InsideHeight)
                        , HalfAxis.Transform(HalfAxis.HAxis.AXIS_X_P, transform)
                        , HalfAxis.Transform(HalfAxis.HAxis.AXIS_Y_P, transform)
                        );

                    Transform3D upTranslation = Transform3D.Translation(new Vector3D(0.0, 0.0, -1 != Solution.SelectedLayerIndex ? DistanceAboveSelectedLayer : 0.0));
                    PalletCap cap = new PalletCap(0, capProperties, bPosition.Transform(upTranslation));
                    cap.DrawEnd(graphics);
                }
                #endregion

                #region Pallet labels
                // ### pallet labels
                if (null != analysisCasePallet)
                {
                    foreach (var pli in analysisCasePallet.PalletLabels)
                    {
                        var pl = new PalletLabel(++pickId, pli.PalletLabelProperties, pli.ToBoxPosition(loadBBox));
                        pl.DrawEnd(graphics);
                    }
                }
                #endregion

                #region Strappers
                // ### strappers
                if (-1 == Solution.SelectedLayerIndex)
                {
                    foreach (var sd in Solution.Strappers)
                    {
                        if (null == sd.Points && sd.Points.Count > 0)
                        {
                            var strapper = new Strapper(
                                transform.transform(IntToAxis(sd.Strapper.Axis)),
                                sd.Strapper.Width,
                                sd.Strapper.Color,
                                sd.Points.Select(p => transform.transform(p)).ToList());
                            strapper.DrawEnd(graphics);
                        }
                    }
                }
                #endregion

                #region Pallet film
                // pallet film : End
                if (analysisCasePallet.HasPalletFilm && null != film)
                    film.DrawEnd(graphics);
                #endregion
            }
            else if (analysis is AnalysisPackableTruck analysisPackableTruck2)
            {
                Truck truck = new Truck(analysisPackableTruck2.TruckProperties);
                truck.DrawEnd(graphics);
            }
            else if (analysis is AnalysisPalletTruck analysisPalletTruck)
            {
                Truck truck = new Truck(analysisPalletTruck.TruckProperties);
                truck.DrawEnd(graphics);
            }
            // ### dimensions
            // dimensions should only be shown when no layer is selected
            if (graphics.ShowDimensions && (-1 == Solution.SelectedLayerIndex))
            {
                graphics.AddDimensions(new DimensionCube(BoundingBoxDim(DimCasePalletSol1), Color.Black, false));
                graphics.AddDimensions(new DimensionCube(BoundingBoxDim(DimCasePalletSol2), Color.Red, true));
            }
            // ###
        }
        public override void Draw(Graphics2D graphics)
        {
            if (null == Solution) return;
        }
        #endregion

        #region Public static methods
        public static void DrawILayer(Graphics3D graphics, ILayer layer, Packable packable, bool showDimensions)
        {
            bool show3D = Properties.Settings.Default.LayerView3D;
            graphics.CameraPosition = show3D ? Graphics3D.Corner_0 : Graphics3D.Top;

            uint pickId = 0;
            BBox3D bbox = new BBox3D();
            // ### layer of boxes ###
            if (layer is Layer3DBox layerBox)
            {
                foreach (BoxPosition bPosition in layerBox)
                {
                    Box b = null;
                    if (packable is PackProperties)
                        b = new Pack(pickId++, packable as PackProperties, bPosition);
                    else
                        b = new Box(pickId++, packable as PackableBrick, bPosition);
                    graphics.AddBox(b);
                    bbox.Extend(b.BBox);
                }
            }
            // ###
            // ### layer of cylinders ###
            if (layer is Layer3DCyl layerCyl)
            {
                foreach (Vector3D vPos in layerCyl)
                {
                    Cyl cyl = null;
                    if (packable is CylinderProperties cylinderProp)
                        cyl = new Cylinder(pickId++, cylinderProp, new CylPosition(vPos, HalfAxis.HAxis.AXIS_Z_P));
                    else if (packable is BottleProperties bottleProp)
                        cyl = new Bottle(pickId++, bottleProp, new CylPosition(vPos, HalfAxis.HAxis.AXIS_Z_P));
                    graphics.AddCylinder(cyl);
                    bbox.Extend(cyl.BBox);
                }
            }
            // ###
            if (showDimensions)
            {
                graphics.AddDimensions(new DimensionCube(bbox, Color.Black, false));
            }
        }
        #endregion

        #region Static properties
        public static double DistanceAboveSelectedLayer { get; set; }
        public static int DimCasePalletSol1 { get; set; } = 0;
        public static int DimCasePalletSol2 { get; set; } = 1;
        #endregion

        #region Helpers
        private BBox3D BoundingBoxDim(int index)
        {
            PalletProperties palletProperties = null;
            if (Solution.Analysis is AnalysisCasePallet analysisCasePallet)
                palletProperties = analysisCasePallet.PalletProperties;
            if (Solution.Analysis is AnalysisCylinderPallet analysisCylinderPallet)
                palletProperties = analysisCylinderPallet.PalletProperties;

            switch (index)
            {
                case 0: return Solution.BBoxGlobal;
                case 1: return Solution.BBoxLoadWDeco;
                case 2: return palletProperties.BoundingBox;
                case 3: return new BBox3D(0.0, 0.0, 0.0, palletProperties.Length, palletProperties.Width, 0.0);
                default: return Solution.BBoxGlobal;
            }
        }

        private void DrawLayerBoundingBox(Graphics3D graphics, BBox3D bbox)
        {
            Vector3D ptMin = bbox.PtMin;
            Vector3D ptMax = bbox.PtMax;

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
            Face[] faces = {
                            new Face(0, vertices[0], vertices[1], vertices[5], vertices[4], "CASE", false),
                            new Face(0, vertices[1], vertices[2], vertices[6], vertices[5], "CASE", false),
                            new Face(0, vertices[2], vertices[3], vertices[7], vertices[6], "CASE", false),
                            new Face(0, vertices[3], vertices[0], vertices[4], vertices[7], "CASE", false),
                        };

            foreach (Face f in faces)
            {
                if (f.IsVisible(ViewDir))
                {
                    Vector3D[] points = f.Points;
                    graphics.AddSegment(new Segment(points[0], points[1], Color.Red));
                    graphics.AddSegment(new Segment(points[1], points[2], Color.Red));
                    graphics.AddSegment(new Segment(points[2], points[3], Color.Red));
                    graphics.AddSegment(new Segment(points[3], points[0], Color.Red));
                }
            }
        }
        private Vector3D IntToAxis(int iAxis)
        {
            switch (iAxis)
            {
                case 0: return Vector3D.XAxis;
                case 1: return Vector3D.YAxis;
                case 2: return Vector3D.ZAxis;
                default: return Vector3D.Zero;
            }
        }
        #endregion

        #region Data members
        private SolutionLayered Solution { get; set; }
        #endregion
    }
}
