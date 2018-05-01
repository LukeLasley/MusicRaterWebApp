using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicRaterWebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [Route("Login/")]
        public ActionResult Login()
        {
            return View();
        }
    }
}