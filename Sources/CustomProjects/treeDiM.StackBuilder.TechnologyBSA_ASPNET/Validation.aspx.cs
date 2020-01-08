#region Using directives
using System;
using System.Web.UI;

using Sharp3D.Math.Core;
#endregion

public partial class Validation : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			ViewState["Angle"] = "45";
		}
		UpdateImage();
    }

	protected void OnUnputChanged()
	{
		UpdateImage();
	}

	protected void UpdateImage()
	{
		string sDimCase = (string)Session["dimCase"];
		Vector3D dimCase = Vector3D.Parse(sDimCase);
		string sWeightCase = (string)Session["weightCase"];
		double weightCase = double.Parse(sWeightCase);
		string sDimPallet = (string)Session["dimPallet"];
		Vector3D dimPallet = Vector3D.Parse(sDimPallet);
		string sPalletWeight = (string)Session["weightPallet"];
		double palletWeight = double.Parse(sPalletWeight);
		string sMaxPalletHeight = (string)Session["maxPalletHeight"];
		double maxPalletHeight = double.Parse(sMaxPalletHeight);

		byte[] imageBytes = null;
		int caseCount = 0;
		int layerCount = 0;
		double weightLoad = 0.0, weightTotal = 0.0;
		Vector3D bbLoad = Vector3D.Zero;
		Vector3D bbTotal = Vector3D.Zero;

		double angle = double.Parse(ViewState["Angle"].ToString());
		PalletStacking.GetSolution(
			dimCase, weightCase,
			dimPallet, palletWeight,
			maxPalletHeight, Session["layerDesc"].ToString(),
			ChkbAlignLayers.Checked,
			ChkbBottomInterlayer.Checked,
			ChkbIntermediateInterlayers.Checked,
			ChkbTopInterlayer.Checked,
			angle,
			ref imageBytes, ref caseCount, ref layerCount, ref weightLoad, ref weightTotal, ref bbLoad, ref bbTotal);

		Session["width"] = "500";
		Session["height"] = "500";
		Session["imageBytes"] = imageBytes;

		ImagePallet.ImageUrl = "~/Handler.ashx?param=" + DateTime.Now.Ticks.ToString();

		loadedPallet.Update();
	}
	protected void OnInputChanged(object sender, EventArgs e)
	{
		UpdateImage();
	}

	protected void AngleIncrement(object sender, EventArgs e)
	{
		double angle = double.Parse(ViewState["Angle"].ToString());
		angle += ConfigSettings.AngleStep;
		ViewState["Angle"] = $"{angle}";
		UpdateImage();
	}
	protected void AngleDecrement(object sender, EventArgs e)
	{
		double angle = double.Parse(ViewState["Angle"].ToString());
		angle -= ConfigSettings.AngleStep;
		ViewState["Angle"] = $"{angle}";
		UpdateImage();
	}
}