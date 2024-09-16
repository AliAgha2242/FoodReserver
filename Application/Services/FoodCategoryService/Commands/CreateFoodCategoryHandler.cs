using Application.Contract.Dtos.FoodCategory;
using Domain.Entities.FoodCategoryAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.FoodCategoryService.Commands
{
    public class CreateFoodCategoryHandler : IRequestHandler<CreateFoodCategoryRequest, CreateFoodCategoryResponse>
    {
        public IFoodCategoryRepository Repository { get; }
        public CreateFoodCategoryHandler(IFoodCategoryRepository repository) 
        {
            Repository = repository;
        }


        public async Task<CreateFoodCategoryResponse> Handle(CreateFoodCategoryRequest request, CancellationToken cancellationToken)
        {
            if (await Repository.ExistAsync(f=>f.CategoryName == request.CategoryName))
                return new CreateFoodCategoryResponse
                {
                    IsOkey = false,
                    Message = "name is already exist .",
                    StatusCode = 500
                };
            

            if(string.IsNullOrWhiteSpace(request.ParentCategoryId.ToString()))
                request.ParentCategoryId = null ;

            else if(!await Repository.ExistAsync(f=>f.Id == request.ParentCategoryId))
                return new CreateFoodCategoryResponse()
                {
                    IsOkey = false,
                    Message = "Parent Category NotFound",
                    StatusCode = 404 
                };

            await Repository.CreateAsync(FoodCategory.Create(request.CategoryName,request.ParentCategoryId));

            await Repository.SaveChengesAsync();
            return new CreateFoodCategoryResponse() ;
        }

    }
}
