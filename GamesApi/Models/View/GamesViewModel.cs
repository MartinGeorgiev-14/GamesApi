using GamesAPI.Data.Models;

namespace GamesAPI.Web.Models.View
{
    public class GamesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal NA_Sales { get; set; }
        public decimal EU_Sales { get; set; }
        public decimal JP_Sales { get; set; }
        public decimal Other_Sales { get; set; }

        public virtual YearModel Year { get; set; }
        public virtual GenreModel GenreModel { get; set; }
        public virtual PublisherModel PublisherModel { get; set; }

    }
}
