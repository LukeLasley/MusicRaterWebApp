using MusicRaterWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicRaterWebApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private MusicRaterContext _context;

        public AdminController()
        {
            _context = new MusicRaterContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //Allows administrator to cleanup album covers that are no longer used.
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