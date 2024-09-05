using Application.Contract.Dtos;
using Application.Services.PersonService.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.bootstrapper
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection MediatRConfigure(this IServiceCollection services)
        {
            services.AddMediatR(p =>
            {
                p.RegisterServicesFromAssemblies
                (typeof(CreatePersonHandller).Assembly,typeof(CreatePersonResponse).Assembly);
            });
            return services ;
        }
    }
}
