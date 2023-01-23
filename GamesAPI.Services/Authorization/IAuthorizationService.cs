using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Services.Authorization
{
    public interface IAuthorizationService
    {
        Task<IdentityResult> RegisterUserAsync(string username, string password);

        Task<string> LoginAsync(string username, string password);
    }
}
