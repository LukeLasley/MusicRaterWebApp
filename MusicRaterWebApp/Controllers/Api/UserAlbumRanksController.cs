using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using MusicRaterWebApp.Dtos;
using MusicRaterWebApp.Models;

namespace MusicRaterWebApp.Controllers.Api
{
    public class UserAlbumRanksController : ApiController
    {
        private MusicRaterContext _context;

        public UserAlbumRanksController()
        {
            _context = new MusicRaterContext();
        }
        //GET /api/userranks
        public IEnumerable<UserAlbumRankDto> GetUserRanks()
        {
            var userRanks = _context.userAlbumRanks.ToList().Select(Mapper.Map<UserAlbumRank, UserAlbumRankDto>);
            return userRanks;
        }

    }
}