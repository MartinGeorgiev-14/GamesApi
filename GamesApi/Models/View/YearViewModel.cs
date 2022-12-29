using GamesAPI.Data.Models;

namespace GamesAPI.Web.Models.View
{
    public class YearViewModel
    {
        public int Id { get; set; }
        public int Year { get; set; }


        public virtual ICollection<GamesModel> GamesModels { get; set; }
    }
}
