using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicRaterWebApp.Models;
using MusicRaterWebApp.ViewModels;

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
            var genres = _context.genres.ToList();
            var albumViewModel = new NewAlbumViewModel()
            {
                genres = genres
            };
            return View(albumViewModel);
        }

        [HttpPost]
        public ActionResult Create(NewAlbumViewModel albumViewModel)
        {
            _context.albums.Add(albumViewModel.album);
            _context.SaveChanges();
            AlbumGenres albumGenre = new AlbumGenres
            {
                albumId = albumViewModel.album.albumId,
                genreId = albumViewModel.genreChosen
            };
            _context.albumGenres.Add(albumGenre);
            _context.SaveChanges();
            String redirect = "GetAlbum/" + albumViewModel.album.albumId;

            return RedirectToAction(redirect, "Album");
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