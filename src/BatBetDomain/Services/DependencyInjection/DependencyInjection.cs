using BatBetDomain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BatBetDomain.Services.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddServicesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IBetsService, BetsService>();
        }
    }
}
