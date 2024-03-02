using BatBetService.DTOs.Request;
using BatBetService.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatBetService.Interfaces.Services
{
    public interface IBetsService
    {
        Task<IList<BetDto>> GetBets(string date);
        Task<BetDto> GetBetById(int id);
        Task<BetDto> CreateBet(PlaceBetDto bet, int userId);
        Task<bool> UpdateBet(int id);
        Task<bool> DeleteBet(int id);
    }
}
