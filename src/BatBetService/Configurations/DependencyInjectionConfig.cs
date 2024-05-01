using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BatBetServiceAPI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
