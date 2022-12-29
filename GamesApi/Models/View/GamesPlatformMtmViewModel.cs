using GamesAPI.Data.Models;

namespace GamesAPI.Web.Models.View
{
    public class GamesPlatformMtmViewModel
    {
        public int Id { get; set; }

        //public int GameId { get; set; }
        public GamesModel GamesModel { get; set; }

        //public int PlatformId { get; set; }
        public PlatformModel PlatformModel { get; set; }
    }
}
