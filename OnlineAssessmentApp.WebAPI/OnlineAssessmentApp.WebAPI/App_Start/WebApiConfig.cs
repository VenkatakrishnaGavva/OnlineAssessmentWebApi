using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineAssessmentApp.WebAPI
{
    public static class WebApiConfig
    {
        private static string GetAllowedOrigins()
        {
            //Make a call to the database to get allowed origins and convert to a comma separated string
            return "https://onlineassessmentangular.azurewebsites.net,http://localhost:4200";
        }
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            string origins = GetAllowedOrigins();
            var cors = new EnableCorsAttribute(origins, "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();
              config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));
              config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
        }
    }
}
