using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp.Dtos
{
    public class UserAlbumRankDto
    {
        public int id { get; set; }
        public int rank { get; set; }
        public int userId { get; set; }
        public int albumId { get; set; }
        public int timesSeen { get; set; }
    }
}