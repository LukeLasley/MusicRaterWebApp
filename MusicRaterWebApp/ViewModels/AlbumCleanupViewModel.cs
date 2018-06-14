using MusicRaterWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp.ViewModels
{
    public class AlbumCleanupViewModel
    {
        public List<Album> albums { get; set; }
        public List<AlbumCovers> covers { get; set; }
    }
}