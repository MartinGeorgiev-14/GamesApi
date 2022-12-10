using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAPI.Data.Models.Models.MTMRelationships
{
    internal class GamesPlatformMTM
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        public GamesModel GamesModel { get; set; }

        public int PlatformId { get; set; }
        public PlatformModel PlatformModel { get; set; }
    }
}
