using AutoMapper;
using Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;
using MongoDB.Entities;
using BetSearchServiceAPI.Models;

namespace BetSearchServiceAPI.Consumers
{
    // Suffix "Consumer" is a convention from MassTransit
    public class BetCreatedConsumer(IMapper mapper) : IConsumer<BetCreated>
    {
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<BetCreated> context)
        {
            Console.WriteLine($"--> Consuming bet created at: {context.Message.CreatedAt:yyyy-MM-dd HH:mm:ss}");

            Bets bets = _mapper.Map<Bets>(context.Message);

            await bets.SaveAsync();
        }
    }
}
