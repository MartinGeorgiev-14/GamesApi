﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Services.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync();
    }
}
