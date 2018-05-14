using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicRaterWebApp.Models
{
    public class Genre
    {
        public Genre()
        {
            this.albums = new HashSet<Album>();
        }
        [Key]
        public int id { get; set; }
        public String genre { get; set; }
        public virtual ICollection<Album> albums { get; set; }
    }
}