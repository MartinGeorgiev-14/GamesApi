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

            this.CreateMap<GamesPlatformMTM, GamesPlatformMtmViewModel>();
            this.CreateMap<GamesPlatformMtmInputModel, GamesPlatformMTM>();

            this.CreateMap<GenreModel, GenreViewModel>();
            this.CreateMap<GenreInputModel, GenreModel>();

            this.CreateMap<PlatformModel, PlatformViewModel>();
            this.CreateMap<PlatformInputModel, PlatformModel>();

            this.CreateMap<PublisherModel, PublisherViewModel>();
            this.CreateMap<PublisherInputModel, PublisherModel>();

            this.CreateMap<YearModel, YearViewModel>();
            this.CreateMap<YearInputModel, YearModel>();
        }
    }
}
