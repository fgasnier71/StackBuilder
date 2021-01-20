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
            CanvasCoordConverter canvasCoord = new CanvasCoordConverter(850, 550, PtMin, PtMax);

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


            int palletPixelWidth = (int)(canvasCoord.LengthWorldToCanvas(DimPallet.X));
            int palletPixelHeight = (int)(canvasCoord.LengthWorldToCanvas(DimPallet.Y));

            // generate box position from 
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 1, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case1.png"));
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 2, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case2.png"));
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 3, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case3.png"));
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 4, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case4.png"));
            MultiCaseImageGenerator.GenerateDefaultPalletImage(DimPallet, PalletIndex == 0? "EUR" : "EUR2", new Size(palletPixelWidth, palletPixelHeight), Path.Combine(Output, "pallet.png"));

            // build reduced list of unique box positions indexed
            BoxPositionIndexed.ReduceListBoxPositionIndexed(BoxPositions, out List<BoxPositionIndexed> listBPIReduced, out Dictionary<int, int> dictIndexNumber);
            foreach (var bp in listBPIReduced)
                _boxPositionsJS.Add(canvasCoord.BPosWorldToCanvas(bp, dictIndexNumber[bp.Index], DimCase));
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
        // instantiate canvasCoord
        var canvasCoord = new CanvasCoordConverter(850, 550, PtMin, PtMax);
        // read box positions serialized as Json in field HFBoxArray
        string sValue = HFBoxArray.Value;
        var bposJS = JsonConvert.DeserializeObject<IList<BoxPositionJS>>(sValue);
        // convert array of BoxPositionJS to BoxPositionIndexed array
        if (null != bposJS)
        {
            var listBoxPositions = new List<BoxPositionIndexed>();
            int localIndex = 0;
            foreach (var bpjs in bposJS)
            {
                var listIndex = canvasCoord.ToBoxPositionIndexed(bpjs, DimCase, localIndex++);
                listBoxPositions.AddRange(listIndex);                
            }
            // sort according to index
            BoxPositionIndexed.Sort(ref listBoxPositions);
            // save session wide
            BoxPositions = listBoxPositions;
            // to validation page
            Response.Redirect("ValidationWebGL.aspx");
        }
    }
    #endregion

    private Vector3D DimCase => Vector3D.Parse((string)Session[SessionVariables.DimCase]);
    private int PalletIndex => (int)Session[SessionVariables.PalletIndex];
    private Vector3D DimPallet => PalletStacking.PalletIndexToDim3D(PalletIndex);
    private List<BoxPositionIndexed> BoxPositions
    {
        get => (List<BoxPositionIndexed>)Session[SessionVariables.BoxPositions];
        set => Session[SessionVariables.BoxPositions] = value;
    }
    #region Data members
    public PalletDimsJS _palletDims = new PalletDimsJS(); 
    public List<BoxPositionJS> _boxPositionsJS = new List<BoxPositionJS>();
    public int _casePixelWidth;
    public int _casePixelHeight;
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
    private string Output => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");
    private Vector2D PtMin => new Vector2D(-50.0, -50.0);
    private Vector2D PtMax => new Vector2D((DimPallet.Y + DimCase.X) * 850.0 / 550.0, DimPallet.Y + DimCase.X);
    #endregion

}