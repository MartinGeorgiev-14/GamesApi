using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Web.Models.Users
{
    public class LoginUserModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
