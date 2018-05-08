using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicRaterWebApp.Models;

namespace MusicRaterWebApp.ViewModels
{
    public class NewAlbumViewModel
    {
        public IEnumerable<Genre> genres { get; set; }
        public Album album { get; set; }
        public int genreChosen { get; set; }
    }
}