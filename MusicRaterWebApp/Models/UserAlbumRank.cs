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
        public int albumId { get; set; }
        public string userId { get; set; }
        public int timesSeen { get; set; }
        public bool knowAlbum { get; set; }
    }
}