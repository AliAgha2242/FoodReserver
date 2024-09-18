using Infrastructure.Database.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.bootstrapper
{
    public static class DBContextConfiguration
    {
        //public static IServiceCollection DbConfigure(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDbContext<ReserveFoodDb>(o =>
        //    {
        //         o.UseSqlServer(configuration.GetConnectionString("Index"));
        //    });
        //    return services;
        //}
    }
}
