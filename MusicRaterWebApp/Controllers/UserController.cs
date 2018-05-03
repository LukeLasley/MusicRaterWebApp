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

        public ActionResult Favorites(int id)
        {
            User user = _context.users.SingleOrDefault(c => c.id == id);
            if (user == null)
                return HttpNotFound();
            else
            {
                var favoriteAlbums = _context.albums.ToList();
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