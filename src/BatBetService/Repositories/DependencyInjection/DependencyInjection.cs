using BatBetService.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BatBetService.Repositories.DependencyInjection
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
