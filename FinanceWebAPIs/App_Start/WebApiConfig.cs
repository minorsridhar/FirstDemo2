using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace FinanceWebAPIs
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
                name: "DefaultIntApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "GetById" }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultStringApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "GetByTicker" }
            );
            //config.Routes.MapHttpRoute(
            //    name: "DefaultStatementApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { action = "GetBySt" }
            //);
              config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            // config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //config.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            //{
            //    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
            //};
        }
    }
}
