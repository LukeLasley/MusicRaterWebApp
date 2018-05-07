using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicRaterWebApp.Models;

namespace MusicRaterWebApp.Controllers
{
    public class AlbumController : Controller
    {
        private MusicRaterContext _context;

        public AlbumController()
        {
            _context = new MusicRaterContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult GetAlbum(int id)
        {
            Album album = _context.albums.SingleOrDefault(c => c.albumId == id);
            if (album == null)
                return HttpNotFound();
            else
            {
                return View(album);
            }
        }
    }
}