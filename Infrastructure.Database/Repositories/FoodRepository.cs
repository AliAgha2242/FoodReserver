using Domain.Entities.AddressAggreagte;
using Domain.Entities.FoodAggregate;
using Infrastructure.Database.baseRepository;
using Infrastructure.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories
{
    public class FoodRepository : GenericRepository<Food>,IFoodRepository
    {
        public ReserveFoodDb FoodDb { get; }
        public FoodRepository(ReserveFoodDb foodDb) : base(foodDb)
        {
            FoodDb = foodDb;
        }


        public async Task Delete(Guid foodId)
        {
            Food? food = await GetAsync(foodId);
            if (food != null)
            {
                food.RemoveFood();
            }

        }
        public async Task Restore(Guid foodId)
        {
            Food? food = await GetAsync(foodId);
            if (food != null)
            {
                food.RestoreFood();
            }

        }
    }
}
