using System;
using System.Web.UI;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

using Sharp3D.Math.Core;
using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Graphics;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
            TBCaseLength.Text = "300";        
            TBCaseWidth.Text = "280";
            TBCaseHeight.Text = "275";
            TBCaseWeight.Text = "1";

            TBPalletLength.Text = "1200";
            TBPalletWidth.Text = "1000";
            TBPalletHeight.Text = "155";
            TBPalletWeight.Text = "1";

            TBMaxPalletHeight.Text = "1700";
        }
    }

    protected void ControlInit(object sender, EventArgs e)
    {
    }

    protected void BTRefresh_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            Vector3D caseDim = new Vector3D(double.Parse(TBCaseLength.Text), double.Parse(TBCaseWidth.Text), double.Parse(TBCaseHeight.Text));
            double caseWeight = double.Parse(TBCaseWeight.Text);
            Vector3D palletDim = new Vector3D(double.Parse(TBPalletLength.Text), double.Parse(TBPalletWidth.Text), double.Parse(TBPalletHeight.Text));
            double palletWeight = double.Parse(TBPalletWeight.Text);
            double maxPalletHeight = double.Parse(TBMaxPalletHeight.Text);
            bool onlyBestLayers = true;

            Session["dimCase"] = caseDim.ToString();
            Session["dimPallet"] = palletDim.ToString();
            Session["maxPalletHeight"] = $"{maxPalletHeight}";
            Session["thumbWidth"] = "100";
            Session["thumbHeight"] = "100";


            List<LayerDetails> listLayers = new List<LayerDetails>();
            GetLayers(caseDim, caseWeight, palletDim, palletWeight, maxPalletHeight, onlyBestLayers, ref listLayers);
            
            dlLayers.DataSource = listLayers;
            dlLayers.DataBind();

            /*
            gvLayers.DataSource = listLayers;
            gvLayers.DataBind();
            */


            byte[] imageBytes = null;
            int caseCount = 0;
            int layerCount = 0;
            double weightLoad = 0.0, weightTotal =0.0;
            Vector3D bbLoad = Vector3D.Zero;
            Vector3D bbTotal = Vector3D.Zero;
            GetBestSolution(caseDim, caseWeight, palletDim, palletWeight, maxPalletHeight, ref imageBytes, ref caseCount, ref layerCount, ref weightLoad, ref weightTotal, ref bbLoad, ref bbTotal);


            Session["width"] = "500";
            Session["height"] = "500";
            Session["imageBytes"] = imageBytes;

            ImagePallet.ImageUrl = "~/Handler.ashx";
        }
    }

    protected void OnNext(object sender, EventArgs e)
    {

    }

    public void GetLayers(Vector3D caseDim, double caseWeight, Vector3D palletDim, double palletWeight, double maxPalletHeight, bool bestLayersOnly, ref List<LayerDetails> listLayers)
    {
        // case
        var boxProperties = new BoxProperties(null, caseDim.X, caseDim.Y, caseDim.Z)
        {
            TapeColor = Color.LightGray,
            TapeWidth = new OptDouble(true, 50.0)
        };
        boxProperties.SetWeight(caseWeight);
        boxProperties.SetAllColors(Enumerable.Repeat(Color.Beige, 6).ToArray());
        // pallet
        var palletProperties = new PalletProperties(null, "EUR2", palletDim.X, palletDim.Y, palletDim.Z)
        {
            Weight = palletWeight,
            Color = Color.Yellow
        };
        // ### define a constraintset object
        var constraintSet = new ConstraintSetCasePallet()
        {
            OptMaxNumber = new OptInt(false, 0),
            OptMaxWeight = new OptDouble(true, 1000.0),
            Overhang = Vector2D.Zero,
        };
        constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
        constraintSet.SetMaxHeight(new OptDouble(true, maxPalletHeight));
        Vector3D vPalletDim = palletProperties.GetStackingDimensions(constraintSet);
        // ###

        // get a list of all possible layers
        ILayerSolver solver = new LayerSolver();
        // build layers and fill CCtrl
        var layers = solver.BuildLayers(boxProperties.OuterDimensions, new Vector2D(vPalletDim.X, vPalletDim.Y), 0.0, constraintSet, bestLayersOnly);
        foreach (var layer in layers)
            listLayers.Add(
                new LayerDetails(
                    layer.Name,
                    layer.LayerDescriptor.ToString(),
                    layer.Count,
                    layer.NoLayers(caseDim.Z))
                );

    }

    public void GetBestSolution(
        Vector3D caseDim, double caseWeight,
        Vector3D palletDim, double palletWeight,
        double maxPalletHeight,
        ref byte[] imageBytes,
        ref int caseCount, ref int layerCount,
        ref double weightLoad, ref double weightTotal,
        ref Vector3D bbLoad, ref Vector3D bbGlob
        )
    {
        // case
        var boxProperties = new BoxProperties(null, caseDim.X, caseDim.Y, caseDim.Z)
        {
            TapeColor = Color.LightGray,
            TapeWidth = new OptDouble(true, 50.0)
        };
        boxProperties.SetWeight(caseWeight);
        boxProperties.SetAllColors(Enumerable.Repeat(Color.Beige, 6).ToArray());
        // pallet
        var palletProperties = new PalletProperties(null, "EUR2", palletDim.X, palletDim.Y, palletDim.Z)
        {
            Weight = palletWeight,
            Color = Color.Yellow
        };
        // constraint set
        var constraintSet = new ConstraintSetCasePallet();
        constraintSet.SetAllowedOrientations(new bool[] { false, false, true });
        constraintSet.SetMaxHeight(new OptDouble(true, maxPalletHeight));
        // use a solver and get a list of sorted analyses + select the best one
        SolverCasePallet solver = new SolverCasePallet(boxProperties, palletProperties, constraintSet);
        var analyses = solver.BuildAnalyses(false);
        if (analyses.Count > 0)
        {
            // first solution
            AnalysisLayered analysis = analyses[0];
            layerCount = analysis.SolutionLay.LayerCount;
            caseCount = analysis.Solution.ItemCount;
            weightLoad = analysis.Solution.LoadWeight;
            weightTotal = analysis.Solution.Weight;
            bbGlob = analysis.Solution.BBoxGlobal.DimensionsVec;
            bbLoad = analysis.Solution.BBoxLoad.DimensionsVec;
            
            // generate image path
            Graphics3DImage graphics = new Graphics3DImage(new Size(500, 500))
            {
                FontSizeRatio = 0.01f,
                CameraPosition = Graphics3D.Corner_0,
                ShowDimensions = true
            };
            
            using (ViewerSolution sv = new ViewerSolution(analysis.SolutionLay))
                sv.Draw(graphics, Transform3D.Identity);
            graphics.Flush();
            Bitmap bmp = graphics.Bitmap;
            ImageConverter converter = new ImageConverter();
            imageBytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }
    }
}

public class LayerDetails
{
    public LayerDetails(string name, string layerDesc, int noCasesPerLayer, int noLayers)
    {
        Name = name;
        LayerDesc = layerDesc;
        NoCasesPerLayer = noCasesPerLayer;
        NoLayers = noLayers;
    }
    public string Name { get; set; }
    public int NoLayers { get; set; }
    public int NoCasesPerLayer { get; set; }
    public int NoCases => NoLayers * NoCasesPerLayer;
    public string LayerDesc { get; set; }
}

public class ConfigSettings
{
    public static string ThumbSize => ConfigurationManager.AppSettings["ThumbnailSize"] + "px";

}