using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Extensions;

namespace Nop.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.Formatters.JsonFormatter.MediaTypeMappings
                .Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                              "text/html",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/json"));
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.AddODataQueryFilter();

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Web API");
                //var doc = GetXmlCommentsPath();
                //c.IncludeXmlComments(doc);
            }).EnableSwaggerUi();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\ApiDoc.xml",
                        System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
