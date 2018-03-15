using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineAssessmentApp.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //EnableCorsAttribute cors = new EnableCorsAttribute("https://onlineassessmentappangularclient.azurewebsites.net", "*", "GET,POST");
            //config.EnableCors(cors);
            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:4200", "*", "GET,POST");
            config.EnableCors(cors);
            //  https://onlineassessmentappangularclient.azurewebsites.net
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));
              config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
