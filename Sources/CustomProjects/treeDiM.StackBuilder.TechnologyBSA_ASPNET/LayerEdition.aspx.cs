#region Using directives
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
#endregion

public partial class LayerEdition : Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SelectedIndex = -1;
        }
        UpdateImage();
    }
    #endregion
    #region Update image
    protected void UpdateImage()
    {
        ImageWidth = Convert.ToInt32(IBLayer.Width.Value);
        ImageHeight = Convert.ToInt32(IBLayer.Width.Value);
        IBLayer.ImageUrl = "~/HandlerLayerEditor.ashx?param=" + DateTime.Now.Ticks.ToString();
        layerImage.Update();
    }
    #endregion
    #region Event handler
    protected void OnIBLayerClicked(object sender, ImageClickEventArgs e)
    {
        var layerEditorHelper = new LayerEditorHelpers(ImageSize, DimCase, DimContainer)
        {
            Positions = BoxPositions
        };
        SelectedIndex = layerEditorHelper.GetPickedIndex(new Point(e.X, e.Y));
        UpdateImage();
    }

    protected void OnArrowClicked(object sender, ImageClickEventArgs e)
    {
        HalfAxis.HAxis axis = HalfAxis.HAxis.AXIS_X_N;
        if (sender == ButtonUp) axis = HalfAxis.HAxis.AXIS_Y_P;
        else if (sender == ButtonDown) axis = HalfAxis.HAxis.AXIS_Y_N;
        else if (sender == ButtonLeft) axis = HalfAxis.HAxis.AXIS_X_N;
        else if (sender == ButtonRight) axis = HalfAxis.HAxis.AXIS_X_P;

        var layerEditHelper = new LayerEditorHelpers(ImageSize, DimCase, DimContainer)
        {
            Positions = BoxPositions,
            SelectedIndex = SelectedIndex
        };
        layerEditHelper.Move(axis, 10.0);
        BoxPositions = layerEditHelper.Positions;

        UpdateImage();
    }
    protected void OnArrowMaxClicked(object sender, ImageClickEventArgs e)
    {
        HalfAxis.HAxis axis = HalfAxis.HAxis.AXIS_X_N;
        if (sender == ButtonUpMost) axis = HalfAxis.HAxis.AXIS_Y_P;
        else if (sender == ButtonDownMost) axis = HalfAxis.HAxis.AXIS_Y_N;
        else if (sender == ButtonLeftMost) axis = HalfAxis.HAxis.AXIS_X_N;
        else if (sender == ButtonRightMost) axis = HalfAxis.HAxis.AXIS_X_P;

        var layerEditHelper = new LayerEditorHelpers(ImageSize, DimCase, DimContainer)
        {
            Positions = (List<BoxPosition>)Session[SessionVariables.BoxPositions],
            SelectedIndex = SelectedIndex
        };
        layerEditHelper.MoveMax(axis);
        BoxPositions = layerEditHelper.Positions;

        UpdateImage();
    }
    protected void OnRotateClicked(object sender, ImageClickEventArgs e)
    {
        var layerEditHelper = new LayerEditorHelpers(ImageSize, DimCase, DimContainer)
        {
            Positions = BoxPositions,
            SelectedIndex = SelectedIndex
        };
        layerEditHelper.Rotate();
        BoxPositions = layerEditHelper.Positions;
        UpdateImage();  
    }
    protected void OnPrevious(object sender, EventArgs e)
    {
        Response.Redirect("LayerSelection.aspx");
    }
    protected void OnNext(object sender, EventArgs e)
    {
        Response.Redirect("Validation.aspx");
    }
    #endregion
    #region Private properties
    private Vector2D DimContainer
    {
        get
        {
            Vector3D vDimContainer = DimPallet;
            return new Vector2D(vDimContainer.X, vDimContainer.Y);
        }
    }
    private Size ImageSize => new Size(Convert.ToInt32(IBLayer.Width.Value), Convert.ToInt32(IBLayer.Height.Value));
    private int ImageWidth
    {
        get => (int)Session[SessionVariables.ImageWidth];
        set => Session[SessionVariables.ImageWidth] = value;
    }
    private int ImageHeight
    {
        get => (int)Session[SessionVariables.ImageHeight];
        set => Session[SessionVariables.ImageHeight] = value;
    }

    private Vector3D DimCase => Vector3D.Parse((string)Session[SessionVariables.DimCase]);
    private Vector3D DimPallet => Vector3D.Parse((string)Session[SessionVariables.DimPallet]);
    private List<BoxPosition> BoxPositions
    {
        get => (List<BoxPosition>)Session[SessionVariables.BoxPositions];
        set => Session[SessionVariables.BoxPositions] = value;
    }
    private int SelectedIndex
    {
        get => (int)Session[SessionVariables.SelectedIndex];
        set => Session[SessionVariables.SelectedIndex] = value;
    }
    #endregion
}