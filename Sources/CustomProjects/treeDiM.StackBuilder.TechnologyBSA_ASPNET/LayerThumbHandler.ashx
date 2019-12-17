<%@ WebHandler Language="C#" Class="LayerThumbHandler" %>

#region Using directives
using System;
using System.Web;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;

using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;
#endregion

public class LayerThumbHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        string sDimBox = (string)context.Session["dimCase"];
        Vector3D caseDim = Vector3D.Parse(sDimBox);

        string sDimPallet = (string)context.Session["dimPallet"];
        Vector3D dimPallet = Vector3D.Parse(sDimPallet);
        Vector2D dimContainer = new Vector2D(dimPallet.X, dimPallet.Y);

        string sLayerDesc = context.Request.QueryString["LayerDesc"];
        var layerDesc = LayerDescBox.Parse(sLayerDesc) as LayerDescBox;
        LayerSolver solver = new LayerSolver();
        var layer = solver.BuildLayer(caseDim, dimContainer, layerDesc, 0.0);

        var boxProperties = new BoxProperties(null, caseDim.X, caseDim.Y, caseDim.Z)
        {
            TapeColor = Color.LightGray,
            TapeWidth = new OptDouble(true, 50.0)
        };
        boxProperties.SetAllColors(Enumerable.Repeat(Color.Beige, 6).ToArray());

        // build image
        Bitmap bmp;
        Graphics2DImage graphics = new Graphics2DImage(ThumbnailSize);
        using (ViewerILayer2D solViewer = new ViewerILayer2D(layer))
        {
            solViewer.Draw(graphics, boxProperties, 0.0, false, true);
            bmp = graphics.Bitmap;
        }
        try
        {
            context.Response.Clear();
            context.Response.ContentType = "Image/Png";
            ImageConverter converter = new ImageConverter();
            byte[] imageBytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
            byte[] buffer = GetImageBuffer(imageBytes);
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.End();
        }
        catch (Exception)
        {
            throw;
        }
    }

    byte[] GetImageBuffer(byte[] imageBytes)
    {
        Image imgOut = null;
        using (var ms = new MemoryStream(imageBytes))
        { imgOut = Image.FromStream(ms); }
        MemoryStream outStream = new MemoryStream();
        imgOut.Save(outStream, ImageFormat.Png);
        return outStream.ToArray();
    }

    public bool IsReusable
    {
        get { return true; }
    }

    private static Size ThumbnailSize
    {
        get
        {
            int thumbSize = int.Parse(ConfigurationManager.AppSettings["ThumbnailSize"]);
            return new Size(thumbSize, thumbSize);
        }
    }

}