using Application.Contract.Dtos.BaseDto;
using MediatR;

namespace Application.Contract.Dtos.Food
{
    public class GetAllFoodRequest : IRequest<List<GetAllFoodResponse>>
    {

    }

    public class GetAllFoodResponse : ResponseBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Prise { get; set; }
        public byte SuitableHowMany { get; set; }
        public string FileAddress { get; set; }
        public string FileExtension { get; set; }
        public string FoodCategory { get; set; }
    }
}
