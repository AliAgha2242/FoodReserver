using Application.Contract.Dtos.BaseDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.FoodCategory
{
    public class GetFoodCategoryRequest : IRequest<GetFoodCategoryResponse>
    {
        public Guid Id { get; set; }

        

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out GetFoodCategoryRequest result)
        {
            throw new NotImplementedException();
        }
    }
    public class GetFoodCategoryResponse : ResponseBase
    {
        public string FoodCategoryName { get; set; }
        public bool IsActive { get; set; }
        public Guid Id { get; set; }
    }
}
