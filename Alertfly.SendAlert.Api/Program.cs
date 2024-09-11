using Alertfly.SendAlert.Core.Interfaces;
using Alertfly.SendAlert.Infrastructure.Consumers;
using Alertfly.SendAlert.Infrastructure.Persistence;
using Alertfly.SendAlert.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System.Collections.Specialized;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var CONNECTION_STRING = builder.Configuration.GetConnectionString("AlertflyCs");

builder.Services.AddDbContext<AlertflyContext>(options => options.UseSqlServer(CONNECTION_STRING));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserFlightRepository, UserFlightRepository>();


builder.Services.AddHostedService<ReceveidAlertFlightConsumer>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();

