using Application.Contract.Dtos.BaseDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.FoodCategory
{
    public class GetAllFoodCategoryRequest : IRequest<List<GetAllFoodCategoryResponse>>
    {
    }

    public class GetAllFoodCategoryResponse : ResponseBase
    {
        public string FoodCategoryName { get; set; }
        public bool IsActive { get; set; }
        public Guid Id { get; set; }
        public string? ParentCategoryName { get; set; }
    }
}
