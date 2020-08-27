using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TicketModels;
using System.Web.OData.Builder;
using System.Web.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace TicketODataAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<TicketInfo>("TicketInfos");

            config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());

            //// Web API configuration and services

            //// Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
