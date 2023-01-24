//using GamesAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Services.Games.IService
{
    public interface IGamesService
    {
        Task<bool> ExistsAsync(int id);

        T? Get<T>(int id);

        int Create<T>(T model);

        void Update<T>(int id, T model);

        Task Delete(int id);
    }
}
