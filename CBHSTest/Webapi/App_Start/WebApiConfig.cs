using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using Webapi.Services;
using System.Web.Mvc;
using System.ComponentModel;
using System.Web.Routing;

namespace Webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
           name: "Api_Get",
           routeTemplate: "{controller}/{id}/{action}",
           defaults: new { id = RouteParameter.Optional, action = "Get" },
           constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );

            config.Routes.MapHttpRoute(
               name: "Api_Post",
               routeTemplate: "{controller}/{id}/{action}",
               defaults: new { id = RouteParameter.Optional, action = "Post" },
               constraints: new { httpMethod = new HttpMethodConstraint("POST") }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));

            var container = new UnityContainer();
            container.RegisterType<IMemberService, MemberService>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
