using System.Web.Http;

namespace Insurance
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ClientPolicyApi",
                routeTemplate: "api/{controller}/{clientId}/{action}/{policyId}",
                defaults: new { clientId = RouteParameter.Optional, policyId = RouteParameter.Optional }
            );
        }
    }
}
