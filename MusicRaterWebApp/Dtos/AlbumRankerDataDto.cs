using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp.Dtos
{
    public class AlbumRankerDataDto
    {
        public AlbumDto album1 { get; set; }
        public AlbumDto album2 { get; set; }
        public double album1Expected { get; set; }
        public double album2Expected { get; set; }
        public UserAlbumRankDto albumRank1 { get; set; }
        public UserAlbumRankDto albumRank2 { get; set; }
        public String album1path { get; set; }
        public String album2path { get; set; }
    }
}