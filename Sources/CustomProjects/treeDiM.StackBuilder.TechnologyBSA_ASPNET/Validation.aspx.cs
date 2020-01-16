#region Using directives
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.IO;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

public partial class Validation : Page
{
    #region Page_Load 
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			Angle = 45.0;
			ChkbAlternateLayers.Checked = AlternateLayers;
			ChkbInterlayerBottom.Checked = InterlayerBottom;
			ChkbInterlayerTop.Checked = InterlayerTop;
			ChkbInterlayersIntermediate.Checked = InterlayersIntermediate;
			TBFileName.Text = FileName;
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
		byte[] imageBytes = null;
		int caseCount = 0;
		int layerCount = 0;
		double weightLoad = 0.0, weightTotal = 0.0;
		Vector3D bbLoad = Vector3D.Zero;
		Vector3D bbTotal = Vector3D.Zero;

		PalletStacking.GetSolution(
			DimCase, WeightCase,
			DimPallet, WeightPallet,
			MaxPalletHeight, BoxPositions,
			ChkbAlternateLayers.Checked,
			ChkbInterlayerBottom.Checked,
			ChkbInterlayersIntermediate.Checked,
			ChkbInterlayerTop.Checked,
			Angle,
			ref imageBytes, ref caseCount, ref layerCount, ref weightLoad, ref weightTotal, ref bbLoad, ref bbTotal);

		Session[SessionVariables.ImageWidth] = 500;
		Session[SessionVariables.ImageHeight] = 500;
		Session[SessionVariables.ImageBytes] = imageBytes;

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
		Angle += ConfigSettings.AngleStep;
		UpdateImage();
	}
	protected void AngleDecrement(object sender, EventArgs e)
	{
		Angle -= ConfigSettings.AngleStep;
		UpdateImage();
	}
	protected void OnExport(object sender, EventArgs e)
	{
		string fileName = TBFileName.Text;
		fileName = Path.ChangeExtension(fileName, "csv");

		byte[] fileBytes = null;
		PalletStacking.Export(
			DimCase, WeightCase,
			DimPallet, WeightPallet,
			MaxPalletHeight, BoxPositions,
			ChkbAlternateLayers.Checked,
			ChkbInterlayerBottom.Checked , ChkbInterlayersIntermediate.Checked, ChkbInterlayerTop.Checked,
			ref fileBytes); 

		if (FtpHelpers.Upload(fileBytes, ConfigSettings.FtpDirectory, fileName, ConfigSettings.FtpUsername, ConfigSettings.FtpPassword))
		{
			ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{fileName} was successfully exported!');", true);
		}
	}
	#endregion

	#region Private variables
	private Vector3D DimCase=> Vector3D.Parse((string)Session[SessionVariables.DimCase]);
	private double WeightCase => (double)Session[SessionVariables.WeightCase];
	private Vector3D DimPallet => Vector3D.Parse((string)Session[SessionVariables.DimPallet]);
	private double WeightPallet => (double)Session[SessionVariables.WeightPallet];
	private double MaxPalletHeight => (double)Session[SessionVariables.MaxPalletHeight];
	private bool AlternateLayers => (bool)Session[SessionVariables.AlternateLayers];
	private bool InterlayerBottom => (bool)Session[SessionVariables.InterlayerBottom];
	private bool InterlayerTop => (bool)Session[SessionVariables.InterlayerTop];
	private bool InterlayersIntermediate => (bool)Session[SessionVariables.InterlayersIntermadiate];
	private double Angle
	{
		get => (double)ViewState["Angle"];
		set => ViewState["Angle"] = value;
	}
	private string FileName => (string)Session[SessionVariables.FileName];
	private List<BoxPosition> BoxPositions => (List<BoxPosition>)Session[SessionVariables.BoxPositions];
    #endregion
}