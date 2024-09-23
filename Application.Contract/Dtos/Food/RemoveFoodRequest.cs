using Application.Contract.Dtos.BaseDto;
using MediatR;

namespace Application.Contract.Dtos.Food
{
    public class RemoveFoodRequest : IRequest<RemoveFoodResponse>
    {
        public Guid Id { get; set; }
    }

    public class RemoveFoodResponse : ResponseBase
    {
    }
}
