using BatBetDomain.Services.DependencyInjection;
using BatBetInfrastructure.Repositories.DependencyInjection;
using BatBetService.Configurations;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddContextConfiguration(builder);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServicesDependecyInjection();
builder.Services.AddRepositoriesDependecyInjection();


WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

//DbInitializer.InitDb(app);

app.Run();