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
    public class GetAllSubCatRequest : IRequest<List<GetAllSubCatResponse>?>
    {
        public Guid Id { get; set; }

        

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out GetAllSubCatRequest result)
        {
            throw new NotImplementedException();
        }
    }

    public class GetAllSubCatResponse : ResponseBase
    {
        public string CategoryName { get; set; }
        public Guid Id { get; set; }
    }
}
