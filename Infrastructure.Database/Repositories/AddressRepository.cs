using Domain.Entities.AddressAggreagte;
using Domain.Entities.PersonAggregate;
using Infrastructure.Database.baseRepository;
using Infrastructure.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public ReserveFoodDb FoodDb { get; }
        public AddressRepository(ReserveFoodDb foodDb) : base(foodDb)
        {
            FoodDb = foodDb;
        }


        public async Task Delete(Guid addressId)
        {
            Address? address = await GetAsync(addressId);
            if (address != null)
            {
                address.RemoveAddress();
            }

        }
        public async Task Restore(Guid addressId)
        {
            Address? address = await GetAsync(addressId);
            if (address != null)
            {
                address.RestoreAddress();
            }

        }

       
    }
}
