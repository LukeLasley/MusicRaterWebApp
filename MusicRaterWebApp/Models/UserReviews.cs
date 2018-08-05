using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp.Models
{
    public class UserReviews
    {
        [Key]
        public int reviewId { get; set; }
        public int albumId { get; set; } 
        public string userId { get; set; }
        public DateTime dateUpdated { get; set; }
        public String review { get; set; }
    }
}