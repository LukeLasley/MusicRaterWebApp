using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicRaterWebApp.Models
{
    public class UserAlbumRank
    {
        [Key]
        public int id { get; set; }
        public int rank { get; set; }
        public User user { get; set; }
        public Album album { get; set; }
    }
}