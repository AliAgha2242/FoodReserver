using Domain.Entities.Base;
using Domain.Entities.OperatoreAggregate;
using Domain.Entities.ReserveAggregate;


namespace Domain.Entities.ReciveAggregate
{
    public class Recive : AggregateRoot
    {
        

        public DateTime ReciveDate { get; private set; }
        public Guid EmployerId { get; private set; }
        public Guid ReserveId { get; private set; }
        public PayType PayType { get; private set; }
        public Employer Employer { get; private set; }
        public Reserve Reserve { get; private set; }


        public Recive(DateTime reciveDate, Guid employerId, Guid reserveId, PayType payType)
        {
            ReciveDate = reciveDate;
            ReserveId = reserveId;
            PayType = payType;
            EmployerId = employerId;
        }

        public static Recive Create(DateTime reciveDate, Guid personId, Guid reserveId, PayType payType)
        {
            return new Recive(reciveDate,personId, reserveId, payType);
        }
        public void Edit(DateTime reciveDate, Guid employerId, Guid reserveId, PayType payType)
        {
            ReciveDate = reciveDate;
            EmployerId = employerId;
            ReserveId = reserveId;
            PayType = payType;
        }

        //ctor for Efcore
    }

    public enum PayType
    {
        PecuniaryPay,
        OnlinePay,
        CartReaderpay
    }
}
