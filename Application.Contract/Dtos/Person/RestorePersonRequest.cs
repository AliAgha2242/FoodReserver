using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.Person
{
    public class RestorePersonRequest : IRequest<RestorePersonResponse>
    {
        public Guid Id { get; set; }
    }

    public class RestorePersonResponse
    {
        public bool IsOkey { get; set; }
    }
}
