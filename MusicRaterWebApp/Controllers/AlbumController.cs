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
            return RedirectToAction("SearchForm", "Album");
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

        //Below code returning model state is invalid
        [HttpPost]
        public ActionResult Save(AlbumFormViewModel albumViewModel)
        {
            if (!ModelState.IsValid)
            { 
                AlbumFormViewModel albumFormViewModel = new AlbumFormViewModel()
                {
                    album = albumViewModel.album,
                    genres = _context.genres.ToList()
                };
                return View("AlbumForm", albumFormViewModel);
            }

            //If the album doesnt exist then add to database
            if (albumViewModel.album.albumId == 0)
            {
                var album = albumViewModel.album;
                Genre genre = _context.genres.SingleOrDefault(c => c.id == albumViewModel.genreChosen);
                album.genres.Add(genre);
                _context.albums.Add(albumViewModel.album);
                _context.SaveChanges();
            }
            else
            {
                //Update database
                Album databaseAlbum = _context.albums.Single(c => c.albumId == albumViewModel.album.albumId);
                Album viewAlbum = albumViewModel.album;
                databaseAlbum.albumName = viewAlbum.albumName;
                databaseAlbum.bandName = viewAlbum.bandName;
                databaseAlbum.year = viewAlbum.year;
                Genre genre = _context.genres.SingleOrDefault(c => c.id == albumViewModel.genreChosen);
                databaseAlbum.genres.Add(genre);
            }

            _context.SaveChanges();
            String redirect = "GetAlbum/" + albumViewModel.album.albumId;

            return RedirectToAction(redirect, "Album");
        }
        
        public ActionResult GetAlbum(int id)
        {
            Album album = _context.albums.SingleOrDefault(c => c.albumId == id);
            AlbumDescriptionViewModel descriptionViewModel = new AlbumDescriptionViewModel
            {
                album = album,
                genres = album.genres.ToList()
            };
            if (album == null)
                return HttpNotFound();
            else
            {
                return View(descriptionViewModel);
            }
        }

        //need to add genre chosen
        public ActionResult Edit(int id)
        {
            Album album = _context.albums.SingleOrDefault(c => c.albumId == id);

            if(album == null)
            {
                return HttpNotFound();
            }
            var g = _context.genres.ToList();
            var viewModel = new AlbumFormViewModel {
                album = album,
                genres = _context.genres.ToList(),
                genreChosen = album.genres.ElementAt(0).id
            };
            return View("AlbumForm", viewModel);
        }

        public ActionResult SearchForm()
        {
            var genres = _context.genres.ToList();
            var albumViewModel = new AlbumFormViewModel()
            {
                genres = genres
            };
            return View(albumViewModel);
        }

        public ActionResult SearchResults(AlbumFormViewModel albumViewModel)
        {
            var albums = _context.albums.Where(c => c.albumName.Equals(albumViewModel.album.albumName) || c.bandName.Equals(albumViewModel.album.bandName) || c.year == albumViewModel.album.year).ToList() ;
            SearchResultsViewModel resultsViewModel = new SearchResultsViewModel
            {
                toShow = albums
            };
            return View(resultsViewModel);
        }

    }
}