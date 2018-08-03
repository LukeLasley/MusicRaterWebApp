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
        public String userId { get; set; }
        public List<Album> favoriteAlbum { get; set; }

    }
}