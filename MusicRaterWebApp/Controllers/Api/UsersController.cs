using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicRaterWebApp.Models;
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

        [HttpPut]
        public IHttpActionResult TrustUser(string email, string username)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == email && x.UserName == username);
            if(user == null)
            {
                return NotFound();
            }
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            try
            {
                UserManager.AddToRole(user.Id, "Trusted");
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("api/users/writereview/")]
        public IHttpActionResult WriteReview(string review, int albumId)
        {
            var userId = User.Identity.GetUserId();
            var albumInDb = _context.albums.SingleOrDefault(x => x.albumId == albumId);
            var userReview = _context.userReviews.SingleOrDefault(x => x.album.albumId == albumInDb.albumId && x.userId == userId);
            if(userReview == null)
            {
                userReview = new UserReviews()
                {
                    userId = userId,
                    album = albumInDb,
                    review = review,
                    dateUpdated = DateTime.Now
                };
                _context.userReviews.Add(userReview);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                userReview.review = review;
                userReview.dateUpdated = DateTime.Now;
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}