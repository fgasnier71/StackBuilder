#region Using directives
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
#endregion

namespace treeDiM.StackBuilder.TechnologyBSA_ASPNET
{
    public static class ConfigSettings
    {
        public static string ThumbSize => ConfigurationManager.AppSettings["ThumbnailSize"] + "px";
        public static bool ShowVirtualKeyboard => bool.Parse(ConfigurationManager.AppSettings["ShowVirtualKeyboard"]);
        public static bool Thumbnails3D => bool.Parse(ConfigurationManager.AppSettings["Use3DThumbnails"]);
        public static int AngleStep => int.Parse(ConfigurationManager.AppSettings["AngleStep"]);
        public static string FtpDirectory => ConfigurationManager.AppSettings["FtpDirectory"];
        public static string FtpUsername => ConfigurationManager.AppSettings["FtpUsername"];
        public static string FtpPassword => ConfigurationManager.AppSettings["FtpPassword"];
        public static float FontSizeRatio => float.Parse(ConfigurationManager.AppSettings["FontSizeRatio"]);
        public static bool WebGLMode => (null != ConfigurationManager.AppSettings["WebGLMode"]) && bool.Parse(ConfigurationManager.AppSettings["WebGLMode"]);
        public static string ExportImageFormat
        {
            get
            {
                string sImageFormat = ConfigurationManager.AppSettings["ExportImageFormat"];
                var listFormat = new List<string> { "bmp", "jpg", "jpeg", "png", "gif" };
                return listFormat.Contains(sImageFormat) ? sImageFormat : "png";
            }
        }
        public static Size ExportImageSize
        { 
            get
            {
                string sImageSize = ConfigurationManager.AppSettings["ExportImageSize"];
                if (string.IsNullOrEmpty(sImageSize))
                    sImageSize = "512, 512";

                try
                {
                    string[] s = sImageSize.Split(',');
                    return new Size(int.Parse(s[0]), int.Parse(s[1]));
                }
                catch (Exception /*ex*/)
                {
                    return new Size(512, 512);
                }
            }
        }
        public static bool ExportShowDimensions
        {
            get
            {
                string sShowDimensions = ConfigurationManager.AppSettings["ExportShowDimensions"];
                try
                {
                    return string.IsNullOrEmpty(sShowDimensions) ? false : bool.Parse(sShowDimensions);
                }
                catch (Exception /*ex*/)
                {
                    return false;
                }

            }
        }
    }
}

