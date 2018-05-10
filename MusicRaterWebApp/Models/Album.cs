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
        [Required(ErrorMessage = "Album name is required")]
        public string albumName { get; set; }
        [Required(ErrorMessage = "Band name is required")]
        public string bandName { get; set; }
        public int? year { get; set; }
    }
}