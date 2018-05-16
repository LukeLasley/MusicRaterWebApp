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
            //Placeholder for work with identity
            bool userLoggedIn = false;
            if (userLoggedIn)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "What is MusicRater";

            return View();
        }
    }
}