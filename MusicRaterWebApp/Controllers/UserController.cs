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

        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        //TODO: Need to update UserAlbumRanks to include Album model.
        [Authorize]
        public ActionResult Favorites(String id)
        {
            if (id == null)
                return HttpNotFound();
            else
            {
                var favoriteAlbumIds = _context.userAlbumRanks.Where(x => x.userId.Equals(id)).OrderByDescending(x => x.rank).Select(x => x.albumId).Take(10).ToList();
                var favoriteAlbumsUnsorted = _context.albums.Where(x => favoriteAlbumIds.Contains(x.albumId)).ToList();
                var favoriteAlbumsArray = new Album[10];
                foreach(var album in favoriteAlbumsUnsorted)
                {
                    int indexOfAlbum = favoriteAlbumIds.IndexOf(album.albumId);
                    favoriteAlbumsArray[indexOfAlbum] = album;
                }
                var favoriteAlbums = favoriteAlbumsArray.ToList();
                var viewModel = new UserFavoriteAlbumsViewModel
                {
                    curUser = 1,
                    favoriteAlbum = favoriteAlbums

                };
                return View(viewModel);
            }
        }
    }
}