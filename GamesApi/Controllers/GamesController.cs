using GamesAPI.Services.Games.IService;
using GamesAPI.Web.Models.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace GamesAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService gamesService;
        private readonly IGamesPlatformMTMService gamesPlatformMTMService;

        public GamesController(IGamesService gamesService, IGamesPlatformMTMService gamesPlatformMTMService)
        {
            this.gamesService = gamesService;
            this.gamesPlatformMTMService = gamesPlatformMTMService;
        }

        [HttpGet("{id}")]
        public IActionResult GetGameId([FromRoute] int id) 
        {
            var model = this.gamesService.GetGames<GamesViewModel>(id);


            if (model == null)
            {
                return this.NotFound();
            }

            return this.Ok(model);
        }

        [HttpGet("asd")]
        public IActionResult Get([FromRoute] int id)
        {
            var model = this.gamesPlatformMTMService.Get<GamesPlatformMtmViewModel>(id);


            if (model == null)
            {
                return this.NotFound();
            }

            return this.Ok(model);
        }

    }
}
