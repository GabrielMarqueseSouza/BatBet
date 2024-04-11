using AutoMapper;
using BatBetInfrastructure.Data;
using BatBetInfrastructure.Repositories.Common;
using BatBetDomain.Entities;
using BatBetDomain.Interfaces.Repositories;

namespace BatBetInfrastructure.Repositories
{
    public class UserRepository(BatBetDbContext context, IMapper mapper) : RepositoryBase<User>(context), IUserRepository
    {
        protected readonly IMapper _mapper = mapper;
    }
}
