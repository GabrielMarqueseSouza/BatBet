using AutoMapper;
using BatBetDomain.Entities;
using BatBetDomain.Interfaces.Repositories;
using BatBetInfrastructure.Data;
using BatBetInfrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BatBetInfrastructure.Repositories
{
    public class GameRepository(BatBetDbContext context, IMapper mapper) : RepositoryBase<Game>(context), IGameRepository
    {
        protected readonly IMapper _mapper = mapper;

        public async Task<Game> GetGameById(int id)
        {
            return await _context.Games
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
