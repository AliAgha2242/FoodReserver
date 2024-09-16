using Domain.Entities.AddressAggreagte;
using Domain.Entities.FoodCategoryAggregate;
using Infrastructure.Database.baseRepository;
using Infrastructure.Database.Database;
using Microsoft.EntityFrameworkCore;
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


        public async Task Remove(Guid foodCategory)
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

        public async Task<ICollection<FoodCategory>> GetAllWithParentRelationAsync()
        {
            return await FoodDb.FoodCategories.Include(f=>f.ParentCategory).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<FoodCategory>> GetAllSubCatAsync(Guid id)
        {
            return await FoodDb.FoodCategories.AsQueryable().AsNoTracking().Where(f=>f.ParentCategoryId == id).ToListAsync();
        }
    }
}
