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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(User user)
        {
            var curUserWithUsername = _context.users.Where(c => c.userFirstName == user.userFirstName).ToList();
            if(curUserWithUsername.Count > 0)
            {
                return RedirectToAction("Signup", "User");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Favorites(int id)
        {
            User user = _context.users.SingleOrDefault(c => c.id == id);
            if (user == null)
                return HttpNotFound();
            else
            {
                var favoriteAlbumIds = _context.userAlbumRanks.OrderByDescending(x => x.rank).Where(x => x.userId == user.id).Select(x => x.albumId).Take(10).ToList();
                var favoriteAlbums = _context.albums.Where(x => favoriteAlbumIds.Contains(x.albumId)).ToList();
                var viewModel = new UserFavoriteAlbumsViewModel
                {
                    curUser = user,
                    favoriteAlbum = favoriteAlbums

                };
                return View(viewModel);
            }
        }
    }
}