using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using TicketDBContxt;
using TicketModels;

namespace TicketOdataService.Controllers
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
        private TDBContext db = new TDBContext();

        // GET: odata/TicketInfoes
        [EnableQuery]
        public IQueryable<TicketInfo> GetTicketInfoes()
        {
            return db.TicketInfos;
        }

        // GET: odata/TicketInfoes(5)
        [EnableQuery]
        public SingleResult<TicketInfo> GetTicketInfo([FromODataUri] int key)
        {
            return SingleResult.Create(db.TicketInfos.Where(ticketInfo => ticketInfo.Ticket_Id == key));
        }

        // PUT: odata/TicketInfoes(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<TicketInfo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TicketInfo ticketInfo = db.TicketInfos.Find(key);
            if (ticketInfo == null)
            {
                return NotFound();
            }

            patch.Put(ticketInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketInfoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(ticketInfo);
        }

        // POST: odata/TicketInfoes
        public IHttpActionResult Post(TicketInfo ticketInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TicketInfos.Add(ticketInfo);
            db.SaveChanges();

            return Created(ticketInfo);
        }

        // PATCH: odata/TicketInfoes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<TicketInfo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TicketInfo ticketInfo = db.TicketInfos.Find(key);
            if (ticketInfo == null)
            {
                return NotFound();
            }

            patch.Patch(ticketInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketInfoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(ticketInfo);
        }

        // DELETE: odata/TicketInfoes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            TicketInfo ticketInfo = db.TicketInfos.Find(key);
            if (ticketInfo == null)
            {
                return NotFound();
            }

            db.TicketInfos.Remove(ticketInfo);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketInfoExists(int key)
        {
            return db.TicketInfos.Count(e => e.Ticket_Id == key) > 0;
        }
    }
}
