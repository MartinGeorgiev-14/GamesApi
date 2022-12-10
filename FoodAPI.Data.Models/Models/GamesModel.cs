using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAPI.Data.Models.Models
{
    internal class GamesModel
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
