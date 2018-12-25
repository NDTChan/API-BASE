using System;
using System.Threading;
using System.Web.Http;
using BTS.SP.API.PHF.Utils;
using BTS.SP.API.PHF.App_Start;
using Telerik.Reporting.Services.WebApi;

namespace BTS.SP.API.PHF
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ReportsControllerConfiguration.RegisterRoutes(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.Config();
            log4net.Config.XmlConfigurator.Configure();
        }
        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            //WriteLogs.LogError(ex);
            if (ex is ThreadAbortException) return;
        }
    }
}
