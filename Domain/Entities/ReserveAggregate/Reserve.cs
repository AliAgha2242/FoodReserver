using Domain.Entities.AddressAggreagte;
using Domain.Entities.Base;
using Domain.Entities.FoodAggregate;
using Domain.Entities.PersonAggregate;
using Domain.Entities.ReciveAggregate;

namespace Domain.Entities.ReserveAggregate
{
    public class Reserve : AggregateRoot
    {

        public DateTime CreateReserveTime { get; private set; }
        public DateTime ReserveDate { get; private set; }
        public bool IsActive { get; private set; }
        public Guid? PersonId { get; private set; }
        public Guid Addressid { get; private set; }
        public Address Address { get; private set; }
        public Person Person{ get; private set; }
        public ICollection<Food> Foods { get; private set; }
        public Recive? Recive{ get; private set; }


        private Reserve( DateTime reserveDate, Guid personId, Guid addressid)
        {
            ReserveDate = reserveDate;
            PersonId = personId;
            Addressid = addressid;
            CreateReserveTime = DateTime.Now;
            IsActive = true;
        }

        public static Reserve Create(DateTime reserveDate, Guid personId, Guid addressid)
        {
            return new Reserve( reserveDate, personId, addressid);
        }

        public void RemoveReserve()
        {
            IsActive = false;
        }
        public void Edit(DateTime reserveDate,Guid addressid)
        {
            ReserveDate = reserveDate;
            Addressid = addressid ;
        }
        //ctor for efCore
        public Reserve()
        {
            
        }
    }
}
