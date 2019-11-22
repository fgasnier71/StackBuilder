#region Using directives
using System;
using System.Drawing;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    internal static class HCylLayoutToImage
    {
        #region Draw
        internal static Bitmap Draw(HCylLayout cylLayout, CylinderProperties cylProperties, Vector3D dimContainer, Size size, bool selected, bool annotate)
        {
            try
            {
                if (null == cylProperties)
                    return Properties.Resources.QuestionMark;
                Graphics3DImage graphics = new Graphics3DImage(size) { MarginPercentage = 0.05 };
                
                using (ViewerHCylLayout solViewer = new ViewerHCylLayout(cylLayout))
                { solViewer.Draw(graphics, cylProperties, 0.0, selected, annotate); }
                return graphics.Bitmap;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                return Properties.Resources.QuestionMark;
            }
        }
        #endregion
        #region Data members
        private static readonly ILog _log = LogManager.GetLogger(typeof(HCylLayoutToImage));
        #endregion
    }
}
