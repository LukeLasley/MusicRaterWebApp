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

        public AlbumRankerViewModel PickTwoAlbumRankerViewModels(string userId)
        {
            var dontChose = _context.userAlbumRanks.Where(x => x.knowAlbum != true && x.userId == userId).Select(x => x.albumId).ToList();
            var albumsChosen = _context.albums.OrderBy(x => Guid.NewGuid()).Where(x => !dontChose.Contains(x.albumId)).Take(2).ToList();
            int album1Id = albumsChosen[0].albumId;
            int album2Id = albumsChosen[1].albumId;
            var albumRanks = _context.userAlbumRanks.Where(x => x.userId.Equals(userId) && (x.albumId == album1Id || x.albumId == album2Id)).ToList();
            if (albumRanks.Count < 2)
            {
                if (albumRanks.Count == 0)
                {
                    foreach (var album in albumsChosen)
                    {
                        var toInput = createNewRank(album, userId);
                        albumRanks.Add(toInput);
                        _context.userAlbumRanks.Add(toInput);
                    };
                }
                else
                {
                    if (albumRanks[0].albumId == albumsChosen[0].albumId)
                    {
                        var toInput = createNewRank(albumsChosen[1], userId);
                        albumRanks.Add(toInput);
                        _context.userAlbumRanks.Add(toInput);
                    }
                    else
                    {
                        var toInput = createNewRank(albumsChosen[0], userId);
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
                albumRank1 = albumRanks[indexOfAlbum1Rank],
                albumRank2 = albumRanks[indexOfAlbum2Rank],
                userId = userId,
                album1path = getAlbumCoverPath(album1Id),
                album2path = getAlbumCoverPath(album2Id)
            };
            return albumRankerViewModel;
        }

        public UserAlbumRank createNewRank(Album album, string userId)
        {
            var rank = new UserAlbumRank()
            {
                rank = 500,
                userId = userId,
                albumId = album.albumId,
                timesSeen = 0,
                knowAlbum = true
            };
            return rank;
        }

        public String getAlbumCoverPath(int albumId)
        {
            var albumCoverPath = "";
            var albumCoverExists = _context.albumCovers.Any(x => x.albumId == albumId && x.active == true);
            if (albumCoverExists)
            {
                var albumCover = _context.albumCovers.Single(x => x.albumId == albumId && x.active == true);
                albumCoverPath = "/Images/Albums/" + albumCover.albumCoverId;
            }
            return albumCoverPath;
        }
    }
}