namespace GamesAPI.Web.Models
{
    public class ViewGamesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal NA_Sales { get; set; }
        public decimal EU_Sales { get; set; }
        public decimal JP_Sales { get; set; }
        public decimal Other_Sales { get; set; }
        

        public int YearId { get; set; }
        public YearModel YearModel { get; set; }
    }
}
