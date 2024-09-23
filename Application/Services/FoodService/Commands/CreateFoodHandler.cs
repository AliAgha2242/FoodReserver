using Application.Contract.Dtos.Food;
using Application.Utilities;
using Domain.Entities.FoodAggregate;
using Domain.Entities.FoodCategoryAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.FoodService.Commands
{
    public class CreateFoodHandler : IRequestHandler<CreateFoodRequest, CreateFoodResponse>
    {
        public IFoodRepository Repository { get; }
        public IFoodCategoryRepository CategoryRepository { get; }
        public FileTools FileTools { get; }

        public CreateFoodHandler(IFoodRepository repository, IFoodCategoryRepository categoryRepository,FileTools fileTools)
        {
            Repository = repository;
            CategoryRepository = categoryRepository;
            FileTools = fileTools;
        }


        public async Task<CreateFoodResponse> Handle(CreateFoodRequest request, CancellationToken cancellationToken)
        {
            if (await Repository.ExistAsync(f => f.Name == request.FoodName))
                return new CreateFoodResponse()
                {
                    IsOkey = false,
                    Message = "this name is already exist .",
                    StatusCode = 500
                };
            if (!await CategoryRepository.ExistAsync(f => f.Id == request.CategoryId))
                return new CreateFoodResponse()
                {
                    IsOkey = false,
                    Message = "category id is notfound.",
                    StatusCode = 404
                };
            
            request.FileTitle = request.FileTitle ?? request.FoodName;
            request.FileAlt = request.FileAlt ?? request.FoodName;

            if (!FileTools.IsNotNull(request.File))
                return new CreateFoodResponse(){IsOkey = false,Message="file is requierd",StatusCode=500};

            if(!FileTools.CheckExtension(request.File))
                return new CreateFoodResponse(){IsOkey=false,Message="file is not valid . the valid type file : "+
                    FileTools.FileValidExtension.AsEnumerable().ToString(),StatusCode = 500};

            if(!FileTools.CheckSize(request.File))
                return new CreateFoodResponse(){ IsOkey=false,Message = "file size is large",StatusCode=500};

            FoodCategory foodCategory = await CategoryRepository.GetAsync(request.CategoryId) ;

            (string , string) addressAndNameFile =  await FileTools.SaveFileAsync(request.File,foodCategory.CategoryName);
            
            var food = Food.Create(request.FoodName, request.Prise, request.Weight,request.CategoryId,
                request.SuitableHowMany,request.FileAlt,request.FileTitle,addressAndNameFile.Item1,
                FileTools.GetFileSize(request.File));

            await Repository.CreateAsync(food);


            await Repository.SaveChengesAsync();
            return new CreateFoodResponse()
            {
                Id = food.Id,
            };


        }
    }
}
