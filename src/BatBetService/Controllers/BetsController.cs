using BatBetDomain.DTOs.Request;
using BatBetDomain.DTOs.Response;
using BatBetDomain.Interfaces.Services;
using BatBetServiceAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBet(PlaceBetDto betDto)
        {
            BetDto placedBet = await _betsService
                    .CreateBet(betDto, User.GetUserId(), User.GetUserClaims());

            return CreatedAtAction(nameof(GetBetById),
                new { placedBet.Id }, placedBet);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBet(int id)
        {
            //TODO: change this validation after configuring the identity user table and removing the current User table
            if (string.IsNullOrEmpty(User.Identity.Name)) return Forbid();

            int result = await _betsService.UpdateBet(id);

            if (result != 0) return Ok($"Updated bet id: {result}");

            return BadRequest("Problem saving changes");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBet(int id)
        {
            //TODO: change this validation after configuring the identity user table and removing the current User table
            if (string.IsNullOrEmpty(User.Identity.Name)) return Forbid();

            bool result = await _betsService.DeleteBet(id);

            if (result) return NoContent();

            return BadRequest("Problem deleting bet");
        }
    }
}