using GamesAPI.Services.Games.IService;
using GamesAPI.Web.Models.Input;
using GamesAPI.Web.Models.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace GamesAPI.Web.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService gamesService;
        private readonly IPlatformService platformService;

        public GamesController(IGamesService gamesService, IPlatformService platformService)
        {
            this.gamesService = gamesService;
            this.platformService = platformService;
        }

        [HttpGet("Game/{id}")]
        public IActionResult GetId([FromRoute] int id) 
        {
            var model = this.gamesService.Get<GamesViewModel>(id);


            if (model == null)
            {
                return this.NotFound();
            }

            return this.Ok(model);
        }

        [HttpPost("Game")]

        public IActionResult Create(GamesInputModel model)
        {
            var id = this.gamesService.Create(model);
            return this.Ok(id);
        }

        [HttpPut("Game/{id}")]

        public IActionResult Update(int id, GamesInputModel model)
        {
            bool exists = this.gamesService.ExistsAsync(id).Result;

            if (!exists)
            {
                return this.NotFound();
            }

            this.gamesService.Update(id, model);

            return this.Ok();
        }

        [HttpDelete("Game/{id}")]

        public async Task<IActionResult> Delete(int id) 
        {
            bool exist = this.gamesService.ExistsAsync(id).Result;

            if (!exist)
            {
                return this.NotFound();
            }

            await this.gamesService.Delete(id);

            return this.Ok();
        }



       
    }
}
