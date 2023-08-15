using Artister.API.Entities;
using Artister.API.Models.Artist;
using Artister.API.Models.Genre;
using Artister.API.Models.Notification;
using Artister.API.Models.Subgenre;
using Artister.API.Models.User;
using AutoMapper;

namespace Artister.API.Configs
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateArtistMap();
            CreateGenreMap();
            CreateNotificationMap();
            CreateSubgenreMap();
            CreateUserMap();
        }
        private void CreateArtistMap()
        {
            CreateMap<Artist, ArtistDto>();
            CreateMap<CreatArtistDto, Artist>();
        }
        private void CreateGenreMap()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<CreateGenreDto, Genre>();
        }
        private void CreateNotificationMap() 
        {
            CreateMap<Notification,NotificationDto>();
            CreateMap<CreateNotificationDto, Notification>();
        }
        private void CreateSubgenreMap()
        {
            CreateMap<Subgenre, SubgenreDto>();
            CreateMap<CreateSubgenreDto, Subgenre>();
        }
        private void CreateUserMap()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
        }
    }
}
