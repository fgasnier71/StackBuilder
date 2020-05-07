#region Using directives
using System.Configuration;
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
        public static bool WebGLMode => (null != ConfigurationManager.AppSettings["WebGLMode"]) ? bool.Parse(ConfigurationManager.AppSettings["WebGLMode"]) : false;
    }
}

