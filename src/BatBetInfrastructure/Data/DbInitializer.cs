using BatBetDomain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatBetInfrastructure.Data
{
    public class DbInitializer
    {
        public static async void InitDb(WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();

            await SeedData(scope.ServiceProvider.GetService<BatBetDbContext>());
        }

        private static async Task<int> SeedData(BatBetDbContext context)
        {
            context.Database.Migrate();

            Game poker = new()
            {
                Id = 1,
                Name = "Poker",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                ImageUrl = "",
                CategoryId = 1,
            };

            Game blackJack = new()
            {
                Id = 2,
                Name = "Blackjack",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                ImageUrl = "",
                CategoryId = 2,
            };

            IList<AvailableBet> availableBets =
            [
                new()
                {
                    Id = 1,
                    Name = "Poker bet",
                    MinValue = 1,
                    MaxValue = 10000000,
                    HighestBet = 0.00,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    LimitDate = DateTime.UtcNow.AddDays(200),
                    IsFinished = false,
                    Canceled = false,
                    WinnerId = "",
                    GameId = 1,
                    Game = poker
                },
                new()
                {
                    Id = 2,
                    Name = "Blackjack bet",
                    MinValue = 50,
                    MaxValue = 900,
                    HighestBet = 0.00,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    LimitDate = DateTime.UtcNow.AddDays(200),
                    IsFinished = false,
                    Canceled = false,
                    WinnerId = "",
                    GameId = 2,
                    Game = blackJack,
                }
            ];

            IList<Bet> bets =
            [
                new()
                {
                    Id = 1,
                    Amount = 10.00,
                    Status = 1,
                    PlatformFee = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(50),
                    GameId = 1,
                    Game = poker,
                    UserId = "",
                    AvailableBetId = availableBets[0].Id,
                },
                new()
                {
                    Id = 2,
                    Amount = 20.00,
                    Status = 1,
                    PlatformFee = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(50),
                    GameId = 1,
                    Game = poker,
                    UserId = "",
                    AvailableBetId = availableBets[0].Id,
                },
                new()
                {
                    Id = 3,
                    Amount = 30.00,
                    Status = 0,
                    PlatformFee = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(50),
                    GameId = 1,
                    Game = poker,
                    UserId = "",
                    AvailableBetId = availableBets[0].Id,
                },
                new()
                {
                    Id = 4,
                    Amount = 40.00,
                    Status = 1,
                    PlatformFee = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(50),
                    GameId = 2,
                    Game = blackJack,
                    UserId = "",
                    AvailableBetId = availableBets[1].Id,
                },
                new()
                {
                    Id = 5,
                    Amount = 50.00,
                    Status = 2,
                    PlatformFee = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(50),
                    GameId = 2,
                    Game = blackJack,
                    UserId = "",
                    AvailableBetId = availableBets[1].Id,
                }
            ];

            Category category = new()
            {
                Id = 1,
                Name = "Card Game",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                ImageUrl = "",
                Games =
                        [
                            poker,
                            blackJack
                        ],
            };

            foreach (Bet item in bets)
            {
                await context.AddAsync(item);
            };

            foreach (AvailableBet item in availableBets)
            {
                await context.AddAsync(item);
            }

            await context.AddAsync(category);

            return context.SaveChangesAsync().Result;
        }
    }
}
