namespace GamesAPI.Web.Models
{
    public class YearModel
    {
        public int Id { get; set; }
        public int Year { get; set; }

        public List<ViewGamesModel> viewGamesModels { get; set; }
    }
}
