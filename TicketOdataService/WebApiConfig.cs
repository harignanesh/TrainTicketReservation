using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using TicketModels;
namespace TicketOdataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config )
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<TicketModels.TicketInfo>("TicketInfo");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}