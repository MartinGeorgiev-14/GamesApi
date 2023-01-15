using AutoMapper;
using AutoMapper.QueryableExtensions;
using GamesAPI.Data;
using GamesAPI.Data.Models;
using GamesAPI.Services.Games.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Services.Games.Service
{
    public class GamesPlatformMTMService : IGamesPlatformMTMService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GamesPlatformMTMService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public int Create<T>(T model)
        {
            var datamodel = mapper.Map<GamesPlatformMTM>(model);

            dbContext.GamesPlatformMTMs.Add(datamodel);
            dbContext.SaveChanges();

            return datamodel.Id;
        }

        public async Task Delete(int id)
        {
            var dataModel = new GamesPlatformMTM
            {
                Id = id,
            };



            dbContext.GamesPlatformMTMs.Remove(dataModel);
            await dbContext.SaveChangesAsync();
        }

        public void Update<T>(int id, T model)
        {
            var dataModel = mapper.Map<GamesPlatformMTM>(model);
            dataModel.Id = id;



            dbContext.GamesPlatformMTMs.Update(dataModel);
            dbContext.SaveChanges();
        }

        public T? Get<T>(int id)
        {
            var game = dbContext.GamesPlatformMTMs.Where(x => x.Id == id)
                .ProjectTo<T>(mapper.ConfigurationProvider)
                .FirstOrDefault();


            return game;
        }



        public async Task<bool> ExistsAsync(int id)
        {
            return await dbContext.GamesPlatformMTMs.AnyAsync(x => x.Id == id);
        }
    }
}
