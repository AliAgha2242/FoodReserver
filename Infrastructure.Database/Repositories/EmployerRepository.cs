using Domain.Entities.AddressAggreagte;
using Domain.Entities.EmployerAggregate;
using Domain.Entities.OperatoreAggregate;
using Infrastructure.Database.baseRepository;
using Infrastructure.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories
{
    public class EmployerRepository : GenericRepository<Employer>, IEmployerRepository
    {
        public ReserveFoodDb FoodDb { get; }
        public EmployerRepository(ReserveFoodDb foodDb) : base(foodDb)
        {
            FoodDb = foodDb;
        }
        public async Task Delete(Guid employerId)
        {
            Employer? employer = await GetAsync(employerId);
            if (employer != null)
            {
                employer.RemoveEmployer();
            }

        }
        public async Task Restore(Guid employerId)
        {
            Employer? employer = await GetAsync(employerId);
            if (employer != null)
            {
                employer.RestoreEmployer();
            }
        }
    }
}
