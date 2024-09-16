using Application.Contract.Dtos.BaseDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.FoodCategory
{
    public class RestoreFoodCategoryRequest : IRequest<RestoreFoodCategoryResponse>
    {
        public Guid Id { get; set; }
    }

    public class RestoreFoodCategoryResponse : ResponseBase
    {
    }
}
