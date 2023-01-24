using GamesAPI.Services.Games.IService;
using GamesAPI.Web.Models.Input;
using GamesAPI.Web.Models.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        [HttpGet("{id}")]

        public IActionResult Get([FromRoute] int id)
        {
            var model = this.publisherService.Get<PublisherViewModel>(id);


            if (model == null)
            {
                return this.NotFound();
            }

            return this.Ok(model);
        }

        [HttpPost]

        public IActionResult Create(PublisherInputModel model)
        {
            var id = this.publisherService.Create(model);
            return this.Ok("id = " + id);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, PublisherInputModel model)
        {
            bool exists = this.publisherService.ExistsAsync(id).Result;

            if (!exists)
            {
                return this.NotFound();
            }

            this.publisherService.Update(id, model);

            return this.Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            bool exist = this.publisherService.ExistsAsync(id).Result;

            if (!exist)
            {
                return this.NotFound();
            }

            await this.publisherService.Delete(id);

            return this.Ok();
        }
    }
}
