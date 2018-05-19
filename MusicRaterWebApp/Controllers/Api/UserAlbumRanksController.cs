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

        //Put /api/useralbumranks/10
        [HttpPut]
        public IHttpActionResult UpdateAlbumRank(int id, double expected)
        {
            var databaseAlbumRank = _context.userAlbumRanks.SingleOrDefault(c => c.id == id);
            if (databaseAlbumRank == null)
            {
                return NotFound();
            }
            databaseAlbumRank.timesSeen++;

            int k = getKConstant(databaseAlbumRank.timesSeen, databaseAlbumRank.rank);
            databaseAlbumRank.rank = getNewRank(expected, 1, k, databaseAlbumRank.rank);
            _context.SaveChanges();
            return Ok();
        }

        private int getKConstant(int timesSeen, int rank)
        {
            if(timesSeen < 10 || rank < 400)
            {
                return 32;
            }
            if(rank > 500 && rank < 700)
            {
                return 24;
            }
            else
            {
                return 16;
            }
        }
        private int getNewRank(double expected, int result, int K, int rank)
        {
            double gainOrLoss = (result - expected) * K;
            double newRankAsDouble = rank + gainOrLoss;
            return (int)newRankAsDouble;
        }
    }
}