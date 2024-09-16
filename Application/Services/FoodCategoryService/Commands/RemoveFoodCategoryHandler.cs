using Application.Contract.Dtos.FoodCategory;
using Domain.Entities.FoodCategoryAggregate;
using MediatR;

namespace Application.Services.FoodCategoryService.Commands
{
    public class RemoveFoodCategoryHandler : IRequestHandler<RemoveFoodCategoryRequest, RemoveFoodCategoryReponse>
    {
        public IFoodCategoryRepository Repository { get; }
        public RemoveFoodCategoryHandler(IFoodCategoryRepository repository)
        {
            Repository = repository;
        }


        public async Task<RemoveFoodCategoryReponse> Handle(RemoveFoodCategoryRequest request, CancellationToken cancellationToken)
        {
            if(!await Repository.ExistAsync(f=>f.Id == request.Id))
                return new RemoveFoodCategoryReponse
                {
                    IsOkey= false,
                    Message = "Food Catgeory NotFound",
                    StatusCode = 500
                };
            Repository.Remove(request.Id).Wait();
            Repository.SaveChengesAsync().Wait();
            return new RemoveFoodCategoryReponse();
        }
    }
}
