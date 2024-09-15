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
    public class RestorePersonHandler : IRequestHandler<RestorePersonRequest, RestorePersonResponse>
    {
        public IPersonRepository Repository { get; }
        public RestorePersonHandler(IPersonRepository repository)
        {
            Repository = repository;
        }


        public async Task<RestorePersonResponse> Handle(RestorePersonRequest request, CancellationToken cancellationToken)
        {
            var person = await Repository.GetAsync(request.Id);
            if (person == null)
                return new RestorePersonResponse()
                {
                    IsOkey = false
                };
            Repository.Restore(request.Id).GetAwaiter();
            Repository.SaveChengesAsync().Wait();
            return new RestorePersonResponse()
            {
                IsOkey = true
            };
        }
    }
}
