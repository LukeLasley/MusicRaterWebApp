using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicRaterWebApp.Models;

namespace MusicRaterWebApp.Controllers.Api
{
    public class AlbumsController : ApiController
    {
        private MusicRaterContext _context;

        public AlbumsController()
        {
            _context = new MusicRaterContext();
        }
        //GET /api/albums
        public IEnumerable<Album> GetAlbums()
        {
            var albums = _context.albums.ToList();
            return albums;
        }

        //GET /api/albums/1
        public Album GetAlbum(int id)
        {
            var album = _context.albums.SingleOrDefault(c => c.albumId == id);
            if( album == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return album;
            }
        }
        //POST /api/albums
        [HttpPost]
        public Album CreateAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.albums.Add(album);
            _context.SaveChanges();
            return album;
        }

        //Put /api/albums/1
        [HttpPut]
        public void UpdateAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var databaseAlbum = _context.albums.SingleOrDefault(c => c.albumId == id);
            if(databaseAlbum == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            databaseAlbum.albumName = album.albumName;
            databaseAlbum.bandName = album.bandName;
            databaseAlbum.year = album.year;

            _context.SaveChanges();
        }

        //DELETE /api/albums/1
        [HttpDelete]
        public void DeleteAlbum(int id)
        {
            var databaseAlbum = _context.albums.SingleOrDefault(c => c.albumId == id);
            if (databaseAlbum == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.albums.Remove(databaseAlbum);
            _context.SaveChanges();
        }

    }
}
