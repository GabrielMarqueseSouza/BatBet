using BatBetDomain.DTOs.Request;
using BatBetDomain.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatBetDomain.Interfaces.Services
{
    public interface IBetsService
    {
        Task<IList<BetDto>> GetBets(string date);
        Task<BetDto> GetBetById(int id);
        Task<BetDto> CreateBet(PlaceBetDto bet, int userId);
        Task<int> UpdateBet(int id);
        Task<bool> DeleteBet(int id);
    }
}
