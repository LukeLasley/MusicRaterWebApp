using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicRaterWebApp.Models;
using MusicRaterWebApp.ViewModels;

namespace MusicRaterWebApp.HelperMethods
{

    public class UserAlbumRankHelperMethods
    {
        private MusicRaterContext _context;
        private EloHelperMethods eloMethods;

        public UserAlbumRankHelperMethods()
        {
            _context = new MusicRaterContext();
            eloMethods = new EloHelperMethods();
        }

        public AlbumRankerViewModel PickTwoAlbumRankerViewModels(int userId)
        {
            var albumsChosen = _context.albums.OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            var user = _context.users.SingleOrDefault(x => x.id == userId);
            int album1Id = albumsChosen[0].albumId;
            int album2Id = albumsChosen[1].albumId;
            var albumRanks = _context.userAlbumRanks.Where(x => x.userId == user.id && (x.albumId == album1Id || x.albumId == album2Id)).ToList();
            if (albumRanks.Count < 2)
            {
                if (albumRanks.Count == 0)
                {
                    foreach (var album in albumsChosen)
                    {
                        var toInput = createNewRank(album, user);
                        albumRanks.Add(toInput);
                        _context.userAlbumRanks.Add(toInput);
                    };
                }
                else
                {
                    if (albumRanks[0].albumId == albumsChosen[0].albumId)
                    {
                        var toInput = createNewRank(albumsChosen[1], user);
                        albumRanks.Add(toInput);
                        _context.userAlbumRanks.Add(toInput);
                    }
                    else
                    {
                        var toInput = createNewRank(albumsChosen[0], user);
                        albumRanks.Insert(0, toInput);
                        _context.userAlbumRanks.Add(toInput);
                    }
                }
                _context.SaveChanges();
            };
            var indexOfAlbum1Rank = -1;
            var indexOfAlbum2Rank = -1;
            if(albumRanks[0].albumId == album1Id)
            {
                indexOfAlbum1Rank = 0;
                indexOfAlbum2Rank = 1;
            }
            else
            {
                indexOfAlbum1Rank = 1;
                indexOfAlbum2Rank = 0;
            }

            var translatedAlbum1Rank = eloMethods.convertRank(albumRanks[indexOfAlbum1Rank].rank);
            var translatedAlbum2Rank = eloMethods.convertRank(albumRanks[indexOfAlbum2Rank].rank);
            var expecteds = eloMethods.getExpectedScores(translatedAlbum1Rank, translatedAlbum2Rank);
            var albumRankerViewModel = new AlbumRankerViewModel()
            {
                album1 = albumsChosen[0],
                album2 = albumsChosen[1],
                album1Expected = expecteds.Item1,
                album2Expected = expecteds.Item2,
                user = user,
                albumRank1 = albumRanks[indexOfAlbum1Rank],
                albumRank2 = albumRanks[indexOfAlbum2Rank]
            };
            return albumRankerViewModel;
        }

        private UserAlbumRank createNewRank(Album album, User user)
        {
            var rank = new UserAlbumRank()
            {
                rank = 500,
                userId = user.id,
                albumId = album.albumId,
                timesSeen = 0
            };
            return rank;
        }
    }
}