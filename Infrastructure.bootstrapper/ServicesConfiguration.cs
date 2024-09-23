using Application.Utilities;
using Domain.Entities.AddressAggreagte;
using Domain.Entities.Base;
using Domain.Entities.FoodAggregate;
using Domain.Entities.FoodCategoryAggregate;
using Domain.Entities.PersonAggregate;
using Domain.Entities.ReserveAggregate;
using Infrastructure.Database.baseRepository;
using Infrastructure.Database.DapperRepository;
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
            services.AddSingleton<PersonTools>();
            services.AddScoped(typeof(IFoodCategoryRepository),typeof(FoodCategoryRepository));
            services.AddScoped<IFoodRepository,FoodRepository>();
            services.AddSingleton<FileTools>();
            services.AddScoped<IReserveRepository,ReserveRepository>();
            services.AddScoped<IAddressRepository,AddressRepository>();
            services.AddScoped<IAddressDapperRepository,AddressDapperRepository>();


           
            return services;
        }
    }
}
