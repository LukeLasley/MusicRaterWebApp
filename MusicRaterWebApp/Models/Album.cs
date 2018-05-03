using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp.Models
{
    public class Album
    {
        [Key]
        public int albumId { get; set;}
        public string albumName { get; set; }
        public string bandName { get; set; }
        public int year { get; set; }
        public string genre { get; set; }
    }
}