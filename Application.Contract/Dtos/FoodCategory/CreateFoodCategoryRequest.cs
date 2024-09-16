using Application.Contract.Dtos.BaseDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.FoodCategory
{
    public class CreateFoodCategoryRequest : IRequest<CreateFoodCategoryResponse>
    {
        public string CategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }

    public class CreateFoodCategoryResponse : ResponseBase
    {
    }

   
}
