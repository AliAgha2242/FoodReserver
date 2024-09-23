using Application.Contract.Dtos.Address;
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
            app.MapDelete("/DeletePerson", async (IMediator mediator, [FromBody] RemovePersonRequest request) =>
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
            }).WithOpenApi().WithTags("Food").DisableAntiforgery();

            app.MapGet("/GetAllFood",async (IMediator mediator) =>
            {
                return await mediator.Send(new GetAllFoodRequest());
                
            }).WithTags("Food");

            app.MapPost("/GetFood",async (IMediator mediator,[FromBody]GetFoodRequest request) =>
            {
                return await mediator.Send(request);
                
            }).WithTags("Food");

            app.MapDelete("/RemoveFood",async (IMediator mediator , [FromBody]RemoveFoodRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("Food");
            app.MapPost("/RestoreFood",async (IMediator mediator , [FromBody]RestoreFoodRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("Food");
            app.MapPost("/EditFood",async (IMediator mediator ,[FromForm] EditFoodRequest request) =>
            {
                return await mediator.Send(request);
            }).WithOpenApi().WithTags("Food").DisableAntiforgery();
            app.MapPost("/SearchFood",async (IMediator mediator ,[FromBody] SearchFoodRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("Food");
            return app ;
        }
        public static IApplicationBuilder AddressMinimalApi(this WebApplication app)
        {
            app.MapPost("/CreateAddress", async (IMediator mediator , [FromBody]CreateAddressRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("Address");
            app.MapPost("/GetAddress", async (IMediator mediator , [FromBody] GetAddressRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("Address");
            app.MapGet("/GetAllAddress", async (IMediator mediator) =>
            {
                return await mediator.Send(new GetAllAddressRequest());
            }).WithTags("Address");
            app.MapPost("/EditAddress", async (IMediator mediator , [FromBody] EditAddressRequest request) =>
            {
                return await mediator.Send(request);
            }).WithTags("Address");
            return app;
        }
    }
}
