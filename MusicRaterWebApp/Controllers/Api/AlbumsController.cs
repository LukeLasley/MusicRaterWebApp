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
        //NEED TO UPDATE TO SEND ACTION RESULT
        public IEnumerable<AlbumDto> GetAlbums()
        {
            var albums = _context.albums.ToList().Select(Mapper.Map<Album,AlbumDto>);
            return albums;
        }

        //GET /api/albums/1
        public IHttpActionResult GetAlbum(int id)
        {
            var album = _context.albums.SingleOrDefault(c => c.albumId == id);
            if( album == null)
            {
                return NotFound();
            }
            else
            {
                return Ok (Mapper.Map<Album,AlbumDto>(album));
            }
        }
        //POST /api/albums
        [HttpPost]
        public IHttpActionResult CreateAlbum(AlbumDto albumDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var album = Mapper.Map<AlbumDto, Album>(albumDto);
            _context.albums.Add(album);
            _context.SaveChanges();
            albumDto.albumId = album.albumId;
            return Created(new Uri(Request.RequestUri + "/" + album.albumId), albumDto);
        }

        //Put /api/albums/1
        [HttpPut]
        public IHttpActionResult UpdateAlbum(int id, AlbumDto albumDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var databaseAlbum = _context.albums.SingleOrDefault(c => c.albumId == id);
            if(databaseAlbum == null)
            {
                return NotFound();
            }
            Mapper.Map(albumDto, databaseAlbum);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/albums/1
        [HttpDelete]
        public IHttpActionResult DeleteAlbum(int id)
        {
            var databaseAlbum = _context.albums.SingleOrDefault(c => c.albumId == id);
            if (databaseAlbum == null)
            {
                return NotFound();
            }
            _context.albums.Remove(databaseAlbum);
            _context.SaveChanges();

            return Ok();
        }

    }
}
