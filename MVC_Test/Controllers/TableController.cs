using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Test.Helpers;
using MVC_Test.Models;

namespace MVC_Test.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        public ActionResult Index()
        {
            var data = new GetDataModule();
            List<Books> aa = new List<Books>();
            var ListBook = data.getAllBooks();

            return View(ListBook);
        }
    }
}