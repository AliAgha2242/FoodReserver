using Domain.Entities.AddressAggreagte;
using Domain.Entities.FoodCategoryAggregate;
using Infrastructure.Database.baseRepository;
using Infrastructure.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories
{
    public class FoodCategoryRepository : GenericRepository<FoodCategory>, IFoodCategoryRepository
    {
        public ReserveFoodDb FoodDb { get; }

        public FoodCategoryRepository(ReserveFoodDb foodDb) : base(foodDb)
        {
            FoodDb = foodDb;
        }


        public async Task Delete(Guid foodCategory)
        {
            FoodCategory? FoodCategory= await GetAsync(foodCategory);
            if (FoodCategory != null)
            {
                FoodCategory.RemoveFoodCategory();
            }

        }
        public async Task Restore(Guid foodCategory)
        {
            FoodCategory? FoodCategory = await GetAsync(foodCategory);
            if (FoodCategory != null)
            {
                FoodCategory.RestoreFoodCategory();
            }

        }
    }
}
