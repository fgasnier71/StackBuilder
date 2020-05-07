#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;

#endregion

namespace treeDiM.StackBuilder.TechnologyBSA_ASPNET
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // clear output directory
                DirectoryHelpers.ClearDirectory(Output);

                try
                {
                    string filePath = Server.MapPath(@"~\Images\Texture.png");
                    if (File.Exists(filePath))
                        BitmapTexture = new Bitmap(filePath);
                }
                catch (Exception ex)
                {
                    string message = ex.ToString();
                }
                DimCaseCtrl = DimCase;
                WeightCaseCtrl = WeightCase;
                DimPalletCtrl = DimPallet;
                WeightPalletCtrl = WeightPallet;
                MaxPalletHeightCtrl = MaxPalletHeight;

                BTRefresh_Click(null, null);
            }
            ExecuteKeyPad();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (dlLayers.SelectedIndex > -1) return;
            ListViewDataItem item = dlLayers.Items[0];
            if (DoSelectDataItem(item) == true)
            {
                // Get 1st ImageButton
                ImageButton imgBtn = (ImageButton)dlLayers.Items[0].FindControl("Image1") as ImageButton;
                // Instantiate new DataListCommandEventArgs
                ListViewCommandEventArgs ev = new ListViewCommandEventArgs(dlLayers.Items[0], imgBtn, new CommandEventArgs(imgBtn.CommandName, imgBtn.CommandArgument));
                // Call ItemCommand handler
                OnLVLayersItemCommand(sender, ev);
            }
        }

        private bool DoSelectDataItem(ListViewDataItem item)
        {
            return item.DisplayIndex == 0; // selects the first item in the list (this is just an example after all; keeping it simple :D )
        }

        protected void BTRefresh_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                bool onlyBestLayers = false;

                DimCase = DimCaseCtrl;
                WeightCase = WeightCaseCtrl;
                DimPallet = DimPalletCtrl;
                WeightPallet = WeightPalletCtrl;
                MaxPalletHeight = MaxPalletHeightCtrl;

                List<LayerDetails> listLayers = new List<LayerDetails>();
                PalletStacking.GetLayers(DimCaseCtrl, WeightCaseCtrl, DimPalletCtrl, WeightPalletCtrl, MaxPalletHeightCtrl, onlyBestLayers, ref listLayers);

                dlLayers.DataSource = listLayers;
                dlLayers.DataBind();
                layersUpdate.Update();
                ExecuteKeyPad();
                PalletDetails.DataSource = null;
                PalletDetails.DataBind();
                dlLayers.SelectedIndex = -1;

                selectedLayer.Update();
            }
        }

        protected void OnNext(object sender, EventArgs e)
        {
            DimCase = DimCaseCtrl;
            WeightCase = WeightCaseCtrl;
            DimPallet = DimPalletCtrl;
            WeightPallet = WeightPalletCtrl;
            MaxPalletHeight = MaxPalletHeightCtrl;
            BoxPositions = BoxPositionsLayer;

            Session[SessionVariables.LayerEdited] = false;
            if (ConfigSettings.WebGLMode)
                Response.Redirect("ValidationWebGL.aspx");
            else
                Response.Redirect("Validation.aspx");
        }

        protected void OnLVLayersItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ImageButtonClick")
            {			
                dlLayers.Items.AsEnumerable().Foreach(a => { var item = (ImageButton)(a.Controls)[1]; item.Attributes["class"] = ""; });
                var selectedItem = (ImageButton)(e.Item.Controls)[1];
                selectedItem.Attributes["class"] = "border";
                // get layer description of selected button
                ViewState["LayerDescriptor"] = e.CommandArgument.ToString();

                dlLayers.SelectedIndex = e.Item.DisplayIndex;

                UpdateImage();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "scroll", "ScrollTo();", true);
                ExecuteKeyPad();
            }
        }

        private void ExecuteKeyPad()
        {
            if (ConfigSettings.ShowVirtualKeyboard)
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "VKeyPad", "ActivateVirtualKeyboard();", true);
        }

        protected void UpdateImage()
        {
            // clear output directory
            DirectoryHelpers.ClearDirectory(Output);

            Vector3D caseDim = DimCaseCtrl;
            double caseWeight = WeightCaseCtrl;
            Vector3D palletDim = DimPalletCtrl;
            double palletWeight = WeightPalletCtrl;
            double maxPalletHeight = MaxPalletHeightCtrl;

            byte[] imageBytes = null;
            int caseCount = 0;
            int layerCount = 0;
            double weightLoad = 0.0, weightTotal = 0.0;
            Vector3D bbLoad = Vector3D.Zero;
            Vector3D bbTotal = Vector3D.Zero;
            string fileGuid = Guid.NewGuid().ToString() + ".glb";
            List<bool> interlayers = new List<bool>();
            
            PalletStacking.GenerateExport(
                caseDim, caseWeight, BitmapTexture,
                palletDim, palletWeight,
                maxPalletHeight,
                BoxPositionsLayer,
                false, false,
                interlayers,
                Path.Combine(Output, fileGuid),
                ref caseCount, ref layerCount,
                ref weightLoad, ref weightTotal,
                ref bbLoad, ref bbTotal
            );

            XModelDiv.InnerHtml = string.Format("<x-model class=\"x-model\" src=\"./Output/{0}\"/>", fileGuid);

            var palletDetails = new List<PalletDetails>
            {
                new PalletDetails("Number of cases", $"{caseCount}", ""),
                new PalletDetails("Layer count", $"{layerCount}", ""),
                new PalletDetails("Load weight", $"{weightLoad}", "kg"),
                new PalletDetails("Total weight", $"{weightTotal}", "kg"),
                new PalletDetails("Load dimensions", $"{bbLoad.X} x {bbLoad.Y} x {bbLoad.Z}", "mm"),
                new PalletDetails("Overall dimensions", $"{bbTotal.X} x {bbTotal.Y} x {bbTotal.Z}", "mm")
            };

            PalletDetails.DataSource = palletDetails;
            PalletDetails.DataBind();

            DimCase = caseDim;
            DimPallet = palletDim;
            MaxPalletHeight = maxPalletHeight;
            Session[SessionVariables.ImageWidth] = 500;
            Session[SessionVariables.ImageHeight] = 460;
            Session[SessionVariables.ImageBytes] = imageBytes;

            selectedLayer.Update();
        }
        protected void OnEditLayer(object sender, EventArgs e)
        {

            DimCase = DimCaseCtrl;
            WeightCase = WeightCaseCtrl; 
            DimPallet = DimPalletCtrl;
            WeightPallet = WeightPalletCtrl;
            SelectedIndex = -1;
            BoxPositions = BoxPositionsLayer;

            Session[SessionVariables.LayerEdited] = true;
            Response.Redirect("LayerEdition.aspx");
        }
        private Vector3D DimCaseCtrl
        {
            get => new Vector3D(double.Parse(TBCaseLength.Text), double.Parse(TBCaseWidth.Text), double.Parse(TBCaseHeight.Text));
            set
            {
                TBCaseLength.Text = value.X.ToString();
                TBCaseWidth.Text = value.Y.ToString();
                TBCaseHeight.Text = value.Z.ToString();
            }
        }
        private double WeightCaseCtrl
        {
            get => double.Parse(TBCaseWeight.Text);
            set => TBCaseWeight.Text = value.ToString();
        }
        private Vector3D DimPalletCtrl
        {
            get => new Vector3D(double.Parse(TBPalletLength.Text), double.Parse(TBPalletWidth.Text), double.Parse(TBPalletHeight.Text));
            set
            {
                TBPalletLength.Text = value.X.ToString();
                TBPalletWidth.Text = value.Y.ToString();
                TBPalletHeight.Text = value.Z.ToString();
            }
        }
        private double WeightPalletCtrl
        {
            get => double.Parse(TBPalletWeight.Text);
            set => TBPalletWeight.Text = value.ToString();
        }
        private double MaxPalletHeightCtrl
        {
            get => double.Parse(TBMaxPalletHeight.Text);
            set => TBMaxPalletHeight.Text = value.ToString();
        }
        private Vector3D DimCase
        {
            get => Vector3D.Parse((string)Session[SessionVariables.DimCase]);
            set => Session[SessionVariables.DimCase] = value.ToString();
        }
        private double WeightCase
        {
            get => (double)Session[SessionVariables.WeightCase];
            set => Session[SessionVariables.WeightCase] = value;
        }
        private Vector3D DimPallet
        {
            get => Vector3D.Parse((string)Session[SessionVariables.DimPallet]);
            set => Session[SessionVariables.DimPallet] = value.ToString();
        }
        private double WeightPallet
        { 
            get => (double)Session[SessionVariables.WeightPallet];
            set => Session[SessionVariables.WeightPallet] = value;
        }
        private double MaxPalletHeight
        {
            get => (double)Session[SessionVariables.MaxPalletHeight];
            set => Session[SessionVariables.MaxPalletHeight] = value;
        }
        private Vector2D DimContainer => new Vector2D(double.Parse(TBPalletLength.Text), double.Parse(TBPalletWidth.Text));
        private List<BoxPosition> BoxPositions
        {
            set => Session[SessionVariables.BoxPositions] = value;
        }
        private int SelectedIndex
        {
            set => Session[SessionVariables.SelectedIndex] = value;
        }
        private List<BoxPosition> BoxPositionsLayer
        {
            get
            {
                var layerDesc = LayerDescBox.Parse(ViewState["LayerDescriptor"].ToString()) as LayerDescBox;
                LayerSolver solver = new LayerSolver();
                var layer = solver.BuildLayer(DimCaseCtrl, DimContainer, layerDesc, 0.0);
                return layer.Positions;
            }
        }
        private Bitmap BitmapTexture
        {
            get => (Bitmap)Session[SessionVariables.BitmapTexture];
            set => Session[SessionVariables.BitmapTexture] = value;
        }
        private string Output => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");
    }
}
