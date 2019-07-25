#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public class ECT_Forms
    {
        static public void ComputeECT()
        {
            try
            {
                var form = new FormComputeECT();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        static public void EditMaterialList()
        {
            try
            {
                var form = new FormCardboardQualityList();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private static readonly ILog _log = LogManager.GetLogger(typeof(ECT_Forms));
    }
}
