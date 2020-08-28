using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TestAPI.Controllers
{
    public class HomeController : ApiController

    {
        [HttpGet]
        public string Index()
        {
            //  ViewBag.Title = "Home Page";

            return "dsd";
        }
    }
}
