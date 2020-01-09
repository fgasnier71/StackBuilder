#region Using directives
using System;
using System.Web.UI;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Sharp3D.Math.Core;
#endregion

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
			PalletStacking.GetLayers(caseDim, caseWeight, palletDim, palletWeight, maxPalletHeight, onlyBestLayers, ref listLayers);

			dlLayers.DataSource = listLayers;
			dlLayers.DataBind();
			layersUpdate.Update();
			ExecuteKeyPad();
			PalletDetails.DataSource = null;
			PalletDetails.DataBind();
			ImagePallet.ImageUrl = "";
			dlLayers.SelectedIndex = -1;

			selectedLayer.Update();
		}
	}

	protected void OnNext(object sender, EventArgs e)
	{
		Vector3D dimCase = new Vector3D(double.Parse(TBCaseLength.Text), double.Parse(TBCaseWidth.Text), double.Parse(TBCaseHeight.Text));
		double weightCase = double.Parse(TBCaseWeight.Text);
		Vector3D dimPallet = new Vector3D(double.Parse(TBPalletLength.Text), double.Parse(TBPalletWidth.Text), double.Parse(TBPalletHeight.Text));
		double weightPallet = double.Parse(TBPalletWeight.Text);
		double maxPalletHeight = double.Parse(TBMaxPalletHeight.Text);

		Session["dimCase"] = dimCase.ToString();
		Session["weightCase"] = weightCase.ToString();
		Session["dimPallet"] = dimPallet.ToString();
		Session["weightPallet"] = weightPallet.ToString();
		Session["maxPalletHeight"] = $"{maxPalletHeight}";
		Session["layerDesc"] = ViewState["LayerDescriptor"].ToString();

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

		string layerDesc = ViewState["LayerDescriptor"].ToString();
		double angle = double.Parse(ViewState["Angle"].ToString());
		PalletStacking.GetSolution(
			caseDim, caseWeight,
			palletDim, palletWeight,
			maxPalletHeight, layerDesc,
			false, false, false, false, angle, ref imageBytes, ref caseCount, ref layerCount, ref weightLoad, ref weightTotal, ref bbLoad, ref bbTotal);

		var palletDetails = new List<PalletDetails>();
		palletDetails.Add(new PalletDetails("Number of cases", $"{caseCount}", ""));
		palletDetails.Add(new PalletDetails("Layer count", $"{layerCount}", ""));
		palletDetails.Add(new PalletDetails("Load weight", $"{weightLoad}", "kg"));
		palletDetails.Add(new PalletDetails("Total weight", $"{weightTotal}", "kg"));
		palletDetails.Add(new PalletDetails("Load dimensions", $"{bbLoad.X} x {bbLoad.Y} x {bbLoad.Z}", "mm x mm x mm"));
		palletDetails.Add(new PalletDetails("Overall dimensions", $"{bbTotal.X} x {bbTotal.Y} x {bbTotal.Z}", "mm x mm x mm"));

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
