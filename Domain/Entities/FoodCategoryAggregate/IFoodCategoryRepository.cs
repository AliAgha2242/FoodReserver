using Domain.Entities.Base;
using Domain.Entities.OperatoreAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.FoodCategoryAggregate
{
    public interface IFoodCategoryRepository : IGenericRepository<FoodCategory>
    {
        Task Remove(Guid foodCategoryId);
        Task Restore(Guid foodCategoryId);
        Task<ICollection<FoodCategory>> GetAllWithParentRelationAsync();
        Task<ICollection<FoodCategory>> GetAllSubCatAsync(Guid id);

    }
}
