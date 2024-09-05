using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.FoodCategoryAggregate
{
    public class FoodCategory : AggregateRoot
    {
        public string CategoryName { get; private set; }
        public DateTime CreationDate { get; private set; }
        public Guid? ParentCategoryId { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<FoodCategory> SubCategory { get; private set; }

        private FoodCategory(string categoryName,Guid? parentCategoryId)
        {
            CategoryName = categoryName;
            CreationDate = DateTime.Now;
            ParentCategoryId = parentCategoryId;
            IsActive = true;
        }

        public static FoodCategory Create(string categoryName,Guid? parentCategoryId)
        {
            return new FoodCategory(categoryName,parentCategoryId);
        }

        public void Edit(string categoryName,Guid? parentCategoryId)
        {
            CategoryName = categoryName;
            ParentCategoryId = parentCategoryId;
        }

        public void RemoveFoodCategory()
        {
            IsActive = false;
        } 

        public void RestoreFoodCategory()
        {
            IsActive = true;
        }

        //Ctor For EfCore
        public FoodCategory()
        {
            
        }
    }
}
