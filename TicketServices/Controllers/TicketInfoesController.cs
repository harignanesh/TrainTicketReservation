using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using TicketDBContxt;
using TicketModels;

namespace TicketServices.Controllers
{
    public class TicketInfoesController : ODataController
    {
        private TDBContext db = new TDBContext();

        // GET: api/TicketInfoes
        [EnableQuery]
        public IQueryable<TicketInfo> GetTicketInfos()
        {
            return db.TicketInfos;
        }

        // GET: api/TicketInfoes/5
        [ResponseType(typeof(TicketInfo))]
        public async Task<IHttpActionResult> GetTicketInfo(int id)
        {
            TicketInfo ticketInfo = await db.TicketInfos.FindAsync(id);
            if (ticketInfo == null)
            {
                return NotFound();
            }

            return Ok(ticketInfo);
        }

        // PUT: api/TicketInfoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTicketInfo(int id, TicketInfo ticketInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketInfo.Ticket_Id)
            {
                return BadRequest();
            }

            db.Entry(ticketInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TicketInfoes
        [ResponseType(typeof(TicketInfo))]
        public async Task<IHttpActionResult> PostTicketInfo(TicketInfo ticketInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TicketInfos.Add(ticketInfo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ticketInfo.Ticket_Id }, ticketInfo);
        }

        // DELETE: api/TicketInfoes/5
        [ResponseType(typeof(TicketInfo))]
        public async Task<IHttpActionResult> DeleteTicketInfo(int id)
        {
            TicketInfo ticketInfo = await db.TicketInfos.FindAsync(id);
            if (ticketInfo == null)
            {
                return NotFound();
            }

            db.TicketInfos.Remove(ticketInfo);
            await db.SaveChangesAsync();

            return Ok(ticketInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketInfoExists(int id)
        {
            return db.TicketInfos.Count(e => e.Ticket_Id == id) > 0;
        }
    }
}