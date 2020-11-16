#region Using directives
using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Drawing;
using System.IO;

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
            double scaleFactor = 500.0 / (DimPallet.Y + 2 * DimCase.X);

            // generate images
            _casePixelWidth = (int)( DimCase.X *  scaleFactor);
            _casePixelHeight = (int)(DimCase.Y * scaleFactor);

            // generate box position from 
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 1, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case1.png"));
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 2, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case2.png"));
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 3, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case3.png"));
            MultiCaseImageGenerator.GenerateDefaultCaseImage(DimCase, new Size(_casePixelWidth, _casePixelHeight), 4, MultiCaseImageGenerator.CaseAlignement.SHARING_LENGTH, Path.Combine(Output, "case4.png"));

            _boxPositions.Add(new BoxPositionJS() { Index = 0, NumberCase = 1, X = 0, Y = 0, Angle = 0 });
        }
    }
    #endregion
    #region Event handlers
    protected void OnPrevious(object sender, EventArgs e)
    {
        Response.Redirect("LayerDesignIntro.aspx");
    }
    #endregion

    #region Back from javascript
    [WebMethod]
    public static void SaveCasePositions(BoxPositionJS[] list)
    {
        foreach (var bpjs in list)
        {
            Console.WriteLine($"BP -> Index: {bpjs.Index} , X: {bpjs.X}, Y: {bpjs.Y}, Angle: {bpjs.Angle}");
        }
        LayerDesignStaticReference.Response.Redirect("ValidationWebGL.aspx");
    }
    #endregion


    private Vector3D DimCase => Vector3D.Parse((string)Session[SessionVariables.DimCase]);
    private Vector3D DimPallet => Vector3D.Parse((string)Session[SessionVariables.DimPallet]);
    private List<BoxPosition> BoxPositions
    {
        get => (List<BoxPosition>)Session[SessionVariables.BoxPositions];
        set => Session[SessionVariables.BoxPositions] = value;
    }


    #region Data members
    public PalletDimsJS _palletDims = new PalletDimsJS(); 
    public List<BoxPositionJS> _boxPositions = new List<BoxPositionJS>();
    public int _casePixelWidth;
    public int _casePixelHeight;
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
    private static LayerDesign LayerDesignStaticReference { get; set; }
    private string Output => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");
    #endregion

}