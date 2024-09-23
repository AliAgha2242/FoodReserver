using Application.Contract.Dtos.BaseDto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Contract.Dtos.Food
{
    public class SearchFoodRequest : IRequest<SearchFoodResponseAgg>
    {
        public string? Name { get; set; }
        public Guid? CategoryId { get; set; }
        public bool? OrderByPriseDesc { get; set; } = false;
        [Range(1,1000,ErrorMessage = "Suitable How Many Field Value Is Not Valid (1-1000 range)")]
        public byte? SuitableHowMany { get; set; }
    }

    public class SearchFoodResponseAgg
    {
        public List<SearchFoodResponse> searchFoodResponses { get; set; }
        public ResponseBase Response { get; set; }
        public SearchFoodRequest Request { get; set; }
    }

    public class SearchFoodResponse 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte SuitableHowMany { get; set; }
        public int Prise { get; set; }
        public uint Weight { get; set; }
        public string Address { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
    }
}
