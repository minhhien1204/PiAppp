using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using PiApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PiApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            // Web API configuration and services
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.MapODataServiceRoute("odata", "odata", model: GetModel());
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
        }
        public static Microsoft.OData.Edm.IEdmModel GetModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Food>("Food");
            builder.EntitySet<Category>("Category");

            return builder.GetEdmModel();
        }
    }
}
