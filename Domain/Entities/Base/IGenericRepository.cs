using Domain.Entities.AddressAggreagte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> GetAsync(Guid entityId);
        Task<ICollection<T>> GetAllAsync();
        Task EditAsync(T entity);
        Task SaveChengesAsync();
        Task<bool> ExistAsync(Expression<Func<T,bool>> expression);
        IQueryable<T> GetAllByQualification(Expression<Func<T,bool>> expression,IQueryable<T> source = null);
        IQueryable<T> GetAllOrderBy(Expression<Func<T,object>> expression , byte OrderByAscOrDesc = 0,IQueryable<T> source = null);
        Task<List<P>> ConvertToListAsync<P>(IQueryable<P> source) where P : class ;
        IQueryable<T> GetAll();
    }
}
