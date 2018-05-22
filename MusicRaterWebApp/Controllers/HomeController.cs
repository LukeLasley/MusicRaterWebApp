using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicRaterWebApp.HelperMethods;
using MusicRaterWebApp.Models;
using MusicRaterWebApp.ViewModels;

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
            //Placeholder for work with identity
            bool userLoggedIn = true;
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

        //home/albumranker
        public ActionResult AlbumRanker()
        {
            var albumRankerViewModel = helperMethods.PickTwoAlbumRankerViewModels(1);
            return View(albumRankerViewModel);
        }

        private UserAlbumRank createNewRank(Album album, User user)
        {
            var rank = new UserAlbumRank()
            {
                rank = 500,
                userId = user.id,
                albumId = album.albumId,
                timesSeen = 0
            };
            return rank;
        }
    }
}