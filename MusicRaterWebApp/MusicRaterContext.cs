using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MusicRaterWebApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MusicRaterWebApp
{
    public class MusicRaterContext : IdentityDbContext<ApplicationUser>
    {
        public MusicRaterContext() : base("MusicraterDatabase") { }
        public DbSet<Album> albums { get; set;}
        public DbSet<Genre> genres { get; set; }
        public DbSet<UserAlbumRank> userAlbumRanks { get; set; }
        public DbSet<AlbumCovers> albumCovers { get; set; }
    }
}