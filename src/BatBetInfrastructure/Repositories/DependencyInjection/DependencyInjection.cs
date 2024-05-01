using BatBetDomain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BatBetInfrastructure.Repositories.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IBetsRepository, BetsRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IAvailableBetsRepository, AvailableBetsRepository>();
        }
    }
}
