using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicRaterWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "What is MusicRater";

            return View();
        }

        public ActionResult Login()
        {
            {
                ViewBag.Message = "Login";

                return View();
            }
        }
    }
}