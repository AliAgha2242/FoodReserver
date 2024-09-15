using Application.Contract.Dtos.Person;
using Application.Utilities;
using Domain.Entities.PersonAggregate;
using MediatR;

namespace Application.Services.PersonService.Commands
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, CreatePersonResponse>
    {
        public IPersonRepository Repository { get; }
        public EncriptTools EncriptTools { get; }
        public PersonTools PersonTools { get; }

        public CreatePersonHandler(IPersonRepository repository, EncriptTools encriptTools,PersonTools personTools)
        {
            Repository = repository;
            EncriptTools = encriptTools;
            PersonTools = personTools;
        }

        public async Task<CreatePersonResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            if(await Repository.ExistAsync(p=>p.PersonName == request.PersonName))
            {
                return new CreatePersonResponse{IsOkey = false};
            }

            string passwordSalt = EncriptTools.GetNewSalt();
            string HashPassword = PersonTools.PasswordGenerator(request.Password,passwordSalt);

            await Repository.CreateAsync(Person.Create(request.PersonName, HashPassword, request.FullName,
               request.Email, request.PhoneNumber, passwordSalt));

            await Repository.SaveChengesAsync() ;

            return new CreatePersonResponse{IsOkey = true };
        }
    }

}
