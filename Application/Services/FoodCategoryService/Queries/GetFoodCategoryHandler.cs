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
    public class GetFoodCategoryHandler : IRequestHandler<GetFoodCategoryRequest, GetFoodCategoryResponse>
    {
        public IFoodCategoryRepository Repository { get; }
        public GetFoodCategoryHandler(IFoodCategoryRepository repository)
        {
            Repository = repository;
        }


        public async Task<GetFoodCategoryResponse> Handle(GetFoodCategoryRequest request, CancellationToken cancellationToken)
        {
            FoodCategory? foodCategory = await Repository.GetAsync(request.Id);
            if (foodCategory == null) 
                return new GetFoodCategoryResponse()
                {
                    IsOkey = false,
                    Message = "Food Category NotFound",
                    StatusCode = 404 
                };
            return new GetFoodCategoryResponse()
            {
                FoodCategoryName = foodCategory.CategoryName,
                Id = request.Id,
                IsActive = foodCategory.IsActive,
            };
        }
    }

}
