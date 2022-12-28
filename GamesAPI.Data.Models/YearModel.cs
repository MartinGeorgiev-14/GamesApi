using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Data.Models
{
    internal class YearModel
    {
        public int Id { get; set; }
        public int Year { get; set; }


        public GamesModel GamesModel { get; set; }
        public int GamesModelId { get; set; }
    }
}
