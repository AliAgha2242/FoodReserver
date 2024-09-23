using Domain.Entities.Base;
using Domain.Entities.OperatoreAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.FoodAggregate
{
    public interface IFoodRepository : IGenericRepository<Food>
    {
        Task Remove(Guid foodId);
        Task Restore(Guid foodId);
        Task<ICollection<Food>> GetAllWithFileAndCategoryRelationAsync();
        Task<Food> GetWithFileAndCategoryRelationAsync(Guid foodId);
        Task<string> GetFoodFileAddressAsync(Guid foodId);
        Task<Food> GetFoodWithFileRelation(Guid id);

    }
}
