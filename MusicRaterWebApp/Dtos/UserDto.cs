using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp.Dtos
{
    public class UserDto
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string userFirstName { get; set; }
        public string email { get; set; }
    }
}