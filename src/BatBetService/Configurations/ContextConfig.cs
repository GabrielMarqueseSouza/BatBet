using BatBetInfrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BatBetService.Configurations
{
    public static class ContextConfig
    {
        public static IServiceCollection AddContextConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<BatBetDbContext>(opt =>
            {
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
