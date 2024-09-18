using Application.Contract.Dtos.BaseDto;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.Food
{
    public class CreateFoodRequest : IRequest<CreateFoodResponse>
    {
        public string FoodName { get; set; }
        public int Prise { get; set; }
        public uint Weight { get; set; }
        public Guid CategoryId { get; set; }
        public byte SuitableHowMany { get; set; }
        public string FileAlt { get; set; }
        public string FileTitle { get; set; }
        public IFormFile File { get; set; }
    }
    public class CreateFoodResponse : ResponseBase
    {
        public Guid Id { get; set; }
    }

}
