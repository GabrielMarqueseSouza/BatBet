using BatBetDomain.Entities;
using BatBetDomain.Interfaces.Common;
using System.Threading.Tasks;

namespace BatBetDomain.Interfaces.Repositories
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        Task<Game> GetGameById(int id);
    }
}
