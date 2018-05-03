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
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAlbum(int id)
        {
            Album album = new Album() { albumName = "SAMPLE" , genre = "pop", bandName = "BANDNAME", year = 1990};
            return View(album);
        }
    }
}