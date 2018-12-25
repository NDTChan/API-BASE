using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Telerik.Reporting.Services.WebApi;

namespace BTS.SP.API.PHF.Controllers
{
    public class ReportsController : ReportsControllerBase
    {
        static Telerik.Reporting.Services.ReportServiceConfiguration configurationInstance =
            new Telerik.Reporting.Services.ReportServiceConfiguration
            {
                HostAppId = "PHF",
                ReportResolver = new ReportFileResolver(HttpContext.Current.Server.MapPath("~/Reports"))
                    .AddFallbackResolver(new ReportTypeResolver()),
                Storage = new Telerik.Reporting.Cache.File.FileStorage(),
            };

        public ReportsController()
        {
            this.ReportServiceConfiguration = configurationInstance;
        }
    }
}
