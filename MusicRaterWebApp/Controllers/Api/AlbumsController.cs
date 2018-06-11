using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicRaterWebApp.Models;
using MusicRaterWebApp.Dtos;
using AutoMapper;
using System.Web;
using System.IO;

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

        [HttpPut]
        public IHttpActionResult UpdateSpotifyUri(int id, string uri)
        {
            var databaseAlbum = _context.albums.SingleOrDefault(x => x.albumId == id);
            if (databaseAlbum == null)
            {
                return NotFound();
            }
            databaseAlbum.spotifyURi = uri;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetCoverPath(int albumId)
        {
            var albumCover = _context.albumCovers.SingleOrDefault(x => x.albumId == albumId);
            if(albumCover == null)
            {
                return NotFound();
            }
            var coverPath = "~/Images/Albums/" + albumCover.albumCoverId;
            return Ok(coverPath);
        }

        public IHttpActionResult Search(string albumname, string artistname, int year)
        {
            var results = new List<Album>();
            if (year != 0)
            {
                results = _context.albums.Where(x => x.albumName.Contains(albumname) && x.bandName.Contains(albumname) && x.year == year).ToList();
            }
            else
            {
                results = _context.albums.Where(x => x.albumName.Contains(albumname) && x.bandName.Contains(albumname) && x.year == year).ToList();
            }
            
            return Ok(Mapper.Map<List<Album>, List<AlbumDto>>(results));
        }

        [HttpPut]
        [Route("api/albums/uploadfile")]
        public IHttpActionResult UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpPostedFile = HttpContext.Current.Request.Files["File"];
                var albumIdAsString = HttpContext.Current.Request["AlbumId"];
                if (httpPostedFile != null && albumIdAsString != null)
                {
                    int albumId = Convert.ToInt32(albumIdAsString);
                    var albumExists = _context.albums.Any(x => x.albumId == albumId);
                    if (albumExists)
                    {
                        var fileName = httpPostedFile.FileName;
                        var guid = Guid.NewGuid().ToString();
                        var newfileName = guid + fileName;
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Albums"), newfileName);
                        var coverAlbumExists = _context.albumCovers.Any(x => x.albumId == albumId && x.active == true);
                        if (coverAlbumExists)
                        {
                            var oldCover = _context.albumCovers.Single(x => x.albumId == albumId && x.active == true);
                            oldCover.active = false;
                        }
                        var cover = new AlbumCovers
                        {
                            albumId = albumId,
                            albumCoverId = newfileName,
                            active = true

                        };
                        _context.albumCovers.Add(cover);
                        _context.SaveChanges();
                        var response = "/Images/Albums/" + newfileName;
                        httpPostedFile.SaveAs(fileSavePath);
                        return Ok(response);
                    }
                }
            }
            return BadRequest();
        }
    }
}
