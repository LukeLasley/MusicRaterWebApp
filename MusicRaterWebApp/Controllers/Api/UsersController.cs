﻿using Microsoft.AspNet.Identity;
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
    }
}