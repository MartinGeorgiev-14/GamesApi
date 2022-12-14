using GamesAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Web.Models.Input
{
    public class GamesInputModel
    {
        [Required]
        [StringLength(50,ErrorMessage = "Exceeding the limits", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage ="Error")]
        public decimal NA_Sales { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Error")]
        public decimal EU_Sales { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Error")]
        public decimal JP_Sales { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Error")]
        public decimal Other_Sales { get; set; }

        [Required]
        public virtual YearModel Year { get; set; }
        [Required]
        public virtual GenreModel GenreModel { get; set; }
        [Required]
        public virtual PublisherModel PublisherModel { get; set; }
    }
}
