using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using TicketModels;
using Microsoft.Data.OData;

namespace TicketODataAPI.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using TicketModels;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<TicketInfo>("TicketInfoes");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TicketInfoesController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/TicketInfoes
        public IHttpActionResult GetTicketInfoes(ODataQueryOptions<TicketInfo> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<TicketInfo>>(ticketInfoes);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/TicketInfoes(5)
        public IHttpActionResult GetTicketInfo([FromODataUri] int key, ODataQueryOptions<TicketInfo> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<TicketInfo>(ticketInfo);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/TicketInfoes(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<TicketInfo> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(ticketInfo);

            // TODO: Save the patched entity.

            // return Updated(ticketInfo);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/TicketInfoes
        public IHttpActionResult Post(TicketInfo ticketInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(ticketInfo);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/TicketInfoes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<TicketInfo> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(ticketInfo);

            // TODO: Save the patched entity.

            // return Updated(ticketInfo);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/TicketInfoes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
