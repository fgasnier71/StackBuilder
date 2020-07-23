using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using stb;

namespace treeDiM.StackBuilder.Exporters
{
    /// <summary>
    /// This uses classes generated from xml schema StackBuilderXMLExport.xsd
    /// Command line is: xsd /c /namespace:stb /language:CS StackBuilderXMLExport.xsd
    /// </summary>
    public class ExporterXML: Exporter
    {
        #region Static members
        public static string FormatName => "xml";
        #endregion

        public ExporterXML() {}
        public override string Name => FormatName;
        public override string Filter => "eXchange Markup Language (*.xml)|*.xml";
        public override string Extension => "xml";
        public override void Export(AnalysisLayered analysis, ref Stream stream)
        {
            SolutionLayered sol = analysis.SolutionLay;

            // build orderDocument element
            orderDocument document = new orderDocument()
            {
                date = DateTime.Now,
                unit = CurrentUnit,
                author = analysis.ParentDocument != null ? analysis.ParentDocument.Author : string.Empty,
                orderType = new orderDocumentOrderType()
                {
                    orderNumber = analysis.Name,
                    orderLine = new orderLine()
                    {
                        itemId = 1,
                        quantity = analysis.Solution.ItemCount
                    },
                    loadSpace = BuildLoadSpace(analysis),
                    item = BuildItem(analysis),
                    load = new load()
                    {
                        loadSpaceId = 1,
                        statistics = new statistics()
                        {
                            loadVolume = sol.LoadVolume,
                            loadWeight = sol.LoadWeight,
                            volumeUtilization = sol.VolumeEfficiency,
                            weightUtilization = sol.WeightEfficiency.ToDouble(),
                            cOfG = new cOfG() { x = sol.COfG.X, y = sol.COfG.Y, z = sol.COfG.Z },
                            loadHeight = sol.BBoxLoad.Height
                        },
                        placement = BuildPlacementArray(sol, analysis)
                    }
                }
            };

            // serialization
            XmlSerializer serializer = new XmlSerializer(typeof(orderDocument));
            serializer.Serialize(stream, document);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
        }
        #region Helpers
        private units CurrentUnit
        {
            get
            {
                switch (UnitsManager.CurrentUnitSystem)
                {
                    case UnitsManager.UnitSystem.UNIT_METRIC1: return units.mmkg;
                    case UnitsManager.UnitSystem.UNIT_METRIC2: return units.cmkg;
                    case UnitsManager.UnitSystem.UNIT_IMPERIAL:
                    case UnitsManager.UnitSystem.UNIT_US: return units.inlb;
                    default: throw new Exception("Unexpected unit system");
                }
            }
        }
        private loadSpace BuildLoadSpace(AnalysisLayered analysis)
        {
            if (analysis is AnalysisCasePallet analysisCasePallet)
            {
                PalletProperties palletProperties = analysisCasePallet.PalletProperties;
                ConstraintSetCasePallet constraintSet = analysisCasePallet.ConstraintSet as ConstraintSetCasePallet;
                return new loadSpace()
                {
                    id = 1,
                    name = palletProperties.Name,
                    length = palletProperties.Length,
                    width = palletProperties.Width,
                    baseHeight = palletProperties.Height,
                    maxLengthOverhang = constraintSet.Overhang.X,
                    maxWidthOverhang = constraintSet.Overhang.Y,
                    maxLoadHeight = constraintSet.OptMaxHeight.Activated ? constraintSet.OptMaxHeight.Value : 0.0,
                    maxLoadWeight = constraintSet.OptMaxWeight.Activated ? constraintSet.OptMaxWeight.Value : 0.0
                };
            }
            else
                throw new Exception(string.Format("Unexpected analysis type : {0}", analysis.GetType()));
        }
        private item BuildItem(AnalysisLayered analysis)
        {
            if (analysis is AnalysisCasePallet analysisCasePallet)
            {
                Packable packable = analysisCasePallet.Content;
                ConstraintSetCasePallet constraintSet = analysisCasePallet.ConstraintSet as ConstraintSetCasePallet;
                bool[] orient = constraintSet.AllowedOrientations;
                StringBuilder sbOrient = new StringBuilder();
                foreach (bool b in orient)
                { sbOrient.Append(b ? "1" : "0"); }
                return new item()
                {
                    id = 1,
                    name = packable.Name,
                    length = packable.OuterDimensions.X,
                    width = packable.OuterDimensions.Y,
                    height = packable.OuterDimensions.Z,
                    weight = packable.Weight,
                    maxWeightOnTop = 0.0,
                    permittedOrientations = sbOrient.ToString()
                };
            }
            else
                throw new Exception(string.Format("Unexpected analysis type : {0}", analysis.GetType()));
        }
        private placement[] BuildPlacementArray(SolutionLayered sol, AnalysisLayered analysis)
        {
            List<placement> lPlacements = new List<placement>();
            List<ILayer> layers = sol.Layers;
            foreach (ILayer layer in layers)
            {
                if (layer is Layer3DBox layerBox)
                {
                    layerBox.Sort(analysis.Content, Layer3DBox.SortType.DIST);
                    foreach (BoxPosition bPosition in layerBox)
                    {
                        Vector3D writtenPosition = ConvertPosition(bPosition, analysis.ContentDimensions);
                        lPlacements.Add(
                            new placement()
                            {
                                itemId = 1,
                                x = writtenPosition.X,
                                y = writtenPosition.Y,
                                z = writtenPosition.Z,
                                L = ToAxis(bPosition.DirectionLength),
                                W = ToAxis(bPosition.DirectionWidth)
                            }
                            );
                    }
                }
            }
            return lPlacements.ToArray();
        }
        private HAxis ToAxis(HalfAxis.HAxis axis)
        {
            switch (axis)
            {
                case HalfAxis.HAxis.AXIS_X_N: return HAxis.XN;
                case HalfAxis.HAxis.AXIS_X_P: return HAxis.XP;
                case HalfAxis.HAxis.AXIS_Y_N: return HAxis.YN;
                case HalfAxis.HAxis.AXIS_Y_P: return HAxis.YP;
                case HalfAxis.HAxis.AXIS_Z_N: return HAxis.ZN;
                case HalfAxis.HAxis.AXIS_Z_P: return HAxis.ZP;
                default: return HAxis.XN;
            }
        }
        #endregion

    }
}
