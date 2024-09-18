using Application.Contract.Dtos.Food;
using Application.Contract.Dtos.FoodCategory;
using Application.Contract.Dtos.Person;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FoodReserve.MinimalApies
{
    public static class MinimalApiExtenssion
    {
        public static IApplicationBuilder PersonMinimalApi(this WebApplication app)
        {
            app.MapPost("/CreatePerson", async (IMediator mediator, [FromBody] CreatePersonRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("Person").DisableAntiforgery();
            app.MapGet("/GetAllPerson", async (IMediator mediator) =>
            {
                return await mediator.Send(new GetAllPersonRequest());
            }).WithTags("Person");
            app.MapPost("/DeletePerson", async (IMediator mediator, [FromBody] RemovePersonRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("Person");
            app.MapPost("/RestorePerson", async (IMediator mediator, [FromBody] RestorePersonRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("Person");
            app.MapPost("/ResetPersonPassword", async (IMediator mediator, [FromBody] ResetPasswordPersonRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("Person").DisableAntiforgery();



            return app;
        }
        public static IApplicationBuilder FoodCategoryMinimalApi(this WebApplication app)
        {
            app.MapPost("/CreateFoodCategory",async (IMediator mediator,[FromBody]CreateFoodCategoryRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("FoodCategory");
            app.MapPost("/EditFoodCategory", async (IMediator mediator, [FromBody]EditFoodCategoryRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("FoodCategory");
            app.MapDelete("/RemoveFoodCategory", async (IMediator mediator, [FromBody]RemoveFoodCategoryRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("FoodCategory");
            app.MapPost("/RestoreFoodCategory", async (IMediator mediator, [FromBody] RestoreFoodCategoryRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("FoodCategory");
            app.MapPost("/GetFoodCategory", async (IMediator mediator, [FromBody]GetFoodCategoryRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("FoodCategory");
            app.MapGet("/GetAllFoodCategory", async (IMediator mediator) =>
            {
                return await mediator.Send(new GetAllFoodCategoryRequest());
            }).WithTags("FoodCategory");
            app.MapPost("/GetSubCategories", async (IMediator mediator, [FromBody] GetAllSubCatRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("FoodCategory");
            return app ;
        } 
        public static IApplicationBuilder FoodMinimalApi(this WebApplication app)
        {
            app.MapPost("/CreateFood", async (IMediator mediator , [FromForm] CreateFoodRequest request) =>
            {
                return await mediator.Send(request);
            }).WithOpenApi().WithTags("Food");
            return app ;
        }
    }
}
