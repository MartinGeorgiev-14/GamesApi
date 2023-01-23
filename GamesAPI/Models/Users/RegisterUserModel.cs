using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Web.Models.Users
{
    public class RegisterUserModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
