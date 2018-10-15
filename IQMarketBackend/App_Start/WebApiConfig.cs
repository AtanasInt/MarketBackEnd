using System.Web.Http;
using Autofac;
using System.Reflection;

using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System;
using System.Net;
using System.Text;
using Autofac.Integration.WebApi;

namespace IQMarketBackend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
           // config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new App_Start.ServicesRegistration("IQMarketBackend"));
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
