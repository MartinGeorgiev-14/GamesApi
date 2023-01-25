using GamesApi.Common;
using GamesAPI.Services.Games.IService;
using GamesAPI.Web.Models.Input;
using GamesAPI.Web.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GamesAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
       private readonly IGenreService genreService;

       public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;   
        }

        [HttpGet("{id}")]

        public IActionResult GetId([FromRoute] int id)
        {
            var model = this.genreService.Get<GenreViewModel>(id);


            if (model == null)
            {
                return this.NotFound();
            }

            return this.Ok(model);
        }

        [HttpPost]
        [Authorize(Roles = ApplicationRoles.Admin)]
        public IActionResult Create(GenreInputModel model)
        {
            var id = this.genreService.Create(model);
            return this.Ok("id = " + id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = ApplicationRoles.Admin)]
        public IActionResult Update(int id, GenreInputModel model)
        {
            bool exists = this.genreService.ExistsAsync(id).Result;

            if (!exists)
            {
                return this.NotFound();
            }

            this.genreService.Update(id, model);

            return this.Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ApplicationRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            bool exist = this.genreService.ExistsAsync(id).Result;

            if (!exist)
            {
                return this.NotFound();
            }

            await this.genreService.Delete(id);

            return this.Ok();
        }

    }
}
