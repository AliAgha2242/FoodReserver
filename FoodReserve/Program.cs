using Application.Utilities;
using Infrastructure.Database;
using Infrastructure.bootstrapper;
using FoodReserve.MinimalApies;
using Infrastructure.Database.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAntiforgery();

//builder.Services.DbConfigure(builder.Configuration.GetConnectionString("Index"));
builder.Services.ServiceConfigure();
builder.Services.MediatRConfigure();

builder.Services.AddOptions();
builder.Services.Configure<EncriptTools>(builder.Configuration.GetSection("EncriptionConfig"));
builder.Services.Configure<EncriptConfiguration>(builder.Configuration.GetSection("EncriptConfiguration"));

//builder.Services.AddDbContext<ReserveFoodDb>(p =>
//{
//    p.UseSqlServer(builder.Configuration.GetConnectionString("Index"));
//});

builder.Services.DbConfigure(builder.Configuration);
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"Files")),
//    RequestPath = "files"
//});



app.UseAntiforgery();
app.UseHttpsRedirection();
app.PersonMinimalApi();
app.FoodCategoryMinimalApi();
app.FoodMinimalApi();
app.AddressMinimalApi();




//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.Run();

