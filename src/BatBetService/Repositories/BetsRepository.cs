using AutoMapper;
using BatBetService.Data;
using BatBetService.DTOs.Response;
using BatBetService.Entities;
using BatBetService.Interfaces.Repositories;
using BatBetService.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatBetService.Repositories
{
    public class BetsRepository(BatBetDbContext context, IMapper mapper) : RepositoryBase<Bet>(context), IBetsRepository
    {
        protected readonly IMapper _mapper = mapper;

        public async Task<IList<Bet>> GetBets(string date)
        {
            IQueryable<Bet> query = _context.Bets;

            if (!string.IsNullOrEmpty(date))
            {
                DateTime parsedDate = DateTime.Parse(date).ToUniversalTime();
                query = query.Where(x => x.CreatedAt.CompareTo(parsedDate) > 0);
            }

            return await query
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<BetDto> GetBetById(int id)
        {
            Bet bet = await _context.Bets
                             .Include(x => x.User)
                             .Include(x => x.Game)
                             .FirstOrDefaultAsync(x => x.Id == id);

            return bet == null ? throw new Exception("Bet not found.") : _mapper.Map<BetDto>(bet);
        }

        public async Task<bool> UpdateBet(int id)
        {
            Bet bet = await _context.Bets
                .Where(x => x.Status == Status.Active)
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Bet not found.");

            bet.UpdatedAt = DateTime.UtcNow;
            bet.Status = Status.Finished;

            bool result = await CommitChanges() > 0;

            return result;
        }
    }
}
