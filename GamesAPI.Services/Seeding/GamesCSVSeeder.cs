using CsvHelper;
using GamesAPI.Data;
using GamesAPI.Data.Models;
using GamesAPI.Services.Models;
using GamesAPI.Services.Seeding.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Services.Seeding
{
    public class GamesCSVSeeder : IGamesCSVSeeder
    {
        private const string CsvPath = "D:\\C#\\GamesApi\\GamesAPI.Services\\vgsales.csv";
        private readonly Dictionary<string, GenreModel> genres = new();
        private readonly Dictionary<string, PublisherModel> publishers = new();
        private readonly Dictionary<string, PlatformModel> platforms = new();
        private readonly ApplicationDbContext applicationDbContext;

        public GamesCSVSeeder(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        public async Task SeedAsync()
        {
            if (this.applicationDbContext.GamesModels.Any())
            {
                return;
            }

            using var reader = new StreamReader(CsvPath);
            
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<GameCSVMap>();
                
                var games = csv.GetRecords<GameCSVModel>();

            foreach (var game in games)
            {
                if (game.Genre == null || game.Publisher == null || game.Platform == null)
                {
                    continue;
                }

                if (!this.genres.ContainsKey(game.Genre))
                {
                    this.genres.Add(game.Genre, new GenreModel
                    {
                        Genre = game.Genre,
                    });

                }
                if (!this.platforms.ContainsKey(game.Platform))
                {
                    this.platforms.Add(game.Platform, new PlatformModel
                    {
                        Platform = game.Platform,
                    });

                }
                if (!this.publishers.ContainsKey(game.Publisher))
                {
                    this.publishers.Add(game.Publisher, new PublisherModel
                    {
                        Publisher = game.Publisher,
                    });
                }
                this.applicationDbContext.GamesModels.Add(new Data.Models.GamesModel
                {
                    Name = game.Name,
                    Year = game.Year,
                    EU_Sales = game.EU_Sales,
                    JP_Sales = game.JP_Sales,
                    NA_Sales = game.NA_Sales,
                    Other_Sales = game.Other_Sales,
                    GenreModel = this.genres[game.Genre],
                    PublisherModel = this.publishers[game.Publisher],
                    PlatformModel = this.platforms[game.Platform],
                    
                });
            }

            await this.applicationDbContext.SaveChangesAsync();
        }
    }
}
