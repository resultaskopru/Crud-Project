using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bir Mvc Projesi.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "resultaskpru@gmail.com";

            return View();
        }
    }
}