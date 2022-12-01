namespace GamesAPI.Web.Models.RelationShips
{
    public class Games_Platform_MTM
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        public ViewGamesModel ViewGamesModel { get; set; }

        public int PlatformId { get; set; }
        public PlatformModel PlatformModel { get; set; }
    }
}
