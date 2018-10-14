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

            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IStudentRepository, StudentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISubjectRepository, SubjectRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes 
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Filter to set basic authentication 
            config.Filters.Add(new BasicAuthenticationAttribute());

            //  create context and create DataBase if not exists
            var context = new WebApiTestContext();
            context.Database.CreateIfNotExists();
        }
    }
}
