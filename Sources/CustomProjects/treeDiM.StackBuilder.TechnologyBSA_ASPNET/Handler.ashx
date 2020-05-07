<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using treeDiM.StackBuilder.TechnologyBSA_ASPNET;

public class Handler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    int _imageWidth, _imageHeight;
    byte[] _imageBytes;

    public void ProcessRequest(HttpContext context)
    {
        if (context.Session[SessionVariables.ImageWidth] != null)
        {
            _imageWidth = (int)context.Session[SessionVariables.ImageWidth];
            _imageHeight = (int)context.Session[SessionVariables.ImageHeight];
            _imageBytes = (byte[])context.Session[SessionVariables.ImageBytes];
        }
        if (_imageWidth > 0 && _imageHeight > 0)
        {
            try
            {
                context.Response.Clear();
                context.Response.ContentType = "Image/Png";
                byte[] buffer = GetImageBuffer(_imageBytes);
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.End();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public bool IsReusable => true;

    private byte[] GetImageBuffer(byte[] imageBytes)
    {
        Image imgOut = null;
        using (var ms = new MemoryStream(imageBytes))
        { imgOut = Image.FromStream(ms); }
        var outStream = new MemoryStream();
        imgOut.Save(outStream, ImageFormat.Png);
        return outStream.ToArray();
    }
}