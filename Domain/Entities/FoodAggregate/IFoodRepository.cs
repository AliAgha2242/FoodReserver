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
        Task Delete(Guid foodId);
        Task Restore(Guid foodId);


    }
}
