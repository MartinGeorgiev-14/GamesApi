using CsvHelper.Configuration;
using GamesAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Services.Seeding.Models
{
    public class GameCSVMap : ClassMap<GameCSVModel>
    {
        public GameCSVMap()
        {
            Map(x => x.Year).Convert(x => x.Row.GetField("Year") == "N/A" ? 2020 : int.Parse(x.Row.GetField("Year")));

            Map(m => m.Name).Name("Name");
            Map(m => m.Publisher).Name("Publisher");
            Map(m => m.Genre).Name("Genre");
            Map(m => m.EU_Sales).Name("EU_Sales").Default(0, true);
            Map(m => m.JP_Sales).Name("JP_Sales").Default(0, true);
            Map(m => m.NA_Sales).Name("NA_Sales").Default(0, true);
            Map(m => m.Other_Sales).Name("Other_Sales").Default(0, true);
            Map(m => m.Platform).Name("Platform");
        }
    }
}
