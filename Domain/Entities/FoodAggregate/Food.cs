using Domain.Entities.Base;
using Domain.Entities.FoodCategoryAggregate;
using Domain.Entities.ReserveAggregate;

namespace Domain.Entities.FoodAggregate
{
    public class Food : AggregateRoot
    {

        public string Name { get; private set; }
        public int Prise { get; private set; }
        public uint Weight { get; private set; }
        public Guid FoodCategoryId { get; private set; }
        public byte SuitableHowMany { get; private set; }
        public bool IsActive { get; private set; }
        public FoodFile FoodFile { get; private set; }
        public FoodCategory FoodCategory { get; private set; }
        public ICollection<Reserve> Reserves { get; private set; }

        private Food(string name, int prise, uint weight,
           Guid foodCategoryId, byte suitableHowMany, string fileAlt, string fileTitle,
           string fileAddress, double fileSize)
        {
            Name = name;
            Prise = prise;
            Weight = weight;
            FoodCategoryId = foodCategoryId;
            SuitableHowMany = suitableHowMany;
            IsActive = true;
            FoodFile = FoodFileGenerate(name, fileAlt, fileTitle, fileAddress, fileSize, this.Id);
        }


        private FoodFile FoodFileGenerate(string name,string fileAlt, string fileTitle,
           string fileAddress, double fileSize, Guid Id)
        {
            return FoodFile.Create(string.Concat(name, "-File"), fileAlt, fileTitle, fileAddress, fileSize, Id);
        }

        public static Food Create(string name , int prise, uint weight,
           Guid foodCategoryId, byte suitableHowMany, string fileAlt, string fileTitle, string fileAddress, double fileSize)
        {
            return new Food(name, prise, weight, foodCategoryId, suitableHowMany,
                fileAlt, fileTitle, fileAddress, fileSize);
        }

        private void FoodFileEdit(string name,string fileAlt, string fileTitle,
           string fileAddress, double fileSize)
        {
            FoodFile.Edit(name,fileAlt,fileTitle,fileAddress,fileSize);
        }

        public void Edit(string name, int prise, uint weight,
           Guid foodCategoryId, byte suitableHowMany,string fileName, string fileAlt, string fileTitle,
           string fileAddress, double fileSize)
        {
            Name = name;
            Prise = prise;
            Weight = weight;
            FoodCategoryId = foodCategoryId;
            SuitableHowMany = suitableHowMany;
            FoodFileEdit(fileName,fileAlt,fileTitle,fileAddress,fileSize);
        }


        public void RemoveFood()
        {
            IsActive = false;
        }
        public void RestoreFood()
        {
            IsActive = true;
        }

        //Ctor For EfCore
        public Food()
        {

        }


    }
}
