﻿using GamesAPI.Data.RolesModels;
using GamesApi.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace GamesAPI.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AuthorizationService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<IdentityResult?> RegisterUserAsync(string username, string password)
        {
            var user = new ApplicationUser
            {
                UserName = username,
            };

            var result = await this.userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return result;
            }

            await this.userManager.AddToRoleAsync(user, ApplicationRoles.User);

            return result;
        }

        public async Task<IdentityResult?> RegisterAdminAsync(string username, string password)
        {
            var admin = new ApplicationUser
            {
                UserName = username,
            };

            var result = await this.userManager.CreateAsync(admin, password);

            if (!result.Succeeded)
            {
                return result;
            }

            await this.userManager.AddToRoleAsync(admin, ApplicationRoles.Admin);

            return result;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null || !await this.userManager.CheckPasswordAsync(user, password))
            {
                return null;
            }

            var role = await this.userManager.GetRolesAsync(user);
            IdentityOptions options = new IdentityOptions();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim("UserName", user.UserName!),
                        new Claim(options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault()!)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JWTSecret"])), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
