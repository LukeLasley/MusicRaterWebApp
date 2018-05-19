using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MusicRaterWebApp.Models;
using MusicRaterWebApp.Dtos;

namespace MusicRaterWebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Album, AlbumDto>();
            Mapper.CreateMap<AlbumDto, Album>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>();
            Mapper.CreateMap<UserAlbumRank, UserAlbumRankDto>();
            Mapper.CreateMap<UserAlbumRankDto, UserAlbumRank>();
        }
    }
}