using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicRaterWebApp.Models;
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

        public ActionResult AlbumRanker()
        {
            var albumsChosen = _context.albums.OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            var user = _context.users.SingleOrDefault(x => x.id == 1);
            int album1Id = albumsChosen[0].albumId;
            int album2Id = albumsChosen[1].albumId;
            var albumRanks = _context.userAlbumRanks.Where(x => x.user.id == user.id && (x.album.albumId == album1Id || x.album.albumId == album2Id)).ToList();
            if (albumRanks.Count < 2)
            {
                if(albumRanks.Count == 0)
                {
                    foreach(var album in albumsChosen)
                    {
                        var toInput = createNewRank(album,user);
                        albumRanks.Add(toInput);
                        _context.userAlbumRanks.Add(toInput);
                    };
                }
                else
                {
                    if (albumRanks[0].album.Equals(albumsChosen[0]))
                    {
                        var toInput = createNewRank(albumsChosen[1], user);
                        albumRanks.Add(toInput);
                        _context.userAlbumRanks.Add(toInput);
                    }
                    else
                    {
                        var toInput = createNewRank(albumsChosen[0], user);
                        albumRanks.Insert(0,toInput);
                        _context.userAlbumRanks.Add(toInput);
                    }
                }
                _context.SaveChanges();
            };
            var translatedAlbum1Rank = Math.Pow(10, ((double)albumRanks[0].rank / 500));
            var translatedAlbum2Rank = Math.Pow(10, ((double)albumRanks[1].rank / 500));
            var expecteds = getExpectedScores(translatedAlbum1Rank, translatedAlbum2Rank);
            var albumRankerViewModel = new AlbumRankerViewModel()
            {
                album1 = albumsChosen[0],
                album2 = albumsChosen[1],
                album1Expected = expecteds.Item1,
                album2Expected = expecteds.Item2,
                user = user,
                albumRank1 = albumRanks[0],
                albumRank2 = albumRanks[1]
            };
            return View(albumRankerViewModel);
        }

        public Tuple<double,double> getExpectedScores(double album1ConvertedRating, double album2ConvertedRating)
        {
            var denominator = album1ConvertedRating + album2ConvertedRating;
            Tuple<double, double> returnTuple = Tuple.Create((album1ConvertedRating/denominator),((album2ConvertedRating / denominator)));
            return returnTuple;
        }

        public UserAlbumRank createNewRank(Album album, User user)
        {
            var rank = new UserAlbumRank()
            {
                rank = 500,
                user = user,
                album = album,
                timesSeen = 0
            };
            return rank;
        }
    }
}