using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicRaterWebApp.ViewModels;

namespace MusicRaterWebApp.Controllers
{
    public class HomeController : Controller
    {

        private MusicRaterContext _context;

        public HomeController()
        {
            _context = new MusicRaterContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

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

        public ActionResult AlbumRanker()
        {
            var album1 = _context.albums.SingleOrDefault(x => x.albumId == 1);
            var album2 = _context.albums.SingleOrDefault(x => x.albumId == 2);
            var albumRankerViewModel = new AlbumRankerViewModel()
            {
                album1 = album1,
                album2 = album2
            };
            return View(albumRankerViewModel);
        }
    }
}