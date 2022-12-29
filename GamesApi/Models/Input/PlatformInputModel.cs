using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Web.Models.Input
{
    public class PlatformInputModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Exceeding the limits", MinimumLength = 1)]
        public string Platform { get; set; }
    }
}
