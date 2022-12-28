using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Data.Models
{
    internal class GamesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal NA_Sales { get; set; }
        public decimal EU_Sales { get; set; }
        public decimal JP_Sales { get; set; }
        public decimal Other_Sales { get; set; }


        public List<GenreModel> GenreModels { get; set; }
        public List<PlatformModel> PlatformModels { get; set; }
        public List<PublisherModel> PublisherModels { get; set; }
        public List<YearModel> YearModels { get; set; }
    }
}
