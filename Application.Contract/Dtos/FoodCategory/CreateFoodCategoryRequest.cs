using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.FoodCategory
{
    public class CreateFoodCategoryRequest
    {
        public string CategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
