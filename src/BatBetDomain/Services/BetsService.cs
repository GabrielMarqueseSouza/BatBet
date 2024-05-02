using AutoMapper;
using BatBetDomain.DTOs.Request;
using BatBetDomain.DTOs.Response;
using BatBetDomain.Entities;
using BatBetDomain.Interfaces.Repositories;
using BatBetDomain.Interfaces.Services;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatBetDomain.Services
{
    public class BetsService(IMapper mapper, IBetsRepository betRepository,
                IGameRepository gameRepository,
                IPublishEndpoint publishEndpoint,
                IAvailableBetsRepository availableBetsRepository) : IBetsService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBetsRepository _betsRepository = betRepository;
        private readonly IGameRepository _gameRepository = gameRepository;
        private readonly IAvailableBetsRepository _availableBetsRepository = availableBetsRepository;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task<IList<BetDto>> GetBets(string date)
        {
            IList<Bet> query = await _betsRepository.GetBets(date);

            IList<BetDto> response = _mapper.Map<IList<BetDto>>(query);

            return response;
        }

        public async Task<BetDto> GetBetById(int id)
        {
            return await _betsRepository.GetBetById(id);
        }

        public async Task<BetDto> CreateBet(PlaceBetDto placeBetDto,
                                            string userId,
                                            string userBalance)
        {
            object[] preConditions =
                await ValidateBetPreConditions(placeBetDto.AvailableBetId, placeBetDto.GameId);

            CheckValidUserBalance(userBalance, placeBetDto.Amount);

            Bet placedBet = _mapper.Map<Bet>(placeBetDto);

            placedBet.PlatformFee = 0.10;
            placedBet.UserId = userId;
            placedBet.UpdatedAt = DateTime.UtcNow;
            placedBet.Game = (Game)preConditions[0];
            placedBet.AvailableBetId = (int)preConditions[1];

            await _betsRepository.Add(placedBet);

            await PublishMessage(placedBet, "Created");

            await PublishBetValueToUpdateUserBalance(userId, placeBetDto.Amount);

            await _betsRepository.CommitChanges();

            BetDto response = await _betsRepository.GetBetById(placedBet.Id);

            return response;
        }

        public async Task<int> UpdateBet(int id)
        {
            int betId = await _betsRepository.UpdateBet(id);

            await PublishMessage(betId, "Updated");

            await _betsRepository.CommitChanges();

            return betId;
        }

        public async Task<bool> DeleteBet(int id)
        {
            Bet bet = await _betsRepository.GetById(id) ??
                    throw new Exception("Bet not found.");

            _betsRepository.Remove(bet);

            await PublishMessage(bet.Id, "Deleted");

            bool result = await _betsRepository.CommitChanges() > 0;

            return result;
        }

        private static void CheckValidUserBalance(string userBalance, double betAmount)
        {
            if (int.Parse(userBalance) < betAmount || int.Parse(userBalance) == 0)
            {
                throw new Exception("Insufficient balance!");
            }
        }

        private async Task PublishMessage<T>(T messageToPublish, string messageType)
        {
            switch (messageType)
            {
                case "Created":
                    BetDto newBet = _mapper.Map<BetDto>(messageToPublish);

                    await _publishEndpoint.Publish(_mapper.Map<BetCreated>(newBet));

                    break;

                case "Updated":
                    await _publishEndpoint.Publish(_mapper.Map<BetUpdated>(messageToPublish));

                    break;

                case "Deleted":
                    await _publishEndpoint.Publish(_mapper.Map<BetDeleted>(messageToPublish));
                    break;
            }
        }

        private async Task PublishBetValueToUpdateUserBalance(string userId, double betAmount)
        {
            UserBalanceUpdated userInfo = new()
            {
                UserId = userId,
                BetAmount = betAmount,
            };

            await _publishEndpoint.Publish(userInfo);
        }

        private async Task<object[]> ValidateBetPreConditions(int availableBetId, int gameId)
        {
            AvailableBet avBet = await _availableBetsRepository
                                       .GetById(availableBetId);

            if (avBet.LimitDate < DateTime.UtcNow)
            {
                throw new BadHttpRequestException("Bets not available for this game anymore.");
            }

            Game game = await _gameRepository
                        .GetGameById(gameId) ?? throw new Exception("Game not found.");

            return [game, avBet.Id];
        }
    }
}
