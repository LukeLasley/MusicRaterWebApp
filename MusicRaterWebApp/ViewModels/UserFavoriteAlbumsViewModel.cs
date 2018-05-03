﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicRaterWebApp.Models;

namespace MusicRaterWebApp.ViewModels
{
    public class UserFavoriteAlbumsViewModel
    {
        public User curUser { get; set; }
        public List<Album> favoriteAlbum { get; set; }
    }
}