using BatBetService.DTOs.Response;
using BatBetService.Entities;
using BatBetService.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatBetService.Interfaces.Repositories
{
    public interface IBetsRepository : IRepositoryBase<Bet>
    {
        Task<IList<Bet>> GetBets(string date);
        Task<BetDto> GetBetById(int id);
        Task<bool> UpdateBet(int id);
    }
}
