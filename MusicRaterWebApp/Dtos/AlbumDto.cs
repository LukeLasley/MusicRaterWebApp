using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using MusicRaterWebApp.Models;

namespace MusicRaterWebApp.Dtos
{
    public class AlbumDto
    {
        public int albumId { get; set; }
        [Required]
        public string albumName { get; set; }
        [Required]
        public string bandName { get; set; }
        public int year { get; set; }
        public List<GenreDto> genres {get; set;}
    }
}