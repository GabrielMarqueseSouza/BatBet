using BatBetDomain.DTOs.Request;
using BatBetDomain.DTOs.Response;
using BatBetDomain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BatBetDomain.Controllers
{
    [ApiController]
    [Route("bets")]
    public class BetsController(IBetsService betsService) : ControllerBase
    {
        private readonly IBetsService _betsService = betsService;

        [HttpGet]
        public async Task<IActionResult> GetBets(string date)
        {
            return Ok(await _betsService.GetBets(date));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBetById(int id)
        {
            return Ok(await _betsService.GetBetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBet(PlaceBetDto betDto, int userId)
        {
            BetDto placedBet = await _betsService.CreateBet(betDto, userId);

            return CreatedAtAction(nameof(GetBetById),
                new { placedBet.Id }, placedBet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBet(int id)
        {
            int result = await _betsService.UpdateBet(id);

            if (result != 0) return Ok($"Updated bet id: {result}");

            return BadRequest("Problem saving changes");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBet(int id)
        {
            bool result = await _betsService.DeleteBet(id);

            if (result) return NoContent();

            return BadRequest("Problem deleting bet");
        }
    }
}