using Application.Utilities;
using Domain.Entities.Base;
using Domain.Entities.PersonAggregate;
using Infrastructure.Database.baseRepository;
using Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.bootstrapper
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ServiceConfigure(this IServiceCollection services)
        {
            services.AddSingleton<EncriptTools>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped(typeof(IPersonRepository),typeof(PersonRepository));
            services.AddScoped<PersonTools>();

            return services;
        }
    }
}
