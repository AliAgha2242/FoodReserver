using Domain.Entities.AddressAggreagte;
using Domain.Entities.ReserveAggregate;
using Infrastructure.Database.baseRepository;
using Infrastructure.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories
{
    public class ReserveRepository : GenericRepository<Reserve>, IReserveRepository
    {
        public ReserveFoodDb FoodDb { get; }
        public ReserveRepository(ReserveFoodDb foodDb) : base(foodDb)
        {
            FoodDb = foodDb;
        }


        public async Task Delete(Guid reserveId)
        {
            Reserve? reserve = await GetAsync(reserveId);
            if (reserve != null)
            {
                reserve.RemoveReserve();
            }
        }
    }
}
