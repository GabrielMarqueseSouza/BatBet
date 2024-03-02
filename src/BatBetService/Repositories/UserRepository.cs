using AutoMapper;
using BatBetService.Data;
using BatBetService.Entities;
using BatBetService.Interfaces.Repositories;
using BatBetService.Repositories.Common;

namespace BatBetService.Repositories
{
    public class UserRepository(BatBetDbContext context, IMapper mapper) : RepositoryBase<User>(context), IUserRepository
    {
        protected readonly IMapper _mapper = mapper;
    }
}
