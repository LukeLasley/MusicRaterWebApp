using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp.Models
{
    public class User
    {
        public User()
        {
            this.userRanks = new HashSet<UserAlbumRank>();
        }
        [Key]
        public int id { get; set; }
        public string userName { get; set; }
        public string userFirstName { get; set; }
        public string email { get; set; }
        public virtual ICollection<UserAlbumRank> userRanks { get; set; }
    }
}