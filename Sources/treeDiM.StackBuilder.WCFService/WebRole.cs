using Microsoft.WindowsAzure.ServiceRuntime;
using log4net.Config;

namespace treeDiM.StackBuilder.WCFService
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            XmlConfigurator.Configure();
            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.
            return base.OnStart();
        }
    }
}
