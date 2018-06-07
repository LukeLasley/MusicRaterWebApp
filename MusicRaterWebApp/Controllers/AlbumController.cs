using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicRaterWebApp.Models;
using MusicRaterWebApp.ViewModels;
using MusicRaterWebApp.HelperMethods;

namespace MusicRaterWebApp.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private MusicRaterContext _context;
        private UserAlbumRankHelperMethods HelperMethods;

        public AlbumController()
        {
            _context = new MusicRaterContext();
            HelperMethods = new UserAlbumRankHelperMethods();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Album
        public ActionResult Index()
        {
            var recentAlbums = _context.albums.OrderByDescending(x => x.albumId).Take(10).ToList();
            SearchResultsViewModel resultsViewModel = new SearchResultsViewModel
            {
                toShow = recentAlbums
            };
            return View(resultsViewModel);

        }
        public ActionResult Search()
        {
            return View();
        }
        [Authorize(Roles = "Administrator, Trusted")]
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
        [Authorize(Roles = "Administrator, Trusted")]
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
        public ActionResult GetAlbum(int id)
        {
            Album album = _context.albums.SingleOrDefault(c => c.albumId == id);
            String spotifyLink = "";
            var curUser = User.Identity.GetUserId();
            var albumRank = _context.userAlbumRanks.Where(x => x.albumId == id && x.userId == curUser).ToList();
            if (album.spotifyURi != null)
            {
                spotifyLink = "https://open.spotify.com/embed?uri=" + album.spotifyURi;
            }
            bool showButton = true;
            int rankId = -1;
            if (albumRank.Count == 1)
            {

                showButton = albumRank[0].knowAlbum;
                rankId = albumRank[0].id;
            }
            if(albumRank.Count == 0)
            {
                var newUserRank = HelperMethods.createNewRank(album, curUser);
                _context.userAlbumRanks.Add(newUserRank);
                _context.SaveChanges();
                showButton = true;
                rankId = newUserRank.id;
            }
            var albumHasCover = _context.albumCovers.Any(x => x.albumId == album.albumId);
            var albumPath = "";
            if (albumHasCover)
            {
                var path = _context.albumCovers.Single(x => x.albumId == album.albumId);
                albumPath = "/Images/Albums/" + path.albumCoverId;
            }
            AlbumDescriptionViewModel descriptionViewModel = new AlbumDescriptionViewModel
            {
                album = album,
                genres = album.genres.ToList(),
                spotifyURI = spotifyLink,
                albumRankId = rankId,
                know = showButton,
                userId = curUser,
                albumImagePath = albumPath

            };
            if (album == null)
                return HttpNotFound();
            else
            {
                if (User.IsInRole("Administrator") || User.IsInRole("Trusted"))
                {
                    return View(descriptionViewModel);
                }
                return View("GetAlbumReadOnly", descriptionViewModel);

            }
        }

        //need to add genre chosen
        [Authorize(Roles = "Administrator, Trusted")]
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
        //Gets all albums

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