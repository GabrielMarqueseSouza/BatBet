using BatBetDomain.Entities;
using BatBetDomain.Interfaces.Repositories;
using BatBetInfrastructure.Data;
using BatBetInfrastructure.Repositories.Common;

namespace BatBetInfrastructure.Repositories
{
    public class AvailableBetsRepository(BatBetDbContext context) : RepositoryBase<AvailableBet>(context), IAvailableBetsRepository
    {
    }
}