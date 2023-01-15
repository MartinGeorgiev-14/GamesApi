using GamesAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Web.Models.Input
{
    public class GenreInputModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Exceeding the limits", MinimumLength = 1)]
        public string Genre { get; set; }


    }
}
