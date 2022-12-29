using GamesAPI.Data.Models;

namespace GamesAPI.Web.Models.View
{
    public class PublisherViewModel
    {
        public int Id { get; set; }
        public string Publisher { get; set; }


        public virtual ICollection<GamesModel> GamesModels { get; set; }
    }
}
