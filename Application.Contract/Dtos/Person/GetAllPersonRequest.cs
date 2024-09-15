using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.Person
{
    public class GetAllPersonRequest : IRequest<List<GetAllPersonResponse>>
    {
    }

    public class GetAllPersonResponse
    {
        public string name { get; set; }
        public string HashPassword { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public Guid Id { get; set; }
    }
}
