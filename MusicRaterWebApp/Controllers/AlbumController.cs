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

        public ActionResult AlbumForm()
        {
            var genres = _context.genres.ToList();
            var albumViewModel = new AlbumFormViewModel()
            {
                genres = genres
            };
            return View(albumViewModel);
        }

        [HttpPost]
        public ActionResult Save(AlbumFormViewModel albumViewModel)
        {
            if(albumViewModel.album.albumId == 0)
            {
                _context.albums.Add(albumViewModel.album);
                _context.SaveChanges();
                AlbumGenres albumGenre = new AlbumGenres
                {
                    albumId = albumViewModel.album.albumId,
                    genreId = albumViewModel.genreChosen
                };
                _context.albumGenres.Add(albumGenre);
            }
            else
            {
                //Update database
                var databaseAlbum = _context.albums.Single(c => c.albumId == albumViewModel.album.albumId);
            }

            _context.SaveChanges();
            String redirect = "GetAlbum/" + albumViewModel.album.albumId;

            return RedirectToAction(redirect, "Album");
        }

        public ActionResult GetAlbum(int id)
        {
            Album album = _context.albums.SingleOrDefault(c => c.albumId == id);
            AlbumGenres albumGenre = _context.albumGenres.SingleOrDefault(c => c.albumId == id);
            Genre genre = _context.genres.SingleOrDefault(c => c.id == albumGenre.genreId);
            AlbumDescriptionViewModel descriptionViewModel = new AlbumDescriptionViewModel
            {
                album = album,
                genres = new List<Genre>()
                {
                    genre
                },
            };
            if (album == null)
                return HttpNotFound();
            else
            {
                return View(descriptionViewModel);
            }
        }
        public ActionResult Edit(int id)
        {
            Album album = _context.albums.SingleOrDefault(c => c.albumId == id);

            if(album == null)
            {
                return HttpNotFound();
            }
            AlbumGenres albumGenre = _context.albumGenres.SingleOrDefault(c => c.albumId == id);
            var viewModel = new AlbumFormViewModel {
                album = album,
                genres = _context.genres.ToList(),
                genreChosen = albumGenre.genreId
            };
            return View("AlbumForm", viewModel);
        }
    }
}