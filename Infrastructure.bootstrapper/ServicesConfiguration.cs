using Application.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.bootstrapper
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ServiceConfigure(this IServiceCollection services)
        {
            services.AddSingleton<EncriptTools>();
            return services;
        }
    }
}
