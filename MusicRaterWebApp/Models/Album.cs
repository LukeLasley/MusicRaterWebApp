using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp.Models
{
    public class Album
    {
        public string albumName { get; set; }
        public string bandName { get; set; }
        public int year { get; set; }
        public string genre { get; set; }
    }
}