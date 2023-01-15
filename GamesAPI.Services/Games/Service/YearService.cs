using AutoMapper;
using GamesAPI.Data.Models;
using GamesAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using GamesAPI.Services.Games.IService;

namespace GamesAPI.Services.Games.Service
{
    public class YearService : IYearService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public YearService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public int Create<T>(T model)
        {
            var datamodel = mapper.Map<YearModel>(model);

            dbContext.YearModels.Add(datamodel);
            dbContext.SaveChanges();

            return datamodel.Id;
        }

        public async Task Delete(int id)
        {
            var dataModel = new YearModel
            {
                Id = id,
            };



            dbContext.YearModels.Remove(dataModel);
            await dbContext.SaveChangesAsync();
        }

        public void Update<T>(int id, T model)
        {
            var dataModel = mapper.Map<YearModel>(model);
            dataModel.Id = id;



            dbContext.YearModels.Update(dataModel);
            dbContext.SaveChanges();
        }

        public T? GetYear<T>(int id)
        {
            var game = dbContext.YearModels.Where(x => x.Id == id)
                .ProjectTo<T>(mapper.ConfigurationProvider)
                .FirstOrDefault();


            return game;
        }




        public async Task<bool> ExistsAsync(int id)
        {
            return await dbContext.YearModels.AnyAsync(x => x.Id == id);
        }
    }
}
