using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicRaterWebApp.HelperMethods;
using MusicRaterWebApp.Models;
using MusicRaterWebApp.ViewModels;
using Microsoft.AspNet.Identity;

namespace MusicRaterWebApp.Controllers
{
    public class HomeController : Controller
    {

        private MusicRaterContext _context;
        private UserAlbumRankHelperMethods helperMethods;

        public HomeController()
        {
            _context = new MusicRaterContext();
            helperMethods = new UserAlbumRankHelperMethods();
            
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

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
            return RedirectToAction("Login", "Account");
        }

        //home/albumranker
        [Authorize]
        public ActionResult AlbumRanker()
        {
            var curUser = User.Identity.GetUserId();
            var albumRankerViewModel = helperMethods.PickTwoAlbumRankerViewModels(curUser);
            return View(albumRankerViewModel);
        }
    }
}