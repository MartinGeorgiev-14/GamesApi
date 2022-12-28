
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GamesAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace GamesAPI.Data
{


    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<GamesModel> GamesModels { get; set; }
        public DbSet<PlatformModel> PlatformModels { get; set; }
        public DbSet<GamesPlatformMTM> GamesPlatformMTMs { get; set; }
        public DbSet<GenreModel> GenreModels { get; set; }
        public DbSet<PublisherModel> PublisherModels { get; set; }
        public DbSet<YearModel> YearModels { get; set; }
    }
}
