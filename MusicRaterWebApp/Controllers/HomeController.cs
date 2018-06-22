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

        //Home page of app
        public ActionResult Index()
        {
            return View();
            
        }

        //Basic about page, not much functionality here
        public ActionResult About()
        {
            ViewBag.Message = "What is MusicRater";

            return View();
        }

        public ActionResult Login()
        {
            return RedirectToAction("Login", "Account");
        }

        //This takes users to the ranking ranking game, must be logged in.
        [Authorize]
        public ActionResult AlbumRanker()
        {
            var curUser = User.Identity.GetUserId();
            var albumRankerViewModel = helperMethods.PickTwoAlbumRankerViewModels(curUser);
            return View(albumRankerViewModel);
        }

        //Allows administrator to cleanup album covers that are no longer used.
        [Authorize(Roles = "Administrator")]
        public ActionResult CoverCleanup()
        {
            //grabs 10 inactive covers
            var inactiveCovers = _context.albumCovers.Where(x => x.active == false).Take(10).ToList();
            
            AlbumCleanupViewModel coverViewModel = new AlbumCleanupViewModel
            {
                covers = inactiveCovers,
            };
            return View(coverViewModel);
        }
    }
}