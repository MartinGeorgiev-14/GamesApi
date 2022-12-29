using GamesAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Web.Models.Input
{
    public class GamesPlatformMtmInputModel
    {
        //public int GameId { get; set; }
        [Required]
        public GamesModel GamesModel { get; set; }

        //public int PlatformId { get; set; }
        [Required]
        public PlatformModel PlatformModel { get; set; }
    }
}
