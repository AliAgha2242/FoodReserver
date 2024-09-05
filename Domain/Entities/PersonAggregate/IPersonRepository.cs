using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PersonAggregate
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task Delete(Guid PersonId);
        Task Restore(Guid PersonId);

    }
}
