using Application.Contract.Dtos.BaseDto;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Application.Contract.Dtos.Food
{
    public class EditFoodRequest : IRequest<EditFoodResponse>
    {
        public Guid Id { get; set; }
        public string? NewName { get; set; }
        public Guid? NewCategoryId { get; set; }
        public int? Prise { get; set; }
        public uint? Weight { get; set; }
        public byte? SuitableHowMany { get; set; }
        public string? FileTitle { get; set; }
        public string? FileAlt { get; set; }
        public IFormFile? File { get; set; }

    }

    public class EditFoodResponse : ResponseBase
    {
    }
}
