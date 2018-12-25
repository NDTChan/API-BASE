using System.Web.Http;
using System.Web.Http.Cors;

namespace BTS.SP.API.PHF
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            UnityConfig.RegisterComponents(config);
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "actionApi",
             routeTemplate: "api/{controller}/{action}/{code}",
             defaults: new { code = RouteParameter.Optional }
            );
        }
    }
}
