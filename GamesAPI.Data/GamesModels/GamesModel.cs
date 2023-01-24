using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Data.Models
{
    public class GamesModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public virtual YearModel Year { get; set; }
        public virtual GenreModel GenreModel { get; set; }
        public virtual PublisherModel PublisherModel { get; set; }

        public double NA_Sales { get; set; }
        public double EU_Sales { get; set; }
        public double JP_Sales { get; set; }
        public double Other_Sales { get; set; }



   
    }
}
