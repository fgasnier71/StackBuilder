#region Using directives
using Sharp3D.Math.Core;
using System;
using System.Collections.Generic;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class AnalysisHPalletTruck : Analysis
    {
        #region Constructor
        public AnalysisHPalletTruck(Document doc)
            : base(doc)
        {
        }
        #endregion

        #region Override Analysis
        public override bool HasValidSolution => null != Solution;
        #endregion

        #region Helpers
        public List<Packable> Content
        {
            get
            {
                List<Packable> listPallet = new List<Packable>();

                return listPallet;
            }
        }
        public List<PalletColumn> GeneratePalletColumns()
        {
            double height = Truck.InsideHeight;

            // build single pallet columns
            var palletColumns = new List<PalletColumn>();
            foreach (var palletItem in PalletItems)
            {
                for (int i = 0; i < palletItem.Number; ++i)
                    palletColumns.Add(new PalletColumn(palletItem.Pack));
            }
            // apply rules one by one
            foreach (var rule in PalletStackingRules)
            {
                bool success = false;

                do
                {
                    success = false;
                    // find pallet above
                    int iPlaceAbove = -1;
                    for (int i = 0; i < palletColumns.Count; ++i)
                    {
                        var palletColumn = palletColumns[i];
                        if (palletColumn.IsPallet(rule.PalletAbove))
                        {
                            iPlaceAbove = i;
                            break;
                        }
                    }

                    if (iPlaceAbove != -1)
                    {
                        // find pallet under
                        int iPlaceUnder = -1;
                        for (int i = 0; i < palletColumns.Count; ++i)
                        {
                            if (i == iPlaceAbove)
                                continue;
                            var palletColumn = palletColumns[i];
                            if (palletColumn.IsPallet(rule.PalletUnder))
                            {
                                iPlaceUnder = i;
                                break;
                            }
                        }
                        if (iPlaceUnder != -1 && iPlaceUnder != iPlaceAbove)
                        {
                            // move
                            if (palletColumns[iPlaceUnder].CanStack(rule.PalletAbove, height))
                            {
                                palletColumns[iPlaceUnder].Pallets.Add(rule.PalletAbove);
                                palletColumns.RemoveAt(iPlaceAbove);

                                success = true;
                            }
                        }
                    }
                }
                while (success);
            }
            return palletColumns;
        }
        #endregion

        #region Public properties
        public List<PalletItem> PalletItems { get; set; } = new List<PalletItem>();
        public List<PalletStackingRule> PalletStackingRules { get; set; } = new List<PalletStackingRule>();
        public HSolutionPalletTruck Solution { get; set; }
        public List<ItemBase> Containers { get; set; } = new List<ItemBase>();
        public TruckProperties Truck
        {
            get => Containers[0] as TruckProperties;
            set { Containers.Clear(); Containers.Add(value); }
        }
        #endregion
    }

    public class PalletItem
    {
        public PalletItem(LoadedPallet p, uint n) { }
        public uint Number { get; set; }
        public LoadedPallet Pack { get; set; }
    }

    public class PalletColumn
    {
        #region Constructor
        public PalletColumn(LoadedPallet loadedPallet)
        {
            Pallets.Add(loadedPallet);
        }
        public PalletColumn(List<LoadedPallet> listPallets)
        {
            Pallets.AddRange(listPallets);
        }
        #endregion

        #region Public methods
        public bool CanStack(LoadedPallet pallet, double maxHeight) => Height + pallet.Height <= maxHeight;
        #endregion

        #region public Properties
        public double Height
        {
            get
            {
                double height = 0;
                foreach (var pallet in Pallets) height += pallet.Height;
                return height;
            } 
        }
        public Vector3D Dimensions
        {
            get
            {
                double length = 0.0, width = 0.0;
                foreach (var p in Pallets)
                {
                    length = Math.Max(p.Length, length);
                    width = Math.Max(p.Width, width);
                }
                return new Vector3D(length, width, Height);
            }
        }

        public bool IsPallet(LoadedPallet pallet) => Pallets.Count == 1 && Pallets[0] == pallet;
        public bool Single => Pallets.Count == 1;
        public bool Empty => Pallets.Count == 0;
        public List<LoadedPallet> Pallets { get; set; } = new List<LoadedPallet>();
        public BoxPosition Position { get; set; }
        #endregion
    }

    public class PalletStackingRule
    {
        #region Constructor
        public PalletStackingRule(LoadedPallet palletAbove, LoadedPallet palletUnder)
        {
            PalletAbove = palletAbove;
            PalletUnder = palletUnder;
        }
        #endregion

        #region Verification
        public bool Equal(PalletStackingRule stackingRule) => stackingRule.PalletAbove == PalletAbove && stackingRule.PalletUnder == PalletUnder;
        public bool Opposite(PalletStackingRule stackingRule) => PalletAbove != PalletUnder && stackingRule.PalletAbove == PalletUnder && stackingRule.PalletUnder == PalletAbove;
        #endregion

        #region Accept method
        public bool CanBeAddedToList(List<PalletStackingRule> rules)
        {
            foreach (var rule in rules)
            {
                if (Equal(rule)) return false;
                if (Opposite(rule)) return false;
            }
            return true;
        }
        #endregion

        #region Data members
        public LoadedPallet PalletAbove { get; private set; }
        public LoadedPallet PalletUnder { get; private set; }
        #endregion
    }

    public class TruckLoad
    {
        public List<PalletColumn> PalletColumns { get; set; } = new List<PalletColumn>();
    }

    public class HSolutionPalletTruck
    {
        public HSolutionPalletTruck(string algo) { Algorithm = algo; }
        public List<TruckLoad> TruckLoads { get; set; } = new List<TruckLoad>();
        public string Algorithm { get; set; }
    }
}