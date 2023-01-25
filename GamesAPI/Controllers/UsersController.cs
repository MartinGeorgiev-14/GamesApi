using GamesAPI.Services.Authorization;
using GamesAPI.Web.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPI.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthorizationService authorizationService;

        public UsersController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            var registerResult = await this.authorizationService.RegisterUserAsync(model.UserName, model.Password);

            return this.Ok(registerResult);
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(RegisterUserModel model)
        {
            var registeredResult = await this.authorizationService.RegisterAdminAsync(model.UserName, model.Password);

            return this.Ok(registeredResult);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserModel model)
        {
            var token = await this.authorizationService.LoginAsync(model.UserName, model.Password);

            if (token == null)
            {
                return this.Unauthorized();
            }

            return this.Ok(token);
        }




    }
}
