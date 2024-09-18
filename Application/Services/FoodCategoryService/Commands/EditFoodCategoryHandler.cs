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
    public class EditFoodCategoryHandler : IRequestHandler<EditFoodCategoryRequest, EditFoodCategoryResponse>
    {
        public IFoodCategoryRepository repository { get; }

        public EditFoodCategoryHandler(IFoodCategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<EditFoodCategoryResponse> Handle(EditFoodCategoryRequest request, CancellationToken cancellationToken)
        {
            if(!await repository.ExistAsync(f=>f.Id == request.id))
                return new EditFoodCategoryResponse()
                {
                    IsOkey = false,
                    Message = "Food Category NotFound .",
                    StatusCode = 404
                };

            if (await repository.ExistAsync(f=>f.CategoryName == request.FoodCategoryName))
                return new EditFoodCategoryResponse
                {
                    IsOkey = false,
                    Message = "name is already exist .",
                    StatusCode = 500
                };

            if(string.IsNullOrWhiteSpace(request.ParentCategoryId.ToString()))
                request.ParentCategoryId = null ;

            else if(!await repository.ExistAsync(f=>f.Id == request.ParentCategoryId))
                return new EditFoodCategoryResponse()
                {
                    IsOkey = false,
                    Message = "Parent Category NotFound",
                    StatusCode = 404 
                };

            FoodCategory foodCategory = await repository.GetAsync(request.id);
            foodCategory?.Edit(request.FoodCategoryName,request.ParentCategoryId);


            await repository.EditAsync(foodCategory);
            await repository.SaveChengesAsync();
            return new EditFoodCategoryResponse();
        }
    }
}
