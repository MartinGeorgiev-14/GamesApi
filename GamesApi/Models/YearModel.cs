namespace GamesAPI.Web.Models
{
    public class YearModel
    {
        public int Id { get; set; }
        public int Year { get; set; }

        public ICollection<ViewGamesModel> ViewGames { get; set; }
    }
}
