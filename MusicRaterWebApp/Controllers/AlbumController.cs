using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
        [Authorize]
        public ActionResult Index()
        {
            var recentAlbums = _context.albums.OrderByDescending(x => x.albumId).Take(10).ToList();
            SearchResultsViewModel resultsViewModel = new SearchResultsViewModel
            {
                toShow = recentAlbums
            };
            return View(resultsViewModel);

        }

        [Authorize]
        public ActionResult AlbumForm()
        {
            var genres = _context.genres.ToList();
            var albumViewModel = new AlbumFormViewModel()
            {
                genres = genres
            };
            return View(albumViewModel);
        }

        //Code works however ModelState is returning invalid each time. Want to add that check back in eventually.
        [HttpPost]
        public ActionResult Save(AlbumFormViewModel albumViewModel)
        {

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
                databaseAlbum.genres.Clear();
                databaseAlbum.genres.Add(genre);
            }

            _context.SaveChanges();
            String redirect = "GetAlbum/" + albumViewModel.album.albumId;

            return RedirectToAction(redirect, "Album");
        }
        [Authorize]
        public ActionResult GetAlbum(int id)
        {
            Album album = _context.albums.SingleOrDefault(c => c.albumId == id);
            String spotifyLink = "";
            var curUser = User.Identity.GetUserId();
            var know = _context.userAlbumRanks.Where(x => x.albumId == id && x.userId == curUser).Select(x=> x.knowAlbum).ToList();
            if (album.spotifyURi != null)
            {
                spotifyLink = "https://open.spotify.com/embed?uri=" + album.spotifyURi;
            }
            bool showButton = true;
            if (know.Count != 1)
            {
                showButton = know[0];
            }
            AlbumDescriptionViewModel descriptionViewModel = new AlbumDescriptionViewModel
            {
                album = album,
                genres = album.genres.ToList(),
                spotifyURI = spotifyLink,
                userId = curUser,
                know = showButton
                
            };
            if (album == null)
                return HttpNotFound();
            else
            {
                return View(descriptionViewModel);
            }
        }

        //need to add genre chosen
        [Authorize]
        public ActionResult Edit(int id)
        {
            Album album = _context.albums.SingleOrDefault(c => c.albumId == id);

            if(album == null)
            {
                return HttpNotFound();
            }
            int genreChosenId = 0;
            if(album.genres.Count > 0)
            {
                genreChosenId = album.genres.ElementAt(0).id;
            }
            var g = _context.genres.ToList();
            var viewModel = new AlbumFormViewModel {
                album = album,
                genres = _context.genres.ToList(),
                genreChosen = genreChosenId
            };
            return View("AlbumForm", viewModel);
        }
        [Authorize]
        public ActionResult SearchForm()
        {
            var genres = _context.genres.ToList();
            var albumViewModel = new AlbumFormViewModel()
            {
                genres = genres
            };
            return View(albumViewModel);
        }
        [Authorize]
        public ActionResult SearchResults(AlbumFormViewModel albumViewModel)
        {
            var albums = _context.albums.Where(c => c.albumName.Equals(albumViewModel.album.albumName) || c.bandName.Equals(albumViewModel.album.bandName) || c.year == albumViewModel.album.year).ToList() ;
            SearchResultsViewModel resultsViewModel = new SearchResultsViewModel
            {
                toShow = albums
            };
            return View(resultsViewModel);
        }
        //Gets all albums
        [Authorize]
        public ActionResult GetAll()
        {
            var albums = _context.albums.ToList();
            var resultsViewModel = new SearchResultsViewModel
            {
                toShow = albums
            };
            return View("SearchResults", resultsViewModel);
        }
    }
}