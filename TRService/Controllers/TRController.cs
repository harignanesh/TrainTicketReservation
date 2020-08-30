using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRModels;
using TRDBContext;
using System.Web.Http.Cors;
using TRService.Managers;
using TRService.IManager;

namespace TRService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TRController : ApiController
    {
        // GET api/TR
        TrainDBContext trDBContext = new TrainDBContext();
        TRManager TRManager = new TRManager();
        [HttpGet]
        public IEnumerable<TrainTicketInfo> Get()
        {
            return trDBContext.TicketInfos.ToList();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST api/values
        public void Post(TrainTicketInfo objTR)
        {
            try
            {
                trDBContext.TicketInfos.Add(objTR);
                trDBContext.SaveChanges();
                TRManager.SendEmail(objTR);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Working!" + ex);
            }


        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
