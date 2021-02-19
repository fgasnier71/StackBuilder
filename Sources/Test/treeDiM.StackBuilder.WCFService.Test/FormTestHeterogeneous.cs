#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using log4net;
using WeifenLuo.WinFormsUI.Docking;

using treeDiM.StackBuilder.WCFService.Test.SB_SR;
#endregion

namespace treeDiM.StackBuilder.WCFService.Test
{
    public partial class FormTestHeterogeneous : DockContent
    {
        #region Constructor
        public FormTestHeterogeneous()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PalletLength = 1200.0; PalletWidth = 1000.0; PalletHeight = 144.0;
            PalletWeight = 22.0;

            MaxPalletHeight = 1700.0;
            MaxPalletWeight = 1000.0;


            Items.Add(
                new DCSBContentItem()
                {
                    Number = 1,
                    Orientation = new DCSBBool3()
                    {
                        X = false,
                        Y = false,
                        Z = true
                    },
                    Case = new DCSBCase()
                    {
                        Name = "Case", 
                        Description = "Default case",
                        DimensionsOuter = new DCSBDim3D() { M0 = 400.0, M1=300.0, M2=200.0 },
                        HasInnerDims = false,
                        DimensionsInner = null,
                        Weight = 1.0,
                        MaxWeight = 100.0,
                        NetWeight= 0.9,
                        ShowTape = true,
                        TapeWidth = 50.0,
                        TapeColor = Color.Beige.ToArgb(),
                        Colors = Enumerable.Repeat(Color.Chocolate.ToArgb(), 6).ToArray()
                    }
                }
                );
        }
        #endregion

        #region Event handlers
        private void OnBoxesAdd(object sender, EventArgs e)
        {

        }
        private void OnBoxesRemove(object sender, EventArgs e)
        {
        }
        private void OnCompute(object sender, EventArgs e)
        {
            try
            {
                DateTime dt0 = DateTime.Now;
                using (StackBuilderClient client = new StackBuilderClient())
                {
                    _log.Info($"Calling web service method");

                    var hSolution = client.SB_GetHSolutionBestCasePallet(
                        Items.ToArray(),
                        new DCSBPallet()
                        {
                            Name = "EUR2",
                            Description = "EUR2",
                            PalletType = "EUR2",
                            Color = Color.Yellow.ToArgb(),
                            Dimensions = PalletDimensions,
                            Weight = PalletWeight,
                        },
                        new DCSBHConstraintSet()
                        {
                            MaxHeight = new DCSBConstraintDouble() { Active = true, Value_d = MaxPalletHeight },
                            MaxWeight = new DCSBConstraintDouble() { Active = false, Value_d = MaxPalletWeight },
                            Overhang = PalletOverhang
                        },
                        new DCCompFormat()
                        {
                            Size = new DCCompSize()
                            {
                                CX = pbStackbuilder.Size.Width,
                                CY = pbStackbuilder.Size.Height
                            },
                            Format = OutFormat.IMAGE
                        },
                        false
                        );

                    // image
                    pbStackbuilder.Image = null;
                    if (null != hSolution.OutFile)
                        using (var ms = new System.IO.MemoryStream(hSolution.OutFile.Bytes))
                        {
                            Image img = Image.FromStream(ms);
                            pbStackbuilder.Image = img;
                        }


                    DateTime dt1 = DateTime.Now;
                    _log.Info($"Web service answered in {(dt1 - dt0).TotalMilliseconds} ms");
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Properties
        // pallet
        private double PalletLength { get => (double)nudPalletDimX.Value; set => nudPalletDimX.Value = (decimal)value; }
        private double PalletWidth { get => (double)nudPalletDimY.Value; set => nudPalletDimY.Value = (decimal)value; }
        private double PalletHeight { get => (double)nudPalletDimZ.Value; set => nudPalletDimZ.Value = (decimal)value; }
        private double PalletWeight { get => (double)nudPalletWeight.Value; set => nudPalletWeight.Value = (decimal)value; }
        private double MaxPalletHeight { get => (double)nudMaxPalletHeight.Value; set => nudMaxPalletHeight.Value = (decimal)value; }
        private double MaxPalletWeight { get => (double)nudMaxPalletWeight.Value; set => nudMaxPalletWeight.Value = (decimal)value; }
        private double OverhangX { get => (double)nudOverhangX.Value; }
        private double OverhangY { get => (double)nudOverhangY.Value; }
        private DCSBDim3D PalletDimensions => new DCSBDim3D() { M0 = PalletLength, M1 = PalletWidth, M2 = PalletHeight };
        private DCSBDim2D PalletOverhang => new DCSBDim2D() { M0 = OverhangX, M1 = OverhangY };

        private List<DCSBContentItem> Items { get; } = new List<DCSBContentItem>();
        private ILog _log = LogManager.GetLogger(typeof(FormTestHeterogeneous));
        #endregion
    }
}
