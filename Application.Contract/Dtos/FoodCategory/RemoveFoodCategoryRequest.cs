using Application.Contract.Dtos.BaseDto;
using MediatR;

namespace Application.Contract.Dtos.FoodCategory
{
    public class RemoveFoodCategoryRequest : IRequest<RemoveFoodCategoryReponse>
    {
        public Guid Id { get; set; }
    }
     public class RemoveFoodCategoryReponse : ResponseBase
    {
    }
}
