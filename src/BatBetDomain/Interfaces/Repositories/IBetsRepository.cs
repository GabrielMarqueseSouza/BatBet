using BatBetDomain.DTOs.Response;
using BatBetDomain.Entities;
using BatBetDomain.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatBetDomain.Interfaces.Repositories
{
    public interface IBetsRepository : IRepositoryBase<Bet>
    {
        Task<IList<Bet>> GetBets(string date);
        Task<BetDto> GetBetById(int id);
        Task<bool> UpdateBet(int id);
    }
}
