using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MusicRaterWebApp.Controllers.Api
{
    public class UsersController : ApiController
    {
        private MusicRaterContext _context;

        public UsersController()
        {
            _context = new MusicRaterContext();
        }

        public IHttpActionResult GetUsers()
        {
            var users = _context.Users.Where(x => x.UserName != "Admin").Select(x => new { x.UserName, x.Email }).ToList();
            return Ok(users);
        }

        public IHttpActionResult GetUser(string searchString)
        {
            var users = _context.Users.Where(x => x.UserName != "Admin" && ( x.Email.Contains(searchString) || x.UserName.Contains(searchString))).Select(x => new { x.UserName, x.Email }).ToList();
            return Ok(users);
        }
    }
}