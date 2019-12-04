<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public class Handler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    int ImageWidth = 0, ImageHeight = 0;
    byte[] imageBytes = null;

    public void ProcessRequest(HttpContext context)
    {
        if (context.Session["height"] != null)
        {
            ImageHeight = int.Parse((string)context.Session["height"]);
            ImageWidth = int.Parse((string)context.Session["width"]);
            imageBytes = (byte[])(context.Session["imageBytes"]);
        }
        if (ImageWidth > 0 && ImageHeight > 0)
        {
            try
            {
                context.Response.Clear();
                context.Response.ContentType = "Image/Png";
                byte[] buffer = GetImageBuffer(imageBytes);
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.End();
            }
            catch (Exception)
            {
                throw;
            }
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

    public bool IsReusable {
        get { return true; }
    }
}