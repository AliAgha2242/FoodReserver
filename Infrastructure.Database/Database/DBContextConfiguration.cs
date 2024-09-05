using Infrastructure.Database.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public static class DBContextConfiguration
    {
        public static IServiceCollection DbConfigure(this IServiceCollection services , string? connectionString)
        {
            services.AddDbContext<ReserveFoodDb>(p =>
            {
                p.UseSqlServer(connectionString);
            });
            return services ;
        }
    }
}
