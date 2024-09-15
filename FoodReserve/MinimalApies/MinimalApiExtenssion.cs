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
            app.MapPost("/CreatePerson", async (IMediator mediator, [FromForm] CreatePersonRequest request) =>
            {
                return await mediator.Send(request);
            }).WithName("Create Person").WithOpenApi().DisableAntiforgery();
            app.MapGet("/GetAllPerson", async (IMediator mediator) =>
            {
                return await mediator.Send(new GetAllPersonRequest());
            });
            app.MapPost("/DeletePerson", async (IMediator mediator, [FromForm] DeletePersonRequest request) =>
            {
                return await mediator.Send(request);
            });
            app.MapPost("/RestorePerson", async (IMediator mediator, [FromForm] RestorePersonRequest request) =>
            {
                return await mediator.Send(request);
            }).WithOpenApi();
            app.MapPost("/ResetPersonPassword", async (IMediator mediator, [FromForm] ResetPasswordPersonRequest request) =>
            {
                return await mediator.Send(request);
            }).WithOpenApi().DisableAntiforgery();



            return app;
        }
    }
}
