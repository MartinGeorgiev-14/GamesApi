using GamesAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Web.Models.Input
{
    public class PublisherInputModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Exceeding the limits", MinimumLength = 1)]
        public string Publisher { get; set; }



    }
}
