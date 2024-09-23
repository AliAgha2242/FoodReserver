using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AddressAggreagte
{
    public interface IAddressRepository:IGenericRepository<Address>
    {
        Task Block(Guid addressId);
        Task UnBlock(Guid addressId);
    }
}
