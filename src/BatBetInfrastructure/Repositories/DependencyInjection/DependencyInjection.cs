using BatBetDomain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BatBetInfrastructure.Repositories.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddRepositoriesDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBetsRepository, BetsRepository>();
        }
    }
}
