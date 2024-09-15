using Application.Contract.Dtos.Person;
using Domain.Entities.PersonAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PersonService.Queries
{
    public class GetAllPersonHandler : IRequestHandler<GetAllPersonRequest, List<GetAllPersonResponse>>
    {
        public IPersonRepository Repository { get; }
        public GetAllPersonHandler(IPersonRepository repository)
        {
            Repository = repository;
        }


        public async Task<List<GetAllPersonResponse>> Handle(GetAllPersonRequest request, CancellationToken cancellationToken)
        {
            var Persons = await Repository.GetAllAsync();
            return Persons.Select(p=>new GetAllPersonResponse()
            {
                FullName = p.FullName,
                HashPassword = p.HashPassword,
                IsActive = p.IsActive,
                name = p.PersonName,
                Id = p.Id,
            }).ToList();
        }
    }
}
