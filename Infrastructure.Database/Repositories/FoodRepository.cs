using Domain.Entities.AddressAggreagte;
using Domain.Entities.FoodAggregate;
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
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        public ReserveFoodDb FoodDb { get; }
        public FoodRepository(ReserveFoodDb foodDb) : base(foodDb)
        {
            FoodDb = foodDb;
        }


        public async Task Remove(Guid foodId)
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

        public async Task<ICollection<Food>> GetAllWithFileAndCategoryRelationAsync()
        {
            var foods = await FoodDb.Foods.AsQueryable()
                .Include(f=>f.FoodFile)
                .Include(f=>f.FoodCategory).AsNoTracking().ToListAsync();

            return foods;
        }

        public async Task<Food> GetWithFileAndCategoryRelationAsync(Guid foodId)
        {
            return await FoodDb.Foods.AsQueryable().Include(f=>f.FoodFile)
                .Include(f=>f.FoodCategory).SingleAsync(f=>f.Id == foodId);
        }

        public async Task<string> GetFoodFileAddressAsync(Guid foodId)
        {
            var food  = await FoodDb.Foods.Include(f=>f.FoodFile).AsNoTracking().AsQueryable().SingleOrDefaultAsync(p=>p.Id == foodId);
            if(food == null)
                return "" ;
            
            return food.FoodFile.Address;
        }

        public async Task<Food> GetFoodWithFileRelation(Guid id)
        {
           return await FoodDb.Foods.AsQueryable().Include(f=>f.FoodFile).SingleOrDefaultAsync(f=>f.Id == id);
        }
    }
}
