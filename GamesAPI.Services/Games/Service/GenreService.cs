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
    public class GenreService : IGenreService
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GenreService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public int Create<T>(T model)
        {
            var datamodel = mapper.Map<GenreModel>(model);

            dbContext.GenreModels.Add(datamodel);
            dbContext.SaveChanges();

            return datamodel.Id;
        }

        public async Task Delete(int id)
        {
            var dataModel = new GenreModel
            {
                Id = id,
            };


            dbContext.GenreModels.Remove(dataModel);
            await dbContext.SaveChangesAsync();
        }

        public void Update<T>(int id, T model)
        {
            var dataModel = mapper.Map<GenreModel>(model);
            dataModel.Id = id;

            dbContext.GenreModels.Update(dataModel);
            dbContext.SaveChanges();
        }

        public T? GetGenres<T>(int id)
        {
            var genre = dbContext.GenreModels.Where(x => x.Id == id)
                .ProjectTo<T>(mapper.ConfigurationProvider)
                .FirstOrDefault();


            return genre;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await dbContext.GamesModels.AnyAsync(x => x.Id == id);
        }


    }
}

