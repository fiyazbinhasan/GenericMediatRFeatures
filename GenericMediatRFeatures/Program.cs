using System.Reflection;
using GenericMediatRFeatures.Data;
using GenericMediatRFeatures.Entities;
using GenericMediatRFeatures.Features.Crud.Create;
using GenericMediatRFeatures.Features.Crud.Read;
using GenericMediatRFeatures.Repositories;
using GenericMediatRFeatures.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddTransient(typeof(IRequestHandler<Read.Query<WeatherForecastModel>, List<WeatherForecastModel>>),
    typeof(Read.QueryHandler<WeatherForecast, WeatherForecastModel>));

builder.Services.AddTransient(typeof(IRequestHandler<Create.Command<WeatherForecastModel>, Unit>),
    typeof(Create.CommandHandler<WeatherForecast, WeatherForecastModel>));

builder.Services.AddTransient(typeof(Create.IRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient(typeof(Read.IRepository<>), typeof(GenericRepository<>));
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseInMemoryDatabase("MemoryDb");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();