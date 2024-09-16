using Application.Contract.Dtos.BaseDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.Person
{
    public class ResetPasswordPersonRequest : IRequest<ResetPasswordPersonResponse>
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class ResetPasswordPersonResponse : ResponseBase
    {
    }
}
