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
    public class DeletePersonHandler : IRequestHandler<DeletePersonRequest, DeletePersonResponse>
    {
        public IPersonRepository Repository { get; }
        public DeletePersonHandler(IPersonRepository repository)
        {
            Repository = repository;
        }


        public async Task<DeletePersonResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            var person = await Repository.GetAsync(request.Id);
            if (person == null)
                return new DeletePersonResponse()
                {
                    IsOkey = false
                };
            Repository.Delete(request.Id).GetAwaiter();
            Repository.SaveChengesAsync().Wait();
            return new DeletePersonResponse()
            {
                IsOkey = true
            };
        }
    }
}
