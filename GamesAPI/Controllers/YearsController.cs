using GamesAPI.Services.Games.IService;
using GamesAPI.Web.Models.Input;
using GamesAPI.Web.Models.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearsController : ControllerBase
    {
        private readonly IYearService yearService;

        public YearsController(IYearService yearService)
        {
            this.yearService = yearService;
        }

        [HttpGet("{id}")]

        public IActionResult Get([FromRoute] int id)
        {
            var model = this.yearService.Get<YearViewModel>(id);


            if (model == null)
            {
                return this.NotFound();
            }

            return this.Ok(model);
        }

        [HttpPost]

        public IActionResult Create(YearInputModel model)
        {
            var id = this.yearService.Create(model);
            return this.Ok("id = " + id);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, YearInputModel model)
        {
            bool exists = this.yearService.ExistsAsync(id).Result;

            if (!exists)
            {
                return this.NotFound();
            }

            this.yearService.Update(id, model);

            return this.Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            bool exist = this.yearService.ExistsAsync(id).Result;

            if (!exist)
            {
                return this.NotFound();
            }

            await this.yearService.Delete(id);

            return this.Ok();
        }
    }
}
