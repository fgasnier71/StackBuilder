#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using log4net;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;
#endregion

namespace treeDiM.StackBuilder.WCFService
{
    public class StackBuilderServ : IStackBuilder
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(StackBuilderServ));
        #endregion

        #region Best solution
        public DCSBSolution SB_GetBestSolution(
            DCSBCase sbCase, DCSBPallet sbPallet, DCSBInterlayer sbInterlayer,
            DCSBConstraintSet sbConstraintSet,
            DCCompFormat expectedFormat, bool showCotations)
        {
            List<string> lErrors = new List<string>();
            try
            {
                BoxProperties boxProperties = new BoxProperties(null, sbCase.DimensionsOuter.M0, sbCase.DimensionsOuter.M1, sbCase.DimensionsOuter.M2)
                {
                    InsideLength = null != sbCase.DimensionsInner ? sbCase.DimensionsInner.M0 : 0.0,
                    InsideWidth = null != sbCase.DimensionsInner ? sbCase.DimensionsInner.M1 : 0.0,
                    InsideHeight = null != sbCase.DimensionsInner ? sbCase.DimensionsInner.M2 : 0.0,
                    TapeColor = Color.FromArgb(sbCase.TapeColor),
                    TapeWidth = new OptDouble(sbCase.TapeWidth != 0.0, sbCase.TapeWidth)
                };
                boxProperties.SetWeight(sbCase.Weight);
                boxProperties.SetNetWeight(new OptDouble(sbCase.NetWeight.HasValue, sbCase.NetWeight.Value));
                if (null != sbCase.Colors && sbCase.Colors.Length >= 6)
                {
                    for (int i = 0; i < 6; ++i)
                        boxProperties.SetColor((HalfAxis.HAxis)i, Color.FromArgb(sbCase.Colors[i]));
                }
                else
                    boxProperties.SetAllColors(
                        new Color[]
                        {
                            Color.Chocolate, Color.Chocolate, Color.Chocolate,
                            Color.Chocolate, Color.Chocolate, Color.Chocolate
                        });

                PalletProperties palletProperties = null;
                if (null != sbPallet.Dimensions)
                    palletProperties = new PalletProperties(null, sbPallet.PalletType,
                        sbPallet.Dimensions.M0, sbPallet.Dimensions.M1, sbPallet.Dimensions.M2)
                    {
                        Weight = sbPallet.Weight,
                        Color = Color.FromArgb(sbPallet.Color),
                        AdmissibleLoadWeight = sbPallet.AdmissibleLoad ?? 0.0
                    };
                else
                    palletProperties = new PalletProperties(null, "EUR2", 1200.0, 1000.0, 150.0);

                InterlayerProperties interlayerProperties = null;
                if (null != sbInterlayer) { }

                OptDouble oMaxWeight = null != sbConstraintSet.MaxWeight ? new OptDouble(sbConstraintSet.MaxWeight.Active, sbConstraintSet.MaxWeight.Value_d) : OptDouble.Zero;
                OptDouble oMaxHeight = null != sbConstraintSet.MaxHeight ? new OptDouble(sbConstraintSet.MaxHeight.Active, sbConstraintSet.MaxHeight.Value_d) : OptDouble.Zero;
                OptInt oMaxNumber = null != sbConstraintSet.MaxNumber ? new OptInt(sbConstraintSet.MaxNumber.Active, sbConstraintSet.MaxNumber.Value_i) : OptInt.Zero;
                ConstraintSetCasePallet constraintSet = new ConstraintSetCasePallet()
                {
                    OptMaxWeight = oMaxWeight,
                    OptMaxNumber = oMaxNumber
                };
                constraintSet.SetMaxHeight(oMaxHeight);
                constraintSet.SetAllowedOrientations(new bool[] { sbConstraintSet.Orientation.X, sbConstraintSet.Orientation.Y, sbConstraintSet.Orientation.Z });

                Vector3D cameraPosition = Graphics3D.Corner_0;
                int layerCount = 0, caseCount = 0, interlayerCount = 0;
                double weightTotal = 0.0, weightLoad = 0.0, efficiency = 0.0;
                double? weightNet = (double?)null;
                Vector3D bbLoad = new Vector3D();
                Vector3D bbGlob = new Vector3D();
                byte[] imageBytes = null;
                string[] errors = null;

                if (StackBuilderProcessor.GetBestSolution(
                    boxProperties, palletProperties, interlayerProperties,
                    constraintSet, cameraPosition, showCotations, 0.01f,
                    new Size(expectedFormat.Size.CX, expectedFormat.Size.CY),
                    ref layerCount, ref caseCount, ref interlayerCount,
                    ref weightTotal, ref weightLoad, ref weightNet,
                    ref bbLoad, ref bbGlob,
                    ref imageBytes, ref errors))
                {
                    foreach (string err in errors)
                        lErrors.Add(err);
                    return new DCSBSolution()
                    {
                        LayerCount = layerCount,
                        CaseCount = caseCount,
                        InterlayerCount = interlayerCount,
                        WeightLoad = weightLoad,
                        WeightTotal = weightTotal,
                        NetWeight = weightNet,
                        BBoxLoad = new DCSBDim3D(bbLoad.X, bbLoad.Y, bbLoad.Z),
                        BBoxTotal = new DCSBDim3D(bbGlob.X, bbGlob.Y, bbGlob.Z),
                        Efficiency = efficiency,
                        OutFile = new DCCompFileOutput()
                        {
                            Bytes = imageBytes,
                            Format = new DCCompFormat()
                            {
                                Format = EOutFormat.IMAGE,
                                Size = new DCCompSize()
                                {
                                    CX = expectedFormat.Size.CX,
                                    CY = expectedFormat.Size.CY
                                }
                            }
                        },
                        Errors = lErrors.ToArray()
                    };
                }
            }
            catch (Exception ex)
            {
                lErrors.Add(ex.Message);
                _log.Error(ex.ToString());
            }
            return new DCSBSolution() { Errors = lErrors.ToArray() };
        }
        #endregion
    }

    #region StackBuilderProcessor
    public class StackBuilderProcessor
    {
        public static bool GetBestSolution(BoxProperties boxProperties, PalletProperties palletProperties, InterlayerProperties interlayer
            , ConstraintSetCasePallet constraintSet
            , Vector3D cameraPosition, bool showCotations, float fontSizeRatio, Size sz
            , ref int layerCount, ref int caseCount, ref int interlayerCount
            , ref double weightTotal, ref double weightLoad, ref double? weightNet
            , ref Vector3D bbLoad, ref Vector3D bbGlob
            , ref byte[] imageBytes
            , ref string[] errors)
        {
            List<string> lErrors = new List<string>();
            try
            {
                // use a solver and get a list of sorted analyses + select the best one
                SolverCasePallet solver = new SolverCasePallet(boxProperties, palletProperties);
                List<Analysis> analyses = solver.BuildAnalyses(constraintSet);
                if (analyses.Count > 0)
                {
                    Analysis analysis = analyses[0];
                    layerCount = analysis.Solution.LayerCount;
                    caseCount = analysis.Solution.ItemCount;
                    interlayerCount = analysis.Solution.LayerCount;

                    weightLoad = analysis.Solution.LoadWeight;
                    weightTotal = analysis.Solution.Weight;

                    OptDouble optNetWeight = analysis.Solution.NetWeight;
                    weightNet = optNetWeight.Activated ? optNetWeight.Value : (double?)null;
                    bbGlob = analysis.Solution.BBoxGlobal.DimensionsVec;
                    bbLoad = analysis.Solution.BBoxLoad.DimensionsVec;

                    Graphics3DImage graphics = null;
                    // generate image path
                    graphics = new Graphics3DImage(sz)
                    {
                        FontSizeRatio = fontSizeRatio,
                        CameraPosition = cameraPosition,
                        ShowDimensions = showCotations
                    };
                    ViewerSolution sv = new ViewerSolution(analysis.Solution);
                    sv.Draw(graphics, Transform3D.Identity);
                    graphics.Flush();
                    Bitmap bmp = graphics.Bitmap;
                    ImageConverter converter = new ImageConverter();
                    imageBytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
                }
            }
            catch (Exception ex)
            {
                lErrors.Add(ex.Message);
            }
            errors = lErrors.ToArray();
            return (0 == lErrors.Count);
        }
    }
    #endregion
}
