using Domain.Entities.Base;
using Domain.Entities.FoodAggregate;
using Infrastructure.Database.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.baseRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ReserveFoodDb FoodDb { get; }
        public GenericRepository(ReserveFoodDb foodDb)
        {
            FoodDb = foodDb;
        }


        public async Task CreateAsync(T entity)
        {
            await FoodDb.Set<T>().AddAsync(entity);
        }

        public void Edit( T entity)
        {
            FoodDb.Set<T>().Update(entity);
        }  

        public async Task<T?> GetAsync(Guid entityId)
        {
            return await FoodDb.Set<T>().FindAsync(entityId);
        } 

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T,bool>> func)
        {
            return await FoodDb.Set<T>().AsNoTracking().Where(func).ToListAsync();
        }

        public async Task SaveChengesAsync()
        {
            await FoodDb.SaveChangesAsync();
        }
    }
}
