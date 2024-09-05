using Domain.Entities.Base;
using Domain.Entities.PersonAggregate;
using Domain.Entities.ReserveAggregate;


namespace Domain.Entities.AddressAggreagte
{
    public class Address : AggregateRoot
    {
        public string Ostan { get; private set; }
        public string Shahr { get; private set; }
        public string RestAddress { get; private set; }
        public int Pelak { get; private set; }
        public int PostalCode { get; private set; }
        public Guid PersonId {get; private set;}
        public bool IsActived { get; private set; }
        public Person Person { get; private set; }
        public ICollection<Reserve> Reserves { get; private set; }

        private Address(string ostan, string shahr, string restAddress,int pelak,int postalCode,Guid personId)
        {
            Ostan = ostan;
            Shahr = shahr;
            RestAddress = restAddress;
            IsActived = true;
            Pelak = pelak;
            PostalCode = postalCode;
            PersonId = personId;
        }
        public static Address Create(string ostan, string shahr, string restAddress,
            int pelak,int postalCode,Guid personId)
        {
            return new Address(ostan, shahr, restAddress,pelak,postalCode,personId);
        }
        

        public void Edit(string ostan, string shahr, string restAddress,int pelak,int postalCode)
        {
            Ostan = ostan;
            Shahr = shahr;
            RestAddress = restAddress;
            IsActived = true;
            Pelak = pelak;
            PostalCode = postalCode;
        }

        public void RemoveAddress()
        {
            this.IsActived = false ;
        }
        public void RestoreAddress()
        {
            this.IsActived = true ;
        }

        //For EfCore
        public Address() { }
    }
}
