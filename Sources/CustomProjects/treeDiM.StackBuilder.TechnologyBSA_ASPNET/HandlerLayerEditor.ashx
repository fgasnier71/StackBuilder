<%@ WebHandler Language="C#" Class="HandlerLayerEditor" %>
#region Using directives
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
#endregion

public class HandlerLayerEditor : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        Size sz = new Size(int.Parse((string)context.Session["imageWidth"]), int.Parse((string)context.Session["imageHeight"]));
        int selectedIndex = int.Parse((string)context.Session["selectedIndex"]);

        Vector3D caseDim = Vector3D.Parse((string)context.Session["dimCase"]);
        Vector3D dimPallet = Vector3D.Parse((string)context.Session["dimPallet"]);
        Vector2D dimContainer = new Vector2D(dimPallet.X, dimPallet.Y);

        var boxProperties = new BoxProperties(null, caseDim.X, caseDim.Y, caseDim.Z)
        {
            TapeWidth = new treeDiM.Basics.OptDouble(true, 50.0),
            TapeColor = Color.LightGray
        };
        boxProperties.SetAllColors(Enumerable.Repeat(Color.Beige, 6).ToArray());

        var layerEditorHelpers = new LayerEditorHelpers(sz)
        {
            Content = boxProperties,
            DimContainer = dimContainer,
            Positions = (List<BoxPosition>)context.Session["boxPositions"],
            SelectedIndex = selectedIndex
        };

        ImageConverter converter = new ImageConverter();
        byte[] buffer = (byte[])converter.ConvertTo(layerEditorHelpers.GetLayerImage(), typeof(byte[]));
        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        context.Response.End();
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}