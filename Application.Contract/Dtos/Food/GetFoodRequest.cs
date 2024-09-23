using Application.Contract.Dtos.BaseDto;
using MediatR;

namespace Application.Contract.Dtos.Food
{
    public class GetFoodRequest : IRequest<GetFoodResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetFoodResponse : ResponseBase
    {
        public string Name { get; set; }
        public long Prise { get; set; }
        public byte SuitableHowMany { get; set; }
        public string FileAddress { get; set; }
        public string FileExtension { get; set; }
        public string FoodCategoryName { get; set; }
    }
}
