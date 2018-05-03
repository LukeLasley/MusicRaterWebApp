using System;
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
      /*  User curUser = new User() { userName = "aaa" };
        List<Album> favoriteAlbums = new List<Album>
        {
            new Album {albumName = "album a"},
            new Album {albumName = "album b"},
            new Album {albumName = "album c"},
        };
        var viewModel = new */
    }
}