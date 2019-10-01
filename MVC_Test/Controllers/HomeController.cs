using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Test.Helpers;
using MVC_Test.Models;
using Microsoft.Extensions.Logging;

namespace MVC_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            InitDB.InitData();

            var data = new GetDataModule();
            List<Books> aa = new List<Books>();
            var ListBook = data.getAllBooks();

            return View(ListBook.OrderByDescending(e => e.Score));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}