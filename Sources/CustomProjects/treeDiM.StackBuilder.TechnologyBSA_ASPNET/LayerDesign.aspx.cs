#region Using directives
using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Drawing;
using System.IO;

using Newtonsoft.Json;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.TechnologyBSA_ASPNET;
#endregion

public partial class LayerDesign : Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CanvasCoordConverter canvasCoord = new CanvasCoordConverter(950, 500, PtMin, PtMax);

            // pallet dimensions
            var palletTopLeft = canvasCoord.PtWorldToCanvas(new Vector2D(0.0, DimPallet.Y));
            var palletBottomRight = canvasCoord.PtWorldToCanvas(new Vector2D(DimPallet.X, 0.0));
            _palletDims.X1 = palletTopLeft.X;
            _palletDims.Y1 = palletTopLeft.Y;
            _palletDims.X2 = palletBottomRight.X;
            _palletDims.Y2 = palletBottomRight.Y;

            // generate images
            _casePixelWidth = (int)(canvasCoord.LengthWorldToCanvas(DimCase.X));
            _casePixelHeight = (int)(canvasCoord.LengthWorldToCanvas(DimCase.Y));

            // generate box position from 
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 1, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case1.png"));
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 2, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case2.png"));
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 3, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case3.png"));
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 4, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case4.png"));

            foreach (var bp in BoxPositions)
                _boxPositions.Add(canvasCoord.BPosWorldToCanvas(bp, 1, DimCase));
        }
    }
    #endregion
    #region Event handlers
    protected void OnPrevious(object sender, EventArgs e)
    {
        Response.Redirect("LayerDesignIntro.aspx");
    }
    protected void OnNext(object sender, EventArgs e)
    {
        var canvasCoord = new CanvasCoordConverter(950, 500, PtMin, PtMax);

        string sValue = HFBoxArray.Value;
        var bposJS = JsonConvert.DeserializeObject<IList<BoxPositionJS>>(sValue);
        if (null != bposJS)
        {
            var listBoxPositions = new List<BoxPositionIndexed>();
            foreach (var bpjs in bposJS)
            {
                var listIndex = canvasCoord.ToBoxPositionIndexed(bpjs, DimCase);
                listBoxPositions.AddRange(listIndex);                
            }
            BoxPositions = listBoxPositions;
            Response.Redirect("ValidationWebGL.aspx");
        }
    }
    #endregion


    private Vector3D DimCase => Vector3D.Parse((string)Session[SessionVariables.DimCase]);
    private Vector3D DimPallet => Vector3D.Parse((string)Session[SessionVariables.DimPallet]);
    private List<BoxPositionIndexed> BoxPositions
    {
        get => (List<BoxPositionIndexed>)Session[SessionVariables.BoxPositions];
        set => Session[SessionVariables.BoxPositions] = value;
    }



    #region Data members
    public PalletDimsJS _palletDims = new PalletDimsJS(); 
    public List<BoxPositionJS> _boxPositions = new List<BoxPositionJS>();
    public int _casePixelWidth;
    public int _casePixelHeight;
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
    private string Output => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");
    private Vector2D PtMin => new Vector2D(-DimCase.X, -DimCase.X);
    private Vector2D PtMax => new Vector2D((DimPallet.Y + DimCase.X) * 950.0 / 500.0, DimPallet.Y + DimCase.X);
    #endregion

}