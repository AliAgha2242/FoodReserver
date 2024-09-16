using Application.Contract.Dtos.BaseDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.FoodCategory
{
    public class EditFoodCategoryRequest : IRequest<EditFoodCategoryResponse>
    {
        public Guid id { get; set; }
        public string FoodCategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }

    }

    public class EditFoodCategoryResponse : ResponseBase
    {

    }
}
