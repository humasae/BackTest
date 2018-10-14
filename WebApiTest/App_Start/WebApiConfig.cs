using System.Web.Http;
using Unity;
using WebApiTest.Filters;
using WebApiTest.Models;

namespace WebApiTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var unityContainer = new UnityContainer();

            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new BasicAuthenticationAttribute());

            var context = new WebApiTestContext();
            context.Database.CreateIfNotExists();
        }
    }
}
