using AutoMapper;
using AutoMapper.QueryableExtensions;
using BatBetService.Data;
using BatBetService.DTOs.Request;
using BatBetService.DTOs.Response;
using BatBetService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatBetService.Controllers
{
    [ApiController]
    [Route("bets")]
    public class BetsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BatBetDbContext _dbContext;
        public BetsController(IMapper mapper, BatBetDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBets(string date)
        {
            IQueryable<Bet> query = _dbContext.Bets
                        .OrderBy(x => x.CreatedAt)
                        .AsQueryable();

            if (!string.IsNullOrEmpty(date))
            {
                query = query
                        .Where(x => x.CreatedAt
                        .CompareTo(DateTime.Parse(date)
                        .ToUniversalTime()) > 0);
            }

            List<BetDto> response = await query.ProjectTo<BetDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Ok(response);
        }    

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBetById(int id)
        {
            var bet = await _dbContext.Bets
                            .Include(x => x.User)
                            .Include(x => x.Game)
                            .FirstOrDefaultAsync(x => x.Id == id);

            if (bet == null) return NotFound();

            return Ok(_mapper.Map<BetDto>(bet));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBet(PlaceBetDto bet, int userId)
        {
            User user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId);

            //create a logic to subtract the bet amount from the user balance
            //and, if the balance is lower than the bet amount, block the user from finishing the bet

            if (user == null)
            {
                return NotFound("User not found");
            }

            Bet placedBet = _mapper.Map<Bet>(bet);

            placedBet.PlatformFee = 0.10;
            placedBet.UserId = userId;

            await _dbContext.AddAsync(placedBet);

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBetById),
                new { placedBet.Id },
                _mapper.Map<PlaceBetDto>(bet));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBet(int id)
        {
            var bet = await _dbContext.Bets
                .Where(x => x.Status == Status.Active)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (bet == null) return NotFound();

            bet.UpdatedAt = DateTime.UtcNow;
            bet.Status = Status.Finished;

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (result) return NoContent();

            return BadRequest("Problem saving changes");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBet(int id)
        {
            Bet bet = await _dbContext.Bets.FindAsync(id);

            if (bet == null) return NotFound();

            _dbContext.Remove(bet);

            bool result = await _dbContext.SaveChangesAsync() > 0;

            if (result) return NoContent();

            return BadRequest("Problem deleting bet");
        }
    }
}
