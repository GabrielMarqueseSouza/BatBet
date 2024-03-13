using BetSearchService.Services;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient<BetSvcHttpClient>();
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

//await DbInitializer.DbInit(app);

app.Run();