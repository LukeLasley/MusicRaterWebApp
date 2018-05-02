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
            var album = new Album() { albumName = "SAMPLE" };
            return View();
        }
    }
}