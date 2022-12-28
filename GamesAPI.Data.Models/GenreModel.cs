using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Data.Models
{
    internal class GenreModel
    {
        public int Id { get; set; }
        public string Genre { get; set; }

        public GamesModel GamesModel { get; set; }
        public int GamesModelId { get; set; }
    }
}
