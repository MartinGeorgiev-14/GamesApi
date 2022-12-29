using GamesAPI.Data.Models;

namespace GamesAPI.Web.Models.View
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<GamesModel> GamesModels { get; set; }
    }
}
