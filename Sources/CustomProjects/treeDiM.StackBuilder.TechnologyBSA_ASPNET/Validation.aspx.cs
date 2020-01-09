#region Using directives
using System;
using System.Web.UI;
using System.IO;

using Sharp3D.Math.Core;
#endregion

public partial class Validation : Page
{
    #region Page_Load 
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			ViewState["Angle"] = "45";
		}
		ExecuteKeyPad();
		UpdateImage();
    }
	#endregion

	private void ExecuteKeyPad()
	{
		if (ConfigSettings.ShowVirtualKeyboard)
			ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "VKeyPad", "ActivateVirtualKeyboard();", true);
	}

	#region Update image
	protected void UpdateImage()
	{
		Vector3D dimCase = Vector3D.Parse((string)Session["dimCase"]);
		double weightCase = double.Parse((string)Session["weightCase"]);
		Vector3D dimPallet = Vector3D.Parse((string)Session["dimPallet"]);
		double palletWeight = double.Parse((string)Session["weightPallet"]);
		double maxPalletHeight = double.Parse((string)Session["maxPalletHeight"]);

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
			ChkbAlternateLayers.Checked,
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
	#endregion

	#region Event handlers
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
	protected void OnExport(object sender, EventArgs e)
	{
		string fileName = TBFileName.Text;
		fileName = Path.ChangeExtension(fileName, "csv");

		Vector3D dimCase = Vector3D.Parse((string)Session["dimCase"]);
		double weightCase = double.Parse((string)Session["weightCase"]);
		Vector3D dimPallet = Vector3D.Parse((string)Session["dimPallet"]);
		double weightPallet = double.Parse((string)Session["weightPallet"]);
		double maxPalletHeight = double.Parse((string)Session["maxPalletHeight"]);
		string layerDesc = Session["layerDesc"].ToString();


		byte[] fileBytes = null;
		PalletStacking.Export(
			dimCase, weightCase,
			dimPallet, weightPallet,
			maxPalletHeight, layerDesc,
			ChkbAlternateLayers.Checked,
			ChkbBottomInterlayer.Checked , ChkbIntermediateInterlayers.Checked, ChkbTopInterlayer.Checked,
			ref fileBytes); 

		if (FtpHelpers.Upload(fileBytes, ConfigSettings.FtpDirectory, fileName, ConfigSettings.FtpUsername, ConfigSettings.FtpPassword))
		{
			ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{fileName} was successfully exported!');", true);
		}
	}

	#endregion
}