using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IdentityDemoWebApi.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Json("WebApi works if you see this");
        }
    }
}
