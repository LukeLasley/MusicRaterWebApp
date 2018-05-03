using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MusicRaterWebApp.Models;

namespace MusicRaterWebApp
{
    public class MusicRaterContext : DbContext
    {
        public DbSet<Album> albums { get; set;}
        public DbSet<Password> passwords { get; set; }
        public DbSet<User> users { get; set; }
    }
}