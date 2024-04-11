using BetSearchServiceAPI.Services;
using BetSearchServiceAPI.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using BetSearchServiceAPI.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<BetSvcHttpClient>();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumersFromNamespaceContaining<BetCreatedConsumer>();

    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("search", false));

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        //STOP MONGODB, CREATE A BET AND CHECK IF AFTER REESTARTING THE DB, IF IT WILL
        //RECEIVE THE PLACED BET MESSAGE
        cfg.ReceiveEndpoint("search-bet-created", e =>
        {
            e.UseMessageRetry(r => r.Interval(5, 5));
            e.ConfigureConsumer<BetCreatedConsumer>(context);
        });

        cfg.ReceiveEndpoint("bet-updated", e =>
        {
            e.UseMessageRetry(r => r.Interval(5, 5));
            e.ConfigureConsumer<BetUpdatedConsumer>(context);
        });

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

await DbInitializer.DbInit(app);

app.Run();