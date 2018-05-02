using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp.Models
{
    public class Password
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
    }
}