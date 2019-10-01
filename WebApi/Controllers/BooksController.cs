using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Helpers;
using WebApi.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{
    public class BooksController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetBookforId(string id)
        {

            var services = new ServiceCollection();
            services.AddLogging();
            var provider = services.BuildServiceProvider();

            var factory = provider.GetService<ILoggerFactory>();
            factory.AddNLog();
            factory.ConfigureNLog("nlog.config");

            var logger = provider.GetService<ILogger<BooksController>>();
            logger.LogCritical("hello nlog");

            var proc = new ProcData();
            RspBook result = proc.GetBookforId(id);


            var response = Request.CreateResponse(HttpStatusCode.OK, result);

            if (result.code == "1")
            {
                response = Request.CreateResponse(HttpStatusCode.Forbidden, result);
            }
            return response;
        }

        [HttpPost]
        public HttpResponseMessage InsertBook(ReqInsertBooks books)
        {
            var proc = new ProcData();
            RspBook result = proc.InsertBooks(books.data);

            var response = Request.CreateResponse(HttpStatusCode.OK, result);

            if (result.code == "1")
            {
                response = Request.CreateResponse(HttpStatusCode.Forbidden, result);
            }
            return response;
        }
        [HttpDelete]
        public HttpResponseMessage DelBook(string id)
        {
            var proc = new ProcData();
            RspBook result = proc.DelBook(id);
            

            var response = Request.CreateResponse(HttpStatusCode.OK, result);

            if (result.code == "1")
            {
                response = Request.CreateResponse(HttpStatusCode.Forbidden, result);
            }
            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateBook(string id, ReqInsertBooks books)
        {
            var proc = new ProcData();
            RspBook result = proc.UpdateBook(id, books.data);


            var response = Request.CreateResponse(HttpStatusCode.OK, result);

            if (result.code == "1")
            {
                response = Request.CreateResponse(HttpStatusCode.Forbidden, result);
            }
            return response;
        }
    }
}
