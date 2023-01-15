using GamesAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Web.Models.Input
{
    public class YearInputModel
    {
        [Required]
        [Range(0, 3000, ErrorMessage = "Error")]
        public int Year { get; set; }


    }
}
