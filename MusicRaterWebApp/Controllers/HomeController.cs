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
            var user = _context.users.SingleOrDefault(x => x.id == 1);
            var albumRanks = _context.userAlbumRanks.Where(x => x.user == user && (x.album == album1 || x.album == album2)).ToList();
            if(albumRanks.Count < 2)
            {
                //find out which one doesn't exist and make it exist
            };
            var translatedAlbum1Rank = translateRating(albumRanks[0].rank);
            var translatedAlbum2Rank = translateRating(albumRanks[1].rank);
            var expecteds = getExpectedScores(translatedAlbum1Rank, translatedAlbum2Rank);
            var albumRankerViewModel = new AlbumRankerViewModel()
            {
                album1 = album1,
                album2 = album2,
                album1Expected = expecteds.Item1,
                album2Expected = expecteds.Item2,
                user = user,
                albumRank1 = albumRanks[0],
                albumRank2 = albumRanks[1]
            };
            return View(albumRankerViewModel);
        }

        //switch 500 to variable
        public double translateRating(int rating)
        {
            double translateRating = Math.Pow(10, ((double)rating/500));
            return translateRating;
        }
        public Tuple<double,double> getExpectedScores(double album1ConvertedRating, double album2ConvertedRating)
        {
            var denominator = album1ConvertedRating + album2ConvertedRating;
            Tuple<double, double> returnTuple = Tuple.Create((album1ConvertedRating/denominator),((album2ConvertedRating / denominator)));
            return returnTuple;
        }
    }
}