using Domain.Entities.Base;

namespace Domain.Entities.FoodAggregate
{
    public class FoodFile : ValueObject
    {
        public string Name { get; private set; }
        public string Alt { get; private set; }
        public string Title { get; private set; }
        public string Address { get; set; }
        public double Size { get; private set; }
        public Guid FoodId { get; set; }
        public DateTime CreationDate { get; private set; }
        public Food Food { get; private set; }
        private FoodFile(string name, string alt, string title, string address, double size, Guid foodId)
        {
            Name = name;
            Alt = alt;
            Title = title;
            Address = address;
            Size = size;
            CreationDate = DateTime.Now;
            FoodId = foodId;
        }

        public static FoodFile Create(string name, string alt, string title,
            string address, double size, Guid foodId)
        {
            return new FoodFile(name, alt, title, address, size, foodId);
        }

        //Ctor For EfCore
        public FoodFile()
        {
            
        }

    }
}
