using GamesApi.Common;
using GamesAPI.Data.RolesModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Services.Seeding
{
    public class RoleSeeder : IRoleSeeder
    {
        private readonly RoleManager<ApplicationRole> roleManeger;

        public RoleSeeder(RoleManager<ApplicationRole> roleManeger)
        {
            this.roleManeger = roleManeger;
        }

        public async Task SeedAsync()
        {
            await this.roleManeger.CreateAsync(new ApplicationRole
            {
                Name = ApplicationRoles.User
            });

            await this.roleManeger.CreateAsync(new ApplicationRole
            {
                Name = ApplicationRoles.Admin
            });

        }
    }
}
