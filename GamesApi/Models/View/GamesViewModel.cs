using GamesAPI.Data.Models;

namespace GamesAPI.Web.Models.View
{
    public class GamesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }
        public virtual GenreModel GenreModel { get; set; }
        public virtual PublisherModel PublisherModel { get; set; }
        public virtual PlatformModel PlatformModel { get; set; }
        public double NA_Sales { get; set; }
        public double EU_Sales { get; set; }
        public double JP_Sales { get; set; }
        public double Other_Sales { get; set; }



    }
}
