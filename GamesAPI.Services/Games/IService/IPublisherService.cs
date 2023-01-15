using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPI.Services.Games.IService
{
    public interface IPublisherService
    {
        Task<bool> ExistsAsync(int id);

        T? GetPlatform<T>(int id);

        int Create<T>(T model);

        void Update<T>(int id, T model);

        Task Delete(int id);
    }
}
