using Microsoft.AspNet.Identity;
using MusicRaterWebApp.Models;
using MusicRaterWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicRaterWebApp.Controllers
{
    public class UserController : Controller
    {
        private MusicRaterContext _context;

        public UserController()
        {
            _context = new MusicRaterContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //No current index page, redirecting to search
        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("User","Search");
        }

        //This view will grab the users favorite albums based on rankings
        [Authorize]
        public ActionResult Favorites()
        {
            var curUser = User.Identity.GetUserId();
            //Grabs top ten albumIds, might do well to update the model to already have album object in them so I don't have to make second call.
            //Albums must have played the rank game at least once to show.
            var favoriteAlbumIds = _context.userAlbumRanks.Where(x => x.userId.Equals(curUser) && x.knowAlbum == true && x.timesSeen > 0).OrderByDescending(x => x.rank).Select(x => x.albumId).Take(10).ToList();
            var favoriteAlbumsUnsorted = _context.albums.Where(x => favoriteAlbumIds.Contains(x.albumId)).ToList();
            var favoriteAlbumsArray = new Album[10];
            //This takes the unsorted array of favorite albums and sorts them based on the initial albumId query
            foreach(var album in favoriteAlbumsUnsorted){
                int indexOfAlbum = favoriteAlbumIds.IndexOf(album.albumId);
                favoriteAlbumsArray[indexOfAlbum] = album;
            }
            var favoriteAlbums = favoriteAlbumsArray.ToList();
            //In case the user doesn't have 10 albums, remove the empty albums.
            favoriteAlbums.RemoveAll(x => x == null);
            var viewModel = new UserFavoriteAlbumsViewModel
            {
                favoriteAlbum = favoriteAlbums

            };
            return View(viewModel);
        }
    }
}