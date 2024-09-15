using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.Person
{
    public class DeletePersonRequest : IRequest<DeletePersonResponse>
    {
        public Guid Id { get; set; }
    }

    public class DeletePersonResponse
    {
        public bool IsOkey { get; set; }
    }
}
