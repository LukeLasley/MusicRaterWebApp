using MusicRaterWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp.ViewModels
{
    public class UserProfileViewModel
    {
        public String username { get; set; }
        public List<Album> favoriteAlbum { get; set; }
        public Dictionary<Album,String> userReviews { get; set; }
        public Dictionary<int,string> covers { get; set; }
    }
}