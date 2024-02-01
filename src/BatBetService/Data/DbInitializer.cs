﻿using BatBetService.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatBetService.Data
{
    public class DbInitializer
    {
        public static async void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            await SeedData(scope.ServiceProvider.GetService<BatBetDbContext>());
        }

        private static async Task<int> SeedData(BatBetDbContext context)
        {
            context.Database.Migrate();

            var pokerGame = new Game
            {
                Id = 1,
                Name = "Poker",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                ImageUrl = "",
                CategoryId = 1,
                AvailableBets = [],
                Bets = []
            };

            var lolGame = new Game
            {
                Id = 2,
                Name = "League of Legends",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                ImageUrl = "",
                CategoryId = 2,
                AvailableBets = [],
                Bets = []
            };

            var user = new User
            {
                Id = 1,
                Name = "First Name",
                LastName = "Last Name",
                Email = "test@test.com",
                Password = "Abc123",
                Country = "BR",
                Address = "Rua Sim",
                State = "MG",
                Complement = "10",
                Age = 20,
                DocumentNumber = "Abcd1234",
                Balance = 700.50,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsBlocked = false,
                BlockReason = null,
            };

            List<Bet> bets =
            [
                new Bet
                {
                    Id = 1,
                    Amount = 10.00,
                    Status = Status.Active,
                    PlatformFee = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(10),
                    GameId = 1,
                    Game = pokerGame,
                    UserId = 1,
                    User = user
                },
                new Bet
                {
                    Id = 2,
                    Amount = 20.00,
                    Status = Status.Active,
                    PlatformFee = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(15),
                    GameId = 1,
                    Game = pokerGame,
                    UserId = 1,
                    User = user
                },
                new Bet
                {
                    Id = 3,
                    Amount = 30.00,
                    Status = Status.Finished,
                    PlatformFee = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(20),
                    GameId = 2,
                    Game = lolGame,
                    UserId = 1,
                    User = user
                },
                new Bet
                {
                    Id = 4,
                    Amount = 40.00,
                    Status = Status.Canceled,
                    PlatformFee = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(25),
                    GameId = 2,
                    Game = lolGame,
                    UserId = 1,
                    User = user
                },
                new Bet
                {
                    Id = 5,
                    Amount = 50.00,
                    Status = Status.Suspended,
                    PlatformFee = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(30),
                    GameId = 1,
                    Game = pokerGame,
                    UserId = 1,
                    User = user
                }
            ];

            List<AvailableBet> availableBets =
            [
                new AvailableBet
                {
                    Id = 1,
                    Name = "Random bet name",
                    MinValue = 1,
                    MaxValue = 100,
                    CreatedAt = DateTime.UtcNow,
                    LimitDate = DateTime.UtcNow.AddDays(60),
                    GameId = 1,
                    Game = pokerGame
                },
                new AvailableBet
                {
                    Id = 2,
                    Name = "Random bet name number two",
                    MinValue = 50,
                    MaxValue = 90,
                    CreatedAt = DateTime.UtcNow,
                    LimitDate = DateTime.UtcNow.AddDays(60),
                    GameId = 2,
                    Game = lolGame,
                }
            ];

            List<Category> category =
            [
                new Category
                {
                    Id = 1,
                    Name = "Card Game",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImageUrl = "",
                    Games =
                        [
                            pokerGame
                        ],
                },
                new Category
                {
                    Id = 2,
                    Name = "Rpg Game",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImageUrl = "",
                    Games =
                        [
                            lolGame
                        ],
                }
            ];

            foreach (var item in bets)
            {
                await context.AddAsync(item);
            };

            foreach (var item in availableBets)
            {
                await context.AddAsync(item);
            }

            foreach (var item in category)
            {
                await context.AddAsync(item);
            }

            return context.SaveChangesAsync().Result;
        }
    }
}
