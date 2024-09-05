using Domain.Entities.Base;
using Domain.Entities.OperatoreAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.EmployerAggregate
{
    public interface IEmployerRepository : IGenericRepository<Employer>
    {
        Task Delete(Guid employerId);
        Task Restore(Guid employerId);

    }
}
