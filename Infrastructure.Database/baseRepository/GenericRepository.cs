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

        public async Task EditAsync(T entity)
        {
            FoodDb.Set<T>().Update(entity);
        }

        public async Task<T> GetAsync(Guid entityId)
        {
            return await FoodDb.Set<T>().FindAsync(entityId);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await FoodDb.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task SaveChengesAsync()
        {
            await FoodDb.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> expression)
        {
            return await FoodDb.Set<T>().AnyAsync(expression);
        }

        public IQueryable<T> GetAllByQualification(Expression<Func<T, bool>> expression, IQueryable<T> sourse = null)
        {
            if (sourse != null)
                return sourse.Where(expression);

            return FoodDb.Set<T>().AsQueryable().Where(expression);
        }
        // Summary:
        //     OrderByAsc = 0 And OrderByDesc = Any Number Exept 0
        
        public IQueryable<T> GetAllOrderBy(Expression<Func<T, object>> expression, byte OrderByAscOrDesc = 0, IQueryable<T> source = null)
        {
            if (OrderByAscOrDesc == 0)
                return (source == null ? FoodDb.Set<T>().OrderBy(expression):source.OrderBy(expression));
            else 
                return (source == null ? FoodDb.Set<T>().OrderByDescending(expression):source.OrderByDescending(expression));
        }

        public async Task<List<P>> ConvertToListAsync<P>(IQueryable<P> source) where P : class 
        {
            return await source.ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            return FoodDb.Set<T>().AsNoTracking().AsQueryable();
        }
    }
}
