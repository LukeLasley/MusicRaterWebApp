using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicRaterWebApp.Models;

namespace MusicRaterWebApp.ViewModels
{
    public class AlbumRankerViewModel
    {
        public Album album1 { get; set; }
        public Album album2 { get; set; }
        public User user { get; set; }
        public int chosen { get; set; }

    }
}