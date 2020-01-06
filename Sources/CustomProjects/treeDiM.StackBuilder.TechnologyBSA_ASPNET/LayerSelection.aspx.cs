using System;
using System.Web.UI;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI.WebControls;

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
			BTRefresh_Click(null, null);

			ViewState["Angle"] = "45";
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
			bool onlyBestLayers = false;

			Session["dimCase"] = caseDim.ToString();
			Session["dimPallet"] = palletDim.ToString();
			Session["maxPalletHeight"] = $"{maxPalletHeight}";

			List<LayerDetails> listLayers = new List<LayerDetails>();
			GetLayers(caseDim, caseWeight, palletDim, palletWeight, maxPalletHeight, onlyBestLayers, ref listLayers);

			dlLayers.DataSource = listLayers;
			dlLayers.DataBind();
			layersUpdate.Update();
			ExecuteKeyPad();
			PalletDetails.DataSource = null;
			PalletDetails.DataBind();
			ImagePallet.ImageUrl = "";
			selectedLayer.Update();
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

		// get a list of all possible layers and fill ListView control
		ILayerSolver solver = new LayerSolver();
		var layers = solver.BuildLayers(boxProperties.OuterDimensions, new Vector2D(vPalletDim.X, vPalletDim.Y), 0.0, constraintSet, bestLayersOnly);
		foreach (var layer in layers)
			listLayers.Add(
				new LayerDetails(
					layer.Name,
					layer.LayerDescriptor.ToString(),
					layer.Count,
					layer.NoLayers(caseDim.Z),
					caseDim.X, caseDim.Y, caseDim.Z)
				);
	}

	public void GetSolution(
		Vector3D caseDim, double caseWeight,
		Vector3D palletDim, double palletWeight,
		double maxPalletHeight,
		LayerDesc layerDesc,
		double angle,
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

		SolutionLayered.SetSolver(new LayerSolver());

		var analysis = new AnalysisCasePallet(boxProperties, palletProperties, constraintSet);
		analysis.AddSolution(layerDesc);
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
			ShowDimensions = true
		};
		graphics.SetCameraPosition(10000.0, angle, 45.0);

		using (ViewerSolution sv = new ViewerSolution(analysis.SolutionLay))
			sv.Draw(graphics, Transform3D.Identity);
		graphics.Flush();
		Bitmap bmp = graphics.Bitmap;
		ImageConverter converter = new ImageConverter();
		imageBytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
	}

	protected void OnIndexChanged(object sender, EventArgs e)
	{
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
		Vector3D caseDim = new Vector3D(double.Parse(TBCaseLength.Text), double.Parse(TBCaseWidth.Text), double.Parse(TBCaseHeight.Text));
		double caseWeight = double.Parse(TBCaseWeight.Text);
		Vector3D palletDim = new Vector3D(double.Parse(TBPalletLength.Text), double.Parse(TBPalletWidth.Text), double.Parse(TBPalletHeight.Text));
		double palletWeight = double.Parse(TBPalletWeight.Text);
		double maxPalletHeight = double.Parse(TBMaxPalletHeight.Text);

		byte[] imageBytes = null;
		int caseCount = 0;
		int layerCount = 0;
		double weightLoad = 0.0, weightTotal = 0.0;
		Vector3D bbLoad = Vector3D.Zero;
		Vector3D bbTotal = Vector3D.Zero;

		var layerDesc = LayerDescBox.Parse(ViewState["LayerDescriptor"].ToString()) as LayerDescBox;
		double angle = double.Parse(ViewState["Angle"].ToString());
		GetSolution(caseDim, caseWeight, palletDim, palletWeight, maxPalletHeight, layerDesc, angle, ref imageBytes, ref caseCount, ref layerCount, ref weightLoad, ref weightTotal, ref bbLoad, ref bbTotal);

		var palletDetails = new List<PalletDetail>();
		palletDetails.Add(new PalletDetail("Number of cases", $"{caseCount}", ""));
		palletDetails.Add(new PalletDetail("Layer count", $"{layerCount}", ""));
		palletDetails.Add(new PalletDetail("Load weight", $"{weightLoad}", "kg"));
		palletDetails.Add(new PalletDetail("Total weight", $"{weightTotal}", "kg"));
		palletDetails.Add(new PalletDetail("Load dimensions", $"{bbLoad.X} x {bbLoad.Y} x {bbLoad.Z}", "mm x mm x mm"));
		palletDetails.Add(new PalletDetail("Overall dimensions", $"{bbTotal.X} x {bbTotal.Y} x {bbTotal.Z}", "mm x mm x mm"));


		PalletDetails.DataSource = palletDetails;
		PalletDetails.DataBind();


		Session["dimCase"] = caseDim.ToString();
		Session["dimPallet"] = palletDim.ToString();
		Session["maxPalletHeight"] = $"{maxPalletHeight}";
		Session["width"] = "500";
		Session["height"] = "500";
		Session["imageBytes"] = imageBytes;

		ImagePallet.ImageUrl = "~/Handler.ashx?param=" + DateTime.Now.Ticks.ToString();

		selectedLayer.Update();
	}

	protected void AngleIncrement(object sender, EventArgs e)
	{
		double angle = double.Parse(ViewState["Angle"].ToString());
		angle += ConfigSettings.AngleStep;
		ViewState["Angle"] = $"{angle}";
		UpdateImage();
		ExecuteKeyPad();
	}
	protected void AngleDecrement(object sender, EventArgs e)
	{
		double angle = double.Parse(ViewState["Angle"].ToString());
		angle -= ConfigSettings.AngleStep;
		ViewState["Angle"] = $"{angle}";
		UpdateImage();
		ExecuteKeyPad();
	}
}

public class LayerDetails
{
	public LayerDetails(string name, string layerDesc, int noCasesPerLayer, int noLayers, double length, double width, double height)
	{
		Name = name;
		LayerDesc = layerDesc;
		NoCasesPerLayer = noCasesPerLayer;
		NoLayers = noLayers;
		Length = length;
		Width = width;
		Height = height;
	}
	public string Name { get; set; }
	public int NoLayers { get; set; }
	public int NoCasesPerLayer { get; set; }
	public double Length { get; set; }
	public double Width { get; set; }
	public double Height { get; set; }
	public int NoCases => NoLayers * NoCasesPerLayer;
	public string LayerDesc { get; set; }
	public string Dimensions => $"{Length}x{Width}x{Height}";
}

public class PalletDetail
{
	public PalletDetail(string name, string value, string unit)
	{
		Name = name; Value = value; Unit = unit;
	}
	public string Name { get; set; }
	public string Value { get; set; }
	public string Unit { get; set; }
}
