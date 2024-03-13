using AutoMapper;
using BatBetDomain.DTOs.Request;
using BatBetDomain.DTOs.Response;
using BatBetDomain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BatBetDomain.Controllers
{
    [ApiController]
    [Route("bets")]
    public class BetsController(IMapper mapper, IBetsService betsService) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
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
        public async Task<IActionResult> CreateBet(PlaceBetDto bet, int userId)
        {
            BetDto placedBet = await _betsService.CreateBet(bet, userId);

            return CreatedAtAction(nameof(GetBetById),
                new { placedBet.Id },
                _mapper.Map<PlaceBetDto>(bet));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBet(int id)
        {
            bool result = await _betsService.UpdateBet(id);

            if (result) return NoContent();

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