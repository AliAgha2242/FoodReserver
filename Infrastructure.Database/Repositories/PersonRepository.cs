using Domain.Entities.PersonAggregate;
using Infrastructure.Database.baseRepository;
using Infrastructure.Database.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public ReserveFoodDb FoodDb { get; }
        public PersonRepository(ReserveFoodDb foodDb) : base(foodDb)
        {
            FoodDb = foodDb;
        }

        public async Task Delete(Guid PersonId)
        {
            Person? person = await GetAsync(PersonId);
            if (person != null)
            {
                person.RemovePerson();
            }

        }

        public async Task Restore(Guid PersonId)
        {
            Person? person = await GetAsync(PersonId);
            if (person != null)
            {
                person.RestorePerson();
            }
        }

        public async Task ResetPassword(Person person, string newPassword)
        {
            person.ResetPassword(newPassword);
        }

        public bool CheckPassword(Person person, string password)
        {
            return person.HashPassword == password;
        }
    }
}
