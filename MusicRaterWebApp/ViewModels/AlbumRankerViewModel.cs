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
        public double album1Expected { get; set; }
        public double album2Expected { get; set; }
        public UserAlbumRank albumRank1 { get; set; }
        public UserAlbumRank albumRank2 { get; set; }
    }
}