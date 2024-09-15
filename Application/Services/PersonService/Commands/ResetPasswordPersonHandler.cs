using Application.Contract.Dtos.Person;
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
    public class ResetPasswordPersonHandler : IRequestHandler<ResetPasswordPersonRequest, ResetPasswordPersonResponse>
    {
        public IPersonRepository Repository { get; }
        public EncriptTools Encript { get; }
        public PersonTools PersonTools { get; }

        public ResetPasswordPersonHandler(IPersonRepository repository,EncriptTools encript,PersonTools personTools)
        {
            Repository = repository;
            Encript = encript;
            PersonTools = personTools;
        }


        public async Task<ResetPasswordPersonResponse> Handle(ResetPasswordPersonRequest request, CancellationToken cancellationToken)
        {


            if(!await Repository.ExistAsync(p=>p.Id == request.Id))
                return new ResetPasswordPersonResponse{IsOkey = false};


            Person? person = await Repository.GetAsync(request.Id);

            string oldPass = PersonTools.PasswordGenerator(request.OldPassword ,person.PasswordSalt);

            if(!Repository.CheckPassword(person,oldPass))
                return new ResetPasswordPersonResponse {IsOkey = false};


            string password = Encript.GetSHA256(request.NewPassword);
            string passSalt = Encript.GetSHA256(person.PasswordSalt);

            await Repository.ResetPassword(person,PersonTools.PasswordGenerator(password,passSalt));

            Repository.SaveChengesAsync().Wait();
            return new ResetPasswordPersonResponse { IsOkey = true};
        }
    }
}
