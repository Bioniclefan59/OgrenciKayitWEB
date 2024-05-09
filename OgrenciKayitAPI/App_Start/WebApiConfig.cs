using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OgrenciKayitAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                //name: "GetStudentNames",
                //routeTemplate: "api/ogrenciler/GetStudentNames",
                //defaults: new { controller = "GetStudentNamesController", action = "GetStudentNames" }
            );
        }
    }
}
