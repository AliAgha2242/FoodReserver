using Domain.Entities.Base;
using Domain.Entities.ReciveAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ReserveAggregate
{
    public interface IReserveRepository : IGenericRepository<Reserve>
    {
        Task Delete(Guid reserveId);
    }
}

