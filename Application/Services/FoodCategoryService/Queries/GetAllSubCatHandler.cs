using Application.Contract.Dtos.FoodCategory;
using Domain.Entities.FoodCategoryAggregate;
using MediatR;

namespace Application.Services.FoodCategoryService.Queries
{
    public class GetAllSubCatHandler : IRequestHandler<GetAllSubCatRequest, List<GetAllSubCatResponse>?>
    {
        public IFoodCategoryRepository Repository { get; }
        public GetAllSubCatHandler(IFoodCategoryRepository repository)
        {
            Repository = repository;
        }

        public async Task<List<GetAllSubCatResponse>> Handle(GetAllSubCatRequest request, CancellationToken cancellationToken)
        {
            ICollection<FoodCategory> parentFoodCategories =  await Repository.GetAllSubCatAsync(request.Id);
            return parentFoodCategories.Select(f=> new GetAllSubCatResponse()
            {
                CategoryName = f.CategoryName,
                Id = f.Id,
            }).ToList();
        }
    }
}
