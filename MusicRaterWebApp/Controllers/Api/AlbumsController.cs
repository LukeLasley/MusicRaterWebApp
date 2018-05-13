using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicRaterWebApp.Models;
using MusicRaterWebApp.Dtos;
using AutoMapper;

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
        public IEnumerable<AlbumDto> GetAlbums()
        {
            var albums = _context.albums.ToList().Select(Mapper.Map<Album,AlbumDto>);
            return albums;
        }

        //GET /api/albums/1
        public AlbumDto GetAlbum(int id)
        {
            var album = _context.albums.SingleOrDefault(c => c.albumId == id);
            if( album == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Mapper.Map<Album,AlbumDto>(album);
            }
        }
        //POST /api/albums
        [HttpPost]
        public AlbumDto CreateAlbum(AlbumDto albumDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var album = Mapper.Map<AlbumDto, Album>(albumDto);
            _context.albums.Add(album);
            _context.SaveChanges();
            albumDto.albumId = album.albumId;
            return albumDto;
        }

        //Put /api/albums/1
        [HttpPut]
        public void UpdateAlbum(int id, AlbumDto albumDto)
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
            Mapper.Map(albumDto, databaseAlbum);
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
