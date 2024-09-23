using Application.Contract.Dtos.BaseDto;
using MediatR;

namespace Application.Contract.Dtos.Food
{
    public class RestoreFoodRequest : IRequest<RestoreFoodResponse>
    {
        public Guid Id { get; set; }
    }

    public class RestoreFoodResponse : ResponseBase
    {
    }
}
