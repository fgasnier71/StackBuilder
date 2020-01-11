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
        }
        Session["selectedIndex"] = "-1";
        UpdateImage();
    }
    #endregion
    protected void UpdateImage()
    {
        Session["imageWidth"] = Convert.ToInt32(IBLayer.Width.Value).ToString();
        Session["imageHeight"] = Convert.ToInt32(IBLayer.Width.Value).ToString();

        IBLayer.ImageUrl = "~/HandlerLayerEditor.ashx?param=" + DateTime.Now.Ticks.ToString();
        layerImage.Update();
    }
    protected void OnIBLayerClicked(object sender, ImageClickEventArgs e)
    {
        var layerEditorHelper = new LayerEditorHelpers(ImageSize)
        {
            Positions = (List<BoxPosition>)Session["boxPositions"]
        };
        int selectedIndex = layerEditorHelper.GetPickedIndex(new Point(e.X, e.Y), DimCase, DimContainer);
        ViewState["SelectedIndex"] = $"{selectedIndex}";
        Session["SelectedIndex"] = $"{selectedIndex}";
        UpdateImage();
    }

    protected void OnArrowClicked(object sender, ImageClickEventArgs e)
    {
        HalfAxis.HAxis axis = HalfAxis.HAxis.AXIS_X_N;
        if (sender == ButtonUp) axis = HalfAxis.HAxis.AXIS_Y_P;
        else if (sender == ButtonDown) axis = HalfAxis.HAxis.AXIS_Y_N;
        else if (sender == ButtonLeft) axis = HalfAxis.HAxis.AXIS_X_N;
        else if (sender == ButtonRight) axis = HalfAxis.HAxis.AXIS_X_P;

        int selectedIndex = int.Parse((string)ViewState["SelectedIndex"]);
        var layerEditHelper = new LayerEditorHelpers(ImageSize)
        {
            Positions = (List<BoxPosition>)Session["boxPositions"],
            SelectedIndex = selectedIndex
        };
        layerEditHelper.Move(axis, 10.0, DimCase);
        Session["boxPositions"] = layerEditHelper.Positions;
        Session["selectedIndex"] = selectedIndex.ToString();

        UpdateImage();
    }

    private Size ImageSize => new Size(Convert.ToInt32(IBLayer.Width.Value), Convert.ToInt32(IBLayer.Height.Value));
    private Vector3D DimCase => Vector3D.Parse((string)Session["dimCase"]);
    private Vector3D DimPallet => Vector3D.Parse((string)Session["dimPallet"]);
    private Vector2D DimContainer
    {
        get
        {
            Vector3D vDimContainer = DimPallet;
            return new Vector2D(vDimContainer.X, vDimContainer.Y);
        }
    }
}