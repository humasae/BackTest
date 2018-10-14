using System.Web.Http;
using Unity;
using Unity.Lifetime;
using WebApiTest.Filters;
using WebApiTest.Models;
using WebApiTest.Models.Impl;
using WebApiTest.Models.Interfaces;
using WebApiTest.Resolver;

namespace WebApiTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var unityContainer = new UnityContainer();

            // Configuración y servicios de API web
            var container = new UnityContainer();
            container.RegisterType<IStudentRepository, StudentRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

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
