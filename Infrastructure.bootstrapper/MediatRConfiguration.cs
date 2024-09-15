using Application.Contract.Dtos.Person;
using Application.Services.PersonService.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.bootstrapper
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection MediatRConfigure(this IServiceCollection services)
        {
            services.AddMediatR(p =>
            {
                p.RegisterServicesFromAssemblies
                (typeof(CreatePersonHandler).Assembly, typeof(CreatePersonResponse).Assembly);
            });
            return services ;
        }
    }
}
