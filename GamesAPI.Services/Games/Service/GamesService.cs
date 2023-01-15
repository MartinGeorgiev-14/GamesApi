using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GamesAPI.Data;
using GamesAPI.Data.Models;
using GamesAPI.Services.Games.IService;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Services.Games.Service
{
    public class GamesService : IGamesService
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GamesService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public int Create<T>(T model)
        {
            var datamodel = mapper.Map<GamesModel>(model);

            dbContext.GamesModels.Add(datamodel);
            dbContext.SaveChanges();

            return datamodel.Id;
        }

        public async Task Delete(int id)
        {
            var dataModel = new GamesModel
            {
                Id = id,
            };



            dbContext.GamesModels.Remove(dataModel);
            await dbContext.SaveChangesAsync();
        }

        public void Update<T>(int id, T model)
        {
            var dataModel = mapper.Map<GamesModel>(model);
            dataModel.Id = id;



            dbContext.GamesModels.Update(dataModel);
            dbContext.SaveChanges();
        }

        public T? GetGames<T>(int id)
        {
            var game = dbContext.GamesModels.Where(x => x.Id == id)
                .ProjectTo<T>(mapper.ConfigurationProvider)
                .FirstOrDefault();


            return game;
        }


        public IEnumerable<T> GetPage<T>(int page, int perPage)
        {
            return dbContext.GamesModels
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ProjectTo<T>(mapper.ConfigurationProvider)
                .ToArray();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await dbContext.GamesModels.AnyAsync(x => x.Id == id);
        }


    }
}

