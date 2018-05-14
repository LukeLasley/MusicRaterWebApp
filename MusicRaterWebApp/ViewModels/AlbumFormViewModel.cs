using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicRaterWebApp.Models;

namespace MusicRaterWebApp.ViewModels
{
    public class AlbumFormViewModel
    {
        public ICollection<Genre> genres { get; set; }
        public Album album { get; set; }
        public int genreChosen { get; set; }
    }
}