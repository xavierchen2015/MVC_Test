using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class BooksController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public HttpResponseMessage InsertBook(ReqInsertBooks entities)
        {
            var context = Request;
            var ddd = entities;
            var proc = new ProcData();
            RspBook result = proc.InsertBooks(ddd.data);

            var response = Request.CreateResponse(HttpStatusCode.OK, result);

            if (result.code == "1")
            {
                response = Request.CreateResponse(HttpStatusCode.Forbidden, result);
            }
            return response;
        }
    }
}
