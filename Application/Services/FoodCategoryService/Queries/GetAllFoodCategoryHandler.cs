using Application.Contract.Dtos.FoodCategory;
using Domain.Entities.FoodCategoryAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.FoodCategoryService.Queries
{
    public class GetAllFoodCategoryHandler : IRequestHandler<GetAllFoodCategoryRequest, List<GetAllFoodCategoryResponse>>
    {
        public IFoodCategoryRepository Repository { get; }
        public GetAllFoodCategoryHandler(IFoodCategoryRepository repository)
        {
            Repository = repository;
        }


       

       
            

        public async Task<List<GetAllFoodCategoryResponse>> Handle(GetAllFoodCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<FoodCategory> foodCategories =  await Repository.GetAllWithParentRelationAsync();
            return foodCategories.Select(f=> new GetAllFoodCategoryResponse()
            {
                FoodCategoryName = f.CategoryName,
                Id = f.Id,
                IsActive = f.IsActive,
                ParentCategoryName = f.ParentCategory?.CategoryName,
                
            }).ToList();
        }
    }
    
}
