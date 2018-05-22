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
        private EloMathHelperMethods eloMethods;

        public UserAlbumRanksController()
        {
            _context = new MusicRaterContext();
            eloMethods = new EloMathHelperMethods();

        }
        //GET /api/userranks
        public IEnumerable<UserAlbumRankDto> GetUserRanks()
        {
            var userRanks = _context.userAlbumRanks.ToList().Select(Mapper.Map<UserAlbumRank, UserAlbumRankDto>);
            return userRanks;
        }

        //GET /api/userranks/1
        public IHttpActionResult GetUserRank(int id)
        {
            var userAlbumRank = _context.userAlbumRanks.SingleOrDefault(c => c.id == id);
            if (userAlbumRank == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<UserAlbumRank, UserAlbumRankDto>(userAlbumRank));
            }
        }

        public IEnumerable<UserAlbumRankDto> GetUserRanksOfUser(int userId)
        {
            var userRanks = _context.userAlbumRanks.Where(c => c.userId == userId).ToList().Select(Mapper.Map<UserAlbumRank, UserAlbumRankDto>);
            return userRanks;
        }

        //Put /api/useralbumranks/1
        [HttpPut]
        public IHttpActionResult UpdateAlbumRank(int id, double expected, int result)
        {
            var databaseAlbumRank = _context.userAlbumRanks.SingleOrDefault(c => c.id == id);
            if (databaseAlbumRank == null)
            {
                return NotFound();
            }
            databaseAlbumRank.timesSeen++;

            int k = eloMethods.getKConstant(databaseAlbumRank.timesSeen, databaseAlbumRank.rank);
            databaseAlbumRank.rank = eloMethods.getNewRank(expected, result, k, databaseAlbumRank.rank);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateRanks(int winnerId, int loserId, double winnerExpected, double loserExpected) {
            var databaseAlbumRanks = _context.userAlbumRanks.Where(c => c.id == winnerId || c.id == loserId).ToList();
            if (databaseAlbumRanks.Count < 2)
            {
                return NotFound();
            }
            foreach(var albumRank in databaseAlbumRanks)
            {
                int result;
                double expected;
                if(albumRank.albumId == winnerId)
                {
                    result = 1;
                    expected = winnerExpected;
                }
                else
                {
                    result = 0;
                    expected = loserExpected;
                }
                albumRank.timesSeen++;
                int k = eloMethods.getKConstant(albumRank.timesSeen, albumRank.rank);
                albumRank.rank = eloMethods.getNewRank(expected, result, k, albumRank.rank);
            }
            _context.SaveChanges();
            return Ok();

        }
    }
}