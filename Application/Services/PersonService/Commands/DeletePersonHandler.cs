using Application.Contract.Dtos.Person;
using Domain.Entities.PersonAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PersonService.Commands
{
    public class DeletePersonHandler : IRequestHandler<RemovePersonRequest, RemovePersonResponse>
    {
        public IPersonRepository Repository { get; }
        public DeletePersonHandler(IPersonRepository repository)
        {
            Repository = repository;
        }


        public async Task<RemovePersonResponse> Handle(RemovePersonRequest request, CancellationToken cancellationToken)
        {
            var person = await Repository.GetAsync(request.Id);
            if (person == null)
                return new RemovePersonResponse()
                {
                    IsOkey = false
                };
            Repository.Delete(request.Id).GetAwaiter();
            Repository.SaveChengesAsync().Wait();
            return new RemovePersonResponse()
            {
                IsOkey = true
            };
        }
    }
}
