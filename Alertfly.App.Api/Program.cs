using Alertfly.App.Application.Commands.AddUser;
using Alertfly.App.Core.Interfaces;
using Alertfly.App.Core.Interfaces.Repositories;
using Alertfly.App.Infrastructure.MessageBus;
using Alertfly.App.Infrastructure.Persistence;
using Alertfly.App.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var CONNECTION_STRING = builder.Configuration.GetConnectionString("AlertflyCs");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(CONNECTION_STRING));

builder.Services.AddMediatR(typeof(AddUserCommand));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IUserFlightRepository, UserFlightRepository>();
builder.Services.AddScoped<IMessageBusService, MessageBusService>();

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
