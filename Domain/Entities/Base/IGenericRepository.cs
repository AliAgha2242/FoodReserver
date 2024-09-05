using Domain.Entities.AddressAggreagte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T?> GetAsync(Guid entityId);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T,bool>> func);
        void Edit(T entity);
        Task SaveChengesAsync();
    }
}
