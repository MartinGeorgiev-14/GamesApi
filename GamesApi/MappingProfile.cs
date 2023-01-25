using AutoMapper;
using GamesAPI.Data.Models;
using GamesAPI.Web.Models.Input;
using GamesAPI.Web.Models.View;

namespace GamesAPI.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<GamesModel, GamesViewModel>();
            this.CreateMap<GamesInputModel, GamesModel>();

            this.CreateMap<GamesModel, GenreViewModel>();
            this.CreateMap<GenreInputModel, GamesModel>();

            this.CreateMap<GenreModel, GenreViewModel>();
            this.CreateMap<GenreInputModel, GenreModel>();

            this.CreateMap<PlatformModel, PlatformViewModel>();
            this.CreateMap<PlatformInputModel, PlatformModel>();

            this.CreateMap<PublisherModel, PublisherViewModel>();
            this.CreateMap<PublisherInputModel, PublisherModel>();


        }
    }
}
