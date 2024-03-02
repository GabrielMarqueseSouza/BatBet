using BatBetService.DTOs.Response;
using BatBetService.Entities;
using BatBetService.Interfaces.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BatBetService.Interfaces.Repositories
{
    public interface IBetsRepository : IRepositoryBase<Bet>
    {
        Task<IQueryable<Bet>> GetBets();
        Task<BetDto> GetBetById(int id);
        Task<bool> UpdateBet(int id);
    }
}
