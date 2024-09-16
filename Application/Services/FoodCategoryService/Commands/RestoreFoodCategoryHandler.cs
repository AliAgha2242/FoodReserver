using Application.Contract.Dtos.FoodCategory;
using Domain.Entities.FoodCategoryAggregate;
using MediatR;

namespace Application.Services.FoodCategoryService.Commands
{
    public class RestoreFoodCategoryHandler : IRequestHandler<RestoreFoodCategoryRequest, RestoreFoodCategoryResponse>
    {
        public IFoodCategoryRepository Repository { get; }
        public RestoreFoodCategoryHandler(IFoodCategoryRepository repository)
        {
            Repository = repository;
        }


        public async Task<RestoreFoodCategoryResponse> Handle(RestoreFoodCategoryRequest request, CancellationToken cancellationToken)
        {
            if(!await Repository.ExistAsync(f=>f.Id == request.Id))
                return new RestoreFoodCategoryResponse
                {
                    IsOkey= false,
                    Message = "Food Catgeory NotFound",
                    StatusCode = 500
                };
            Repository.Restore(request.Id).Wait();
            Repository.SaveChengesAsync().Wait();
            return new RestoreFoodCategoryResponse();
        }
    }
}
