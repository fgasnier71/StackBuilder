#region Using directives
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.IO;
using System.Drawing;

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
			ChkbMirrorLength.Checked = LayersMirrorLength;
			ChkbMirrorWidth.Checked = LayersMirrorWidth;
			ChkbInterlayerBottom.Checked = InterlayerBottom;
			ChkbInterlayerTop.Checked = InterlayerTop;
			ChkbInterlayersIntermediate.Checked = InterlayersIntermediate;
			TBFileName.Text = FileName;

			// clear output directory
			DirectoryHelpers.ClearDirectory(Output);
		}
		ExecuteKeyPad();
		UpdateImage();
    }
	private void ExecuteKeyPad()
	{
		if (ConfigSettings.ShowVirtualKeyboard)
			ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "VKeyPad", "ActivateVirtualKeyboard();", true);
	}
	#endregion

	#region Update image
	protected void UpdateImage()
	{
		int caseCount = 0;
		int layerCount = 0;
		double weightLoad = 0.0, weightTotal = 0.0;
		Vector3D bbLoad = Vector3D.Zero;
		Vector3D bbTotal = Vector3D.Zero;
		string fileGuid = Guid.NewGuid().ToString() + ".glb";

		PalletStacking.GenerateExport(
			DimCase, WeightCase, BitmapTexture,
			DimPallet, WeightPallet,
			MaxPalletHeight,
			BoxPositions,
			ChkbMirrorLength.Checked, ChkbMirrorWidth.Checked,
			ChkbInterlayerBottom.Checked, ChkbInterlayersIntermediate.Checked, ChkbInterlayerTop.Checked,
			Path.Combine(Output, fileGuid),
			ref caseCount, ref layerCount,
			ref weightLoad, ref weightTotal,
			ref bbLoad, ref bbTotal
			);

		XModelDiv.InnerHtml = string.Format("<x-model class=\"x-model\" src=\"./Output/{0}\"/>", fileGuid);

		loadedPallet.Update();
	}
	#endregion

	#region Event handlers
	protected void OnInputChanged(object sender, EventArgs e)
	{
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
			ChkbMirrorLength.Checked, ChkbMirrorWidth.Checked,
			ChkbInterlayerBottom.Checked , ChkbInterlayersIntermediate.Checked, ChkbInterlayerTop.Checked,
			ref fileBytes); 

		if (FtpHelpers.Upload(fileBytes, ConfigSettings.FtpDirectory, fileName, ConfigSettings.FtpUsername, ConfigSettings.FtpPassword))
		{
			ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{fileName} was successfully exported!');", true);
		}
	}
	protected void OnPrevious(object sender, EventArgs e)
	{
		// clear output directory
		DirectoryHelpers.ClearDirectory(Output);

		if (LayerEdited)
			Response.Redirect("LayerEdition.aspx");
		else
			Response.Redirect("LayerSelectionWebGL.aspx");
	}
	#endregion

	#region Private variables
	private Vector3D DimCase=> Vector3D.Parse((string)Session[SessionVariables.DimCase]);
	private double WeightCase => (double)Session[SessionVariables.WeightCase];
	private Vector3D DimPallet => Vector3D.Parse((string)Session[SessionVariables.DimPallet]);
	private double WeightPallet => (double)Session[SessionVariables.WeightPallet];
	private double MaxPalletHeight => (double)Session[SessionVariables.MaxPalletHeight];
	private bool LayersMirrorLength => (bool)Session[SessionVariables.LayersMirrorLength];
	private bool LayersMirrorWidth => (bool)Session[SessionVariables.LayersMirrorWidth];
	private bool InterlayerBottom => (bool)Session[SessionVariables.InterlayerBottom];
	private bool InterlayerTop => (bool)Session[SessionVariables.InterlayerTop];
	private bool InterlayersIntermediate => (bool)Session[SessionVariables.InterlayersIntermadiate];
	private bool LayerEdited => (bool)Session[SessionVariables.LayerEdited];
	private string FileName => (string)Session[SessionVariables.FileName];
	private List<BoxPosition> BoxPositions => (List<BoxPosition>)Session[SessionVariables.BoxPositions];
	private Bitmap BitmapTexture => (Bitmap)Session[SessionVariables.BitmapTexture];
	private string Output => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");
	#endregion

}