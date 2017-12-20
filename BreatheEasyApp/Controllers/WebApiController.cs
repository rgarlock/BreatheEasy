using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BreatheEasyApp.Controllers
{
    public class WebApiController : ApiController
    {
        public class VSController : ApiController
        {
            // GET api/<controller>   : url to use => api/vs
            public string Get()
            {
                return "Hi from web api controller";
            }

            // GET api/<controller>/5   : url to use => api/vs/5
            public string Get(int id)
            {
                return (id + 1).ToString();
            }
        }
    }
}
