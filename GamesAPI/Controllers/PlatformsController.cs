using GamesAPI.Services.Games.IService;
using GamesAPI.Web.Models.Input;
using GamesAPI.Web.Models.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService platformService;

        public PlatformsController(IPlatformService platformService)
        {
            this.platformService = platformService;
        }

        [HttpGet("{id}")]

        public IActionResult GetId([FromRoute] int id)
        {
            var model = this.platformService.Get<PlatformViewModel>(id);


            if (model == null)
            {
                return this.NotFound();
            }

            return this.Ok(model);
        }

        [HttpPost]

        public IActionResult Create(PlatformInputModel model)
        {
            var id = this.platformService.Create(model);
            return this.Ok("id = " + id);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, PlatformInputModel model)
        {
            bool exists = this.platformService.ExistsAsync(id).Result;

            if (!exists)
            {
                return this.NotFound();
            }

            this.platformService.Update(id, model);

            return this.Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            bool exist = this.platformService.ExistsAsync(id).Result;

            if (!exist)
            {
                return this.NotFound();
            }

            await this.platformService.Delete(id);

            return this.Ok();
        }
    }
}
