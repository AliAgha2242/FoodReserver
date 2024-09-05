using Application.Contract.Dtos;
using Application.Utilities;
using Domain.Entities.PersonAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PersonService.Commands
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, CreatePersonResponse>
    {
        public IPersonRepository Repository { get; }
        public EncriptTools EncriptTools { get; }

        public CreatePersonHandler(IPersonRepository repository,EncriptTools encriptTools)
        {
            Repository = repository;
            EncriptTools = encriptTools;
        }


        public async Task<CreatePersonResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            string passwordSalt = EncriptTools.GetNewSalt();
            string HashPassword = EncriptTools.GetSHA256(request.Password, passwordSalt);

            await Repository.CreateAsync(Person.Create(request.PersonName,HashPassword,request.FullName,
                request.Email,request.PhoneNumber,passwordSalt));

            return new CreatePersonResponse();
        }
    }
    public class CreatePersonRequest : IRequest<CreatePersonRequest>
    {
        public string PersonName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName{ get; set; }
    }
    public class CreatePersonResponse  
    {

    }
}
