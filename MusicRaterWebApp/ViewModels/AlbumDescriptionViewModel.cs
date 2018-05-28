using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicRaterWebApp.Models;

namespace MusicRaterWebApp.ViewModels
{
    public class AlbumDescriptionViewModel
    {
        public Album album { get; set; }
        public List<Genre> genres { get; set; }
        public string spotifyURI { get; set; }
        public string userId { get; set; }
        public bool know { get; set; }
    }
}